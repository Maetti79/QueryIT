namespace QueryIT
{
    partial class FilterForm
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
            this.searchBox = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.caseSensetiveChk = new System.Windows.Forms.CheckBox();
            this.exactChk = new System.Windows.Forms.CheckBox();
            this.columnBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Location = new System.Drawing.Point(77, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(295, 20);
            this.searchBox.TabIndex = 0;
            this.searchBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBtn.Location = new System.Drawing.Point(272, 109);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(100, 23);
            this.SearchBtn.TabIndex = 2;
            this.SearchBtn.Text = "Filter (Ctrl+F)";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // caseSensetiveChk
            // 
            this.caseSensetiveChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.caseSensetiveChk.AutoSize = true;
            this.caseSensetiveChk.Location = new System.Drawing.Point(272, 64);
            this.caseSensetiveChk.Name = "caseSensetiveChk";
            this.caseSensetiveChk.Size = new System.Drawing.Size(100, 17);
            this.caseSensetiveChk.TabIndex = 3;
            this.caseSensetiveChk.Text = "Case Sensetive";
            this.caseSensetiveChk.UseVisualStyleBackColor = true;
            // 
            // exactChk
            // 
            this.exactChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exactChk.AutoSize = true;
            this.exactChk.Location = new System.Drawing.Point(272, 41);
            this.exactChk.Name = "exactChk";
            this.exactChk.Size = new System.Drawing.Size(86, 17);
            this.exactChk.TabIndex = 4;
            this.exactChk.Text = "Exact Match";
            this.exactChk.UseVisualStyleBackColor = true;
            // 
            // columnBox
            // 
            this.columnBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.columnBox.FormattingEnabled = true;
            this.columnBox.Location = new System.Drawing.Point(77, 38);
            this.columnBox.Name = "columnBox";
            this.columnBox.Size = new System.Drawing.Size(189, 94);
            this.columnBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Filter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Columns";
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 143);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.columnBox);
            this.Controls.Add(this.exactChk);
            this.Controls.Add(this.caseSensetiveChk);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.searchBox);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Filter";
            this.Load += new System.EventHandler(this.FilterForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.CheckBox caseSensetiveChk;
        private System.Windows.Forms.CheckBox exactChk;
        private System.Windows.Forms.CheckedListBox columnBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}