namespace QueryIT {
    partial class ConvertForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConvertForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label12 = new System.Windows.Forms.Label();
            this.Preset = new System.Windows.Forms.ComboBox();
            this.strip = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ConvertBtn = new System.Windows.Forms.Button();
            this.seperator = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.openBtn = new System.Windows.Forms.Button();
            this.filename = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tryBtn = new System.Windows.Forms.Button();
            this.delimiter = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.multiline = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ending = new System.Windows.Forms.ComboBox();
            this.end = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.TextBox();
            this.subfix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.prefix = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.fileBox = new System.Windows.Forms.RichTextBox();
            this.convertGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.convertGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.Preset);
            this.splitContainer1.Panel1.Controls.Add(this.strip);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.ConvertBtn);
            this.splitContainer1.Panel1.Controls.Add(this.seperator);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.openBtn);
            this.splitContainer1.Panel1.Controls.Add(this.filename);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.tryBtn);
            this.splitContainer1.Panel1.Controls.Add(this.delimiter);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.header);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.multiline);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.ending);
            this.splitContainer1.Panel1.Controls.Add(this.end);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.start);
            this.splitContainer1.Panel1.Controls.Add(this.subfix);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.prefix);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(584, 361);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Preset";
            // 
            // Preset
            // 
            this.Preset.FormattingEnabled = true;
            this.Preset.Items.AddRange(new object[] {
            "VAR_DUMP",
            "XML",
            "JSON"});
            this.Preset.Location = new System.Drawing.Point(70, 7);
            this.Preset.Name = "Preset";
            this.Preset.Size = new System.Drawing.Size(120, 21);
            this.Preset.TabIndex = 27;
            this.Preset.Text = "VAR_DUMP";
            this.Preset.SelectedIndexChanged += new System.EventHandler(this.Preset_SelectedIndexChanged);
            // 
            // strip
            // 
            this.strip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.strip.Location = new System.Drawing.Point(70, 271);
            this.strip.Name = "strip";
            this.strip.Size = new System.Drawing.Size(120, 20);
            this.strip.TabIndex = 26;
            this.strip.Text = "\'";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 274);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Strip Char";
            // 
            // ConvertBtn
            // 
            this.ConvertBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ConvertBtn.Location = new System.Drawing.Point(71, 326);
            this.ConvertBtn.Name = "ConvertBtn";
            this.ConvertBtn.Size = new System.Drawing.Size(119, 23);
            this.ConvertBtn.TabIndex = 24;
            this.ConvertBtn.Text = "Convert";
            this.ConvertBtn.UseVisualStyleBackColor = true;
            this.ConvertBtn.Click += new System.EventHandler(this.ConvertBtn_Click);
            // 
            // seperator
            // 
            this.seperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.seperator.Location = new System.Drawing.Point(70, 249);
            this.seperator.Name = "seperator";
            this.seperator.Size = new System.Drawing.Size(120, 20);
            this.seperator.TabIndex = 23;
            this.seperator.Text = ",";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 252);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Seperator";
            // 
            // openBtn
            // 
            this.openBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openBtn.Image = ((System.Drawing.Image)(resources.GetObject("openBtn.Image")));
            this.openBtn.Location = new System.Drawing.Point(163, 29);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(27, 20);
            this.openBtn.TabIndex = 21;
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // filename
            // 
            this.filename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filename.Location = new System.Drawing.Point(70, 30);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(87, 20);
            this.filename.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "File";
            // 
            // tryBtn
            // 
            this.tryBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tryBtn.Location = new System.Drawing.Point(70, 297);
            this.tryBtn.Name = "tryBtn";
            this.tryBtn.Size = new System.Drawing.Size(120, 23);
            this.tryBtn.TabIndex = 18;
            this.tryBtn.Text = "Preview";
            this.tryBtn.UseVisualStyleBackColor = true;
            this.tryBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // delimiter
            // 
            this.delimiter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.delimiter.Location = new System.Drawing.Point(71, 175);
            this.delimiter.Name = "delimiter";
            this.delimiter.Size = new System.Drawing.Size(120, 20);
            this.delimiter.TabIndex = 17;
            this.delimiter.Text = ":";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "HVDelimiter";
            // 
            // header
            // 
            this.header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.header.AutoCompleteCustomSource.AddRange(new string[] {
            "yes",
            "no"});
            this.header.FormattingEnabled = true;
            this.header.Location = new System.Drawing.Point(71, 152);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(120, 21);
            this.header.TabIndex = 15;
            this.header.Text = "yes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "ColumnH";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "MultiLine";
            // 
            // multiline
            // 
            this.multiline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.multiline.FormattingEnabled = true;
            this.multiline.Items.AddRange(new object[] {
            "yes",
            "no"});
            this.multiline.Location = new System.Drawing.Point(70, 201);
            this.multiline.Name = "multiline";
            this.multiline.Size = new System.Drawing.Size(120, 21);
            this.multiline.TabIndex = 12;
            this.multiline.Text = "yes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "LineEnding";
            // 
            // ending
            // 
            this.ending.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ending.FormattingEnabled = true;
            this.ending.Items.AddRange(new object[] {
            "\\r",
            "\\n",
            "\\r\\n"});
            this.ending.Location = new System.Drawing.Point(70, 225);
            this.ending.Name = "ending";
            this.ending.Size = new System.Drawing.Size(120, 21);
            this.ending.TabIndex = 10;
            this.ending.Text = "\\r\\n";
            // 
            // end
            // 
            this.end.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.end.Location = new System.Drawing.Point(70, 126);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(120, 20);
            this.end.TabIndex = 9;
            this.end.Text = "}";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Row End";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Row Start";
            // 
            // start
            // 
            this.start.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.start.Location = new System.Drawing.Point(70, 104);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(120, 20);
            this.start.TabIndex = 6;
            this.start.Text = "{";
            this.start.TextChanged += new System.EventHandler(this.start_TextChanged);
            // 
            // subfix
            // 
            this.subfix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.subfix.Location = new System.Drawing.Point(70, 78);
            this.subfix.Name = "subfix";
            this.subfix.Size = new System.Drawing.Size(120, 20);
            this.subfix.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Strip Subfix";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Strip Prefix";
            // 
            // prefix
            // 
            this.prefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.prefix.Location = new System.Drawing.Point(70, 56);
            this.prefix.Name = "prefix";
            this.prefix.Size = new System.Drawing.Size(120, 20);
            this.prefix.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.fileBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.convertGrid);
            this.splitContainer2.Size = new System.Drawing.Size(387, 361);
            this.splitContainer2.SplitterDistance = 165;
            this.splitContainer2.TabIndex = 0;
            // 
            // fileBox
            // 
            this.fileBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileBox.Location = new System.Drawing.Point(0, 0);
            this.fileBox.Name = "fileBox";
            this.fileBox.Size = new System.Drawing.Size(387, 165);
            this.fileBox.TabIndex = 0;
            this.fileBox.Text = "";
            // 
            // convertGrid
            // 
            this.convertGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.convertGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.convertGrid.Location = new System.Drawing.Point(0, 0);
            this.convertGrid.Name = "convertGrid";
            this.convertGrid.Size = new System.Drawing.Size(387, 192);
            this.convertGrid.TabIndex = 0;
            // 
            // ConvertForm
            // 
            this.AcceptButton = this.ConvertBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ConvertForm";
            this.Text = "Convert [BETA]";
            this.Load += new System.EventHandler(this.ConvertForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.convertGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ending;
        private System.Windows.Forms.TextBox end;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox start;
        private System.Windows.Forms.TextBox subfix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox prefix;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox fileBox;
        private System.Windows.Forms.DataGridView convertGrid;
        private System.Windows.Forms.TextBox delimiter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox header;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox multiline;
        private System.Windows.Forms.Button tryBtn;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.TextBox filename;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox seperator;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button ConvertBtn;
        private System.Windows.Forms.TextBox strip;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox Preset;
        private System.Windows.Forms.Label label12;
    }
}