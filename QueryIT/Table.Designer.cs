namespace QueryIT {
    partial class TableForm {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableTab = new System.Windows.Forms.TabControl();
            this.tablePage = new System.Windows.Forms.TabPage();
            this.tableSchemaGrid = new System.Windows.Forms.DataGridView();
            this.sqlPage = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.tableTab.SuspendLayout();
            this.tablePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableSchemaGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.cancelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(352, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cancelToolStripMenuItem.Image")));
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cancelToolStripMenuItem.Text = "Cancel";
            // 
            // tableTab
            // 
            this.tableTab.Controls.Add(this.tablePage);
            this.tableTab.Controls.Add(this.sqlPage);
            this.tableTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableTab.Location = new System.Drawing.Point(0, 24);
            this.tableTab.Name = "tableTab";
            this.tableTab.SelectedIndex = 0;
            this.tableTab.Size = new System.Drawing.Size(352, 341);
            this.tableTab.TabIndex = 1;
            // 
            // tablePage
            // 
            this.tablePage.Controls.Add(this.tableSchemaGrid);
            this.tablePage.Location = new System.Drawing.Point(4, 22);
            this.tablePage.Name = "tablePage";
            this.tablePage.Padding = new System.Windows.Forms.Padding(3);
            this.tablePage.Size = new System.Drawing.Size(344, 315);
            this.tablePage.TabIndex = 0;
            this.tablePage.Text = "Table Schema";
            this.tablePage.UseVisualStyleBackColor = true;
            // 
            // tableSchemaGrid
            // 
            this.tableSchemaGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableSchemaGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableSchemaGrid.Location = new System.Drawing.Point(3, 3);
            this.tableSchemaGrid.Name = "tableSchemaGrid";
            this.tableSchemaGrid.Size = new System.Drawing.Size(338, 309);
            this.tableSchemaGrid.TabIndex = 0;
            // 
            // sqlPage
            // 
            this.sqlPage.Location = new System.Drawing.Point(4, 22);
            this.sqlPage.Name = "sqlPage";
            this.sqlPage.Padding = new System.Windows.Forms.Padding(3);
            this.sqlPage.Size = new System.Drawing.Size(344, 315);
            this.sqlPage.TabIndex = 1;
            this.sqlPage.Text = "SQL Statment";
            this.sqlPage.UseVisualStyleBackColor = true;
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 365);
            this.Controls.Add(this.tableTab);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TableForm";
            this.Text = "Table";
            this.Load += new System.EventHandler(this.Table_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableTab.ResumeLayout(false);
            this.tablePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableSchemaGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tableTab;
        private System.Windows.Forms.TabPage tablePage;
        private System.Windows.Forms.TabPage sqlPage;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.DataGridView tableSchemaGrid;

    }
}