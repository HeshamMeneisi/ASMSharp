using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASMSharp
{
    class RConsole : RichTextBox
    {
        public Action<string> LineRead;
        int lockedlines = -1;

        protected override void OnKeyDown(KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Enter && Lines.Length > 0)
                if (LineRead != null) LineRead(Lines[Lines.Length - 1]);
            base.OnKeyDown(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (Lines.Length - 1 <= lockedlines)
            {
                Text += "\n";
                Select(Text.Length, 0);
            }
            lockedlines = Lines.Length - 2;
        }

        protected override void OnSelectionChanged(EventArgs e)
        {
            base.OnSelectionChanged(e);
            if (GetLineFromCharIndex(SelectionStart) == Lines.Length - 1)
                ReadOnly = false;
            else
                ReadOnly = true;
        }

        public void WriteLine(string l)
        {
            Invoke(new MethodInvoker(() =>
            {
                Text += l + "\n";
                Select(Text.Length, 0);
                ScrollToCaret();
            }));
        }
    }
}
