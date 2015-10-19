using System;
using System.Linq;
using System.Windows.Forms;

namespace ASMSharp
{
    class RConsole : RichTextBox
    {
        public Action<string> LineRead;
        string newline = "> ";
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && Lines.Length > 0)
                if (LineRead != null)
                {
                    LineRead(Lines[Lines.Length - 2].Substring(newline.Length));
                    Select(Text.Length, 0);                    
                }

            base.OnKeyPress(e);
        }
        bool internalediting = false;
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            // Precaution
            if (internalediting) return;
            SetupInput();
        }

        private void SetupInput()
        {
            if (Lines.Length == 0)
            {
                Text = newline;
                Select(Text.Length, 0);
            }
            else if (!Lines[Lines.Length - 1].StartsWith(newline))
            {
                string[] temp = Lines;
                temp[temp.Length - 1] = newline;
                Lines = temp;
                Select(Text.Length, 0);
            }
        }

        protected override void OnSelectionChanged(EventArgs e)
        {
            base.OnSelectionChanged(e);
            ReadOnly = !(GetLineFromCharIndex(SelectionStart) == Lines.Length - 1 && SelectionStart >= (GetFirstCharIndexOfCurrentLine() + newline.Length));
        }

        public void WriteLine(string l)
        {
            try
            {
                Invoke(new MethodInvoker(() =>
                {
                    internalediting = true;
                    if (Lines.Length > 0)
                        Lines = Lines.Take(Lines.Length - 1).ToArray();
                    Text += "\n" + l + "\n" + newline;
                    Select(Text.Length, 0);
                    ScrollToCaret();
                    internalediting = false;
                }));
            }
            catch { /* Disposed */}
        }
    }
}
