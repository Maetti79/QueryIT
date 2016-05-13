namespace PluginTAB
{
    partial class ExportForm
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
            this.OkBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.lineEndingBox = new System.Windows.Forms.ComboBox();
            this.fieldDelimiterBox = new System.Windows.Forms.ComboBox();
            this.columnNamesChk = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OkBtn
            // 
            this.OkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OkBtn.Location = new System.Drawing.Point(12, 120);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 0;
            this.OkBtn.Text = "Export";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(122, 120);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // lineEndingBox
            // 
            this.lineEndingBox.FormattingEnabled = true;
            this.lineEndingBox.Items.AddRange(new object[] {
            "\\n",
            "\\r\\n"});
            this.lineEndingBox.Location = new System.Drawing.Point(100, 61);
            this.lineEndingBox.Name = "lineEndingBox";
            this.lineEndingBox.Size = new System.Drawing.Size(97, 21);
            this.lineEndingBox.TabIndex = 2;
            this.lineEndingBox.Text = "\\n";
            // 
            // fieldDelimiterBox
            // 
            this.fieldDelimiterBox.FormattingEnabled = true;
            this.fieldDelimiterBox.Items.AddRange(new object[] {
            ",",
            ";",
            "\\t"});
            this.fieldDelimiterBox.Location = new System.Drawing.Point(100, 34);
            this.fieldDelimiterBox.Name = "fieldDelimiterBox";
            this.fieldDelimiterBox.Size = new System.Drawing.Size(97, 21);
            this.fieldDelimiterBox.TabIndex = 3;
            this.fieldDelimiterBox.Text = "\\t";
            // 
            // columnNamesChk
            // 
            this.columnNamesChk.AutoSize = true;
            this.columnNamesChk.Checked = true;
            this.columnNamesChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.columnNamesChk.Location = new System.Drawing.Point(100, 10);
            this.columnNamesChk.Name = "columnNamesChk";
            this.columnNamesChk.Size = new System.Drawing.Size(97, 17);
            this.columnNamesChk.TabIndex = 4;
            this.columnNamesChk.Text = "Column Names";
            this.columnNamesChk.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Delimiter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Line Ending";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "First Row";
            // 
            // ExportForm
            // 
            this.AcceptButton = this.OkBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(209, 161);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.columnNamesChk);
            this.Controls.Add(this.fieldDelimiterBox);
            this.Controls.Add(this.lineEndingBox);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OkBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportForm";
            this.Text = "Export";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.ComboBox lineEndingBox;
        private System.Windows.Forms.ComboBox fieldDelimiterBox;
        private System.Windows.Forms.CheckBox columnNamesChk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}