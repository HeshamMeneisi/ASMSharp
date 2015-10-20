using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ASMSharp
{
    class LineView : RichTextBox
    {
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
            int headerend = Regex.Match(Rtf, "fs32").Index + 5;
            string[] rtflines = Regex.Split(Rtf.Substring(headerend - 1), "\\\\par\r\n");
            string header = Rtf.Substring(0, headerend - 1);
            int lines = codebox.Lines.Length, i = Lines.Length + 1;
            List<int> lnum = new List<int>();
            while (i <= lines)
                lnum.Add(i++);
            if (lnum.Count > 0)
            {
                string[] nrtflines = new string[rtflines.Length + lnum.Count];
                rtflines.CopyTo(nrtflines, 0);
                lnum.Select(t => t.ToString()).ToArray().CopyTo(nrtflines, rtflines.Length - 1);
                Rtf = header + string.Join("\\par\r\n", nrtflines);
            }
            else if (lines == 0)
            {
                Rtf = header + string.Join("\\par\r\n", rtflines.Take(1).ToArray());
            }
            else if (i - 1 > lines)
            {
                string[] nrtflines = rtflines.Take(lines).ToArray();
                if (nrtflines.Length >= 2 && nrtflines[nrtflines.Length - 2].StartsWith("\\highlight"))
                    nrtflines[nrtflines.Length - 2] += "\\highlight0";
                Rtf = header + string.Join("\\par\r\n", nrtflines);
                breakpoints.RemoveAll(t => t >= lines);      
            }
            TrimToText();
            MessageManager.ResumeDrawing(this);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            ToggleBreakPoint(GetLineFromCharIndex(GetCharIndexFromPosition(new Point(0, e.Y))));
            base.OnMouseDown(e);
        }
        List<int> breakpoints = new List<int>();
        private void ToggleBreakPoint(int v)
        {
            if (v < 0 || v >= Lines.Length) return;
            if (breakpoints.Contains(v))
            {
                breakpoints.Remove(v);
                int f;
                Select(f = GetFirstCharIndexFromLine(v), Lines[v].Length);
                SelectionBackColor = BackColor;
                Select(f, 0);
            }
            else
            {
                breakpoints.Add(v);
                int f, l;
                Select(f = GetFirstCharIndexFromLine(v), l = Lines[v].Length);
                SelectionBackColor = Color.Red;
                Select(f + l, 0);
                SelectionBackColor = BackColor;
            }
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
            int pos = MessageManager.GetScrollPos(codebox.Handle, 1 /*Vertical*/);
            if (pos == MessageManager.GetScrollPos(Handle, 1)) return;
            // Prepare the appropriate window message parameter
            pos <<= 16;
            uint wParam = 4 | (uint)pos;
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
