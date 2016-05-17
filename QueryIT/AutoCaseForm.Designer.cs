namespace QueryIT {
    partial class AutoCaseForm {
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
            this.SearchBtn = new System.Windows.Forms.Button();
            this.columnBox = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.caseBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SearchBtn
            // 
            this.SearchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBtn.Location = new System.Drawing.Point(272, 111);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(100, 23);
            this.SearchBtn.TabIndex = 4;
            this.SearchBtn.Text = "Change (Ctrl+R)";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // columnBox
            // 
            this.columnBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.columnBox.FormattingEnabled = true;
            this.columnBox.Location = new System.Drawing.Point(77, 40);
            this.columnBox.Name = "columnBox";
            this.columnBox.Size = new System.Drawing.Size(189, 94);
            this.columnBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Columns";
            // 
            // caseBox
            // 
            this.caseBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.caseBox.AutoCompleteCustomSource.AddRange(new string[] {
            "to lower",
            "to UPPER",
            "to Capitalized Words "});
            this.caseBox.FormattingEnabled = true;
            this.caseBox.Items.AddRange(new object[] {
            "to lower",
            "to UPPER",
            "to Title Case"});
            this.caseBox.Location = new System.Drawing.Point(77, 12);
            this.caseBox.Name = "caseBox";
            this.caseBox.Size = new System.Drawing.Size(295, 21);
            this.caseBox.TabIndex = 10;
            this.caseBox.Text = "to Capitalized Words ";
            this.caseBox.SelectedIndexChanged += new System.EventHandler(this.caseBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Case";
            // 
            // AutoCaseForm
            // 
            this.AcceptButton = this.SearchBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 138);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.caseBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.columnBox);
            this.Controls.Add(this.SearchBtn);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoCaseForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Auto Case";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.CheckedListBox columnBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox caseBox;
        private System.Windows.Forms.Label label1;
    }
}