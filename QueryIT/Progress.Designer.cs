namespace QueryIT {
    partial class ProgressForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressForm));
            this.progress = new System.Windows.Forms.ProgressBar();
            this.TimeLbl = new System.Windows.Forms.Label();
            this.EstimationLbl = new System.Windows.Forms.Label();
            this.SpeedLbl = new System.Windows.Forms.Label();
            this.killBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progress
            // 
            this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progress.Location = new System.Drawing.Point(12, 12);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(327, 47);
            this.progress.TabIndex = 0;
            // 
            // TimeLbl
            // 
            this.TimeLbl.AutoSize = true;
            this.TimeLbl.Location = new System.Drawing.Point(9, 71);
            this.TimeLbl.Name = "TimeLbl";
            this.TimeLbl.Size = new System.Drawing.Size(51, 13);
            this.TimeLbl.TabIndex = 1;
            this.TimeLbl.Text = "Runnung";
            // 
            // EstimationLbl
            // 
            this.EstimationLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EstimationLbl.AutoSize = true;
            this.EstimationLbl.Location = new System.Drawing.Point(155, 71);
            this.EstimationLbl.Name = "EstimationLbl";
            this.EstimationLbl.Size = new System.Drawing.Size(53, 13);
            this.EstimationLbl.TabIndex = 2;
            this.EstimationLbl.Text = "Estimated";
            // 
            // SpeedLbl
            // 
            this.SpeedLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SpeedLbl.AutoSize = true;
            this.SpeedLbl.Location = new System.Drawing.Point(301, 71);
            this.SpeedLbl.Name = "SpeedLbl";
            this.SpeedLbl.Size = new System.Drawing.Size(38, 13);
            this.SpeedLbl.TabIndex = 3;
            this.SpeedLbl.Text = "Speed";
            // 
            // killBtn
            // 
            this.killBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.killBtn.Image = ((System.Drawing.Image)(resources.GetObject("killBtn.Image")));
            this.killBtn.Location = new System.Drawing.Point(345, 12);
            this.killBtn.Name = "killBtn";
            this.killBtn.Size = new System.Drawing.Size(47, 47);
            this.killBtn.TabIndex = 4;
            this.killBtn.UseVisualStyleBackColor = true;
            this.killBtn.Click += new System.EventHandler(this.killBtn_Click);
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 100);
            this.Controls.Add(this.killBtn);
            this.Controls.Add(this.SpeedLbl);
            this.Controls.Add(this.EstimationLbl);
            this.Controls.Add(this.TimeLbl);
            this.Controls.Add(this.progress);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Progress";
            this.Load += new System.EventHandler(this.ProgressForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label TimeLbl;
        private System.Windows.Forms.Label EstimationLbl;
        private System.Windows.Forms.Label SpeedLbl;
        private System.Windows.Forms.Button killBtn;
    }
}