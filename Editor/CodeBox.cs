using ASMSharp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ASMSharp
{
    class CodeBox : RichTextBox
    {
        public CodeBox()
        { LabelColor = Color.Brown; Edited = false; }

        #region Properties
        public Dictionary<string, Color> ColoringProfile = new Dictionary<string, Color>();
        public LineView LineView
        {
            get { return ld; }
            set
            {
                ld = value;
                ld.CodeBox = this;
            }
        }
        public Color LabelColor { get; set; }
        public bool Edited { get; set; }
        #endregion

        #region LineView
        private LineView ld = null;
        protected override void OnVScroll(EventArgs e)
        {
            LineView.SyncVerticalToCodeBox();
            base.OnVScroll(e);
        }
        #endregion

        #region State Management
        public int MaxChangesStored = 50;
        LinkedList<CodeBoxState> past = new LinkedList<CodeBoxState>();
        LinkedList<CodeBoxState> future = new LinkedList<CodeBoxState>();
        private void RecordState(LinkedList<CodeBoxState> target)
        {
            target.AddLast(new CodeBoxState(Lines, SelectionStart));
            if (target.Count > MaxChangesStored)
                target.RemoveFirst();
        }
        private void RestoreState(LinkedList<CodeBoxState> target)
        {
            var temp = target.Last;
            if (temp != null)
            {
                var data = temp.Value;
                Lines = data.Lines;
                Select(data.Cursor, 0);
                target.RemoveLast();
                ColorSyntax();
            }
        }
        public void RecordState()
        {
            RecordState(past);
        }
        new public void Undo()
        {
            if (past.Count == 0) return;
            RecordState(future);
            RestoreState(past);
        }
        new public void Redo()
        {
            if (future.Count == 0) return;
            RecordState(past);
            RestoreState(future);
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Edited = true;
        }
        #endregion

        #region Formatting
        // TODO: Implement coloring by manually parsing the RTF in the formatter.       
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
                e.Handled = true;
            else if (e.Control && e.KeyCode == Keys.V)
            {
                e.Handled = true;
                Paste();
            }
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
                if (GetLineFromCharIndex(SelectionStart) >= Lines.Length - 1)
                    ScrollToCaret();
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
                e.Handled = true;
            base.OnKeyUp(e);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space || e.KeyChar == (char)Keys.Tab || e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                FormatCodeBox(true, true, e.KeyChar);
                if (GetLineFromCharIndex(SelectionStart) >= Lines.Length - 1)
                    ScrollToCaret();
            }
            base.OnKeyPress(e);
        }
        public void FormatCodeBox(bool isusertyping = false, bool color = true, char addfirst = '\0', int start = -1, int end = -1)
        {
            ZoomFactor = 1f;
            MessageManager.SuspendDrawing(this);
            int s = SelectionStart, l = SelectionLength, lb = GetLineFromCharIndex(s);
            if (addfirst != '\0')
            {
                if (addfirst == '\r') addfirst = '\n';
                SelectedText = addfirst.ToString();
            }
            bool estate = Edited;
            //SelectAll();
            SelectionBackColor = BackColor; // Triggers TextChanged
            Edited = estate;
            // This is temporary (and very loose) RTF parsing, RTFParser should be the only source of RTF when finished

            int headerend = Regex.Match(Rtf, "fs32").Index + 5;
            string header = Rtf.Substring(0, headerend - 1);
            string[] rtflines = Regex.Split(Rtf.Substring(headerend - 1), "\\\\par\r\n");
            List<int> changed = new List<int>();
            bool shifted = addfirst == '\n' && s == GetFirstCharIndexFromLine(lb);
            lb += shifted ? 1 : 0;
            if (isusertyping)
            {
                // Unformat current line
                CodeFormatter.FormatLine(Lines[lb], out rtflines[lb]);
                changed.Add(lb);
            }
            else
            {
                for (int i = (start >= 0 && start < Lines.Length ? start : 0); i < (end >= 0 && end < Lines.Length ? end : Lines.Length); i++)
                {
                    string res = "";
                    if (CodeFormatter.FormatLine(Lines[i], out res))
                    {
                        rtflines[i] = res;
                        changed.Add(i);
                    }
                }
            }
            if (changed.Count == 0) goto Finish;
            // Make s relative to line start
            s -= GetFirstCharIndexFromLine(lb);
            // If nothing has changed just finish
            string[] prevlines = past.Count > 0 ? past.Last.Value.Lines : null;
            ld.StopUpdating();
            RecordState();
            Rtf = header + string.Join("\\par\r\n", rtflines);
            // Remove labels from hashtable
            if (prevlines != null)
                foreach (int i in changed)
                {
                    if (i >= prevlines.Length) break; // Changed is sorted by default
                    // Note: Changed lines in rtf are raw
                    var newlabels = new List<string>();
                    foreach (Match m in Regex.Matches((i > 0 ? "\n" : "") + rtflines[i], Settings.Default.LabelRegex))
                        newlabels.Add(m.Value);
                    int oi = i - (shifted ? 1 : 0);
                    string line = prevlines[oi];
                    foreach (Match mm in Regex.Matches((oi > 0 ? "\n" : "") + line/*Simulate line existense in text*/
                        , Settings.Default.LabelRegex))
                        if (!newlabels.Contains(mm.Value))
                            UnregisterLabel(mm.Value);
                    foreach (string label in newlabels)
                        RegisterLabel(label); // Does nothing if registred
                }
            //
            // Restore cursor and selection state
            s += GetFirstCharIndexFromLine(lb);
            int nl = Text.Length;
            if (s >= nl) s = nl;
            if (isusertyping && s >= 0 && s < nl)
            {
                if (Text[s] == '\n') s++;
                char it;
                while (s < nl && ((it = Text[s]) == ' ' || it == '\t'))
                {
                    s++; l--;
                }
            }
            while (s + l > nl) l--;
            if (l < 0) l = 0;            
            if (color) { Select(s, l); ColorSyntax(isusertyping ? changed : null); }
            Finish:
            ld.StartUpdating();
            Select(s, l);
            LineView.SyncVerticalToCodeBox();
            Focus();
            MessageManager.ResumeDrawing(this);
        }

        private void UnregisterLabel(string value)
        {
            if (!labels.Contains(value)) return;
            labels.Remove(value);
            foreach (Match mm in Regex.Matches(Text, "(?<=[\\s,@#])" + value + "(?=[\\s,\\.])"))
            {
                Select(mm.Index, mm.Length);
                SelectionColor = ForeColor;
            }
        }
        private void RegisterLabel(string value)
        {
            if (labels.Contains(value)) return;
            labels.Add(value);
            foreach (Match mm in Regex.Matches(Text, "(?<=[\\s,@#])" + value + "(?=[\\s,\\.])"))
            {
                Select(mm.Index, mm.Length);
                SelectionColor = LabelColor;
            }
        }
        HashSet<string> labels = new HashSet<string>();
        public void ColorSyntax(List<int> targetlines = null)
        {
            MessageManager.SuspendDrawing(this);
            // Reset all colors            
            int s = SelectionStart, l = SelectionLength;
            if (targetlines == null)
            {
                foreach (string word in ColoringProfile.Keys)
                {
                    Color c = ColoringProfile[word];
                    foreach (Match m in Regex.Matches(Text, word, RegexOptions.IgnoreCase))
                    {
                        Select(m.Index, m.Length);
                        SelectionColor = c;
                    }
                }
            }
            else
            {
                foreach (int i in targetlines)
                {
                    string line = Lines[i];
                    if (line.StartsWith(".")) continue;
                    int start = GetFirstCharIndexFromLine(i);
                    foreach (string word in ColoringProfile.Keys)
                    {
                        Color c = ColoringProfile[word];
                        foreach (Match m in Regex.Matches(line, word, RegexOptions.IgnoreCase))
                        {
                            Select(start + m.Index, m.Length);
                            SelectionColor = c;
                        }
                    }
                }
            }
            // Color labels            
            if (targetlines == null)
            {
                labels.Clear();
                foreach (Match m in Regex.Matches(Text, Settings.Default.LabelRegex))
                    RegisterLabel(m.Value);
            }
            else
            {
                foreach (int i in targetlines)
                {
                    string line = Lines[i];
                    if (line.StartsWith(".")) continue;
                    int start = GetFirstCharIndexFromLine(i);
                    string tline = "\n" + line;
                    foreach (string lb in labels)
                        foreach (Match mm in Regex.Matches(tline, "(?<=[\\s\n,@#])" + lb + "(?=[\\s,\\.])", RegexOptions.None))
                        {
                            Select(start + mm.Index - 1, mm.Length);
                            SelectionColor = LabelColor;
                        }
                }
            }
            //            
            Select(s, l);
            Focus();
            MessageManager.ResumeDrawing(this);
        }
        protected override void OnContentsResized(ContentsResizedEventArgs e)
        {
            base.OnContentsResized(e);
            ZoomFactor = 0.9f; ZoomFactor = 1;
        }
        new void Paste()
        {
            if (Clipboard.ContainsText())
            {
                string text = SelectedText = Clipboard.GetText().Replace("\r\n", "\n");
                int lastl = GetLineFromCharIndex(SelectionStart);
                FormatCodeBox(false, true, '\0', lastl - text.Count(c => c == '\n'), lastl);
            }
        }
        #endregion
    }
    class CodeBoxState
    {
        public string[] Lines { get; set; }
        public int Cursor { get; set; }
        public CodeBoxState(string[] st, int ind)
        {
            Lines = st; Cursor = ind;
        }
    }
}
