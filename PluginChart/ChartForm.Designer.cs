namespace PluginChart
{
    partial class ChartForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartForm));
            this.chartTabs = new System.Windows.Forms.TabControl();
            this.bindingTab = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.YSeriesList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.xAxisBox = new System.Windows.Forms.ComboBox();
            this.chartTab = new System.Windows.Forms.TabPage();
            this.Chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartTabs.SuspendLayout();
            this.bindingTab.SuspendLayout();
            this.chartTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartTabs
            // 
            this.chartTabs.Controls.Add(this.bindingTab);
            this.chartTabs.Controls.Add(this.chartTab);
            this.chartTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTabs.Location = new System.Drawing.Point(0, 24);
            this.chartTabs.Name = "chartTabs";
            this.chartTabs.SelectedIndex = 0;
            this.chartTabs.Size = new System.Drawing.Size(484, 287);
            this.chartTabs.TabIndex = 0;
            // 
            // bindingTab
            // 
            this.bindingTab.Controls.Add(this.label2);
            this.bindingTab.Controls.Add(this.YSeriesList);
            this.bindingTab.Controls.Add(this.label1);
            this.bindingTab.Controls.Add(this.xAxisBox);
            this.bindingTab.Location = new System.Drawing.Point(4, 22);
            this.bindingTab.Name = "bindingTab";
            this.bindingTab.Padding = new System.Windows.Forms.Padding(3);
            this.bindingTab.Size = new System.Drawing.Size(476, 261);
            this.bindingTab.TabIndex = 0;
            this.bindingTab.Text = "Binding";
            this.bindingTab.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y-Series";
            // 
            // YSeriesList
            // 
            this.YSeriesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.YSeriesList.CheckOnClick = true;
            this.YSeriesList.FormattingEnabled = true;
            this.YSeriesList.Location = new System.Drawing.Point(60, 34);
            this.YSeriesList.Name = "YSeriesList";
            this.YSeriesList.Size = new System.Drawing.Size(408, 214);
            this.YSeriesList.TabIndex = 2;
            this.YSeriesList.SelectedIndexChanged += new System.EventHandler(this.YSeriesList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X-Axis";
            // 
            // xAxisBox
            // 
            this.xAxisBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xAxisBox.FormattingEnabled = true;
            this.xAxisBox.Location = new System.Drawing.Point(60, 6);
            this.xAxisBox.Name = "xAxisBox";
            this.xAxisBox.Size = new System.Drawing.Size(408, 21);
            this.xAxisBox.TabIndex = 0;
            this.xAxisBox.Text = "(Select X-Axis)";
            this.xAxisBox.SelectedIndexChanged += new System.EventHandler(this.xAxisBox_SelectedIndexChanged);
            // 
            // chartTab
            // 
            this.chartTab.Controls.Add(this.Chart1);
            this.chartTab.Location = new System.Drawing.Point(4, 22);
            this.chartTab.Name = "chartTab";
            this.chartTab.Padding = new System.Windows.Forms.Padding(3);
            this.chartTab.Size = new System.Drawing.Size(476, 261);
            this.chartTab.TabIndex = 1;
            this.chartTab.Text = "Chart";
            this.chartTab.UseVisualStyleBackColor = true;
            // 
            // Chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.Chart1.ChartAreas.Add(chartArea1);
            this.Chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.Chart1.Legends.Add(legend1);
            this.Chart1.Location = new System.Drawing.Point(3, 3);
            this.Chart1.Name = "Chart1";
            this.Chart1.Size = new System.Drawing.Size(470, 255);
            this.Chart1.TabIndex = 0;
            this.Chart1.Text = "chart1";
            this.Chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chartToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chartToolStripMenuItem
            // 
            this.chartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.chartToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("chartToolStripMenuItem.Image")));
            this.chartToolStripMenuItem.Name = "chartToolStripMenuItem";
            this.chartToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.chartToolStripMenuItem.Text = "Chart";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadToolStripMenuItem.Image")));
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.chartTabs);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ChartForm";
            this.Text = "ChartView";
            this.Load += new System.EventHandler(this.ChartForm_Load);
            this.chartTabs.ResumeLayout(false);
            this.bindingTab.ResumeLayout(false);
            this.bindingTab.PerformLayout();
            this.chartTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl chartTabs;
        private System.Windows.Forms.TabPage bindingTab;
        private System.Windows.Forms.TabPage chartTab;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox xAxisBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox YSeriesList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    }
}