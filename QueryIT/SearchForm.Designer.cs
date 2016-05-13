namespace QueryIT
{
    partial class SearchForm
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
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Location = new System.Drawing.Point(12, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(295, 20);
            this.searchBox.TabIndex = 0;
            this.searchBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBtn.Location = new System.Drawing.Point(208, 35);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(100, 23);
            this.SearchBtn.TabIndex = 2;
            this.SearchBtn.Text = "Search (Ctrl+F)";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // caseSensetiveChk
            // 
            this.caseSensetiveChk.AutoSize = true;
            this.caseSensetiveChk.Location = new System.Drawing.Point(13, 41);
            this.caseSensetiveChk.Name = "caseSensetiveChk";
            this.caseSensetiveChk.Size = new System.Drawing.Size(100, 17);
            this.caseSensetiveChk.TabIndex = 3;
            this.caseSensetiveChk.Text = "Case Sensetive";
            this.caseSensetiveChk.UseVisualStyleBackColor = true;
            // 
            // exactChk
            // 
            this.exactChk.AutoSize = true;
            this.exactChk.Location = new System.Drawing.Point(116, 41);
            this.exactChk.Name = "exactChk";
            this.exactChk.Size = new System.Drawing.Size(86, 17);
            this.exactChk.TabIndex = 4;
            this.exactChk.Text = "Exact Match";
            this.exactChk.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            this.AcceptButton = this.SearchBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 69);
            this.Controls.Add(this.exactChk);
            this.Controls.Add(this.caseSensetiveChk);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.searchBox);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.CheckBox caseSensetiveChk;
        private System.Windows.Forms.CheckBox exactChk;
    }
}