namespace ASMSharp
{
    partial class mainFrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainFrm));
            this.codeboxmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.runmenuitem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminatemenuitem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statStrip = new System.Windows.Forms.StatusStrip();
            this.statLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progBar = new System.Windows.Forms.ToolStripProgressBar();
            this.openfilewatcher = new System.IO.FileSystemWatcher();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.codeBox = new ASMSharp.CodeBox();
            this.codeBoxLines = new ASMSharp.LineView();
            this.consoleBox = new ASMSharp.RConsole();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newBtn = new System.Windows.Forms.ToolStripButton();
            this.open = new System.Windows.Forms.ToolStripButton();
            this.saveBtn = new System.Windows.Forms.ToolStripButton();
            this.saveasBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.formatBtn = new System.Windows.Forms.ToolStripButton();
            this.buildrunBtn = new System.Windows.Forms.ToolStripButton();
            this.stopBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsBtn = new System.Windows.Forms.ToolStripButton();
            this.codeboxmenu.SuspendLayout();
            this.statStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openfilewatcher)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // codeboxmenu
            // 
            this.codeboxmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItem1,
            this.runmenuitem,
            this.terminatemenuitem,
            this.toolStripSeparator3,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.codeboxmenu.Name = "codeboxmenu";
            this.codeboxmenu.Size = new System.Drawing.Size(187, 214);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.open_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveasBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.F)));
            this.toolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem1.Text = "Format";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.formatBtn_Click);
            // 
            // runmenuitem
            // 
            this.runmenuitem.Image = ((System.Drawing.Image)(resources.GetObject("runmenuitem.Image")));
            this.runmenuitem.Name = "runmenuitem";
            this.runmenuitem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.runmenuitem.Size = new System.Drawing.Size(186, 22);
            this.runmenuitem.Text = "Build and Run";
            this.runmenuitem.Click += new System.EventHandler(this.buildrunBtn_Click);
            // 
            // terminatemenuitem
            // 
            this.terminatemenuitem.Image = ((System.Drawing.Image)(resources.GetObject("terminatemenuitem.Image")));
            this.terminatemenuitem.Name = "terminatemenuitem";
            this.terminatemenuitem.Size = new System.Drawing.Size(186, 22);
            this.terminatemenuitem.Text = "Terminate";
            this.terminatemenuitem.Visible = false;
            this.terminatemenuitem.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(183, 6);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Image = global::ASMSharp.Properties.Resources.undo;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Image = global::ASMSharp.Properties.Resources.redo;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // statStrip
            // 
            this.statStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statLabel,
            this.progBar});
            this.statStrip.Location = new System.Drawing.Point(0, 539);
            this.statStrip.Name = "statStrip";
            this.statStrip.Size = new System.Drawing.Size(884, 22);
            this.statStrip.TabIndex = 1;
            this.statStrip.Text = "statusStrip1";
            // 
            // statLabel
            // 
            this.statLabel.Name = "statLabel";
            this.statLabel.Size = new System.Drawing.Size(29, 17);
            this.statLabel.Text = "Idle.";
            // 
            // progBar
            // 
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(100, 16);
            this.progBar.Visible = false;
            // 
            // openfilewatcher
            // 
            this.openfilewatcher.EnableRaisingEvents = true;
            this.openfilewatcher.SynchronizingObject = this;
            this.openfilewatcher.Changed += new System.IO.FileSystemEventHandler(this.openfilewatcher_Changed);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Size = new System.Drawing.Size(884, 484);
            this.splitContainer3.SplitterDistance = 521;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 55);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.codeBox);
            this.splitContainer3.Panel1.Controls.Add(this.codeBoxLines);
            this.splitContainer3.Panel1MinSize = 200;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.consoleBox);
            this.splitContainer3.Panel2MinSize = 150;
            this.splitContainer3.TabIndex = 4;
            // 
            // codeBox
            // 
            this.codeBox.AcceptsTab = true;
            this.codeBox.BackColor = System.Drawing.Color.Black;
            this.codeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeBox.ContextMenuStrip = this.codeboxmenu;
            this.codeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeBox.Edited = false;
            this.codeBox.ForeColor = System.Drawing.Color.White;
            this.codeBox.LabelColor = System.Drawing.Color.Brown;
            this.codeBox.LineView = this.codeBoxLines;
            this.codeBox.Location = new System.Drawing.Point(21, 0);
            this.codeBox.Name = "codeBox";
            this.codeBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.codeBox.Size = new System.Drawing.Size(500, 484);
            this.codeBox.TabIndex = 0;
            this.codeBox.Text = "";
            this.codeBox.WordWrap = false;
            // 
            // codeBoxLines
            // 
            this.codeBoxLines.BackColor = System.Drawing.Color.Black;
            this.codeBoxLines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeBoxLines.CodeBox = this.codeBox;
            this.codeBoxLines.Dock = System.Windows.Forms.DockStyle.Left;
            this.codeBoxLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeBoxLines.ForeColor = System.Drawing.Color.White;
            this.codeBoxLines.Location = new System.Drawing.Point(0, 0);
            this.codeBoxLines.Name = "codeBoxLines";
            this.codeBoxLines.ReadOnly = true;
            this.codeBoxLines.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedHorizontal;
            this.codeBoxLines.Size = new System.Drawing.Size(21, 484);
            this.codeBoxLines.TabIndex = 1;
            this.codeBoxLines.Text = "";
            this.codeBoxLines.WordWrap = false;
            // 
            // consoleBox
            // 
            this.consoleBox.BackColor = System.Drawing.Color.Black;
            this.consoleBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.consoleBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleBox.ForeColor = System.Drawing.Color.White;
            this.consoleBox.Location = new System.Drawing.Point(0, 0);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ReadOnly = true;
            this.consoleBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.consoleBox.Size = new System.Drawing.Size(359, 484);
            this.consoleBox.TabIndex = 0;
            this.consoleBox.Text = "";
            this.consoleBox.WordWrap = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBtn,
            this.open,
            this.saveBtn,
            this.saveasBtn,
            this.toolStripSeparator1,
            this.formatBtn,
            this.buildrunBtn,
            this.stopBtn,
            this.toolStripSeparator4,
            this.optionsBtn});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(884, 55);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "Tools";
            // 
            // newBtn
            // 
            this.newBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newBtn.Image = ((System.Drawing.Image)(resources.GetObject("newBtn.Image")));
            this.newBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(52, 52);
            this.newBtn.Text = "New";
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // open
            // 
            this.open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.open.Image = ((System.Drawing.Image)(resources.GetObject("open.Image")));
            this.open.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(52, 52);
            this.open.Text = "Open";
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveBtn.Image")));
            this.saveBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(52, 52);
            this.saveBtn.Text = "Save";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // saveasBtn
            // 
            this.saveasBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveasBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveasBtn.Image")));
            this.saveasBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveasBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveasBtn.Name = "saveasBtn";
            this.saveasBtn.Size = new System.Drawing.Size(52, 52);
            this.saveasBtn.Text = "Save As";
            this.saveasBtn.Click += new System.EventHandler(this.saveasBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(16, 48);
            // 
            // formatBtn
            // 
            this.formatBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.formatBtn.Image = ((System.Drawing.Image)(resources.GetObject("formatBtn.Image")));
            this.formatBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.formatBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.formatBtn.Name = "formatBtn";
            this.formatBtn.Size = new System.Drawing.Size(51, 52);
            this.formatBtn.Text = "Format";
            this.formatBtn.Click += new System.EventHandler(this.formatBtn_Click);
            // 
            // buildrunBtn
            // 
            this.buildrunBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buildrunBtn.Image = ((System.Drawing.Image)(resources.GetObject("buildrunBtn.Image")));
            this.buildrunBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buildrunBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buildrunBtn.Name = "buildrunBtn";
            this.buildrunBtn.Size = new System.Drawing.Size(52, 52);
            this.buildrunBtn.Text = "Build and Run";
            this.buildrunBtn.Click += new System.EventHandler(this.buildrunBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopBtn.Image = ((System.Drawing.Image)(resources.GetObject("stopBtn.Image")));
            this.stopBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stopBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(52, 52);
            this.stopBtn.Text = "Terminate";
            this.stopBtn.Visible = false;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.AutoSize = false;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(16, 48);
            // 
            // optionsBtn
            // 
            this.optionsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.optionsBtn.Image = global::ASMSharp.Properties.Resources.options;
            this.optionsBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.optionsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optionsBtn.Name = "optionsBtn";
            this.optionsBtn.Size = new System.Drawing.Size(44, 52);
            this.optionsBtn.Text = "Options";
            this.optionsBtn.Click += new System.EventHandler(this.optionsBtn_Click);
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "mainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASMSharp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainFrm_FormClosing);
            this.Load += new System.EventHandler(this.mainFrm_Load);
            this.codeboxmenu.ResumeLayout(false);
            this.statStrip.ResumeLayout(false);
            this.statStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openfilewatcher)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statStrip;
        private System.Windows.Forms.ContextMenuStrip codeboxmenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem runmenuitem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public System.Windows.Forms.ToolStripStatusLabel statLabel;
        public System.Windows.Forms.ToolStripProgressBar progBar;
        private System.Windows.Forms.ToolStripMenuItem terminatemenuitem;
        private System.IO.FileSystemWatcher openfilewatcher;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private CodeBox codeBox;
        private RConsole consoleBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newBtn;
        private System.Windows.Forms.ToolStripButton open;
        private System.Windows.Forms.ToolStripButton saveBtn;
        private System.Windows.Forms.ToolStripButton saveasBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton formatBtn;
        private System.Windows.Forms.ToolStripButton buildrunBtn;
        private System.Windows.Forms.ToolStripButton stopBtn;
        private System.Windows.Forms.ToolStripButton optionsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private LineView codeBoxLines;
    }
}

