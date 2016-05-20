namespace QueryIT
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainIcons = new System.Windows.Forms.ImageList(this.components);
            this.MainStatus = new System.Windows.Forms.StatusStrip();
            this.leftStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.rightStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.memLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.cpuLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.queryerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectLeftMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.modulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveColumnMappingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.crossJoinToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.forEachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectRightMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bugReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statsTimer = new System.Windows.Forms.Timer(this.components);
            this.MainStatus.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainIcons
            // 
            this.MainIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MainIcons.ImageStream")));
            this.MainIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.MainIcons.Images.SetKeyName(0, "Database-Connecting.png");
            this.MainIcons.Images.SetKeyName(1, "Database-Connected.png");
            this.MainIcons.Images.SetKeyName(2, "Database-Disconnected.png");
            this.MainIcons.Images.SetKeyName(3, "open.png");
            this.MainIcons.Images.SetKeyName(4, "save.png");
            this.MainIcons.Images.SetKeyName(5, "checkbook.png");
            this.MainIcons.Images.SetKeyName(6, "list.png");
            this.MainIcons.Images.SetKeyName(7, "note.png");
            this.MainIcons.Images.SetKeyName(8, "notepad.png");
            this.MainIcons.Images.SetKeyName(9, "text.png");
            // 
            // MainStatus
            // 
            this.MainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftStatus,
            this.rightStatus,
            this.memLbl,
            this.cpuLbl});
            this.MainStatus.Location = new System.Drawing.Point(0, 439);
            this.MainStatus.Name = "MainStatus";
            this.MainStatus.Size = new System.Drawing.Size(784, 22);
            this.MainStatus.TabIndex = 4;
            this.MainStatus.Text = "statusStrip1";
            // 
            // leftStatus
            // 
            this.leftStatus.Image = ((System.Drawing.Image)(resources.GetObject("leftStatus.Image")));
            this.leftStatus.Name = "leftStatus";
            this.leftStatus.Size = new System.Drawing.Size(59, 17);
            this.leftStatus.Text = "Source";
            // 
            // rightStatus
            // 
            this.rightStatus.Image = ((System.Drawing.Image)(resources.GetObject("rightStatus.Image")));
            this.rightStatus.Name = "rightStatus";
            this.rightStatus.Size = new System.Drawing.Size(83, 17);
            this.rightStatus.Text = "Destination";
            // 
            // memLbl
            // 
            this.memLbl.Image = ((System.Drawing.Image)(resources.GetObject("memLbl.Image")));
            this.memLbl.Name = "memLbl";
            this.memLbl.Size = new System.Drawing.Size(98, 17);
            this.memLbl.Text = "Memory: 0MB";
            // 
            // cpuLbl
            // 
            this.cpuLbl.Image = ((System.Drawing.Image)(resources.GetObject("cpuLbl.Image")));
            this.cpuLbl.Name = "cpuLbl";
            this.cpuLbl.Size = new System.Drawing.Size(68, 17);
            this.cpuLbl.Text = "CPU: 0%";
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.queryerToolStripMenuItem,
            this.connectLeftMenu,
            this.modulesToolStripMenuItem,
            this.connectRightMenu,
            this.connectionsToolStripMenuItem,
            this.pluginsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(784, 24);
            this.MainMenu.TabIndex = 5;
            this.MainMenu.Text = "MainMenu";
            // 
            // queryerToolStripMenuItem
            // 
            this.queryerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("queryerToolStripMenuItem.Image")));
            this.queryerToolStripMenuItem.Name = "queryerToolStripMenuItem";
            this.queryerToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.queryerToolStripMenuItem.Text = "Queryer";
            this.queryerToolStripMenuItem.Click += new System.EventHandler(this.queryerToolStripMenuItem_Click);
            // 
            // connectLeftMenu
            // 
            this.connectLeftMenu.Image = ((System.Drawing.Image)(resources.GetObject("connectLeftMenu.Image")));
            this.connectLeftMenu.Name = "connectLeftMenu";
            this.connectLeftMenu.Size = new System.Drawing.Size(116, 20);
            this.connectLeftMenu.Text = "Source Queryer";
            this.connectLeftMenu.Click += new System.EventHandler(this.connectLeftMenu_Click);
            // 
            // modulesToolStripMenuItem
            // 
            this.modulesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveColumnMappingToolStripMenuItem,
            this.compareToolStripMenuItem1,
            this.crossJoinToolStripMenuItem1,
            this.forEachToolStripMenuItem});
            this.modulesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modulesToolStripMenuItem.Image")));
            this.modulesToolStripMenuItem.Name = "modulesToolStripMenuItem";
            this.modulesToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.modulesToolStripMenuItem.Text = "Modules";
            // 
            // moveColumnMappingToolStripMenuItem
            // 
            this.moveColumnMappingToolStripMenuItem.Enabled = false;
            this.moveColumnMappingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("moveColumnMappingToolStripMenuItem.Image")));
            this.moveColumnMappingToolStripMenuItem.Name = "moveColumnMappingToolStripMenuItem";
            this.moveColumnMappingToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.moveColumnMappingToolStripMenuItem.Text = "Move (Column Mapping)";
            this.moveColumnMappingToolStripMenuItem.ToolTipText = "Move Records from Source to Destination";
            this.moveColumnMappingToolStripMenuItem.Click += new System.EventHandler(this.moveColumnMappingToolStripMenuItem_Click);
            // 
            // compareToolStripMenuItem1
            // 
            this.compareToolStripMenuItem1.Enabled = false;
            this.compareToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("compareToolStripMenuItem1.Image")));
            this.compareToolStripMenuItem1.Name = "compareToolStripMenuItem1";
            this.compareToolStripMenuItem1.Size = new System.Drawing.Size(209, 22);
            this.compareToolStripMenuItem1.Text = "Compare";
            this.compareToolStripMenuItem1.ToolTipText = "Compare Source with Destination";
            this.compareToolStripMenuItem1.Click += new System.EventHandler(this.compareToolStripMenuItem1_Click);
            // 
            // crossJoinToolStripMenuItem1
            // 
            this.crossJoinToolStripMenuItem1.Enabled = false;
            this.crossJoinToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("crossJoinToolStripMenuItem1.Image")));
            this.crossJoinToolStripMenuItem1.Name = "crossJoinToolStripMenuItem1";
            this.crossJoinToolStripMenuItem1.Size = new System.Drawing.Size(209, 22);
            this.crossJoinToolStripMenuItem1.Text = "CrossJoin";
            this.crossJoinToolStripMenuItem1.ToolTipText = "CrossJoin Source with Destination";
            this.crossJoinToolStripMenuItem1.Click += new System.EventHandler(this.crossJoinToolStripMenuItem1_Click);
            // 
            // forEachToolStripMenuItem
            // 
            this.forEachToolStripMenuItem.Enabled = false;
            this.forEachToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("forEachToolStripMenuItem.Image")));
            this.forEachToolStripMenuItem.Name = "forEachToolStripMenuItem";
            this.forEachToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.forEachToolStripMenuItem.Text = "ForEach";
            this.forEachToolStripMenuItem.ToolTipText = "ForEach Record in Source Execute an SQL Statement in Destination";
            this.forEachToolStripMenuItem.Click += new System.EventHandler(this.forEachToolStripMenuItem_Click);
            // 
            // connectRightMenu
            // 
            this.connectRightMenu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.connectRightMenu.Image = ((System.Drawing.Image)(resources.GetObject("connectRightMenu.Image")));
            this.connectRightMenu.Name = "connectRightMenu";
            this.connectRightMenu.Size = new System.Drawing.Size(140, 20);
            this.connectRightMenu.Text = "Destination Queryer";
            this.connectRightMenu.Click += new System.EventHandler(this.connectRightMenu_Click);
            // 
            // connectionsToolStripMenuItem
            // 
            this.connectionsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("connectionsToolStripMenuItem.Image")));
            this.connectionsToolStripMenuItem.Name = "connectionsToolStripMenuItem";
            this.connectionsToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.connectionsToolStripMenuItem.Text = "Connections";
            this.connectionsToolStripMenuItem.ToolTipText = "Manage Connections";
            this.connectionsToolStripMenuItem.Click += new System.EventHandler(this.connectionsToolStripMenuItem_Click);
            // 
            // pluginsToolStripMenuItem
            // 
            this.pluginsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pluginsToolStripMenuItem.Image")));
            this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.pluginsToolStripMenuItem.Text = "Plugins";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.licenseToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.bugReportToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // licenseToolStripMenuItem
            // 
            this.licenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("licenseToolStripMenuItem.Image")));
            this.licenseToolStripMenuItem.Name = "licenseToolStripMenuItem";
            this.licenseToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.licenseToolStripMenuItem.Text = "License";
            this.licenseToolStripMenuItem.Click += new System.EventHandler(this.licenseToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Enabled = false;
            this.updateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updateToolStripMenuItem.Image")));
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Visible = false;
            // 
            // bugReportToolStripMenuItem
            // 
            this.bugReportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bugReportToolStripMenuItem.Image")));
            this.bugReportToolStripMenuItem.Name = "bugReportToolStripMenuItem";
            this.bugReportToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.bugReportToolStripMenuItem.Text = "Bug Report";
            this.bugReportToolStripMenuItem.Click += new System.EventHandler(this.bugReportToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Enabled = false;
            this.helpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripMenuItem.Image")));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Visible = false;
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem1.Image")));
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // statsTimer
            // 
            this.statsTimer.Enabled = true;
            this.statsTimer.Interval = 250;
            this.statsTimer.Tick += new System.EventHandler(this.statsTimer_Tick);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.MainStatus);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "QueryIT";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.MainStatus.ResumeLayout(false);
            this.MainStatus.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList MainIcons;
        private System.Windows.Forms.StatusStrip MainStatus;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem connectLeftMenu;
        private System.Windows.Forms.ToolStripMenuItem connectRightMenu;
        private System.Windows.Forms.ToolStripMenuItem queryerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Timer statsTimer;
        private System.Windows.Forms.ToolStripStatusLabel memLbl;
        private System.Windows.Forms.ToolStripStatusLabel cpuLbl;
        private System.Windows.Forms.ToolStripStatusLabel leftStatus;
        private System.Windows.Forms.ToolStripStatusLabel rightStatus;
        private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bugReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveColumnMappingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem crossJoinToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem forEachToolStripMenuItem;
    }
}

