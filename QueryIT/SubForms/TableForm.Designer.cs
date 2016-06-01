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
            this.tableBox = new System.Windows.Forms.TextBox();
            this.tableSchemaGrid = new System.Windows.Forms.DataGridView();
            this.sqlPage = new System.Windows.Forms.TabPage();
            this.sqlSplitH = new System.Windows.Forms.SplitContainer();
            this.sqlRtf = new System.Windows.Forms.RichTextBox();
            this.resultBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.tableTab.SuspendLayout();
            this.tablePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableSchemaGrid)).BeginInit();
            this.sqlPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sqlSplitH)).BeginInit();
            this.sqlSplitH.Panel1.SuspendLayout();
            this.sqlSplitH.Panel2.SuspendLayout();
            this.sqlSplitH.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.cancelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(434, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.saveToolStripMenuItem.Text = "Apply";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cancelToolStripMenuItem.Image")));
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // tableTab
            // 
            this.tableTab.Controls.Add(this.tablePage);
            this.tableTab.Controls.Add(this.sqlPage);
            this.tableTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableTab.Location = new System.Drawing.Point(0, 24);
            this.tableTab.Name = "tableTab";
            this.tableTab.SelectedIndex = 0;
            this.tableTab.Size = new System.Drawing.Size(434, 317);
            this.tableTab.TabIndex = 1;
            // 
            // tablePage
            // 
            this.tablePage.Controls.Add(this.tableBox);
            this.tablePage.Controls.Add(this.tableSchemaGrid);
            this.tablePage.Location = new System.Drawing.Point(4, 22);
            this.tablePage.Name = "tablePage";
            this.tablePage.Padding = new System.Windows.Forms.Padding(3);
            this.tablePage.Size = new System.Drawing.Size(426, 291);
            this.tablePage.TabIndex = 0;
            this.tablePage.Text = "Table Schema";
            this.tablePage.UseVisualStyleBackColor = true;
            // 
            // tableBox
            // 
            this.tableBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableBox.Location = new System.Drawing.Point(0, 0);
            this.tableBox.Name = "tableBox";
            this.tableBox.Size = new System.Drawing.Size(426, 20);
            this.tableBox.TabIndex = 2;
            this.tableBox.TextChanged += new System.EventHandler(this.tableBox_TextChanged);
            // 
            // tableSchemaGrid
            // 
            this.tableSchemaGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableSchemaGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableSchemaGrid.Location = new System.Drawing.Point(0, 26);
            this.tableSchemaGrid.Name = "tableSchemaGrid";
            this.tableSchemaGrid.Size = new System.Drawing.Size(426, 265);
            this.tableSchemaGrid.TabIndex = 0;
            this.tableSchemaGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableSchemaGrid_CellContentClick);
            this.tableSchemaGrid.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableSchemaGrid_CellLeave);
            this.tableSchemaGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.typeColumnDataGridView_CellValidating);
            this.tableSchemaGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableSchemaGrid_CellValueChanged);
            this.tableSchemaGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.typeColumnDataGridView_OnCurrentCellDirtyStateChanged);
            this.tableSchemaGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.typeColumnDataGridView_EditingControlShowing);
            this.tableSchemaGrid.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.tableSchemaGrid_UserAddedRow);
            this.tableSchemaGrid.Click += new System.EventHandler(this.tableSchemaGrid_Click);
            // 
            // sqlPage
            // 
            this.sqlPage.Controls.Add(this.sqlSplitH);
            this.sqlPage.Location = new System.Drawing.Point(4, 22);
            this.sqlPage.Name = "sqlPage";
            this.sqlPage.Padding = new System.Windows.Forms.Padding(3);
            this.sqlPage.Size = new System.Drawing.Size(426, 291);
            this.sqlPage.TabIndex = 1;
            this.sqlPage.Text = "SQL Statment";
            this.sqlPage.UseVisualStyleBackColor = true;
            // 
            // sqlSplitH
            // 
            this.sqlSplitH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlSplitH.Location = new System.Drawing.Point(3, 3);
            this.sqlSplitH.Name = "sqlSplitH";
            this.sqlSplitH.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sqlSplitH.Panel1
            // 
            this.sqlSplitH.Panel1.Controls.Add(this.sqlRtf);
            // 
            // sqlSplitH.Panel2
            // 
            this.sqlSplitH.Panel2.Controls.Add(this.resultBox);
            this.sqlSplitH.Size = new System.Drawing.Size(420, 285);
            this.sqlSplitH.SplitterDistance = 141;
            this.sqlSplitH.TabIndex = 5;
            // 
            // sqlRtf
            // 
            this.sqlRtf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlRtf.Location = new System.Drawing.Point(0, 0);
            this.sqlRtf.Name = "sqlRtf";
            this.sqlRtf.Size = new System.Drawing.Size(420, 141);
            this.sqlRtf.TabIndex = 1;
            this.sqlRtf.Text = "";
            // 
            // resultBox
            // 
            this.resultBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultBox.Location = new System.Drawing.Point(0, 0);
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.Size = new System.Drawing.Size(420, 140);
            this.resultBox.TabIndex = 5;
            this.resultBox.Text = "";
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 341);
            this.Controls.Add(this.tableTab);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TableForm";
            this.Text = "Table [ALPHA]";
            this.Load += new System.EventHandler(this.Table_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableTab.ResumeLayout(false);
            this.tablePage.ResumeLayout(false);
            this.tablePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableSchemaGrid)).EndInit();
            this.sqlPage.ResumeLayout(false);
            this.sqlSplitH.Panel1.ResumeLayout(false);
            this.sqlSplitH.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sqlSplitH)).EndInit();
            this.sqlSplitH.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox tableBox;
        private System.Windows.Forms.SplitContainer sqlSplitH;
        private System.Windows.Forms.RichTextBox sqlRtf;
        private System.Windows.Forms.RichTextBox resultBox;

    }
}