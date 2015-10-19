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
            LineView.SyncVerticalToCodeBox();
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
                FormatCodeBox(true, e.KeyChar == (char)Keys.Enter, true, e.KeyChar);
            }
            base.OnKeyPress(e);
        }
        public void FormatCodeBox(bool isusertyping = false, bool nextline = false, bool color = true, char addfirst = '\0')
        {
            RecordState(past);
            SuspendLayout();
            Enabled = false;
            int s = SelectionStart, l = SelectionLength, lb = GetLineFromCharIndex(s);
            if (addfirst != '\0') { Text = Text.Insert(s, addfirst.ToString().Replace("\r", "\n")); s++; }
            // Make s relative to line stat
            s -= GetFirstCharIndexFromLine(lb);
            Lines = CodeFormatter.Format(Lines).ToArray();
            // Restore cursor and selection state
            s += GetFirstCharIndexFromLine(lb);
            int nl = Text.Length;
            if (s >= nl) s = nl - 1;
            if (s > 0)
            {
                if (isusertyping)
                {
                    if (Text[s - 1] != '\n')
                    {
                        char it = Text[s];
                        do
                        {
                            s++; l--;
                        } while (s < nl && ((it = Text[s]) == ' ' || it == '\t'));
                        if (it == '\n' && nextline)
                            s++;
                    }
                }
                while (s + l > nl) l--;
                if (l < 0) l = 0;
                Select(s, l);
                LineView.SyncVerticalToCodeBox();
                //ScrollToCaret(); This is not needed
            }
            if (color) ColorSyntax();
            Enabled = true;
            ResumeLayout();
            Focus();
        }
        public void ColorSyntax()
        {
            SuspendLayout();
            Enabled = false;
            // Reset all colors            
            int s = SelectionStart, l = SelectionLength;
            SelectAll();
            SelectionBackColor = BackColor; SelectionColor = ForeColor;
            Select(0, 0);            
            foreach (string word in ColoringProfile.Keys)
            {
                Color c = ColoringProfile[word];
                foreach (Match m in Regex.Matches(Text, word, RegexOptions.IgnoreCase))
                {
                    Select(m.Index, m.Length);
                    SelectionColor = c;
                }
            }
            // Color labels            
            foreach (Match m in Regex.Matches(Text, Settings.Default.LabelRegex))
            {
                Select(m.Index, m.Length);
                SelectionColor = LabelColor;
                foreach (Match mm in Regex.Matches(Text, "(?<=[\\s,@#])" + m.Value + "(?=[\\s,\\.])"))
                {
                    Select(mm.Index, mm.Length);
                    SelectionColor = LabelColor;
                }
            }
            //
            Select(s, l);
            Enabled = true;
            ResumeLayout();
            Focus();
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
