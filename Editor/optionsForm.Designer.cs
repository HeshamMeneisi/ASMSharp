namespace ASMSharp
{
    partial class optionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(optionsForm));
            this.simexebrowse = new System.Windows.Forms.Button();
            this.asmExe = new System.Windows.Forms.TextBox();
            this.optionsTabControl = new System.Windows.Forms.TabControl();
            this.settingsPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.asmsettings = new System.Windows.Forms.GroupBox();
            this.asminput = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.asmscript = new System.Windows.Forms.TextBox();
            this.asmscriptBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.asmarg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.asmexBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.simsettings = new System.Windows.Forms.GroupBox();
            this.siminput = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.simarg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.simexe = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cforecol = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.cbackcol = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.cfontsizeNum = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.codeforecolor = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.codebackcol = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.fontsizeNum = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.formatterPref = new System.Windows.Forms.GroupBox();
            this.decCol = new System.Windows.Forms.Button();
            this.decReg = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.intCol = new System.Windows.Forms.Button();
            this.intReg = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.regCol = new System.Windows.Forms.Button();
            this.regReg = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.labelCol = new System.Windows.Forms.Button();
            this.labelReg = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.synCol = new System.Windows.Forms.Button();
            this.synReg = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.colwsText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.optionsToolStrip = new System.Windows.Forms.ToolStrip();
            this.saveseBtn = new System.Windows.Forms.ToolStripButton();
            this.restoresetBtn = new System.Windows.Forms.ToolStripButton();
            this.optionsTabControl.SuspendLayout();
            this.settingsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.asmsettings.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.simsettings.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cfontsizeNum)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontsizeNum)).BeginInit();
            this.formatterPref.SuspendLayout();
            this.optionsToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // simexebrowse
            // 
            this.simexebrowse.Dock = System.Windows.Forms.DockStyle.Right;
            this.simexebrowse.Location = new System.Drawing.Point(516, 0);
            this.simexebrowse.Name = "simexebrowse";
            this.simexebrowse.Size = new System.Drawing.Size(37, 23);
            this.simexebrowse.TabIndex = 2;
            this.simexebrowse.Text = "...";
            this.simexebrowse.UseVisualStyleBackColor = true;
            this.simexebrowse.Click += new System.EventHandler(this.gBrowse_Click);
            // 
            // asmExe
            // 
            this.asmExe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.asmExe.Location = new System.Drawing.Point(0, 0);
            this.asmExe.Name = "asmExe";
            this.asmExe.Size = new System.Drawing.Size(516, 20);
            this.asmExe.TabIndex = 1;
            // 
            // optionsTabControl
            // 
            this.optionsTabControl.Controls.Add(this.settingsPage);
            this.optionsTabControl.Controls.Add(this.tabPage1);
            this.optionsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsTabControl.Location = new System.Drawing.Point(0, 23);
            this.optionsTabControl.Name = "optionsTabControl";
            this.optionsTabControl.SelectedIndex = 0;
            this.optionsTabControl.Size = new System.Drawing.Size(573, 478);
            this.optionsTabControl.TabIndex = 1;
            // 
            // settingsPage
            // 
            this.settingsPage.Controls.Add(this.splitContainer1);
            this.settingsPage.Location = new System.Drawing.Point(4, 22);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsPage.Size = new System.Drawing.Size(565, 452);
            this.settingsPage.TabIndex = 2;
            this.settingsPage.Text = "Settings";
            this.settingsPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.asmsettings);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.simsettings);
            this.splitContainer1.Size = new System.Drawing.Size(559, 446);
            this.splitContainer1.SplitterDistance = 224;
            this.splitContainer1.TabIndex = 0;
            // 
            // asmsettings
            // 
            this.asmsettings.Controls.Add(this.asminput);
            this.asmsettings.Controls.Add(this.label7);
            this.asmsettings.Controls.Add(this.panel3);
            this.asmsettings.Controls.Add(this.label3);
            this.asmsettings.Controls.Add(this.asmarg);
            this.asmsettings.Controls.Add(this.label2);
            this.asmsettings.Controls.Add(this.panel1);
            this.asmsettings.Controls.Add(this.label1);
            this.asmsettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.asmsettings.Location = new System.Drawing.Point(0, 0);
            this.asmsettings.Name = "asmsettings";
            this.asmsettings.Size = new System.Drawing.Size(559, 224);
            this.asmsettings.TabIndex = 0;
            this.asmsettings.TabStop = false;
            this.asmsettings.Text = "Assembler";
            // 
            // asminput
            // 
            this.asminput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.asminput.Location = new System.Drawing.Point(3, 98);
            this.asminput.Name = "asminput";
            this.asminput.Size = new System.Drawing.Size(553, 87);
            this.asminput.TabIndex = 2;
            this.asminput.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label7.Location = new System.Drawing.Point(3, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Run Script";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.asmscript);
            this.panel3.Controls.Add(this.asmscriptBrowse);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 198);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(553, 23);
            this.panel3.TabIndex = 4;
            // 
            // asmscript
            // 
            this.asmscript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.asmscript.Location = new System.Drawing.Point(0, 0);
            this.asmscript.Name = "asmscript";
            this.asmscript.Size = new System.Drawing.Size(516, 20);
            this.asmscript.TabIndex = 1;
            // 
            // asmscriptBrowse
            // 
            this.asmscriptBrowse.Dock = System.Windows.Forms.DockStyle.Right;
            this.asmscriptBrowse.Location = new System.Drawing.Point(516, 0);
            this.asmscriptBrowse.Name = "asmscriptBrowse";
            this.asmscriptBrowse.Size = new System.Drawing.Size(37, 23);
            this.asmscriptBrowse.TabIndex = 2;
            this.asmscriptBrowse.Text = "...";
            this.asmscriptBrowse.UseVisualStyleBackColor = true;
            this.asmscriptBrowse.Click += new System.EventHandler(this.gBrowse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(3, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Input";
            // 
            // asmarg
            // 
            this.asmarg.Dock = System.Windows.Forms.DockStyle.Top;
            this.asmarg.Location = new System.Drawing.Point(3, 65);
            this.asmarg.Name = "asmarg";
            this.asmarg.Size = new System.Drawing.Size(553, 20);
            this.asmarg.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Arguments";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.asmExe);
            this.panel1.Controls.Add(this.asmexBrowse);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 23);
            this.panel1.TabIndex = 1;
            // 
            // asmexBrowse
            // 
            this.asmexBrowse.Dock = System.Windows.Forms.DockStyle.Right;
            this.asmexBrowse.Location = new System.Drawing.Point(516, 0);
            this.asmexBrowse.Name = "asmexBrowse";
            this.asmexBrowse.Size = new System.Drawing.Size(37, 23);
            this.asmexBrowse.TabIndex = 2;
            this.asmexBrowse.Text = "...";
            this.asmexBrowse.UseVisualStyleBackColor = true;
            this.asmexBrowse.Click += new System.EventHandler(this.gBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Executable";
            // 
            // simsettings
            // 
            this.simsettings.Controls.Add(this.siminput);
            this.simsettings.Controls.Add(this.label4);
            this.simsettings.Controls.Add(this.simarg);
            this.simsettings.Controls.Add(this.label5);
            this.simsettings.Controls.Add(this.panel2);
            this.simsettings.Controls.Add(this.label6);
            this.simsettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simsettings.Location = new System.Drawing.Point(0, 0);
            this.simsettings.Name = "simsettings";
            this.simsettings.Size = new System.Drawing.Size(559, 218);
            this.simsettings.TabIndex = 1;
            this.simsettings.TabStop = false;
            this.simsettings.Text = "Simulator";
            // 
            // siminput
            // 
            this.siminput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.siminput.Location = new System.Drawing.Point(3, 98);
            this.siminput.Name = "siminput";
            this.siminput.Size = new System.Drawing.Size(553, 117);
            this.siminput.TabIndex = 2;
            this.siminput.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(3, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Input";
            // 
            // simarg
            // 
            this.simarg.Dock = System.Windows.Forms.DockStyle.Top;
            this.simarg.Location = new System.Drawing.Point(3, 65);
            this.simarg.Name = "simarg";
            this.simarg.Size = new System.Drawing.Size(553, 20);
            this.simarg.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(3, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Arguments";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.simexe);
            this.panel2.Controls.Add(this.simexebrowse);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(553, 23);
            this.panel2.TabIndex = 1;
            // 
            // simexe
            // 
            this.simexe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simexe.Location = new System.Drawing.Point(0, 0);
            this.simexe.Name = "simexe";
            this.simexe.Size = new System.Drawing.Size(516, 20);
            this.simexe.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(3, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Executable";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.formatterPref);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(565, 452);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Preferences";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cforecol);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.cbackcol);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.cfontsizeNum);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(280, 323);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 126);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Console";
            // 
            // cforecol
            // 
            this.cforecol.Dock = System.Windows.Forms.DockStyle.Top;
            this.cforecol.Location = new System.Drawing.Point(3, 95);
            this.cforecol.Name = "cforecol";
            this.cforecol.Size = new System.Drawing.Size(276, 20);
            this.cforecol.TabIndex = 11;
            this.cforecol.Click += new System.EventHandler(this.gColClick);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Top;
            this.label17.Location = new System.Drawing.Point(3, 82);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(92, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "Default Text Color";
            // 
            // cbackcol
            // 
            this.cbackcol.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbackcol.Location = new System.Drawing.Point(3, 62);
            this.cbackcol.Name = "cbackcol";
            this.cbackcol.Size = new System.Drawing.Size(276, 20);
            this.cbackcol.TabIndex = 9;
            this.cbackcol.Click += new System.EventHandler(this.gColClick);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.Location = new System.Drawing.Point(3, 49);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(92, 13);
            this.label18.TabIndex = 8;
            this.label18.Text = "Background Color";
            // 
            // cfontsizeNum
            // 
            this.cfontsizeNum.Dock = System.Windows.Forms.DockStyle.Top;
            this.cfontsizeNum.Location = new System.Drawing.Point(3, 29);
            this.cfontsizeNum.Name = "cfontsizeNum";
            this.cfontsizeNum.Size = new System.Drawing.Size(276, 20);
            this.cfontsizeNum.TabIndex = 7;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Top;
            this.label19.Location = new System.Drawing.Point(3, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 13);
            this.label19.TabIndex = 6;
            this.label19.Text = "Font Size";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.codeforecolor);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.codebackcol);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.fontsizeNum);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 323);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 126);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Editor";
            // 
            // codeforecolor
            // 
            this.codeforecolor.Dock = System.Windows.Forms.DockStyle.Top;
            this.codeforecolor.Location = new System.Drawing.Point(3, 95);
            this.codeforecolor.Name = "codeforecolor";
            this.codeforecolor.Size = new System.Drawing.Size(271, 20);
            this.codeforecolor.TabIndex = 11;
            this.codeforecolor.Click += new System.EventHandler(this.gColClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Location = new System.Drawing.Point(3, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Default Text Color";
            // 
            // codebackcol
            // 
            this.codebackcol.Dock = System.Windows.Forms.DockStyle.Top;
            this.codebackcol.Location = new System.Drawing.Point(3, 62);
            this.codebackcol.Name = "codebackcol";
            this.codebackcol.Size = new System.Drawing.Size(271, 20);
            this.codebackcol.TabIndex = 9;
            this.codebackcol.Click += new System.EventHandler(this.gColClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Location = new System.Drawing.Point(3, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Background Color";
            // 
            // fontsizeNum
            // 
            this.fontsizeNum.Dock = System.Windows.Forms.DockStyle.Top;
            this.fontsizeNum.Location = new System.Drawing.Point(3, 29);
            this.fontsizeNum.Name = "fontsizeNum";
            this.fontsizeNum.Size = new System.Drawing.Size(271, 20);
            this.fontsizeNum.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Location = new System.Drawing.Point(3, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Font Size";
            // 
            // formatterPref
            // 
            this.formatterPref.Controls.Add(this.decCol);
            this.formatterPref.Controls.Add(this.decReg);
            this.formatterPref.Controls.Add(this.label16);
            this.formatterPref.Controls.Add(this.intCol);
            this.formatterPref.Controls.Add(this.intReg);
            this.formatterPref.Controls.Add(this.label15);
            this.formatterPref.Controls.Add(this.regCol);
            this.formatterPref.Controls.Add(this.regReg);
            this.formatterPref.Controls.Add(this.label14);
            this.formatterPref.Controls.Add(this.labelCol);
            this.formatterPref.Controls.Add(this.labelReg);
            this.formatterPref.Controls.Add(this.label13);
            this.formatterPref.Controls.Add(this.synCol);
            this.formatterPref.Controls.Add(this.synReg);
            this.formatterPref.Controls.Add(this.label12);
            this.formatterPref.Controls.Add(this.colwsText);
            this.formatterPref.Controls.Add(this.label8);
            this.formatterPref.Dock = System.Windows.Forms.DockStyle.Top;
            this.formatterPref.Location = new System.Drawing.Point(3, 3);
            this.formatterPref.Name = "formatterPref";
            this.formatterPref.Size = new System.Drawing.Size(559, 320);
            this.formatterPref.TabIndex = 1;
            this.formatterPref.TabStop = false;
            this.formatterPref.Text = "Formatter";
            // 
            // decCol
            // 
            this.decCol.Dock = System.Windows.Forms.DockStyle.Top;
            this.decCol.Location = new System.Drawing.Point(3, 294);
            this.decCol.Name = "decCol";
            this.decCol.Size = new System.Drawing.Size(553, 20);
            this.decCol.TabIndex = 24;
            this.decCol.Click += new System.EventHandler(this.gColClick);
            // 
            // decReg
            // 
            this.decReg.Dock = System.Windows.Forms.DockStyle.Top;
            this.decReg.Location = new System.Drawing.Point(3, 274);
            this.decReg.Name = "decReg";
            this.decReg.Size = new System.Drawing.Size(553, 20);
            this.decReg.TabIndex = 19;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Top;
            this.label16.Location = new System.Drawing.Point(3, 261);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 13);
            this.label16.TabIndex = 18;
            this.label16.Text = "Decimal";
            // 
            // intCol
            // 
            this.intCol.Dock = System.Windows.Forms.DockStyle.Top;
            this.intCol.Location = new System.Drawing.Point(3, 241);
            this.intCol.Name = "intCol";
            this.intCol.Size = new System.Drawing.Size(553, 20);
            this.intCol.TabIndex = 11;
            this.intCol.Click += new System.EventHandler(this.gColClick);
            // 
            // intReg
            // 
            this.intReg.Dock = System.Windows.Forms.DockStyle.Top;
            this.intReg.Location = new System.Drawing.Point(3, 221);
            this.intReg.Name = "intReg";
            this.intReg.Size = new System.Drawing.Size(553, 20);
            this.intReg.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Location = new System.Drawing.Point(3, 208);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Integers";
            // 
            // regCol
            // 
            this.regCol.Dock = System.Windows.Forms.DockStyle.Top;
            this.regCol.Location = new System.Drawing.Point(3, 188);
            this.regCol.Name = "regCol";
            this.regCol.Size = new System.Drawing.Size(553, 20);
            this.regCol.TabIndex = 13;
            this.regCol.Click += new System.EventHandler(this.gColClick);
            // 
            // regReg
            // 
            this.regReg.Dock = System.Windows.Forms.DockStyle.Top;
            this.regReg.Location = new System.Drawing.Point(3, 168);
            this.regReg.Name = "regReg";
            this.regReg.Size = new System.Drawing.Size(553, 20);
            this.regReg.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Top;
            this.label14.Location = new System.Drawing.Point(3, 155);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Registers";
            // 
            // labelCol
            // 
            this.labelCol.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCol.Location = new System.Drawing.Point(3, 135);
            this.labelCol.Name = "labelCol";
            this.labelCol.Size = new System.Drawing.Size(553, 20);
            this.labelCol.TabIndex = 20;
            this.labelCol.Click += new System.EventHandler(this.gColClick);
            // 
            // labelReg
            // 
            this.labelReg.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelReg.Location = new System.Drawing.Point(3, 115);
            this.labelReg.Name = "labelReg";
            this.labelReg.Size = new System.Drawing.Size(553, 20);
            this.labelReg.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Location = new System.Drawing.Point(3, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Label";
            // 
            // synCol
            // 
            this.synCol.Dock = System.Windows.Forms.DockStyle.Top;
            this.synCol.Location = new System.Drawing.Point(3, 82);
            this.synCol.Name = "synCol";
            this.synCol.Size = new System.Drawing.Size(553, 20);
            this.synCol.TabIndex = 23;
            this.synCol.Click += new System.EventHandler(this.gColClick);
            // 
            // synReg
            // 
            this.synReg.Dock = System.Windows.Forms.DockStyle.Top;
            this.synReg.Location = new System.Drawing.Point(3, 62);
            this.synReg.Name = "synReg";
            this.synReg.Size = new System.Drawing.Size(553, 20);
            this.synReg.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Location = new System.Drawing.Point(3, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Syntax";
            // 
            // colwsText
            // 
            this.colwsText.Dock = System.Windows.Forms.DockStyle.Top;
            this.colwsText.Location = new System.Drawing.Point(3, 29);
            this.colwsText.Name = "colwsText";
            this.colwsText.Size = new System.Drawing.Size(553, 20);
            this.colwsText.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(3, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(257, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Column dimensions in characters (Comma Separated)";
            // 
            // optionsToolStrip
            // 
            this.optionsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveseBtn,
            this.restoresetBtn});
            this.optionsToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.optionsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.optionsToolStrip.Name = "optionsToolStrip";
            this.optionsToolStrip.Size = new System.Drawing.Size(573, 23);
            this.optionsToolStrip.TabIndex = 2;
            this.optionsToolStrip.Text = "Options";
            // 
            // saveseBtn
            // 
            this.saveseBtn.Image = global::ASMSharp.Properties.Resources.save;
            this.saveseBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveseBtn.Name = "saveseBtn";
            this.saveseBtn.Size = new System.Drawing.Size(51, 20);
            this.saveseBtn.Text = "Save";
            this.saveseBtn.Click += new System.EventHandler(this.savesetbtn_Click);
            // 
            // restoresetBtn
            // 
            this.restoresetBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.restoresetBtn.Image = ((System.Drawing.Image)(resources.GetObject("restoresetBtn.Image")));
            this.restoresetBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.restoresetBtn.Name = "restoresetBtn";
            this.restoresetBtn.Size = new System.Drawing.Size(95, 19);
            this.restoresetBtn.Text = "Restore defaults";
            this.restoresetBtn.Click += new System.EventHandler(this.defbtn_Click);
            // 
            // optionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 501);
            this.Controls.Add(this.optionsTabControl);
            this.Controls.Add(this.optionsToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "optionsForm";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.optionsForm_Load);
            this.optionsTabControl.ResumeLayout(false);
            this.settingsPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.asmsettings.ResumeLayout(false);
            this.asmsettings.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.simsettings.ResumeLayout(false);
            this.simsettings.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cfontsizeNum)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontsizeNum)).EndInit();
            this.formatterPref.ResumeLayout(false);
            this.formatterPref.PerformLayout();
            this.optionsToolStrip.ResumeLayout(false);
            this.optionsToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button simexebrowse;
        private System.Windows.Forms.TextBox asmExe;
        private System.Windows.Forms.TabControl optionsTabControl;
        private System.Windows.Forms.TabPage settingsPage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox asmsettings;
        private System.Windows.Forms.RichTextBox asminput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox asmscript;
        private System.Windows.Forms.Button asmscriptBrowse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox asmarg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button asmexBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox simsettings;
        private System.Windows.Forms.RichTextBox siminput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox simarg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox simexe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStrip optionsToolStrip;
        private System.Windows.Forms.ToolStripButton saveseBtn;
        private System.Windows.Forms.ToolStripButton restoresetBtn;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown fontsizeNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button codebackcol;
        private System.Windows.Forms.Button codeforecolor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox formatterPref;
        private System.Windows.Forms.TextBox colwsText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox intReg;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox regReg;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button regCol;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button intCol;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button decCol;
        private System.Windows.Forms.TextBox decReg;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button labelCol;
        private System.Windows.Forms.TextBox labelReg;
        private System.Windows.Forms.Button synCol;
        private System.Windows.Forms.TextBox synReg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cforecol;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button cbackcol;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown cfontsizeNum;
        private System.Windows.Forms.Label label19;
    }
}