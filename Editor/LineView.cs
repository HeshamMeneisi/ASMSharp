using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASMSharp
{
    class LineView : RichTextBox
    {
        public CodeBox CodeBox { set {
                Text = "";
                Width = 0;
                ReadOnly = true;
                ScrollBars = RichTextBoxScrollBars.None;
                WordWrap = false;             
            } }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            SuspendLayout();
            Enabled = false;
            Graphics gpx = Graphics.FromHwnd(Handle);
            try {
                Width = (int)gpx.MeasureString(Lines[Lines.Length - 1], Font).Width;
            }
            catch { Width = 0; } // Empty code
            Enabled = true;
            ResumeLayout();
        }
    }
}
