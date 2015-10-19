using ASMSharp.Properties;
using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace ASMSharp
{
    public partial class optionsForm : Form
    {
        public optionsForm()
        {
            InitializeComponent();
            Settings.Default.PropertyChanged += pch;
        }
        bool edited = false;
        private void pch(object sender, PropertyChangedEventArgs e)
        {
            edited = true;
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
            // This does not save
            Settings.Default.Reset();
            edited = true;
        }

        private void savesetbtn_Click(object sender, EventArgs e)
        {
            string[] ar = colwsText.Text.Split(','); int r = 0;
            foreach (string s in ar)
            {
                if (!int.TryParse(s, out r))
                {
                    MessageBox.Show("Invalid input for column length setting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Settings.Default.Save();
            edited = false;
        }

        private void optionsForm_Load(object sender, EventArgs e)
        {
            asmexBrowse.Tag = asmExe;
            asmscriptBrowse.Tag = asmscript;
            simexebrowse.Tag = simexe;

            // Settings
            asmExe.DataBindings.Add("Text", Settings.Default, "ASMExe", true, DataSourceUpdateMode.OnPropertyChanged);
            asmarg.DataBindings.Add("Text", Settings.Default, "ASMArgs", true, DataSourceUpdateMode.OnPropertyChanged);
            asminput.DataBindings.Add("Text", Settings.Default, "ASMInput", true, DataSourceUpdateMode.OnPropertyChanged);
            asmscript.DataBindings.Add("Text", Settings.Default, "ASMScript", true, DataSourceUpdateMode.OnPropertyChanged);
            simexe.DataBindings.Add("Text", Settings.Default, "SIMExe", true, DataSourceUpdateMode.OnPropertyChanged);
            simarg.DataBindings.Add("Text", Settings.Default, "SIMArgs", true, DataSourceUpdateMode.OnPropertyChanged);
            siminput.DataBindings.Add("Text", Settings.Default, "SIMInput", true, DataSourceUpdateMode.OnPropertyChanged);

            codebackcol.DataBindings.Add("BackColor", Settings.Default, "CodeBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            codeforecolor.DataBindings.Add("BackColor", Settings.Default, "CodeForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            synCol.DataBindings.Add("BackColor", Settings.Default, "SyntaxColor", true, DataSourceUpdateMode.OnPropertyChanged);
            labelCol.DataBindings.Add("BackColor", Settings.Default, "LabelColor", true, DataSourceUpdateMode.OnPropertyChanged);
            regCol.DataBindings.Add("BackColor", Settings.Default, "RegisterColor", true, DataSourceUpdateMode.OnPropertyChanged);
            intCol.DataBindings.Add("BackColor", Settings.Default, "IntegerColor", true, DataSourceUpdateMode.OnPropertyChanged);
            decCol.DataBindings.Add("BackColor", Settings.Default, "DecColor", true, DataSourceUpdateMode.OnPropertyChanged);
            hexCol.DataBindings.Add("BackColor", Settings.Default, "HexColor", true, DataSourceUpdateMode.OnPropertyChanged);
            strCol.DataBindings.Add("BackColor", Settings.Default, "StringColor", true, DataSourceUpdateMode.OnPropertyChanged);
            cbackcol.DataBindings.Add("BackColor", Settings.Default, "ConsoleBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            cforecol.DataBindings.Add("BackColor", Settings.Default, "ConsoleForeColor", true, DataSourceUpdateMode.OnPropertyChanged);

            synReg.DataBindings.Add("Text", Settings.Default, "SyntaxRegex", true, DataSourceUpdateMode.OnPropertyChanged);
            labelReg.DataBindings.Add("Text", Settings.Default, "LabelRegex", true, DataSourceUpdateMode.OnPropertyChanged);
            regReg.DataBindings.Add("Text", Settings.Default, "RegisterRegex", true, DataSourceUpdateMode.OnPropertyChanged);
            intReg.DataBindings.Add("Text", Settings.Default, "IntegerRegex", true, DataSourceUpdateMode.OnPropertyChanged);
            decReg.DataBindings.Add("Text", Settings.Default, "DecRegex", true, DataSourceUpdateMode.OnPropertyChanged);
            hexReg.DataBindings.Add("Text", Settings.Default, "HexRegex", true, DataSourceUpdateMode.OnPropertyChanged);
            strReg.DataBindings.Add("Text", Settings.Default, "StringRegex", true, DataSourceUpdateMode.OnPropertyChanged);
            colwsText.DataBindings.Add("Text", Settings.Default, "ColCellCountArray", true, DataSourceUpdateMode.OnPropertyChanged);
            fontsizeNum.DataBindings.Add("Value", Settings.Default, "FontSize", true, DataSourceUpdateMode.OnPropertyChanged);
            cfontsizeNum.DataBindings.Add("Value", Settings.Default, "ConsoleFontSize", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void gColClick(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = (sender as Button).BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
                (sender as Button).BackColor = dlg.Color;
            (sender as Button).Update();
        }

        private void optionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (edited)
            {
                switch (MessageBox.Show("You have not saved. Changes will be lost. Save now?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    case DialogResult.Yes: Settings.Default.Save(); break;
                    case DialogResult.No: Settings.Default.Reload(); break;
                    default: e.Cancel = true; break;
                }
            }
        }
    }
}
