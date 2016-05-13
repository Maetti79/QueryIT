namespace QueryIT
{
    partial class MoveForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveForm));
            this.moveTabs = new System.Windows.Forms.TabControl();
            this.moveMapTab = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.moveMapGroup = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.truncateBox = new System.Windows.Forms.CheckBox();
            this.posLbl = new System.Windows.Forms.Label();
            this.recordsLbl = new System.Windows.Forms.Label();
            this.historyCheck = new System.Windows.Forms.CheckBox();
            this.EsimateLbl = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.stopCheck = new System.Windows.Forms.CheckBox();
            this.ignoreCheck = new System.Windows.Forms.CheckBox();
            this.typecastCheck = new System.Windows.Forms.CheckBox();
            this.moveProgress = new System.Windows.Forms.ProgressBar();
            this.moveMapGrid = new System.Windows.Forms.DataGridView();
            this.moveResultTab = new System.Windows.Forms.TabPage();
            this.moveResultBox = new System.Windows.Forms.RichTextBox();
            this.moveHistoryTab = new System.Windows.Forms.TabPage();
            this.moveHistoryBox = new System.Windows.Forms.RichTextBox();
            this.MoveIcons = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusTimer = new System.Windows.Forms.Timer(this.components);
            this.moveTabs.SuspendLayout();
            this.moveMapTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.moveMapGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moveMapGrid)).BeginInit();
            this.moveResultTab.SuspendLayout();
            this.moveHistoryTab.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // moveTabs
            // 
            this.moveTabs.Controls.Add(this.moveMapTab);
            this.moveTabs.Controls.Add(this.moveResultTab);
            this.moveTabs.Controls.Add(this.moveHistoryTab);
            this.moveTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moveTabs.ImageList = this.MoveIcons;
            this.moveTabs.Location = new System.Drawing.Point(0, 24);
            this.moveTabs.Name = "moveTabs";
            this.moveTabs.SelectedIndex = 0;
            this.moveTabs.Size = new System.Drawing.Size(584, 337);
            this.moveTabs.TabIndex = 0;
            // 
            // moveMapTab
            // 
            this.moveMapTab.Controls.Add(this.splitContainer1);
            this.moveMapTab.ImageIndex = 4;
            this.moveMapTab.Location = new System.Drawing.Point(4, 23);
            this.moveMapTab.Name = "moveMapTab";
            this.moveMapTab.Padding = new System.Windows.Forms.Padding(3);
            this.moveMapTab.Size = new System.Drawing.Size(576, 310);
            this.moveMapTab.TabIndex = 0;
            this.moveMapTab.Text = "Column Map";
            this.moveMapTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.moveMapGroup);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.moveMapGrid);
            this.splitContainer1.Size = new System.Drawing.Size(570, 304);
            this.splitContainer1.SplitterDistance = 189;
            this.splitContainer1.TabIndex = 1;
            // 
            // moveMapGroup
            // 
            this.moveMapGroup.Controls.Add(this.label2);
            this.moveMapGroup.Controls.Add(this.label1);
            this.moveMapGroup.Controls.Add(this.truncateBox);
            this.moveMapGroup.Controls.Add(this.posLbl);
            this.moveMapGroup.Controls.Add(this.recordsLbl);
            this.moveMapGroup.Controls.Add(this.historyCheck);
            this.moveMapGroup.Controls.Add(this.EsimateLbl);
            this.moveMapGroup.Controls.Add(this.statusLabel);
            this.moveMapGroup.Controls.Add(this.stopCheck);
            this.moveMapGroup.Controls.Add(this.ignoreCheck);
            this.moveMapGroup.Controls.Add(this.typecastCheck);
            this.moveMapGroup.Controls.Add(this.moveProgress);
            this.moveMapGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moveMapGroup.Location = new System.Drawing.Point(0, 0);
            this.moveMapGroup.Name = "moveMapGroup";
            this.moveMapGroup.Size = new System.Drawing.Size(189, 304);
            this.moveMapGroup.TabIndex = 0;
            this.moveMapGroup.TabStop = false;
            this.moveMapGroup.Text = "ODBC Data Mover";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "User at your own RISK";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "BETA - Work in Progress";
            // 
            // truncateBox
            // 
            this.truncateBox.AutoSize = true;
            this.truncateBox.Location = new System.Drawing.Point(6, 176);
            this.truncateBox.Name = "truncateBox";
            this.truncateBox.Size = new System.Drawing.Size(105, 17);
            this.truncateBox.TabIndex = 9;
            this.truncateBox.Text = "use TRUNCATE";
            this.truncateBox.UseVisualStyleBackColor = true;
            // 
            // posLbl
            // 
            this.posLbl.AutoSize = true;
            this.posLbl.Location = new System.Drawing.Point(2, 42);
            this.posLbl.Name = "posLbl";
            this.posLbl.Size = new System.Drawing.Size(51, 13);
            this.posLbl.TabIndex = 8;
            this.posLbl.Text = "Record 0";
            // 
            // recordsLbl
            // 
            this.recordsLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.recordsLbl.Location = new System.Drawing.Point(87, 42);
            this.recordsLbl.Name = "recordsLbl";
            this.recordsLbl.Size = new System.Drawing.Size(100, 13);
            this.recordsLbl.TabIndex = 7;
            this.recordsLbl.Text = "0 Records";
            this.recordsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // historyCheck
            // 
            this.historyCheck.AutoSize = true;
            this.historyCheck.Location = new System.Drawing.Point(6, 84);
            this.historyCheck.Name = "historyCheck";
            this.historyCheck.Size = new System.Drawing.Size(91, 17);
            this.historyCheck.TabIndex = 6;
            this.historyCheck.Text = "Log to History";
            this.historyCheck.UseVisualStyleBackColor = true;
            // 
            // EsimateLbl
            // 
            this.EsimateLbl.AutoSize = true;
            this.EsimateLbl.Location = new System.Drawing.Point(3, 68);
            this.EsimateLbl.Name = "EsimateLbl";
            this.EsimateLbl.Size = new System.Drawing.Size(47, 13);
            this.EsimateLbl.TabIndex = 5;
            this.EsimateLbl.Text = "Duration";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(3, 55);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(37, 13);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "Status";
            // 
            // stopCheck
            // 
            this.stopCheck.AutoSize = true;
            this.stopCheck.Location = new System.Drawing.Point(5, 130);
            this.stopCheck.Name = "stopCheck";
            this.stopCheck.Size = new System.Drawing.Size(85, 17);
            this.stopCheck.TabIndex = 3;
            this.stopCheck.Text = "stop on error";
            this.stopCheck.UseVisualStyleBackColor = true;
            // 
            // ignoreCheck
            // 
            this.ignoreCheck.AutoSize = true;
            this.ignoreCheck.Location = new System.Drawing.Point(6, 153);
            this.ignoreCheck.Name = "ignoreCheck";
            this.ignoreCheck.Size = new System.Drawing.Size(131, 17);
            this.ignoreCheck.TabIndex = 2;
            this.ignoreCheck.Text = "use INSERT IGNORE";
            this.ignoreCheck.UseVisualStyleBackColor = true;
            // 
            // typecastCheck
            // 
            this.typecastCheck.AutoSize = true;
            this.typecastCheck.Location = new System.Drawing.Point(6, 107);
            this.typecastCheck.Name = "typecastCheck";
            this.typecastCheck.Size = new System.Drawing.Size(93, 17);
            this.typecastCheck.TabIndex = 1;
            this.typecastCheck.Text = "force typecast";
            this.typecastCheck.UseVisualStyleBackColor = true;
            // 
            // moveProgress
            // 
            this.moveProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.moveProgress.Location = new System.Drawing.Point(6, 19);
            this.moveProgress.Name = "moveProgress";
            this.moveProgress.Size = new System.Drawing.Size(177, 20);
            this.moveProgress.TabIndex = 0;
            // 
            // moveMapGrid
            // 
            this.moveMapGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.moveMapGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moveMapGrid.Location = new System.Drawing.Point(0, 0);
            this.moveMapGrid.Name = "moveMapGrid";
            this.moveMapGrid.Size = new System.Drawing.Size(377, 304);
            this.moveMapGrid.TabIndex = 2;
            // 
            // moveResultTab
            // 
            this.moveResultTab.Controls.Add(this.moveResultBox);
            this.moveResultTab.ImageIndex = 9;
            this.moveResultTab.Location = new System.Drawing.Point(4, 23);
            this.moveResultTab.Name = "moveResultTab";
            this.moveResultTab.Padding = new System.Windows.Forms.Padding(3);
            this.moveResultTab.Size = new System.Drawing.Size(576, 310);
            this.moveResultTab.TabIndex = 1;
            this.moveResultTab.Text = "Result";
            this.moveResultTab.UseVisualStyleBackColor = true;
            // 
            // moveResultBox
            // 
            this.moveResultBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moveResultBox.Location = new System.Drawing.Point(3, 3);
            this.moveResultBox.Name = "moveResultBox";
            this.moveResultBox.Size = new System.Drawing.Size(570, 304);
            this.moveResultBox.TabIndex = 0;
            this.moveResultBox.Text = "";
            // 
            // moveHistoryTab
            // 
            this.moveHistoryTab.Controls.Add(this.moveHistoryBox);
            this.moveHistoryTab.ImageIndex = 8;
            this.moveHistoryTab.Location = new System.Drawing.Point(4, 23);
            this.moveHistoryTab.Name = "moveHistoryTab";
            this.moveHistoryTab.Size = new System.Drawing.Size(576, 310);
            this.moveHistoryTab.TabIndex = 2;
            this.moveHistoryTab.Text = "History";
            this.moveHistoryTab.UseVisualStyleBackColor = true;
            // 
            // moveHistoryBox
            // 
            this.moveHistoryBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.moveHistoryBox.Location = new System.Drawing.Point(3, 3);
            this.moveHistoryBox.Name = "moveHistoryBox";
            this.moveHistoryBox.Size = new System.Drawing.Size(617, 407);
            this.moveHistoryBox.TabIndex = 0;
            this.moveHistoryBox.Text = "";
            // 
            // MoveIcons
            // 
            this.MoveIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MoveIcons.ImageStream")));
            this.MoveIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.MoveIcons.Images.SetKeyName(0, "Database-Connecting.png");
            this.MoveIcons.Images.SetKeyName(1, "Database-Connected.png");
            this.MoveIcons.Images.SetKeyName(2, "Database-Disconnected.png");
            this.MoveIcons.Images.SetKeyName(3, "1-csv.png");
            this.MoveIcons.Images.SetKeyName(4, "1-DB.png");
            this.MoveIcons.Images.SetKeyName(5, "2-Table.png");
            this.MoveIcons.Images.SetKeyName(6, "3-Column.png");
            this.MoveIcons.Images.SetKeyName(7, "chart_bar.png");
            this.MoveIcons.Images.SetKeyName(8, "clock.png");
            this.MoveIcons.Images.SetKeyName(9, "application_lightning.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapToolStripMenuItem,
            this.runToolStripMenuItem,
            this.killToolStripMenuItem,
            this.pluginsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.mapToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mapToolStripMenuItem.Image")));
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.mapToolStripMenuItem.Text = "Map";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadToolStripMenuItem.Image")));
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.loadToolStripMenuItem.Text = "Load (*.qit)";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.saveToolStripMenuItem.Text = "Save (*.qit)";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.saveAsToolStripMenuItem.Text = "Save as (*.qit)";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("runToolStripMenuItem.Image")));
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.runToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // killToolStripMenuItem
            // 
            this.killToolStripMenuItem.Enabled = false;
            this.killToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("killToolStripMenuItem.Image")));
            this.killToolStripMenuItem.Name = "killToolStripMenuItem";
            this.killToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.killToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.killToolStripMenuItem.Text = "Kill";
            this.killToolStripMenuItem.Click += new System.EventHandler(this.killToolStripMenuItem_Click);
            // 
            // pluginsToolStripMenuItem
            // 
            this.pluginsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pluginsToolStripMenuItem.Image")));
            this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.pluginsToolStripMenuItem.Text = "Plugins";
            // 
            // statusTimer
            // 
            this.statusTimer.Interval = 1000;
            this.statusTimer.Tick += new System.EventHandler(this.statusTimer_Tick);
            // 
            // MoveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.moveTabs);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MoveForm";
            this.Text = "Mover";
            this.Activated += new System.EventHandler(this.MoveForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MoveForm_FormClosing);
            this.Load += new System.EventHandler(this.MoveForm_Load);
            this.Move += new System.EventHandler(this.MoveForm_Move);
            this.Resize += new System.EventHandler(this.MoveForm_Resize);
            this.moveTabs.ResumeLayout(false);
            this.moveMapTab.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.moveMapGroup.ResumeLayout(false);
            this.moveMapGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moveMapGrid)).EndInit();
            this.moveResultTab.ResumeLayout(false);
            this.moveHistoryTab.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl moveTabs;
        private System.Windows.Forms.TabPage moveMapTab;
        private System.Windows.Forms.TabPage moveResultTab;
        private System.Windows.Forms.RichTextBox moveResultBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem killToolStripMenuItem;
        private System.Windows.Forms.TabPage moveHistoryTab;
        private System.Windows.Forms.RichTextBox moveHistoryBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox moveMapGroup;
        private System.Windows.Forms.DataGridView moveMapGrid;
        private System.Windows.Forms.ProgressBar moveProgress;
        private System.Windows.Forms.CheckBox typecastCheck;
        private System.Windows.Forms.CheckBox ignoreCheck;
        private System.Windows.Forms.CheckBox stopCheck;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label EsimateLbl;
        private System.Windows.Forms.CheckBox historyCheck;
        private System.Windows.Forms.Timer statusTimer;
        private System.Windows.Forms.Label posLbl;
        private System.Windows.Forms.Label recordsLbl;
        private System.Windows.Forms.CheckBox truncateBox;
        private System.Windows.Forms.ImageList MoveIcons;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}