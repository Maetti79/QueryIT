namespace QueryIT {
    partial class ConcatForm {
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.beforeTxt = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.afterTxt = new System.Windows.Forms.TextBox();
            this.columnList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(254, 43);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(100, 21);
            this.SearchBtn.TabIndex = 4;
            this.SearchBtn.Text = "Concat (Ctrl+R)";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Columns";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Concat";
            // 
            // beforeTxt
            // 
            this.beforeTxt.Location = new System.Drawing.Point(59, 15);
            this.beforeTxt.Name = "beforeTxt";
            this.beforeTxt.Size = new System.Drawing.Size(89, 20);
            this.beforeTxt.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(173, 15);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(56, 20);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "Cell Value";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // afterTxt
            // 
            this.afterTxt.Location = new System.Drawing.Point(254, 15);
            this.afterTxt.Name = "afterTxt";
            this.afterTxt.Size = new System.Drawing.Size(100, 20);
            this.afterTxt.TabIndex = 14;
            // 
            // columnList
            // 
            this.columnList.FormattingEnabled = true;
            this.columnList.Location = new System.Drawing.Point(59, 43);
            this.columnList.Name = "columnList";
            this.columnList.Size = new System.Drawing.Size(189, 21);
            this.columnList.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "+";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "+";
            // 
            // ConcatForm
            // 
            this.AcceptButton = this.SearchBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 76);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.columnList);
            this.Controls.Add(this.afterTxt);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.beforeTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SearchBtn);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConcatForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Concat";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox beforeTxt;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox afterTxt;
        private System.Windows.Forms.ComboBox columnList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}