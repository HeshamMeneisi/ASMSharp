using ASMSharp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASMSharp
{
    class CodeBox : RichTextBox
    {
        public Dictionary<string, Color> ColoringProfile = new Dictionary<string, Color>();
        public Color StartCOlor = Color.Green;
        public CodeBox()
        { LabelColor = Color.Brown; }        

        public int MaxChangesStored = 50;
        LinkedList<CodeBoxState> past = new LinkedList<CodeBoxState>();
        LinkedList<CodeBoxState> future = new LinkedList<CodeBoxState>();

        public Color LabelColor { get; set; }

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
                ScrollToCaret();
            }
            if (color) ColorSyntax();
            Enabled = true;
            Focus();
        }
        public void ColorSyntax()
        {
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
