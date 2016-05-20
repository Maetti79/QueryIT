namespace QueryIT
{
    partial class DateTimeForm
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
            this.dtm = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.OkBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.nowBtn = new System.Windows.Forms.Button();
            this.TimeBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dtm
            // 
            this.dtm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtm.Location = new System.Drawing.Point(0, 0);
            this.dtm.Name = "dtm";
            this.dtm.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Time: ";
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(12, 190);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 3;
            this.OkBtn.Text = "OK";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(93, 190);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // nowBtn
            // 
            this.nowBtn.Location = new System.Drawing.Point(129, 164);
            this.nowBtn.Name = "nowBtn";
            this.nowBtn.Size = new System.Drawing.Size(37, 20);
            this.nowBtn.TabIndex = 5;
            this.nowBtn.Text = "Now";
            this.nowBtn.UseVisualStyleBackColor = true;
            this.nowBtn.Click += new System.EventHandler(this.nowBtn_Click);
            // 
            // TimeBox
            // 
            this.TimeBox.Location = new System.Drawing.Point(54, 165);
            this.TimeBox.Name = "TimeBox";
            this.TimeBox.Size = new System.Drawing.Size(69, 20);
            this.TimeBox.TabIndex = 6;
            // 
            // DateTimeForm
            // 
            this.AcceptButton = this.OkBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(178, 221);
            this.Controls.Add(this.TimeBox);
            this.Controls.Add(this.nowBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtm);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DateTimeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "DateTime";
            this.Load += new System.EventHandler(this.DateTimeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar dtm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button nowBtn;
        private System.Windows.Forms.TextBox TimeBox;
    }
}