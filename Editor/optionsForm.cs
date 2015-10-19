using ASMSharp.Properties;
using System;
using System.Windows.Forms;

namespace ASMSharp
{
    public partial class optionsForm : Form
    {
        public optionsForm()
        {
            InitializeComponent();
        }

        private void gBrowse_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            TextBox target;
            if (b != null && (target = b.Tag as TextBox) != null)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Multiselect = false;
                dlg.DefaultExt = "exe";
                if (dlg.ShowDialog() == DialogResult.OK)
                    target.Text = dlg.FileName;
            }
        }

        private void defbtn_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            Settings.Default.Save();
        }

        private void savesetbtn_Click(object sender, EventArgs e)
        {            
            string[] ar = colwsText.Text.Split(',');int r = 0;
            foreach(string s in ar)
            {
                if(!int.TryParse(s, out r))
                {
                    MessageBox.Show("Invalid input for column length setting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            firstLabel.Focus(); // Unfocus all controls to sync data bindings.
            Settings.Default.Save();
        }

        private void optionsForm_Load(object sender, EventArgs e)
        {
            asmexBrowse.Tag = asmExe;
            asmscriptBrowse.Tag = asmscript;
            simexebrowse.Tag = simexe;

            // Settings
            asmExe.DataBindings.Add("Text", Settings.Default, "ASMExe");
            asmarg.DataBindings.Add("Text", Settings.Default, "ASMArgs");
            asminput.DataBindings.Add("Text", Settings.Default, "ASMInput");
            asmscript.DataBindings.Add("Text", Settings.Default, "ASMScript");
            simexe.DataBindings.Add("Text", Settings.Default, "SIMExe");
            simarg.DataBindings.Add("Text", Settings.Default, "SIMArgs");
            siminput.DataBindings.Add("Text", Settings.Default, "SIMInput");

            codebackcol.DataBindings.Add("BackColor", Settings.Default, "CodeBackColor");
            codeforecolor.DataBindings.Add("BackColor", Settings.Default, "CodeForeColor");
            synCol.DataBindings.Add("BackColor", Settings.Default, "SyntaxColor");
            labelCol.DataBindings.Add("BackColor", Settings.Default, "LabelColor");
            regCol.DataBindings.Add("BackColor", Settings.Default, "RegisterColor");
            intCol.DataBindings.Add("BackColor", Settings.Default, "IntegerColor");
            decCol.DataBindings.Add("BackColor", Settings.Default, "DecColor");
            hexCol.DataBindings.Add("BackColor", Settings.Default, "HexColor");
            strCol.DataBindings.Add("BackColor", Settings.Default, "StringColor");
            cbackcol.DataBindings.Add("BackColor", Settings.Default, "ConsoleBackColor");
            cforecol.DataBindings.Add("BackColor", Settings.Default, "ConsoleForeColor");

            synReg.DataBindings.Add("Text", Settings.Default, "SyntaxRegex");
            labelReg.DataBindings.Add("Text", Settings.Default, "LabelRegex");
            regReg.DataBindings.Add("Text", Settings.Default, "RegisterRegex");
            intReg.DataBindings.Add("Text", Settings.Default, "IntegerRegex");
            decReg.DataBindings.Add("Text", Settings.Default, "DecRegex");
            hexReg.DataBindings.Add("Text", Settings.Default, "HexRegex");
            strReg.DataBindings.Add("Text", Settings.Default, "StringRegex");
            colwsText.DataBindings.Add("Text", Settings.Default, "ColCellCountArray");
            fontsizeNum.DataBindings.Add("Value", Settings.Default, "FontSize");
            cfontsizeNum.DataBindings.Add("Value", Settings.Default, "ConsoleFontSize");
        }

        private void gColClick(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = (sender as Button).BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
                (sender as Button).BackColor = dlg.Color;
            (sender as Button).Update();
        }
    }
}
