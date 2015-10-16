using ASMSharp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASMSharp
{
    class CodeBox : RichTextBox
    {
        // External
        [DllImport("User32.dll")]
        public extern static int GetScrollPos(IntPtr hWnd, int nBar);

        [DllImport("User32.dll")]
        public extern static int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
        //
        public Dictionary<string, Color> ColoringProfile = new Dictionary<string, Color>();
        public Color StartCOlor = Color.Green;
        public LineView ld = null;
        public LineView LineView
        {
            get { return ld; }
            set
            {
                ld = value;
                ld.CodeBox = this;
            }
        }
        public CodeBox()
        { LabelColor = Color.Brown; }

        public int MaxChangesStored = 50;
        LinkedList<CodeBoxState> past = new LinkedList<CodeBoxState>();
        LinkedList<CodeBoxState> future = new LinkedList<CodeBoxState>();

        public Color LabelColor { get; set; }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (ld == null) return;
            ld.Enabled = false;
            int lines = Lines.Length, i = ld.Lines.Length+1;
            List<int> lnum = new List<int>();
            while (i <= lines)
                lnum.Add(i++);
            if (ld.Text != "" && lnum.Count > 0) ld.Text += "\n";
            ld.Text += string.Join("\n",lnum);
            if (i > lines)
                ld.Lines = ld.Lines.Take(lines).ToArray();                        
            ld.Enabled = true;
        }
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if (ld == null) return;
            ld.Font = Font;          
        }
        // TODO: Find a more recurring event to firmly link the lineview to the codebox (On hold and slide)
        protected override void OnVScroll(EventArgs e)
        {
            base.OnVScroll(e);            
            SyncLineView();
        }

        private void SyncLineView()
        {
            if (ld == null) return;
            int nPos = GetScrollPos(Handle, 1 /*Vertical*/);
            nPos <<= 16;
            uint wParam = (uint)4 | (uint)nPos;
            SendMessage(ld.Handle, (int)0x0115, new IntPtr(wParam), new IntPtr(0));
        }

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
            RecordState(future);
            RestoreState(past);
        }
        new public void Redo()
        {
            RecordState(past);
            RestoreState(future);
        }
        public void FormatCodeBox(bool isusertyping = false, bool nextline = false, bool color = true)
        {
            RecordState(past);
            SuspendLayout();
            Enabled = false;
            int s = SelectionStart, l = SelectionLength, lb = GetLineFromCharIndex(s);
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
                SyncLineView();
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
            ForeColor = ForeColor;
            BackColor = BackColor;
            int s = SelectionStart, l = SelectionLength;
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
                foreach (Match mm in Regex.Matches(Text, "(?<=[\\s,])" + m.Value + "(?=[\\s,\\.])"))
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
