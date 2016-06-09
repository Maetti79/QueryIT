namespace QueryIT
{
    partial class CrossJoin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrossJoin));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.resultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportcsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crossJoinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.crossjoinGroup = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DestinationSelect = new System.Windows.Forms.ComboBox();
            this.SourceSelect = new System.Windows.Forms.ComboBox();
            this.crossjoinView = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.crossjoinGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crossjoinView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resultToolStripMenuItem,
            this.crossJoinToolStripMenuItem,
            this.killToolStripMenuItem,
            this.pluginsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // resultToolStripMenuItem
            // 
            this.resultToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportcsvToolStripMenuItem});
            this.resultToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("resultToolStripMenuItem.Image")));
            this.resultToolStripMenuItem.Name = "resultToolStripMenuItem";
            this.resultToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.resultToolStripMenuItem.Text = "Result";
            // 
            // exportcsvToolStripMenuItem
            // 
            this.exportcsvToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportcsvToolStripMenuItem.Image")));
            this.exportcsvToolStripMenuItem.Name = "exportcsvToolStripMenuItem";
            this.exportcsvToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportcsvToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.exportcsvToolStripMenuItem.Text = "Export (*.csv)";
            this.exportcsvToolStripMenuItem.Click += new System.EventHandler(this.exportcsvToolStripMenuItem_Click);
            // 
            // crossJoinToolStripMenuItem
            // 
            this.crossJoinToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("crossJoinToolStripMenuItem.Image")));
            this.crossJoinToolStripMenuItem.Name = "crossJoinToolStripMenuItem";
            this.crossJoinToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.crossJoinToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.crossJoinToolStripMenuItem.Text = "Run";
            this.crossJoinToolStripMenuItem.Click += new System.EventHandler(this.crossJoinToolStripMenuItem_Click);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.crossjoinGroup);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.crossjoinView);
            this.splitContainer1.Size = new System.Drawing.Size(584, 337);
            this.splitContainer1.SplitterDistance = 194;
            this.splitContainer1.TabIndex = 1;
            // 
            // crossjoinGroup
            // 
            this.crossjoinGroup.Controls.Add(this.label2);
            this.crossjoinGroup.Controls.Add(this.label1);
            this.crossjoinGroup.Controls.Add(this.DestinationSelect);
            this.crossjoinGroup.Controls.Add(this.SourceSelect);
            this.crossjoinGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crossjoinGroup.Location = new System.Drawing.Point(0, 0);
            this.crossjoinGroup.Name = "crossjoinGroup";
            this.crossjoinGroup.Size = new System.Drawing.Size(194, 337);
            this.crossjoinGroup.TabIndex = 0;
            this.crossjoinGroup.TabStop = false;
            this.crossjoinGroup.Text = "CrossJoin Results";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Destination";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Source";
            // 
            // DestinationSelect
            // 
            this.DestinationSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationSelect.FormattingEnabled = true;
            this.DestinationSelect.Location = new System.Drawing.Point(15, 126);
            this.DestinationSelect.Name = "DestinationSelect";
            this.DestinationSelect.Size = new System.Drawing.Size(173, 21);
            this.DestinationSelect.TabIndex = 1;
            this.DestinationSelect.Text = "(select column)";
            // 
            // SourceSelect
            // 
            this.SourceSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SourceSelect.FormattingEnabled = true;
            this.SourceSelect.Location = new System.Drawing.Point(15, 59);
            this.SourceSelect.Name = "SourceSelect";
            this.SourceSelect.Size = new System.Drawing.Size(173, 21);
            this.SourceSelect.TabIndex = 0;
            this.SourceSelect.Text = "(select column)";
            this.SourceSelect.SelectedIndexChanged += new System.EventHandler(this.SourceSelect_SelectedIndexChanged);
            // 
            // crossjoinView
            // 
            this.crossjoinView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.crossjoinView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.crossjoinView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crossjoinView.Location = new System.Drawing.Point(0, 0);
            this.crossjoinView.Name = "crossjoinView";
            this.crossjoinView.Size = new System.Drawing.Size(386, 337);
            this.crossjoinView.TabIndex = 0;
            // 
            // CrossJoin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CrossJoin";
            this.Text = "CrossJoin";
            this.Load += new System.EventHandler(this.CrossJoinForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.crossjoinGroup.ResumeLayout(false);
            this.crossjoinGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crossjoinView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView crossjoinView;
        private System.Windows.Forms.ToolStripMenuItem crossJoinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem killToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
        private System.Windows.Forms.GroupBox crossjoinGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DestinationSelect;
        private System.Windows.Forms.ComboBox SourceSelect;
        private System.Windows.Forms.ToolStripMenuItem exportcsvToolStripMenuItem;
    }
}