namespace QueryIT
{
    partial class LicenseForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenseForm));
            this.OkBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.SerialLbl = new System.Windows.Forms.Label();
            this.LicenseBox = new System.Windows.Forms.ListView();
            this.licenseIcons = new System.Windows.Forms.ImageList(this.components);
            this.donateBtn = new System.Windows.Forms.Button();
            this.LicenseLab = new System.Windows.Forms.Label();
            this.ExpiresLbl = new System.Windows.Forms.Label();
            this.EulaRtf = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // OkBtn
            // 
            this.OkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OkBtn.Location = new System.Drawing.Point(12, 433);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 1;
            this.OkBtn.Text = "Reload";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.Location = new System.Drawing.Point(700, 433);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(72, 23);
            this.CloseBtn.TabIndex = 2;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // SerialLbl
            // 
            this.SerialLbl.AutoSize = true;
            this.SerialLbl.Location = new System.Drawing.Point(12, 9);
            this.SerialLbl.Name = "SerialLbl";
            this.SerialLbl.Size = new System.Drawing.Size(192, 13);
            this.SerialLbl.TabIndex = 3;
            this.SerialLbl.Text = "License Key: ####-####-####-####";
            // 
            // LicenseBox
            // 
            this.LicenseBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.LicenseBox.Location = new System.Drawing.Point(12, 56);
            this.LicenseBox.Name = "LicenseBox";
            this.LicenseBox.Size = new System.Drawing.Size(271, 371);
            this.LicenseBox.SmallImageList = this.licenseIcons;
            this.LicenseBox.TabIndex = 4;
            this.LicenseBox.UseCompatibleStateImageBehavior = false;
            this.LicenseBox.View = System.Windows.Forms.View.List;
            this.LicenseBox.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // licenseIcons
            // 
            this.licenseIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("licenseIcons.ImageStream")));
            this.licenseIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.licenseIcons.Images.SetKeyName(0, "cross.png");
            this.licenseIcons.Images.SetKeyName(1, "accept.png");
            // 
            // donateBtn
            // 
            this.donateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.donateBtn.Location = new System.Drawing.Point(697, 27);
            this.donateBtn.Name = "donateBtn";
            this.donateBtn.Size = new System.Drawing.Size(75, 23);
            this.donateBtn.TabIndex = 5;
            this.donateBtn.Text = "Donate";
            this.donateBtn.UseVisualStyleBackColor = true;
            this.donateBtn.Click += new System.EventHandler(this.donateBtn_Click);
            // 
            // LicenseLab
            // 
            this.LicenseLab.AutoSize = true;
            this.LicenseLab.Location = new System.Drawing.Point(12, 32);
            this.LicenseLab.Name = "LicenseLab";
            this.LicenseLab.Size = new System.Drawing.Size(88, 13);
            this.LicenseLab.TabIndex = 6;
            this.LicenseLab.Text = "Type: Shareware";
            // 
            // ExpiresLbl
            // 
            this.ExpiresLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExpiresLbl.AutoSize = true;
            this.ExpiresLbl.Location = new System.Drawing.Point(671, 9);
            this.ExpiresLbl.Name = "ExpiresLbl";
            this.ExpiresLbl.Size = new System.Drawing.Size(101, 13);
            this.ExpiresLbl.TabIndex = 7;
            this.ExpiresLbl.Text = "Expires: 2016-12-31";
            this.ExpiresLbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // EulaRtf
            // 
            this.EulaRtf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EulaRtf.Location = new System.Drawing.Point(289, 56);
            this.EulaRtf.Name = "EulaRtf";
            this.EulaRtf.Size = new System.Drawing.Size(483, 371);
            this.EulaRtf.TabIndex = 8;
            this.EulaRtf.Text = "";
            // 
            // LicenseForm
            // 
            this.AcceptButton = this.CloseBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.EulaRtf);
            this.Controls.Add(this.ExpiresLbl);
            this.Controls.Add(this.LicenseLab);
            this.Controls.Add(this.donateBtn);
            this.Controls.Add(this.LicenseBox);
            this.Controls.Add(this.SerialLbl);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.OkBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LicenseForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "License";
            this.Load += new System.EventHandler(this.LicenseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Label SerialLbl;
        private System.Windows.Forms.ListView LicenseBox;
        private System.Windows.Forms.ImageList licenseIcons;
        private System.Windows.Forms.Button donateBtn;
        private System.Windows.Forms.Label LicenseLab;
        private System.Windows.Forms.Label ExpiresLbl;
        private System.Windows.Forms.RichTextBox EulaRtf;
    }
}