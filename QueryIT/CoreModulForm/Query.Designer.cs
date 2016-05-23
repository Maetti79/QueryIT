namespace QueryIT
{
    partial class QueryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryForm));
            this.QueryTabs = new System.Windows.Forms.TabControl();
            this.queryTab = new System.Windows.Forms.TabPage();
            this.querySplitV = new System.Windows.Forms.SplitContainer();
            this.DatabaseTree = new System.Windows.Forms.TreeView();
            this.schemaContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.alterTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QueryIcons = new System.Windows.Forms.ImageList(this.components);
            this.querySplitH = new System.Windows.Forms.SplitContainer();
            this.queryBox = new System.Windows.Forms.RichTextBox();
            this.resultGrid = new System.Windows.Forms.DataGridView();
            this.resultContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.filterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.autoCaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.concatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.uniqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doubleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resultTab = new System.Windows.Forms.TabPage();
            this.resultBox = new System.Windows.Forms.RichTextBox();
            this.historyTab = new System.Windows.Forms.TabPage();
            this.historyBox = new System.Windows.Forms.RichTextBox();
            this.queryMenu = new System.Windows.Forms.MenuStrip();
            this.queryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newclearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadsqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savesqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportcsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSQLToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.queryRunMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.concatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uniqToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doubleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsDestinationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newQueryerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QueryerTimer = new System.Windows.Forms.Timer(this.components);
            this.autocomplete = new AutocompleteMenuNS.AutocompleteMenu();
            this.hashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hashToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.QueryTabs.SuspendLayout();
            this.queryTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.querySplitV)).BeginInit();
            this.querySplitV.Panel1.SuspendLayout();
            this.querySplitV.Panel2.SuspendLayout();
            this.querySplitV.SuspendLayout();
            this.schemaContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.querySplitH)).BeginInit();
            this.querySplitH.Panel1.SuspendLayout();
            this.querySplitH.Panel2.SuspendLayout();
            this.querySplitH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            this.resultContextMenu.SuspendLayout();
            this.resultTab.SuspendLayout();
            this.historyTab.SuspendLayout();
            this.queryMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // QueryTabs
            // 
            this.QueryTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.QueryTabs.Controls.Add(this.queryTab);
            this.QueryTabs.Controls.Add(this.resultTab);
            this.QueryTabs.Controls.Add(this.historyTab);
            this.QueryTabs.ImageList = this.QueryIcons;
            this.QueryTabs.Location = new System.Drawing.Point(0, 27);
            this.QueryTabs.Name = "QueryTabs";
            this.QueryTabs.SelectedIndex = 0;
            this.QueryTabs.Size = new System.Drawing.Size(584, 334);
            this.QueryTabs.TabIndex = 0;
            // 
            // queryTab
            // 
            this.queryTab.Controls.Add(this.querySplitV);
            this.queryTab.ImageIndex = 4;
            this.queryTab.Location = new System.Drawing.Point(4, 23);
            this.queryTab.Name = "queryTab";
            this.queryTab.Padding = new System.Windows.Forms.Padding(3);
            this.queryTab.Size = new System.Drawing.Size(576, 307);
            this.queryTab.TabIndex = 0;
            this.queryTab.Text = "Query";
            this.queryTab.UseVisualStyleBackColor = true;
            // 
            // querySplitV
            // 
            this.querySplitV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.querySplitV.Location = new System.Drawing.Point(3, 3);
            this.querySplitV.Name = "querySplitV";
            // 
            // querySplitV.Panel1
            // 
            this.querySplitV.Panel1.Controls.Add(this.DatabaseTree);
            // 
            // querySplitV.Panel2
            // 
            this.querySplitV.Panel2.Controls.Add(this.querySplitH);
            this.querySplitV.Size = new System.Drawing.Size(570, 301);
            this.querySplitV.SplitterDistance = 189;
            this.querySplitV.TabIndex = 1;
            // 
            // DatabaseTree
            // 
            this.DatabaseTree.ContextMenuStrip = this.schemaContextMenu;
            this.DatabaseTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatabaseTree.ImageIndex = 9;
            this.DatabaseTree.ImageList = this.QueryIcons;
            this.DatabaseTree.Location = new System.Drawing.Point(0, 0);
            this.DatabaseTree.Name = "DatabaseTree";
            this.DatabaseTree.SelectedImageIndex = 0;
            this.DatabaseTree.Size = new System.Drawing.Size(189, 301);
            this.DatabaseTree.TabIndex = 0;
            this.DatabaseTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DatabaseTree_AfterSelect);
            this.DatabaseTree.DoubleClick += new System.EventHandler(this.DatabaseTree_DoubleClick);
            // 
            // schemaContextMenu
            // 
            this.schemaContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alterTableToolStripMenuItem});
            this.schemaContextMenu.Name = "schemaContextMenu";
            this.schemaContextMenu.Size = new System.Drawing.Size(132, 26);
            // 
            // alterTableToolStripMenuItem
            // 
            this.alterTableToolStripMenuItem.Enabled = false;
            this.alterTableToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("alterTableToolStripMenuItem.Image")));
            this.alterTableToolStripMenuItem.Name = "alterTableToolStripMenuItem";
            this.alterTableToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.alterTableToolStripMenuItem.Text = "Alter Table";
            this.alterTableToolStripMenuItem.Click += new System.EventHandler(this.alterTableToolStripMenuItem_Click);
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
            // 
            // querySplitH
            // 
            this.querySplitH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.querySplitH.Location = new System.Drawing.Point(0, 0);
            this.querySplitH.Name = "querySplitH";
            this.querySplitH.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // querySplitH.Panel1
            // 
            this.querySplitH.Panel1.Controls.Add(this.queryBox);
            // 
            // querySplitH.Panel2
            // 
            this.querySplitH.Panel2.Controls.Add(this.resultGrid);
            this.querySplitH.Size = new System.Drawing.Size(377, 301);
            this.querySplitH.SplitterDistance = 92;
            this.querySplitH.TabIndex = 0;
            // 
            // queryBox
            // 
            this.autocomplete.SetAutocompleteMenu(this.queryBox, this.autocomplete);
            this.queryBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queryBox.Location = new System.Drawing.Point(0, 0);
            this.queryBox.Name = "queryBox";
            this.queryBox.Size = new System.Drawing.Size(377, 92);
            this.queryBox.TabIndex = 0;
            this.queryBox.Text = "";
            this.queryBox.TextChanged += new System.EventHandler(this.queryBox_TextChanged);
            // 
            // resultGrid
            // 
            this.resultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGrid.ContextMenuStrip = this.resultContextMenu;
            this.resultGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultGrid.Location = new System.Drawing.Point(0, 0);
            this.resultGrid.Name = "resultGrid";
            this.resultGrid.Size = new System.Drawing.Size(377, 205);
            this.resultGrid.TabIndex = 0;
            this.resultGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultGrid_CellClick);
            // 
            // resultContextMenu
            // 
            this.resultContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterToolStripMenuItem1,
            this.searchToolStripMenuItem1,
            this.replaceToolStripMenuItem1,
            this.autoCaseToolStripMenuItem1,
            this.concatToolStripMenuItem1,
            this.uniqueToolStripMenuItem,
            this.doubleToolStripMenuItem1,
            this.hashToolStripMenuItem1});
            this.resultContextMenu.Name = "resultContextMenu";
            this.resultContextMenu.Size = new System.Drawing.Size(153, 202);
            // 
            // filterToolStripMenuItem1
            // 
            this.filterToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("filterToolStripMenuItem1.Image")));
            this.filterToolStripMenuItem1.Name = "filterToolStripMenuItem1";
            this.filterToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.filterToolStripMenuItem1.Text = "Filter";
            this.filterToolStripMenuItem1.Click += new System.EventHandler(this.filterToolStripMenuItem1_Click);
            // 
            // searchToolStripMenuItem1
            // 
            this.searchToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripMenuItem1.Image")));
            this.searchToolStripMenuItem1.Name = "searchToolStripMenuItem1";
            this.searchToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.searchToolStripMenuItem1.Text = "Search";
            this.searchToolStripMenuItem1.Click += new System.EventHandler(this.searchToolStripMenuItem1_Click);
            // 
            // replaceToolStripMenuItem1
            // 
            this.replaceToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("replaceToolStripMenuItem1.Image")));
            this.replaceToolStripMenuItem1.Name = "replaceToolStripMenuItem1";
            this.replaceToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.replaceToolStripMenuItem1.Text = "Replace";
            this.replaceToolStripMenuItem1.Click += new System.EventHandler(this.replaceToolStripMenuItem1_Click);
            // 
            // autoCaseToolStripMenuItem1
            // 
            this.autoCaseToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("autoCaseToolStripMenuItem1.Image")));
            this.autoCaseToolStripMenuItem1.Name = "autoCaseToolStripMenuItem1";
            this.autoCaseToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.autoCaseToolStripMenuItem1.Text = "AutoCase";
            this.autoCaseToolStripMenuItem1.Click += new System.EventHandler(this.autoCaseToolStripMenuItem1_Click);
            // 
            // concatToolStripMenuItem1
            // 
            this.concatToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("concatToolStripMenuItem1.Image")));
            this.concatToolStripMenuItem1.Name = "concatToolStripMenuItem1";
            this.concatToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.concatToolStripMenuItem1.Text = "Concat";
            this.concatToolStripMenuItem1.Click += new System.EventHandler(this.concatToolStripMenuItem1_Click);
            // 
            // uniqueToolStripMenuItem
            // 
            this.uniqueToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uniqueToolStripMenuItem.Image")));
            this.uniqueToolStripMenuItem.Name = "uniqueToolStripMenuItem";
            this.uniqueToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.uniqueToolStripMenuItem.Text = "Unique";
            this.uniqueToolStripMenuItem.Click += new System.EventHandler(this.uniqueToolStripMenuItem_Click);
            // 
            // doubleToolStripMenuItem1
            // 
            this.doubleToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("doubleToolStripMenuItem1.Image")));
            this.doubleToolStripMenuItem1.Name = "doubleToolStripMenuItem1";
            this.doubleToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.doubleToolStripMenuItem1.Text = "Double";
            this.doubleToolStripMenuItem1.Click += new System.EventHandler(this.doubleToolStripMenuItem1_Click);
            // 
            // resultTab
            // 
            this.resultTab.Controls.Add(this.resultBox);
            this.resultTab.ImageIndex = 9;
            this.resultTab.Location = new System.Drawing.Point(4, 23);
            this.resultTab.Name = "resultTab";
            this.resultTab.Padding = new System.Windows.Forms.Padding(3);
            this.resultTab.Size = new System.Drawing.Size(576, 307);
            this.resultTab.TabIndex = 1;
            this.resultTab.Text = "Result";
            this.resultTab.UseVisualStyleBackColor = true;
            // 
            // resultBox
            // 
            this.autocomplete.SetAutocompleteMenu(this.resultBox, null);
            this.resultBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultBox.Location = new System.Drawing.Point(3, 3);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(570, 301);
            this.resultBox.TabIndex = 0;
            this.resultBox.Text = "";
            // 
            // historyTab
            // 
            this.historyTab.Controls.Add(this.historyBox);
            this.historyTab.ImageIndex = 8;
            this.historyTab.Location = new System.Drawing.Point(4, 23);
            this.historyTab.Name = "historyTab";
            this.historyTab.Size = new System.Drawing.Size(576, 307);
            this.historyTab.TabIndex = 2;
            this.historyTab.Text = "History";
            this.historyTab.UseVisualStyleBackColor = true;
            // 
            // historyBox
            // 
            this.historyBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.autocomplete.SetAutocompleteMenu(this.historyBox, null);
            this.historyBox.Location = new System.Drawing.Point(3, 3);
            this.historyBox.Name = "historyBox";
            this.historyBox.Size = new System.Drawing.Size(578, 414);
            this.historyBox.TabIndex = 0;
            this.historyBox.Text = "";
            // 
            // queryMenu
            // 
            this.queryMenu.AllowMerge = false;
            this.queryMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.queryToolStripMenuItem,
            this.resultToolStripMenuItem,
            this.queryRunMenu,
            this.killToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.connectionToolStripMenuItem,
            this.pluginsToolStripMenuItem});
            this.queryMenu.Location = new System.Drawing.Point(0, 0);
            this.queryMenu.Name = "queryMenu";
            this.queryMenu.Size = new System.Drawing.Size(584, 24);
            this.queryMenu.TabIndex = 1;
            this.queryMenu.Text = "menuStrip1";
            // 
            // queryToolStripMenuItem
            // 
            this.queryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newclearAllToolStripMenuItem,
            this.loadsqlToolStripMenuItem,
            this.savesqlToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.queryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("queryToolStripMenuItem.Image")));
            this.queryToolStripMenuItem.Name = "queryToolStripMenuItem";
            this.queryToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.queryToolStripMenuItem.Text = "Query";
            // 
            // newclearAllToolStripMenuItem
            // 
            this.newclearAllToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newclearAllToolStripMenuItem.Image")));
            this.newclearAllToolStripMenuItem.Name = "newclearAllToolStripMenuItem";
            this.newclearAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newclearAllToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.newclearAllToolStripMenuItem.Text = "New (clear)";
            this.newclearAllToolStripMenuItem.Click += new System.EventHandler(this.newclearAllToolStripMenuItem_Click);
            // 
            // loadsqlToolStripMenuItem
            // 
            this.loadsqlToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadsqlToolStripMenuItem.Image")));
            this.loadsqlToolStripMenuItem.Name = "loadsqlToolStripMenuItem";
            this.loadsqlToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadsqlToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.loadsqlToolStripMenuItem.Text = "Load (*.sql)";
            this.loadsqlToolStripMenuItem.Click += new System.EventHandler(this.loadsqlToolStripMenuItem_Click);
            // 
            // savesqlToolStripMenuItem
            // 
            this.savesqlToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("savesqlToolStripMenuItem.Image")));
            this.savesqlToolStripMenuItem.Name = "savesqlToolStripMenuItem";
            this.savesqlToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.savesqlToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.savesqlToolStripMenuItem.Text = "Save (*.sql)";
            this.savesqlToolStripMenuItem.Click += new System.EventHandler(this.savesqlToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.saveAsToolStripMenuItem.Text = "Save as (*.sql)";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // resultToolStripMenuItem
            // 
            this.resultToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportcsvToolStripMenuItem,
            this.saveSQLToolStripMenuItem1});
            this.resultToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("resultToolStripMenuItem.Image")));
            this.resultToolStripMenuItem.Name = "resultToolStripMenuItem";
            this.resultToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.resultToolStripMenuItem.Text = "Result";
            // 
            // exportcsvToolStripMenuItem
            // 
            this.exportcsvToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportcsvToolStripMenuItem.Image")));
            this.exportcsvToolStripMenuItem.Name = "exportcsvToolStripMenuItem";
            this.exportcsvToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportcsvToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.exportcsvToolStripMenuItem.Text = "Export (*.csv)";
            this.exportcsvToolStripMenuItem.Click += new System.EventHandler(this.exportcsvToolStripMenuItem_Click);
            // 
            // saveSQLToolStripMenuItem1
            // 
            this.saveSQLToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("saveSQLToolStripMenuItem1.Image")));
            this.saveSQLToolStripMenuItem1.Name = "saveSQLToolStripMenuItem1";
            this.saveSQLToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.saveSQLToolStripMenuItem1.Size = new System.Drawing.Size(191, 22);
            this.saveSQLToolStripMenuItem1.Text = "Save Changes";
            this.saveSQLToolStripMenuItem1.Click += new System.EventHandler(this.saveSQLToolStripMenuItem1_Click);
            // 
            // queryRunMenu
            // 
            this.queryRunMenu.Image = ((System.Drawing.Image)(resources.GetObject("queryRunMenu.Image")));
            this.queryRunMenu.Name = "queryRunMenu";
            this.queryRunMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.queryRunMenu.Size = new System.Drawing.Size(56, 20);
            this.queryRunMenu.Text = "Run";
            this.queryRunMenu.ToolTipText = "Run SQL Query";
            this.queryRunMenu.Click += new System.EventHandler(this.queryRunMenu_Click_1);
            // 
            // killToolStripMenuItem
            // 
            this.killToolStripMenuItem.Enabled = false;
            this.killToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("killToolStripMenuItem.Image")));
            this.killToolStripMenuItem.Name = "killToolStripMenuItem";
            this.killToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.killToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.killToolStripMenuItem.Text = "Kill";
            this.killToolStripMenuItem.ToolTipText = "Subtasks like Query, Search, Replace, Filter, Uniq";
            this.killToolStripMenuItem.Click += new System.EventHandler(this.killToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateTimeToolStripMenuItem,
            this.toolStripSeparator1,
            this.filterToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.replaceToolStripMenuItem,
            this.autoCaseToolStripMenuItem,
            this.concatToolStripMenuItem,
            this.uniqToolStripMenuItem,
            this.doubleToolStripMenuItem,
            this.hashToolStripMenuItem});
            this.toolsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("toolsToolStripMenuItem.Image")));
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.toolsToolStripMenuItem.ToolTipText = "Result Tools";
            // 
            // dateTimeToolStripMenuItem
            // 
            this.dateTimeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dateTimeToolStripMenuItem.Image")));
            this.dateTimeToolStripMenuItem.Name = "dateTimeToolStripMenuItem";
            this.dateTimeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.dateTimeToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.dateTimeToolStripMenuItem.Text = "DateTime";
            this.dateTimeToolStripMenuItem.ToolTipText = "DateTime Picker";
            this.dateTimeToolStripMenuItem.Click += new System.EventHandler(this.dateTimeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(249, 6);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("filterToolStripMenuItem.Image")));
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.F)));
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.filterToolStripMenuItem.Text = "Filter";
            this.filterToolStripMenuItem.ToolTipText = "Filter Result";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripMenuItem.Image")));
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.ToolTipText = "Search in Result";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("replaceToolStripMenuItem.Image")));
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.replaceToolStripMenuItem.Text = "Replace";
            this.replaceToolStripMenuItem.ToolTipText = "Replace in Result";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            // 
            // autoCaseToolStripMenuItem
            // 
            this.autoCaseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("autoCaseToolStripMenuItem.Image")));
            this.autoCaseToolStripMenuItem.Name = "autoCaseToolStripMenuItem";
            this.autoCaseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.A)));
            this.autoCaseToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.autoCaseToolStripMenuItem.Text = "AutoCase";
            this.autoCaseToolStripMenuItem.Click += new System.EventHandler(this.autoCaseToolStripMenuItem_Click);
            // 
            // concatToolStripMenuItem
            // 
            this.concatToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("concatToolStripMenuItem.Image")));
            this.concatToolStripMenuItem.Name = "concatToolStripMenuItem";
            this.concatToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.C)));
            this.concatToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.concatToolStripMenuItem.Text = "Concat";
            this.concatToolStripMenuItem.Click += new System.EventHandler(this.concatToolStripMenuItem_Click);
            // 
            // uniqToolStripMenuItem
            // 
            this.uniqToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uniqToolStripMenuItem.Image")));
            this.uniqToolStripMenuItem.Name = "uniqToolStripMenuItem";
            this.uniqToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.uniqToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.uniqToolStripMenuItem.Text = "Unique";
            this.uniqToolStripMenuItem.ToolTipText = "Delete duplicates in Result";
            this.uniqToolStripMenuItem.Click += new System.EventHandler(this.uniqToolStripMenuItem_Click);
            // 
            // doubleToolStripMenuItem
            // 
            this.doubleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("doubleToolStripMenuItem.Image")));
            this.doubleToolStripMenuItem.Name = "doubleToolStripMenuItem";
            this.doubleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.D)));
            this.doubleToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.doubleToolStripMenuItem.Text = "Double";
            this.doubleToolStripMenuItem.Click += new System.EventHandler(this.doubleToolStripMenuItem_Click);
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.setAsSourceToolStripMenuItem,
            this.setAsDestinationToolStripMenuItem,
            this.newQueryerToolStripMenuItem});
            this.connectionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("connectionToolStripMenuItem.Image")));
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("connectToolStripMenuItem.Image")));
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("disconnectToolStripMenuItem.Image")));
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // setAsSourceToolStripMenuItem
            // 
            this.setAsSourceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("setAsSourceToolStripMenuItem.Image")));
            this.setAsSourceToolStripMenuItem.Name = "setAsSourceToolStripMenuItem";
            this.setAsSourceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                        | System.Windows.Forms.Keys.S)));
            this.setAsSourceToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.setAsSourceToolStripMenuItem.Text = "Open as Source";
            this.setAsSourceToolStripMenuItem.Click += new System.EventHandler(this.setAsSourceToolStripMenuItem_Click);
            // 
            // setAsDestinationToolStripMenuItem
            // 
            this.setAsDestinationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("setAsDestinationToolStripMenuItem.Image")));
            this.setAsDestinationToolStripMenuItem.Name = "setAsDestinationToolStripMenuItem";
            this.setAsDestinationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                        | System.Windows.Forms.Keys.D)));
            this.setAsDestinationToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.setAsDestinationToolStripMenuItem.Text = "Open as Destination";
            this.setAsDestinationToolStripMenuItem.Click += new System.EventHandler(this.setAsDestinationToolStripMenuItem_Click);
            // 
            // newQueryerToolStripMenuItem
            // 
            this.newQueryerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newQueryerToolStripMenuItem.Image")));
            this.newQueryerToolStripMenuItem.Name = "newQueryerToolStripMenuItem";
            this.newQueryerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                        | System.Windows.Forms.Keys.N)));
            this.newQueryerToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.newQueryerToolStripMenuItem.Text = "Open new Queryer";
            this.newQueryerToolStripMenuItem.Click += new System.EventHandler(this.newQueryerToolStripMenuItem_Click);
            // 
            // pluginsToolStripMenuItem
            // 
            this.pluginsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pluginsToolStripMenuItem.Image")));
            this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.pluginsToolStripMenuItem.Text = "Plugins";
            // 
            // QueryerTimer
            // 
            this.QueryerTimer.Enabled = true;
            this.QueryerTimer.Interval = 1000;
            this.QueryerTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // autocomplete
            // 
            this.autocomplete.Colors = ((AutocompleteMenuNS.Colors)(resources.GetObject("autocomplete.Colors")));
            this.autocomplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.autocomplete.ImageList = this.QueryIcons;
            this.autocomplete.Items = new string[0];
            this.autocomplete.TargetControlWrapper = null;
            // 
            // hashToolStripMenuItem
            // 
            this.hashToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hashToolStripMenuItem.Image")));
            this.hashToolStripMenuItem.Name = "hashToolStripMenuItem";
            this.hashToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.H)));
            this.hashToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.hashToolStripMenuItem.Text = "Hash";
            this.hashToolStripMenuItem.Click += new System.EventHandler(this.hashToolStripMenuItem_Click);
            // 
            // hashToolStripMenuItem1
            // 
            this.hashToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("hashToolStripMenuItem1.Image")));
            this.hashToolStripMenuItem1.Name = "hashToolStripMenuItem1";
            this.hashToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.hashToolStripMenuItem1.Text = "Hash";
            this.hashToolStripMenuItem1.Click += new System.EventHandler(this.hashToolStripMenuItem1_Click);
            // 
            // QueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.queryMenu);
            this.Controls.Add(this.QueryTabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QueryForm";
            this.Text = "ODBC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QueryForm_FormClosing);
            this.Load += new System.EventHandler(this.QueryForm_Load);
            this.Move += new System.EventHandler(this.QueryForm_Move);
            this.Resize += new System.EventHandler(this.QueryForm_Resize);
            this.QueryTabs.ResumeLayout(false);
            this.queryTab.ResumeLayout(false);
            this.querySplitV.Panel1.ResumeLayout(false);
            this.querySplitV.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.querySplitV)).EndInit();
            this.querySplitV.ResumeLayout(false);
            this.schemaContextMenu.ResumeLayout(false);
            this.querySplitH.Panel1.ResumeLayout(false);
            this.querySplitH.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.querySplitH)).EndInit();
            this.querySplitH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).EndInit();
            this.resultContextMenu.ResumeLayout(false);
            this.resultTab.ResumeLayout(false);
            this.historyTab.ResumeLayout(false);
            this.queryMenu.ResumeLayout(false);
            this.queryMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl QueryTabs;
        private System.Windows.Forms.TabPage queryTab;
        private System.Windows.Forms.TabPage resultTab;
        private System.Windows.Forms.ImageList QueryIcons;
        private System.Windows.Forms.RichTextBox resultBox;
        private System.Windows.Forms.SplitContainer querySplitV;
        private System.Windows.Forms.TreeView DatabaseTree;
        private System.Windows.Forms.SplitContainer querySplitH;
        private System.Windows.Forms.RichTextBox queryBox;
        private System.Windows.Forms.DataGridView resultGrid;
        private System.Windows.Forms.TabPage historyTab;
        private System.Windows.Forms.RichTextBox historyBox;
        private System.Windows.Forms.MenuStrip queryMenu;
        private System.Windows.Forms.ToolStripMenuItem queryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newclearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadsqlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savesqlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportcsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queryRunMenu;
        private System.Windows.Forms.ToolStripMenuItem killToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.Timer QueryerTimer;
        private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSQLToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem setAsSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAsDestinationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newQueryerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uniqToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doubleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoCaseToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip resultContextMenu;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem autoCaseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem uniqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doubleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem concatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem concatToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip schemaContextMenu;
        private System.Windows.Forms.ToolStripMenuItem alterTableToolStripMenuItem;
        private AutocompleteMenuNS.AutocompleteMenu autocomplete;
        private System.Windows.Forms.ToolStripMenuItem hashToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hashToolStripMenuItem1;

    }
}