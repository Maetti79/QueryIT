namespace QueryIT
{
    partial class AboutForm
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
            this.aboutGroup = new System.Windows.Forms.GroupBox();
            this.OkBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SerialLbl = new System.Windows.Forms.Label();
            this.VersionLbl = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.aboutGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // aboutGroup
            // 
            this.aboutGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutGroup.Controls.Add(this.linkLabel1);
            this.aboutGroup.Controls.Add(this.OkBtn);
            this.aboutGroup.Controls.Add(this.label6);
            this.aboutGroup.Controls.Add(this.label5);
            this.aboutGroup.Controls.Add(this.label4);
            this.aboutGroup.Controls.Add(this.label3);
            this.aboutGroup.Controls.Add(this.SerialLbl);
            this.aboutGroup.Controls.Add(this.VersionLbl);
            this.aboutGroup.Location = new System.Drawing.Point(12, 12);
            this.aboutGroup.Name = "aboutGroup";
            this.aboutGroup.Size = new System.Drawing.Size(270, 247);
            this.aboutGroup.TabIndex = 0;
            this.aboutGroup.TabStop = false;
            this.aboutGroup.Text = "QueryIT";
            this.aboutGroup.Enter += new System.EventHandler(this.aboutGroup_Enter);
            // 
            // OkBtn
            // 
            this.OkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.OkBtn.Location = new System.Drawing.Point(106, 212);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(61, 23);
            this.OkBtn.TabIndex = 4;
            this.OkBtn.Text = "Close";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "© 2016";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "41836 Hückelhoven - Ratheim";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Steinstraße 35";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dennis Mittmann";
            // 
            // SerialLbl
            // 
            this.SerialLbl.AutoSize = true;
            this.SerialLbl.Location = new System.Drawing.Point(11, 55);
            this.SerialLbl.Name = "SerialLbl";
            this.SerialLbl.Size = new System.Drawing.Size(33, 13);
            this.SerialLbl.TabIndex = 1;
            this.SerialLbl.Text = "Serial";
            this.SerialLbl.Click += new System.EventHandler(this.label2_Click);
            // 
            // VersionLbl
            // 
            this.VersionLbl.AutoSize = true;
            this.VersionLbl.Location = new System.Drawing.Point(55, 33);
            this.VersionLbl.Name = "VersionLbl";
            this.VersionLbl.Size = new System.Drawing.Size(42, 13);
            this.VersionLbl.TabIndex = 0;
            this.VersionLbl.Text = "Version";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(55, 163);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(129, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://queryit.purepix.net/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // AboutForm
            // 
            this.AcceptButton = this.OkBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 271);
            this.Controls.Add(this.aboutGroup);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "About";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.aboutGroup.ResumeLayout(false);
            this.aboutGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox aboutGroup;
        private System.Windows.Forms.Label VersionLbl;
        private System.Windows.Forms.Label SerialLbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}