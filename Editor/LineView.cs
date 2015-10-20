using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ASMSharp
{
    class LineView : RichTextBox
    {
        // External
        [DllImport("User32.dll")]
        public extern static int GetScrollPos(IntPtr hWnd, int nBar);
        //
        CodeBox codebox = null;
        public CodeBox CodeBox
        {
            set
            {
                if (value == codebox) return;
                codebox = value;
                Text = "";
                ScrollBars = RichTextBoxScrollBars.ForcedHorizontal;
                ReadOnly = true;
                WordWrap = false;
                BorderStyle = value.BorderStyle;
                Font = value.Font;
                value.TextChanged += textChanged;
                value.FontChanged += fontChanged;
            }
            get { return codebox; }
        }
        private void fontChanged(object sender, EventArgs e)
        {
            Font = (sender as RichTextBox).Font;
        }

        private void textChanged(object sender, EventArgs e)
        {
            if (!update) return;
            if (Lines.Length == codebox.Lines.Length) return;
            MessageManager.SuspendDrawing(this);
            int lines = codebox.Lines.Length, i = Lines.Length + 1;
            List<int> lnum = new List<int>();
            while (i <= lines)
                lnum.Add(i++);
            if (Text != "" && lnum.Count > 0) AppendText("\n");
            AppendText(string.Join("\n", lnum.Select(t => t.ToString()).ToArray()));
            if (i - 1 > lines)
                Lines = Lines.Take(lines).ToArray();
            TrimToText();
            MessageManager.ResumeDrawing(this);
        }
        protected override void OnSelectionChanged(EventArgs e)
        {
            if (!update) return;
            if (SelectionLength == 0 && (SelectionStart == Text.Length || Text[SelectionStart] == '\n'))
            {
                int idx = codebox.GetCharIndexFromPosition(new Point(0, GetPositionFromCharIndex(SelectionStart).Y));
                codebox.Select(idx, 0);
                codebox.Focus();
            }
            base.OnSelectionChanged(e);
        }
        public void TrimToText()
        {
            MessageManager.SuspendDrawing(this);
            Graphics gpx = Graphics.FromHwnd(Handle);
            float fallback = 0;
            try
            {
                fallback = gpx.MeasureString("_", Font).Width;
                Width = (int)gpx.MeasureString(Lines[Lines.Length - 1], Font).Width;
            }
            catch { Width = (int)fallback; } // Empty code            
            MessageManager.ResumeDrawing(this);
        }
        public void SyncVerticalToCodeBox()
        {
            MessageManager.SuspendDrawing(this);
            // Get position
            int pos = GetScrollPos(codebox.Handle, 1 /*Vertical*/);
            if (pos == GetScrollPos(Handle, 1)) return;
            // Prepare the appropriate window message parameter
            pos <<= 16;
            uint wParam = (uint)4 | (uint)pos;
            // Forward message
            MessageManager.SendMessage(Handle, (int)0x0115, new IntPtr(wParam), new IntPtr(0));
            MessageManager.ResumeDrawing(this);
        }
        bool update = true;
        internal void StopUpdating()
        {
            update = false;
        }

        internal void StartUpdating()
        {
            update = true;
        }
    }
}
