namespace QueryIT
{
    partial class ForeachForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForeachForm));
            this.loopTabs = new System.Windows.Forms.TabControl();
            this.moveMapTab = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.DatabaseTree = new System.Windows.Forms.TreeView();
            this.QueryIcons = new System.Windows.Forms.ImageList(this.components);
            this.previewPosLbl = new System.Windows.Forms.Label();
            this.nextBtn = new System.Windows.Forms.Button();
            this.prevBtn = new System.Windows.Forms.Button();
            this.placeholderList = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.sqlBox = new System.Windows.Forms.RichTextBox();
            this.sqlPreviewBox = new System.Windows.Forms.RichTextBox();
            this.moveResultTab = new System.Windows.Forms.TabPage();
            this.loopResultBox = new System.Windows.Forms.RichTextBox();
            this.moveHistoryTab = new System.Windows.Forms.TabPage();
            this.loopHistoryBox = new System.Windows.Forms.RichTextBox();
            this.MoveIcons = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autocomplete = new AutocompleteMenuNS.AutocompleteMenu();
            this.loopTabs.SuspendLayout();
            this.moveMapTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.moveResultTab.SuspendLayout();
            this.moveHistoryTab.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loopTabs
            // 
            this.loopTabs.Controls.Add(this.moveMapTab);
            this.loopTabs.Controls.Add(this.moveResultTab);
            this.loopTabs.Controls.Add(this.moveHistoryTab);
            this.loopTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loopTabs.ImageList = this.MoveIcons;
            this.loopTabs.Location = new System.Drawing.Point(0, 24);
            this.loopTabs.Name = "loopTabs";
            this.loopTabs.SelectedIndex = 0;
            this.loopTabs.Size = new System.Drawing.Size(584, 337);
            this.loopTabs.TabIndex = 0;
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
            this.moveMapTab.Text = "Record Loop";
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(570, 304);
            this.splitContainer1.SplitterDistance = 189;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.DatabaseTree);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.previewPosLbl);
            this.splitContainer3.Panel2.Controls.Add(this.nextBtn);
            this.splitContainer3.Panel2.Controls.Add(this.prevBtn);
            this.splitContainer3.Panel2.Controls.Add(this.placeholderList);
            this.splitContainer3.Size = new System.Drawing.Size(189, 304);
            this.splitContainer3.SplitterDistance = 152;
            this.splitContainer3.TabIndex = 14;
            // 
            // DatabaseTree
            // 
            this.DatabaseTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatabaseTree.ImageIndex = 0;
            this.DatabaseTree.ImageList = this.QueryIcons;
            this.DatabaseTree.Location = new System.Drawing.Point(0, 0);
            this.DatabaseTree.Name = "DatabaseTree";
            this.DatabaseTree.SelectedImageIndex = 0;
            this.DatabaseTree.Size = new System.Drawing.Size(189, 152);
            this.DatabaseTree.TabIndex = 13;
            // 
            // QueryIcons
            // 
            this.QueryIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("QueryIcons.ImageStream")));
            this.QueryIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.QueryIcons.Images.SetKeyName(0, "Database-Connecting.png");
            this.QueryIcons.Images.SetKeyName(1, "Database-Connected.png");
            this.QueryIcons.Images.SetKeyName(2, "Database-Disconnected.png");
            this.QueryIcons.Images.SetKeyName(3, "1-csv.png");
            this.QueryIcons.Images.SetKeyName(4, "1-DB.png");
            this.QueryIcons.Images.SetKeyName(5, "2-Table.png");
            this.QueryIcons.Images.SetKeyName(6, "3-Column.png");
            this.QueryIcons.Images.SetKeyName(7, "chart_bar.png");
            this.QueryIcons.Images.SetKeyName(8, "clock.png");
            this.QueryIcons.Images.SetKeyName(9, "application_lightning.png");
            this.QueryIcons.Images.SetKeyName(10, "key.png");
            this.QueryIcons.Images.SetKeyName(11, "list.png");
            this.QueryIcons.Images.SetKeyName(12, "text.png");
            this.QueryIcons.Images.SetKeyName(13, "notepad.png");
            this.QueryIcons.Images.SetKeyName(14, "checkbook.png");
            // 
            // previewPosLbl
            // 
            this.previewPosLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.previewPosLbl.AutoSize = true;
            this.previewPosLbl.Location = new System.Drawing.Point(33, 130);
            this.previewPosLbl.Name = "previewPosLbl";
            this.previewPosLbl.Size = new System.Drawing.Size(43, 13);
            this.previewPosLbl.TabIndex = 17;
            this.previewPosLbl.Text = "0 / max";
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextBtn.Location = new System.Drawing.Point(162, 125);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(27, 23);
            this.nextBtn.TabIndex = 16;
            this.nextBtn.Text = ">";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // prevBtn
            // 
            this.prevBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prevBtn.Location = new System.Drawing.Point(0, 125);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(27, 23);
            this.prevBtn.TabIndex = 15;
            this.prevBtn.Text = "<";
            this.prevBtn.UseVisualStyleBackColor = true;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // placeholderList
            // 
            this.placeholderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.placeholderList.FormattingEnabled = true;
            this.placeholderList.Location = new System.Drawing.Point(0, 0);
            this.placeholderList.Name = "placeholderList";
            this.placeholderList.Size = new System.Drawing.Size(189, 121);
            this.placeholderList.TabIndex = 14;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.sqlBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.sqlPreviewBox);
            this.splitContainer2.Size = new System.Drawing.Size(377, 304);
            this.splitContainer2.SplitterDistance = 148;
            this.splitContainer2.TabIndex = 0;
            // 
            // sqlBox
            // 
            this.autocomplete.SetAutocompleteMenu(this.sqlBox, this.autocomplete);
            this.sqlBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlBox.Font = new System.Drawing.Font("Consolas", 12F);
            this.sqlBox.Location = new System.Drawing.Point(0, 0);
            this.sqlBox.Name = "sqlBox";
            this.sqlBox.Size = new System.Drawing.Size(377, 148);
            this.sqlBox.TabIndex = 4;
            this.sqlBox.Text = "";
            this.sqlBox.TextChanged += new System.EventHandler(this.sqlBox_TextChanged);
            // 
            // sqlPreviewBox
            // 
            this.autocomplete.SetAutocompleteMenu(this.sqlPreviewBox, null);
            this.sqlPreviewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlPreviewBox.Font = new System.Drawing.Font("Consolas", 12F);
            this.sqlPreviewBox.Location = new System.Drawing.Point(0, 0);
            this.sqlPreviewBox.Name = "sqlPreviewBox";
            this.sqlPreviewBox.ReadOnly = true;
            this.sqlPreviewBox.Size = new System.Drawing.Size(377, 152);
            this.sqlPreviewBox.TabIndex = 0;
            this.sqlPreviewBox.Text = "";
            this.sqlPreviewBox.TextChanged += new System.EventHandler(this.sqlPreviewBox_TextChanged);
            // 
            // moveResultTab
            // 
            this.moveResultTab.Controls.Add(this.loopResultBox);
            this.moveResultTab.ImageIndex = 9;
            this.moveResultTab.Location = new System.Drawing.Point(4, 23);
            this.moveResultTab.Name = "moveResultTab";
            this.moveResultTab.Padding = new System.Windows.Forms.Padding(3);
            this.moveResultTab.Size = new System.Drawing.Size(576, 310);
            this.moveResultTab.TabIndex = 1;
            this.moveResultTab.Text = "Result";
            this.moveResultTab.UseVisualStyleBackColor = true;
            // 
            // loopResultBox
            // 
            this.autocomplete.SetAutocompleteMenu(this.loopResultBox, null);
            this.loopResultBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loopResultBox.Location = new System.Drawing.Point(3, 3);
            this.loopResultBox.Name = "loopResultBox";
            this.loopResultBox.Size = new System.Drawing.Size(570, 304);
            this.loopResultBox.TabIndex = 0;
            this.loopResultBox.Text = "";
            // 
            // moveHistoryTab
            // 
            this.moveHistoryTab.Controls.Add(this.loopHistoryBox);
            this.moveHistoryTab.ImageIndex = 8;
            this.moveHistoryTab.Location = new System.Drawing.Point(4, 23);
            this.moveHistoryTab.Name = "moveHistoryTab";
            this.moveHistoryTab.Size = new System.Drawing.Size(576, 310);
            this.moveHistoryTab.TabIndex = 2;
            this.moveHistoryTab.Text = "History";
            this.moveHistoryTab.UseVisualStyleBackColor = true;
            // 
            // loopHistoryBox
            // 
            this.loopHistoryBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.autocomplete.SetAutocompleteMenu(this.loopHistoryBox, null);
            this.loopHistoryBox.Location = new System.Drawing.Point(3, 3);
            this.loopHistoryBox.Name = "loopHistoryBox";
            this.loopHistoryBox.Size = new System.Drawing.Size(617, 407);
            this.loopHistoryBox.TabIndex = 0;
            this.loopHistoryBox.Text = "";
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
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.mapToolStripMenuItem.Text = "ForEach";
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
            // autocomplete
            // 
            this.autocomplete.Colors = ((AutocompleteMenuNS.Colors)(resources.GetObject("autocomplete.Colors")));
            this.autocomplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.autocomplete.ImageList = this.QueryIcons;
            this.autocomplete.Items = new string[0];
            this.autocomplete.TargetControlWrapper = null;
            // 
            // ForeachForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.loopTabs);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ForeachForm";
            this.Text = "ForEach [BETA]";
            this.Activated += new System.EventHandler(this.ForeachForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ForeachForm_FormClosing);
            this.Load += new System.EventHandler(this.ForeachForm_Load);
            this.Move += new System.EventHandler(this.ForeachForm_Move);
            this.Resize += new System.EventHandler(this.ForeachForm_Resize);
            this.loopTabs.ResumeLayout(false);
            this.moveMapTab.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.moveResultTab.ResumeLayout(false);
            this.moveHistoryTab.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl loopTabs;
        private System.Windows.Forms.TabPage moveMapTab;
        private System.Windows.Forms.TabPage moveResultTab;
        private System.Windows.Forms.RichTextBox loopResultBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem killToolStripMenuItem;
        private System.Windows.Forms.TabPage moveHistoryTab;
        private System.Windows.Forms.RichTextBox loopHistoryBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList MoveIcons;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox sqlBox;
        private System.Windows.Forms.RichTextBox sqlPreviewBox;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TreeView DatabaseTree;
        private System.Windows.Forms.ListBox placeholderList;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.ImageList QueryIcons;
        private System.Windows.Forms.Label previewPosLbl;
        private AutocompleteMenuNS.AutocompleteMenu autocomplete;
    }
}