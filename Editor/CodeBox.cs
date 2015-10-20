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
            base.OnVScroll(e);
            //LineView.SyncVerticalToCodeBox();
        }
        #endregion

        #region State Management
        public int MaxChangesStored = 50;
        LinkedList<CodeBoxState> past = new LinkedList<CodeBoxState>();
        LinkedList<CodeBoxState> future = new LinkedList<CodeBoxState>();
        private void RecordState(LinkedList<CodeBoxState> target)
        {
            target.AddLast(new CodeBoxState(Text, SelectionStart));
            if (target.Count > MaxChangesStored)
                target.RemoveFirst();
        }
        private void RestoreState(LinkedList<CodeBoxState> target)
        {
            var temp = target.Last;
            if (temp != null)
            {
                var data = temp.Value;
                Text = data.Text;
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
            base.OnKeyDown(e);
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
            }
            base.OnKeyPress(e);
        }
        public void FormatCodeBox(bool isusertyping = false, bool color = true, char addfirst = '\0')
        {
            RecordState();
            MessageManager.SuspendDrawing(this);
            int s = SelectionStart, l = SelectionLength, lb = GetLineFromCharIndex(s);
            if (addfirst != '\0') { SelectedText = addfirst.ToString().Replace("\r", "\n"); }

            // This is temporary (and very loose) RTF parsing, RTFParser should be the only source of RTF when finished

            int headerend = Regex.Match(Rtf, "fs32").Index + 5;
            string header = Rtf.Substring(0, headerend - 1);
            string[] rtflines = Regex.Split(Rtf.Substring(headerend - 1), "\\\\par\r\n");
            List<int> changed = new List<int>();
            if (isusertyping)
            {
                // Unformat current line
                CodeFormatter.FormatLine(Lines[lb], out rtflines[lb]);
                changed.Add(lb);
            }
            else
            {
                for (int i = 0; i < Lines.Length; i++)
                {
                    string res = "";
                    if (CodeFormatter.FormatLine(Lines[i], out res))
                    {
                        rtflines[i] = res;
                        changed.Add(i);
                    }
                }
            }
            if (s < Text.Length)
                lb += Text[s] == '\n' ? 1 : 0;
            // Make s relative to line start
            s -= GetFirstCharIndexFromLine(lb);
            // If nothing has changed just finish
            if (changed.Count == 0) goto Finish;
            // TODO: Disable event throwing (Too many TextChanged causes lag)
            Rtf = header + string.Join("\\par\r\n", rtflines);
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
            Select(s, l);
            LineView.SyncVerticalToCodeBox();
            if (color) ColorSyntax(changed);

            Finish:
            Focus();
            string test = Rtf;
            MessageManager.ResumeDrawing(this);
        }
        public void ColorSyntax(List<int> targetlines = null)
        {
            MessageManager.SuspendDrawing(this);
            // Reset all colors            
            int s = SelectionStart, l = SelectionLength;
            SelectAll();
            SelectionBackColor = BackColor;
            Select(0, 0);

            for (int i = 0; i < Lines.Length; i++)
            {
                if (targetlines != null && !targetlines.Contains(i)) continue;
                string line = Lines[i];
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
            // Color labels            
            foreach (Match m in Regex.Matches(Text, Settings.Default.LabelRegex))
            {
                Select(m.Index, m.Length);
                SelectionColor = LabelColor;
                foreach (Match mm in Regex.Matches(Text, "(?<=[\\s,@#])" + m.Value + "(?=[\\s,\\.])"))
                {
                    if (targetlines == null || targetlines.Contains(GetLineFromCharIndex(mm.Index)))
                    {
                        Select(mm.Index, mm.Length);
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
            ZoomFactor = 1;
        }
        #endregion
    }
    class CodeBoxState
    {
        public string Text { get; set; }
        public int Cursor { get; set; }
        public CodeBoxState(string st, int ind)
        {
            Text = st; Cursor = ind;
        }
    }
}
