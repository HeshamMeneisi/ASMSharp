using ASMSharp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ASMSharp
{
    public partial class mainFrm : Form
    {
        public System.Windows.Forms.Timer progBarTimer;
        public mainFrm(string[] args)
        {
            progBarTimer = new System.Windows.Forms.Timer();
            progBarTimer.Interval = 200;
            progBarTimer.Tick += progttick;

            Executer.OutputLine += lineoutputted;
            TaskManager.Started += taskstarted;
            TaskManager.Finished += taskfinished;
            Executer.Finished += exefinisehd;
            Executer.OutputError += onerror;

            InitializeComponent();

            if (args.Length > 0)
                OpenFile(args[0]);
        }
        private void onerror(int line, string error)
        {
            string msg = "@Line [" + line + "] : " + error;
            consoleBox.WriteLine(msg);
            line--; // To zero based
            this.Invoke(new MethodInvoker(() =>
            {
                int indx = codeBox.GetFirstCharIndexFromLine(line);
                int ln = codeBox.Lines[line].Length;
                codeBox.Select(indx, ln);
                codeBox.SelectionBackColor = Color.Red;
                codeBox.SelectionColor = Color.Yellow;
                codeBox.Select(indx, 0);
            }));
        }
        private void mainFrm_Load(object sender, EventArgs e)
        {
            SetupFont();
            codeBox.DataBindings.Add("BackColor", Settings.Default, "CodeBackColor");
            codeBox.DataBindings.Add("ForeColor", Settings.Default, "CodeForeColor");
            codeBox.DataBindings.Add("LabelColor", Settings.Default, "LabelColor");
            codeBoxLines.DataBindings.Add("BackColor", Settings.Default, "CodeBackColor");
            codeBoxLines.DataBindings.Add("ForeColor", Settings.Default, "CodeForeColor");
            consoleBox.DataBindings.Add("BackColor", Settings.Default, "ConsoleBackColor");
            consoleBox.DataBindings.Add("ForeColor", Settings.Default, "ConsoleForeColor");
            // Many small vs one big expression doesn't matter that much
            SetCodeBoxColors();
            consoleBox.LineRead += lineread;
            codeBox.Edited = false;
        }

        private void SetCodeBoxColors()
        {
            codeBox.ColoringProfile = new Dictionary<string, Color>()
            {
                // Integers
                {Settings.Default.IntegerRegex,Settings.Default.IntegerColor },
                // Floats
                {Settings.Default.DecRegex,Settings.Default.DecColor },
                // Commands
                {Settings.Default.SyntaxRegex,Settings.Default.SyntaxColor },
                // Data types
                {Settings.Default.DataTypeRegex,Settings.Default.DataTypeColor },
                // Register names
                { Settings.Default.RegisterRegex,Settings.Default.RegisterColor },
                // Hex
                { Settings.Default.HexRegex,Settings.Default.HexColor },
                // Strings
                { Settings.Default.StringRegex,Settings.Default.StringColor }
            };
            codeBox.ColorSyntax();
        }

        private void SetupFont()
        {
            codeBox.Font = new Font(FontFamily.GenericMonospace, Settings.Default.FontSize);
            consoleBox.Font = new Font(FontFamily.GenericMonospace, Settings.Default.ConsoleFontSize);
        }

        private void lineread(string obj)
        {
            Executer.Input(obj);
        }

        private void exefinisehd(DateTime obj)
        {
            consoleBox.WriteLine("> Execution finished at " + obj.ToShortTimeString());
            try
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    buildrunBtn.Visible = runmenuitem.Visible = true;
                    stopBtn.Visible = terminatemenuitem.Visible = false;
                }));
            }
            catch { /* Disposed */}
        }

        private void taskfinished(TaskInfo obj)
        {
            try
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    progBar.Visible = false; progBarTimer.Stop();
                    statLabel.Text = TaskManager.defaultLabel;
                }));
            }
            catch { /* Disposed */}
        }

        private void taskstarted(TaskInfo obj)
        {
            try
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    statLabel.Text = obj.Label;
                    if (obj.ShowProg)
                    {
                        progBar.Visible = true;
                        progBarTimer.Start();
                    }
                }));
            }
            catch { /* Disposed */}
        }

        private void lineoutputted(string obj)
        {
            consoleBox.WriteLine(obj);
        }

        private void progttick(object sender, EventArgs e)
        {
            if (progBar.Value == 100)
                progBar.Value = 0;
            progBar.PerformStep();
        }

        string stub = "Prog     start   1000\n\n         end     Prog";
        //int FontSize { get { return Settings.Default.FontSize; } }
        string openfile = "";
        string CurrentFile
        {
            get { return openfile; }
            set
            {
                openfile = value; codeBox.Edited = false;
                if (value != "")
                {
                    openfilewatcher.Path = Path.GetDirectoryName(value);
                    openfilewatcher.Filter = Path.GetFileName(value);
                }
            }
        }
        private void newBtn_Click(object sender, EventArgs e)
        {
            if (codeBox.Edited)
                switch (MessageBox.Show("Changes to the open file will be lost. Would you like to save first?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    case DialogResult.Yes: FormateAndSave(); break;
                    case DialogResult.Cancel: return;
                }
            CurrentFile = "";
            codeBox.Text = stub;
            codeBox.ColorSyntax();
        }

        private void FormateAndSave(bool silent = false)
        {
            codeBox.FormatCodeBox();
            SaveAs(CurrentFile, silent);
        }
        string filefilter = "Assembly Code|*.asm|All|*.*";
        private void SaveAs(string fname = "", bool silent = false)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = filefilter; dlg.DefaultExt = ".asm";
            if (fname != "")
                if (silent)
                {
                    CurrentFile = fname;
                    goto save;
                }
                else
                    dlg.FileName = fname;
            if (dlg.ShowDialog() == DialogResult.OK)
                CurrentFile = dlg.FileName;
            else return;
            save:
            openfilewatcher.EnableRaisingEvents = false;
            StreamWriter sw = new StreamWriter(CurrentFile);
            sw.Write(codeBox.Text.Replace("\n", "\r\n")); // For editors to show lines correctly \r\n is necessary
            sw.Close();
            openfilewatcher.EnableRaisingEvents = true;
        }

        private void open_Click(object sender, EventArgs e)
        {
            if (codeBox.Edited)
                switch (MessageBox.Show("Changes to the open file will be lost. Would you like to save first?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    case DialogResult.Yes: FormateAndSave(); break;
                    case DialogResult.Cancel: return;
                }
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = filefilter; dlg.DefaultExt = ".asm";
            dlg.Multiselect = false;
            if (CurrentFile != "")
                dlg.InitialDirectory = Path.GetDirectoryName(CurrentFile);
            if (dlg.ShowDialog() == DialogResult.OK)
                OpenFile(dlg.FileName);
        }

        private void OpenFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                MessageBox.Show("File not found:\n" + fileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CurrentFile = fileName;
            StreamReader sr = new StreamReader(File.OpenRead(fileName));
            codeBox.Text = sr.ReadToEnd();
            sr.Close();
            codeBox.ColorSyntax();
            codeBox.RecordState();
            codeBox.Edited = false;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            FormateAndSave(true);
        }

        private void saveasBtn_Click(object sender, EventArgs e)
        {
            string temp = CurrentFile;
            CurrentFile = "";
            FormateAndSave();
            if (CurrentFile == "") CurrentFile = temp;
        }

        private void formatBtn_Click(object sender, EventArgs e)
        {
            codeBox.FormatCodeBox();
        }
        private void buildrunBtn_Click(object sender, EventArgs e)
        {
            codeBox.FormatCodeBox();
            buildrunBtn.Visible = runmenuitem.Visible = false;
            stopBtn.Visible = terminatemenuitem.Visible = true;
            consoleBox.Clear();
            Executer.Start(codeBox.Text);
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeBox.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeBox.Redo();
        }
        private void stopBtn_Click(object sender, EventArgs e)
        {
            Executer.Terminate();
        }

        private void mainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Executer.IsRunning)
            {
                e.Cancel = true;
                Executer.Finished += (d) => { try { Invoke(new MethodInvoker(() => this.Close())); } catch {/* Disposed */ } };
                Executer.Terminate();
            }
            else if (codeBox.Edited)
                switch (MessageBox.Show("Would you like to save current file first?", "Exiting", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk))
                {
                    case DialogResult.Cancel: e.Cancel = true; return;
                    case DialogResult.Yes: FormateAndSave(true); break;
                }
        }

        private void openfilewatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (MessageBox.Show("The current file has been changed outside of the program. Would you like to reload it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                OpenFile(CurrentFile);
        }
        private void optionsBtn_Click(object sender, EventArgs e)
        {
            optionsForm frm = new optionsForm();
            frm.ShowDialog(this);
            SetupFont();
            SetCodeBoxColors();
        }
    }
}
