﻿namespace QueryIT {
    partial class ChunkForm {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChunkForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.runinChunksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chunkSplitH = new System.Windows.Forms.SplitContainer();
            this.chunkSplitVL = new System.Windows.Forms.SplitContainer();
            this.selectSQL = new System.Windows.Forms.RichTextBox();
            this.chunkResultGrid = new System.Windows.Forms.DataGridView();
            this.chunkSplitVR = new System.Windows.Forms.SplitContainer();
            this.insertupdateSQL = new System.Windows.Forms.RichTextBox();
            this.chunkGroup = new System.Windows.Forms.GroupBox();
            this.chunk = new System.Windows.Forms.TextBox();
            this.offset = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.QueryIcons = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chunkSplitH)).BeginInit();
            this.chunkSplitH.Panel1.SuspendLayout();
            this.chunkSplitH.Panel2.SuspendLayout();
            this.chunkSplitH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chunkSplitVL)).BeginInit();
            this.chunkSplitVL.Panel1.SuspendLayout();
            this.chunkSplitVL.Panel2.SuspendLayout();
            this.chunkSplitVL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chunkResultGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chunkSplitVR)).BeginInit();
            this.chunkSplitVR.Panel1.SuspendLayout();
            this.chunkSplitVR.SuspendLayout();
            this.chunkGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runinChunksToolStripMenuItem,
            this.runToolStripMenuItem,
            this.killToolStripMenuItem,
            this.pluginsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // runinChunksToolStripMenuItem
            // 
            this.runinChunksToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("runinChunksToolStripMenuItem.Image")));
            this.runinChunksToolStripMenuItem.Name = "runinChunksToolStripMenuItem";
            this.runinChunksToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.runinChunksToolStripMenuItem.Text = "Chunk";
            this.runinChunksToolStripMenuItem.Click += new System.EventHandler(this.runinChunksToolStripMenuItem_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("runToolStripMenuItem.Image")));
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // killToolStripMenuItem
            // 
            this.killToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("killToolStripMenuItem.Image")));
            this.killToolStripMenuItem.Name = "killToolStripMenuItem";
            this.killToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.killToolStripMenuItem.Text = "Kill";
            this.killToolStripMenuItem.Click += new System.EventHandler(this.killToolStripMenuItem_Click_1);
            // 
            // pluginsToolStripMenuItem
            // 
            this.pluginsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pluginsToolStripMenuItem.Image")));
            this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.pluginsToolStripMenuItem.Text = "Plugins";
            // 
            // chunkSplitH
            // 
            this.chunkSplitH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chunkSplitH.Location = new System.Drawing.Point(0, 83);
            this.chunkSplitH.Name = "chunkSplitH";
            // 
            // chunkSplitH.Panel1
            // 
            this.chunkSplitH.Panel1.Controls.Add(this.chunkSplitVL);
            // 
            // chunkSplitH.Panel2
            // 
            this.chunkSplitH.Panel2.Controls.Add(this.chunkSplitVR);
            this.chunkSplitH.Size = new System.Drawing.Size(584, 277);
            this.chunkSplitH.SplitterDistance = 290;
            this.chunkSplitH.TabIndex = 1;
            // 
            // chunkSplitVL
            // 
            this.chunkSplitVL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chunkSplitVL.Location = new System.Drawing.Point(0, 0);
            this.chunkSplitVL.Name = "chunkSplitVL";
            this.chunkSplitVL.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // chunkSplitVL.Panel1
            // 
            this.chunkSplitVL.Panel1.Controls.Add(this.selectSQL);
            // 
            // chunkSplitVL.Panel2
            // 
            this.chunkSplitVL.Panel2.Controls.Add(this.chunkResultGrid);
            this.chunkSplitVL.Size = new System.Drawing.Size(290, 277);
            this.chunkSplitVL.SplitterDistance = 78;
            this.chunkSplitVL.TabIndex = 0;
            // 
            // selectSQL
            // 
            this.selectSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectSQL.Location = new System.Drawing.Point(0, 0);
            this.selectSQL.Name = "selectSQL";
            this.selectSQL.Size = new System.Drawing.Size(290, 78);
            this.selectSQL.TabIndex = 0;
            this.selectSQL.Text = "";
            this.selectSQL.SelectionChanged += new System.EventHandler(this.selectSQL_SelectionChanged);
            // 
            // chunkResultGrid
            // 
            this.chunkResultGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.chunkResultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chunkResultGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chunkResultGrid.Location = new System.Drawing.Point(0, 0);
            this.chunkResultGrid.Name = "chunkResultGrid";
            this.chunkResultGrid.Size = new System.Drawing.Size(290, 195);
            this.chunkResultGrid.TabIndex = 0;
            // 
            // chunkSplitVR
            // 
            this.chunkSplitVR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chunkSplitVR.Location = new System.Drawing.Point(0, 0);
            this.chunkSplitVR.Name = "chunkSplitVR";
            this.chunkSplitVR.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // chunkSplitVR.Panel1
            // 
            this.chunkSplitVR.Panel1.Controls.Add(this.insertupdateSQL);
            this.chunkSplitVR.Size = new System.Drawing.Size(290, 277);
            this.chunkSplitVR.SplitterDistance = 78;
            this.chunkSplitVR.TabIndex = 0;
            // 
            // insertupdateSQL
            // 
            this.insertupdateSQL.Dock = System.Windows.Forms.DockStyle.Top;
            this.insertupdateSQL.Location = new System.Drawing.Point(0, 0);
            this.insertupdateSQL.Name = "insertupdateSQL";
            this.insertupdateSQL.Size = new System.Drawing.Size(290, 78);
            this.insertupdateSQL.TabIndex = 0;
            this.insertupdateSQL.Text = "";
            this.insertupdateSQL.SelectionChanged += new System.EventHandler(this.insertupdateSQL_SelectionChanged);
            // 
            // chunkGroup
            // 
            this.chunkGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chunkGroup.Controls.Add(this.chunk);
            this.chunkGroup.Controls.Add(this.offset);
            this.chunkGroup.Controls.Add(this.label2);
            this.chunkGroup.Controls.Add(this.label1);
            this.chunkGroup.Location = new System.Drawing.Point(0, 27);
            this.chunkGroup.Name = "chunkGroup";
            this.chunkGroup.Size = new System.Drawing.Size(584, 50);
            this.chunkGroup.TabIndex = 2;
            this.chunkGroup.TabStop = false;
            this.chunkGroup.Text = "Chunk Settings";
            // 
            // chunk
            // 
            this.chunk.Location = new System.Drawing.Point(251, 22);
            this.chunk.Name = "chunk";
            this.chunk.Size = new System.Drawing.Size(100, 20);
            this.chunk.TabIndex = 6;
            this.chunk.Text = "100";
            // 
            // offset
            // 
            this.offset.Location = new System.Drawing.Point(82, 22);
            this.offset.Name = "offset";
            this.offset.Size = new System.Drawing.Size(99, 20);
            this.offset.TabIndex = 3;
            this.offset.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Start Position";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ChunkSize";
            // 
            // QueryIcons
            // 
            this.QueryIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("QueryIcons.ImageStream")));
            this.QueryIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.QueryIcons.Images.SetKeyName(0, "Database-Connecting.png");
            this.QueryIcons.Images.SetKeyName(1, "Database-Connected.png");
            this.QueryIcons.Images.SetKeyName(2, "Database-Disconnected.png");
            this.QueryIcons.Images.SetKeyName(3, "1-csv.png");
            this.QueryIcons.Images.SetKeyName(4, "1-DB.png");
            this.QueryIcons.Images.SetKeyName(5, "2-Table.png");
            this.QueryIcons.Images.SetKeyName(6, "3-Column.png");
            this.QueryIcons.Images.SetKeyName(7, "chart_bar.png");
            this.QueryIcons.Images.SetKeyName(8, "clock.png");
            this.QueryIcons.Images.SetKeyName(9, "application_lightning.png");
            this.QueryIcons.Images.SetKeyName(10, "key.png");
            this.QueryIcons.Images.SetKeyName(11, "list.png");
            this.QueryIcons.Images.SetKeyName(12, "text.png");
            this.QueryIcons.Images.SetKeyName(13, "notepad.png");
            this.QueryIcons.Images.SetKeyName(14, "checkbook.png");
            // 
            // ChunkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.chunkGroup);
            this.Controls.Add(this.chunkSplitH);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ChunkForm";
            this.Text = "Chunk [ALPHA]";
            this.Load += new System.EventHandler(this.ChunkForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.chunkSplitH.Panel1.ResumeLayout(false);
            this.chunkSplitH.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chunkSplitH)).EndInit();
            this.chunkSplitH.ResumeLayout(false);
            this.chunkSplitVL.Panel1.ResumeLayout(false);
            this.chunkSplitVL.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chunkSplitVL)).EndInit();
            this.chunkSplitVL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chunkResultGrid)).EndInit();
            this.chunkSplitVR.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chunkSplitVR)).EndInit();
            this.chunkSplitVR.ResumeLayout(false);
            this.chunkGroup.ResumeLayout(false);
            this.chunkGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem runinChunksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem killToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer chunkSplitH;
        private System.Windows.Forms.SplitContainer chunkSplitVL;
        private System.Windows.Forms.SplitContainer chunkSplitVR;
        private System.Windows.Forms.RichTextBox selectSQL;
        private System.Windows.Forms.RichTextBox insertupdateSQL;
        private System.Windows.Forms.GroupBox chunkGroup;
        private AutocompleteMenuNS.AutocompleteMenu autocomplete;
        private System.Windows.Forms.ImageList QueryIcons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox offset;
        private System.Windows.Forms.TextBox chunk;
        private System.Windows.Forms.DataGridView chunkResultGrid;
    }
}