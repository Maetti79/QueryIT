namespace QueryIT
{
    partial class CompareForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompareForm));
            this.tabCompare = new System.Windows.Forms.TabControl();
            this.sourceTab = new System.Windows.Forms.TabPage();
            this.sourceGrid = new System.Windows.Forms.DataGridView();
            this.compareTab = new System.Windows.Forms.TabPage();
            this.bothGrid = new System.Windows.Forms.DataGridView();
            this.destinationTab = new System.Windows.Forms.TabPage();
            this.destinationGrid = new System.Windows.Forms.DataGridView();
            this.compareIcons = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.resultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.destinationOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.destinationToSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soruceToDestinationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doubleInSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMatchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doubleInDestinationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabCompare.SuspendLayout();
            this.sourceTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourceGrid)).BeginInit();
            this.compareTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bothGrid)).BeginInit();
            this.destinationTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.destinationGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCompare
            // 
            this.tabCompare.Controls.Add(this.sourceTab);
            this.tabCompare.Controls.Add(this.compareTab);
            this.tabCompare.Controls.Add(this.destinationTab);
            this.tabCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCompare.ImageList = this.compareIcons;
            this.tabCompare.Location = new System.Drawing.Point(0, 24);
            this.tabCompare.Name = "tabCompare";
            this.tabCompare.SelectedIndex = 0;
            this.tabCompare.Size = new System.Drawing.Size(584, 337);
            this.tabCompare.TabIndex = 0;
            // 
            // sourceTab
            // 
            this.sourceTab.Controls.Add(this.sourceGrid);
            this.sourceTab.ImageIndex = 0;
            this.sourceTab.Location = new System.Drawing.Point(4, 23);
            this.sourceTab.Name = "sourceTab";
            this.sourceTab.Size = new System.Drawing.Size(576, 310);
            this.sourceTab.TabIndex = 0;
            this.sourceTab.Text = "Source only";
            this.sourceTab.UseVisualStyleBackColor = true;
            // 
            // sourceGrid
            // 
            this.sourceGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.sourceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sourceGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceGrid.Location = new System.Drawing.Point(0, 0);
            this.sourceGrid.Name = "sourceGrid";
            this.sourceGrid.Size = new System.Drawing.Size(576, 310);
            this.sourceGrid.TabIndex = 0;
            // 
            // compareTab
            // 
            this.compareTab.Controls.Add(this.bothGrid);
            this.compareTab.ImageIndex = 1;
            this.compareTab.Location = new System.Drawing.Point(4, 23);
            this.compareTab.Name = "compareTab";
            this.compareTab.Size = new System.Drawing.Size(576, 310);
            this.compareTab.TabIndex = 2;
            this.compareTab.Text = "Both";
            this.compareTab.UseVisualStyleBackColor = true;
            // 
            // bothGrid
            // 
            this.bothGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.bothGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bothGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bothGrid.Location = new System.Drawing.Point(0, 0);
            this.bothGrid.Name = "bothGrid";
            this.bothGrid.Size = new System.Drawing.Size(576, 310);
            this.bothGrid.TabIndex = 0;
            // 
            // destinationTab
            // 
            this.destinationTab.Controls.Add(this.destinationGrid);
            this.destinationTab.ImageIndex = 2;
            this.destinationTab.Location = new System.Drawing.Point(4, 23);
            this.destinationTab.Name = "destinationTab";
            this.destinationTab.Size = new System.Drawing.Size(576, 310);
            this.destinationTab.TabIndex = 1;
            this.destinationTab.Text = "Destination only";
            this.destinationTab.UseVisualStyleBackColor = true;
            // 
            // destinationGrid
            // 
            this.destinationGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.destinationGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.destinationGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.destinationGrid.Location = new System.Drawing.Point(0, 0);
            this.destinationGrid.Name = "destinationGrid";
            this.destinationGrid.Size = new System.Drawing.Size(576, 310);
            this.destinationGrid.TabIndex = 0;
            // 
            // compareIcons
            // 
            this.compareIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("compareIcons.ImageStream")));
            this.compareIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.compareIcons.Images.SetKeyName(0, "shape_aling_right.png");
            this.compareIcons.Images.SetKeyName(1, "shape_aling_center.png");
            this.compareIcons.Images.SetKeyName(2, "shape_aling_left.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resultToolStripMenuItem,
            this.compareToolStripMenuItem,
            this.killToolStripMenuItem,
            this.pluginsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // resultToolStripMenuItem
            // 
            this.resultToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportSourceToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.deleteRecordsToolStripMenuItem});
            this.resultToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("resultToolStripMenuItem.Image")));
            this.resultToolStripMenuItem.Name = "resultToolStripMenuItem";
            this.resultToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.resultToolStripMenuItem.Text = "Result";
            // 
            // exportSourceToolStripMenuItem
            // 
            this.exportSourceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceOnlyToolStripMenuItem,
            this.matchesToolStripMenuItem,
            this.destinationOnlyToolStripMenuItem});
            this.exportSourceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportSourceToolStripMenuItem.Image")));
            this.exportSourceToolStripMenuItem.Name = "exportSourceToolStripMenuItem";
            this.exportSourceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportSourceToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.exportSourceToolStripMenuItem.Text = "Export (*.csv)";
            this.exportSourceToolStripMenuItem.Click += new System.EventHandler(this.exportSourceToolStripMenuItem_Click);
            // 
            // sourceOnlyToolStripMenuItem
            // 
            this.sourceOnlyToolStripMenuItem.Name = "sourceOnlyToolStripMenuItem";
            this.sourceOnlyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.sourceOnlyToolStripMenuItem.Text = "Source only";
            this.sourceOnlyToolStripMenuItem.Click += new System.EventHandler(this.sourceOnlyToolStripMenuItem_Click);
            // 
            // matchesToolStripMenuItem
            // 
            this.matchesToolStripMenuItem.Name = "matchesToolStripMenuItem";
            this.matchesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.matchesToolStripMenuItem.Text = "Both";
            this.matchesToolStripMenuItem.Click += new System.EventHandler(this.matchesToolStripMenuItem_Click);
            // 
            // destinationOnlyToolStripMenuItem
            // 
            this.destinationOnlyToolStripMenuItem.Name = "destinationOnlyToolStripMenuItem";
            this.destinationOnlyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.destinationOnlyToolStripMenuItem.Text = "Destination only";
            this.destinationOnlyToolStripMenuItem.Click += new System.EventHandler(this.destinationOnlyToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.destinationToSourceToolStripMenuItem,
            this.soruceToDestinationToolStripMenuItem});
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.saveToolStripMenuItem.Text = "Insert Missing";
            // 
            // destinationToSourceToolStripMenuItem
            // 
            this.destinationToSourceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("destinationToSourceToolStripMenuItem.Image")));
            this.destinationToSourceToolStripMenuItem.Name = "destinationToSourceToolStripMenuItem";
            this.destinationToSourceToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.destinationToSourceToolStripMenuItem.Text = "to Source";
            // 
            // soruceToDestinationToolStripMenuItem
            // 
            this.soruceToDestinationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("soruceToDestinationToolStripMenuItem.Image")));
            this.soruceToDestinationToolStripMenuItem.Name = "soruceToDestinationToolStripMenuItem";
            this.soruceToDestinationToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.soruceToDestinationToolStripMenuItem.Text = "to Destination";
            // 
            // deleteRecordsToolStripMenuItem
            // 
            this.deleteRecordsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doubleInSourceToolStripMenuItem,
            this.deleteMatchesToolStripMenuItem,
            this.doubleInDestinationToolStripMenuItem});
            this.deleteRecordsToolStripMenuItem.Enabled = false;
            this.deleteRecordsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteRecordsToolStripMenuItem.Image")));
            this.deleteRecordsToolStripMenuItem.Name = "deleteRecordsToolStripMenuItem";
            this.deleteRecordsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteRecordsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.deleteRecordsToolStripMenuItem.Text = "Delete Double";
            // 
            // doubleInSourceToolStripMenuItem
            // 
            this.doubleInSourceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("doubleInSourceToolStripMenuItem.Image")));
            this.doubleInSourceToolStripMenuItem.Name = "doubleInSourceToolStripMenuItem";
            this.doubleInSourceToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.doubleInSourceToolStripMenuItem.Text = "in Source";
            // 
            // deleteMatchesToolStripMenuItem
            // 
            this.deleteMatchesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteMatchesToolStripMenuItem.Image")));
            this.deleteMatchesToolStripMenuItem.Name = "deleteMatchesToolStripMenuItem";
            this.deleteMatchesToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.deleteMatchesToolStripMenuItem.Text = "in Both";
            // 
            // doubleInDestinationToolStripMenuItem
            // 
            this.doubleInDestinationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("doubleInDestinationToolStripMenuItem.Image")));
            this.doubleInDestinationToolStripMenuItem.Name = "doubleInDestinationToolStripMenuItem";
            this.doubleInDestinationToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.doubleInDestinationToolStripMenuItem.Text = "in Destination";
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("compareToolStripMenuItem.Image")));
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.compareToolStripMenuItem.Text = "Compare";
            this.compareToolStripMenuItem.Click += new System.EventHandler(this.compareToolStripMenuItem_Click);
            // 
            // killToolStripMenuItem
            // 
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
            // CompareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.tabCompare);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CompareForm";
            this.Text = "Compare";
            this.Load += new System.EventHandler(this.CompareForm_Load);
            this.tabCompare.ResumeLayout(false);
            this.sourceTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sourceGrid)).EndInit();
            this.compareTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bothGrid)).EndInit();
            this.destinationTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.destinationGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabCompare;
        private System.Windows.Forms.TabPage sourceTab;
        private System.Windows.Forms.TabPage compareTab;
        private System.Windows.Forms.TabPage destinationTab;
        private System.Windows.Forms.ImageList compareIcons;
        private System.Windows.Forms.DataGridView sourceGrid;
        private System.Windows.Forms.DataGridView bothGrid;
        private System.Windows.Forms.DataGridView destinationGrid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sourceOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem destinationOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soruceToDestinationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem destinationToSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doubleInSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMatchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doubleInDestinationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem killToolStripMenuItem;
    }
}