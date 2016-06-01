using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Globalization;
using IPlugin;
using QueryIT.model;
using AutocompleteMenuNS;

namespace QueryIT {
    public partial class QueryerForm : Form {
        private MainForm parent;
        private String LicenseInformation = "";

        public PluginCore plugincore = new PluginCore(Environment.CurrentDirectory);
        public Datasource QDS;
        public DataTable DT;
        public int index = 0;
        public string nameindex = "";
        public string align = "";
        public bool isMoved = false;
        public bool run = false;
        public bool search = false;

        public string database;
        public string table;
        public string column;
        public int cellColumn;
        public int cellRow;

        public string sqlfilepath = "";

        public QueryerForm() {
            InitializeComponent();
        }

        public void loadPlugins() {
            try {
                Array pls = plugincore.getPlugins(LicenseInformation);
                foreach(Object pl in pls) {
                    if(plugincore.Hook(pl.ToString()) == pluginHook.Queryer || plugincore.Hook(pl.ToString()) == pluginHook.All) {
                        ToolStripMenuItem item = new ToolStripMenuItem();
                        item.Text = plugincore.Description(pl.ToString());
                        item.Name = pl.ToString();
                        item.Image = plugincore.Icon(pl.ToString());
                        item.Click += new EventHandler(MenuItemClickHandler);
                        pluginsToolStripMenuItem.DropDownItems.Insert(pluginsToolStripMenuItem.DropDownItems.Count, item);
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        public QueryerForm(Datasource ds, string a) {
            try {
                InitializeComponent();
                QDS = ds;
                align = a;
                reloadSchema();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void MenuItemClickHandler(object sender, EventArgs e) {
            try {
                ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
                DT = plugincore.Process(clickedItem.Name.ToString(), DT, "");
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        public void doResize() {
            try {
                if(this.WindowState == FormWindowState.Normal && isMoved == false) {
                    if(align == "left") {
                        this.Left = 0;
                        this.Top = 0;
                        this.Height = this.Parent.Height - 5;
                        this.Width = (this.Parent.Width / 2) - 5;
                    }
                    if(align == "right") {
                        this.Left = (this.Parent.Width / 2);
                        this.Top = 0;
                        this.Height = this.Parent.Height - 5;
                        this.Width = (this.Parent.Width / 2) - 5;
                    }
                    if(align == "mid") {
                        this.Top = 0;
                        this.Left = (this.Parent.Width / 4) - 5;
                        this.Height = this.Parent.Height - 5;
                        this.Width = (this.Parent.Width / 2) - 5;
                        this.WindowState = FormWindowState.Maximized;
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void DatabaseTree_DoubleClick(object sender, EventArgs e) {
            try {
                if(DatabaseTree.SelectedNode != null) {
                    foreach(TreeNode tn in DatabaseTree.Nodes) {
                        if(tn.Text.ToString() == DatabaseTree.SelectedNode.Text.ToString()) {
                            tn.NodeFont = new Font(DatabaseTree.Font, FontStyle.Bold);
                            tn.Text = tn.Text;
                        } else {
                            tn.NodeFont = DatabaseTree.Font;
                            tn.Text = tn.Text;
                        }
                    }
                    database = QDS.database;
                    if(DatabaseTree.SelectedNode.ImageIndex == 3) {
                        database = DatabaseTree.SelectedNode.Text.ToString();
                        //Switch Database
                        QDS.switchDatabase(DatabaseTree.SelectedNode.Text.ToString());
                        reloadSchema();
                    } else if(DatabaseTree.SelectedNode.ImageIndex == 4) {
                        database = DatabaseTree.SelectedNode.Text.ToString();
                        //Switch Database
                        QDS.switchDatabase(DatabaseTree.SelectedNode.Text.ToString());
                        reloadSchema();
                    }
                    if(DatabaseTree.SelectedNode.ImageIndex == 5) {
                        table = DatabaseTree.SelectedNode.Text.ToString();
                        database = DatabaseTree.SelectedNode.Parent.Text.ToString();
                        DatabaseTree.SelectedNode.Parent.NodeFont = new Font(DatabaseTree.Font, FontStyle.Bold);
                        DatabaseTree.SelectedNode.Parent.Text = DatabaseTree.SelectedNode.Parent.Text;
                        if(QueryTabs.TabPages.ContainsKey("Tab" + table.Replace(".csv", "")) == true) {
                            QueryTabs.SelectedIndex = QueryTabs.TabPages.IndexOfKey("Tab" + table.Replace(".csv", ""));
                        } else {
                            //New Tab
                            TabPage tpNew = new TabPage();
                            tpNew.Name = "Tab" + table.Replace(".csv", "");
                            tpNew.Text = table.Replace(".csv", "");
                            tpNew.Padding = queryTab.Padding;
                            tpNew.Margin = queryTab.Margin;
                            tpNew.ImageIndex = QueryTabs.TabPages[0].ImageIndex;
                            //Splitter
                            SplitContainer spNew = new SplitContainer();
                            spNew.Name = "splitBox" + table.Replace(".csv", "");
                            spNew.Orientation = querySplitH.Orientation;
                            spNew.SplitterDistance = 25;
                            spNew.Margin = querySplitH.Margin;
                            spNew.Dock = DockStyle.Fill;
                            //Query Box -> Splitter 1
                            RichTextBox qrtNew = new RichTextBox();
                            qrtNew.Name = "queryBox" + table.Replace(".csv", "");
                            qrtNew.Font = queryBox.Font;
                            qrtNew.Dock = DockStyle.Fill;

                            qrtNew.Text = QDS.DBschema.D[database].T[table].SQLSelectTop();

                            qrtNew.SyntaxHighlight();
                            qrtNew.TextChanged += new System.EventHandler(this.rtfBox_TextChanged);
                            autocomplete.SetAutocompleteMenu(qrtNew, autocomplete);
                            spNew.Panel1.Controls.Add(qrtNew);
                            //Result Tabs -> Spliter 2
                            TabControl tcNew = new TabControl();
                            tcNew.Name = "resultTabs" + table.Replace(".csv", "");
                            tcNew.Dock = DockStyle.Fill;
                            tcNew.ImageList = resultTabs.ImageList;
                            tcNew.Padding = resultTabs.Padding;
                            tcNew.Margin = resultTabs.Margin;
                            //ResultGridTab -> Spliter2 -> Result Tabs
                            TabPage rgtNew = new TabPage();
                            rgtNew.Name = "resultGridTab" + table;
                            rgtNew.ImageIndex = resultTabs.TabPages[0].ImageIndex;
                            rgtNew.Text = resultTabs.TabPages[0].Text;
                            rgtNew.Padding = resultTabs.TabPages[0].Padding;
                            rgtNew.Margin = resultTabs.TabPages[0].Margin;
                            rgtNew.Dock = DockStyle.Fill;
                            DataGridView dgvNew = new DataGridView();
                            dgvNew.Name = "resultGrid" + table.Replace(".csv", "");
                            dgvNew.Dock = DockStyle.Fill;
                            dgvNew.Margin = resultGrid.Margin;
                            rgtNew.Controls.Add(dgvNew);
                            tcNew.Controls.Add(rgtNew);
                            //ResultTextTab -> Spliter2 -> Result Tabs
                            TabPage rttNew = new TabPage();
                            rttNew.Name = "resultTextTab" + table.Replace(".csv", "");
                            rttNew.ImageIndex = resultTabs.TabPages[1].ImageIndex;
                            rttNew.Text = resultTabs.TabPages[1].Text;
                            rttNew.Padding = resultTabs.TabPages[1].Padding;
                            rttNew.Margin = resultTabs.TabPages[1].Margin;
                            rttNew.Dock = DockStyle.Fill;
                            RichTextBox rrtNew = new RichTextBox();
                            rrtNew.Name = "resultTextBox" + table.Replace(".csv", "");
                            rrtNew.Dock = DockStyle.Fill;
                            rrtNew.Font = resultTextBox.Font;
                            rrtNew.ReadOnly = true;
                            //rrtNew.TextChanged += new System.EventHandler(this.rtfBox_TextChanged);
                            rttNew.Controls.Add(rrtNew);
                            tcNew.Controls.Add(rttNew);
                            //ResultTextTab -> Spliter2 -> Result Tabs
                            TabPage rhtNew = new TabPage();
                            rhtNew.ImageIndex = resultTabs.TabPages[2].ImageIndex;
                            rhtNew.Text = resultTabs.TabPages[2].Text;
                            rhtNew.Padding = resultTabs.TabPages[2].Padding;
                            rhtNew.Margin = resultTabs.TabPages[2].Margin;
                            rhtNew.Name = "resultHistoryTab" + table.Replace(".csv", "");
                            rhtNew.Dock = DockStyle.Fill;
                            RichTextBox rhrtNew = new RichTextBox();
                            rhrtNew.Name = "resultHistoryTextBox" + table.Replace(".csv", "");
                            rhrtNew.Dock = DockStyle.Fill;
                            rhrtNew.Font = resultHistoryTextBox.Font;
                            rhrtNew.ReadOnly = true;
                            //rhrtNew.TextChanged += new System.EventHandler(this.rtfBox_TextChanged);
                            rhtNew.Controls.Add(rhrtNew);
                            tcNew.Controls.Add(rhtNew);
                            spNew.Panel2.Controls.Add(tcNew);
                            tpNew.Controls.Add(spNew);
                            QueryTabs.TabPages.Add(tpNew);
                            QueryTabs.SelectedIndex = QueryTabs.TabPages.IndexOfKey("Tab" + table.Replace(".csv", ""));
                        }
                        QDS.table = DatabaseTree.SelectedNode.Text.ToString();
                    } else if(DatabaseTree.SelectedNode.ImageIndex == 6) {
                        column = DatabaseTree.SelectedNode.Text.ToString();
                        if(queryBox.Text.Length == 0) {
                            string querypart = DatabaseTree.SelectedNode.Text.ToString().Substring(0, DatabaseTree.SelectedNode.Text.IndexOf("("));
                            queryBox.Text += querypart;
                        }
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void QueryerForm_Load(object sender, EventArgs e) {
            parent = this.MdiParent as MainForm;
            LicenseInformation = parent.LicenseInformation;
            try {
                if(QDS.conectionString.Contains("Microsoft Text Driver")) {
                    this.Icon = Icon.FromHandle(((Bitmap)QueryIcons.Images[3]).GetHicon());
                    this.Text = nameindex + " CSV: " + QDS.database + "";
                } else {
                    this.Icon = Icon.FromHandle(((Bitmap)QueryIcons.Images[4]).GetHicon());
                    this.Text = nameindex + " MySQL: " + QDS.database + "";
                }
                if(nameindex.ToString() == "Source") {
                    setAsSourceToolStripMenuItem.Enabled = false;
                }
                if(nameindex.ToString() == "Destination") {
                    setAsDestinationToolStripMenuItem.Enabled = false;
                }
                loadPlugins();
                doResize();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void queryRunMenu_Click_1(object sender, EventArgs e) {
            try {
                queryRunMenu.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                run = true;
                if(LicenseInformation.Contains("Query") == false) {
                    try {
                        using(var sform = new LicenseForm(parent)) {
                            var result = sform.ShowDialog();
                            if(result == DialogResult.OK) {

                            }
                        }
                    } catch(Exception err) {
                        parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                    }
                }

                string query = "";
                TabPage qTab = getSelectedTab();
                RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                RichTextBox rtBox = getSelectedResultTextBox(qTab);
                RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                TabControl rTabs = getSelectedResultTabs(qTab);
                query = qBox.Text.ToString();
                if(query.Length > 0) {
                    DT = new DataTable();
                    DT.Clear();
                    cellRow = -1;
                    cellColumn = -1;
                    if(QDS.executeSql(query.ToString())) {
                        rBox.Columns.Clear();
                        rBox.DataSource = null;
                        if(QDS.hasResult() == true && QDS.hasErrors() == false) {
                            rTabs.SelectTab(0);
                            //Needed to Copy for Cell Edit
                            if(QDS.row_count > 0) {
                                DT = QDS.result.Copy();
                            } else {
                                rTabs.SelectTab(1);
                            }
                        } else {
                            rTabs.SelectTab(1);
                        }
                        rBox.DataSource = DT;
                        rBox.Refresh();
                        rtBox.Text = "Date: " + QDS.utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                        "Result: " + QDS.row_count.ToString() + " Records\n" +
                        "Query: '" + QDS.sql.ToString() + "'\n";
                        rhBox.Text = "Date: " + QDS.utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                        "Result: " + QDS.row_count.ToString() + " Records\n" +
                        "Query: '" + QDS.sql.ToString() + "'\n" +
                        "\n" + rhBox.Text.ToString();
                    } else {
                        if(QDS.hasErrors() == true) {
                            rTabs.SelectTab(1);
                            rtBox.Text = "Date: " + QDS.utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                            "Query: '" + QDS.sql.ToString() + "'\n" +
                            "Error: " + QDS.error.ToString() + "\n";
                            rhBox.Text = "Date: " + QDS.utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                            "Query: '" + QDS.sql.ToString() + "'\n" +
                            "Error: " + QDS.error.ToString() + "\n" +
                            "\n" + rhBox.Text.ToString();
                        }
                    }
                }
                run = false;
                queryRunMenu.Enabled = true;
                killToolStripMenuItem.Enabled = false;
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                run = false;
                queryRunMenu.Enabled = true;
                killToolStripMenuItem.Enabled = false;
            }
        }

        private void QueryerForm_Resize(object sender, EventArgs e) {
            //isMoved = true;
        }

        private void exportcsvToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                using(var sfd = new SaveFileDialog()) {
                    sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    if(sfd.ShowDialog() == DialogResult.OK) {
                        QDS.exportCSV(sfd.FileName);
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void newclearAllToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                TabPage qTab = getSelectedTab();
                RichTextBox qBox = getSelectedQueryBox(qTab);
                qBox.Text = "";
                sqlfilepath = "";
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void savesqlToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                TabPage qTab = getSelectedTab();
                RichTextBox qBox = getSelectedQueryBox(qTab);
                if(File.Exists(sqlfilepath) == true) {
                    File.WriteAllText(sqlfilepath, qBox.Text.ToString());
                } else {
                    using(var sfd = new SaveFileDialog()) {
                        sfd.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*";
                        sfd.FilterIndex = 1;

                        if(sfd.ShowDialog() == DialogResult.OK) {
                            sqlfilepath = sfd.FileName;
                            File.WriteAllText(sfd.FileName, qBox.Text.ToString());
                        }
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void loadsqlToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                TabPage qTab = getSelectedTab();
                RichTextBox qBox = getSelectedQueryBox(qTab);
                using(var sfd = new OpenFileDialog()) {
                    sfd.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;

                    if(sfd.ShowDialog() == DialogResult.OK) {
                        sqlfilepath = sfd.FileName;
                        qBox.Text = File.ReadAllText(sfd.FileName);
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void QueryerForm_Move(object sender, EventArgs e) {
            //isMoved = true;
        }

        private void rtfBox_TextChanged(object sender, EventArgs e) {
            try {
                if(sender.GetType() == typeof(RichTextBox)) {
                    RichTextBox tb = (RichTextBox)sender;
                    tb.SyntaxHighlight();
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                TabPage qTab = getSelectedTab();
                RichTextBox qBox = getSelectedQueryBox(qTab);
                using(var sfd = new DateTimeForm()) {
                    if(sfd.ShowDialog() == DialogResult.OK) {
                        qBox.SelectedText = "'" + sfd.DateTimeStr + "'";
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void killToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                run = false;
                QDS.run = false;
                QDS.cancelSQL();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void QueryerForm_FormClosing(object sender, FormClosingEventArgs e) {
            run = false;
            QDS.run = false;
            QDS.disconnect();
        }

        private void DatabaseTree_AfterSelect(object sender, TreeViewEventArgs e) {
            try {

            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        public void reloadSchema() {
            try {
                //AutoComplete
                var acitems = new List<AutocompleteItem>();
                Array.Sort(SQLSyntax.SQLblue);
                foreach(var key in SQLSyntax.SQLblue) {
                    acitems.Add(new AutocompleteItem(key.ToString()) { ImageIndex = 0 });
                }
                Array.Sort(SQLSyntax.SQLmagenta);
                foreach(var key in SQLSyntax.SQLmagenta) {
                    acitems.Add(new AutocompleteItem(key.ToString()) { ImageIndex = 0 });
                }
                //TreeView
                string database = QDS.database;
                if(QDS.DBschema.Databases != null) {
                    foreach(DatabaseSchema db in QDS.DBschema.Databases) {
                        if(DatabaseTree.Nodes.IndexOfKey(db.DatabaseName) == -1) {
                            //Add, Database to TreeView
                            DatabaseTree.Nodes.Add(db.DatabaseName, db.DatabaseName);
                            //Seelct Font
                            if(db.DatabaseName == database) {
                                DatabaseTree.Nodes[db.DatabaseName].NodeFont = new Font(DatabaseTree.Font, FontStyle.Bold);
                                DatabaseTree.Nodes[db.DatabaseName].Text = DatabaseTree.Nodes[db.DatabaseName].Text;
                            } else {
                                DatabaseTree.Nodes[db.DatabaseName].NodeFont = DatabaseTree.Font;
                                DatabaseTree.Nodes[db.DatabaseName].Text = DatabaseTree.Nodes[db.DatabaseName].Text;
                            }
                            //Select Icon
                            if(QDS.conectionString.Contains("Microsoft Text Driver")) {
                                DatabaseTree.Nodes[db.DatabaseName].ImageIndex = 3;
                                DatabaseTree.Nodes[db.DatabaseName].SelectedImageIndex = 3;
                            } else {
                                DatabaseTree.Nodes[db.DatabaseName].ImageIndex = 4;
                                DatabaseTree.Nodes[db.DatabaseName].SelectedImageIndex = 4;
                            }
                        } else {
                            //Skip, Database is already in TreeView
                        }
                        if(db.Tables != null) {
                            foreach(TableSchema tbl in db.Tables) {
                                if(DatabaseTree.Nodes[db.DatabaseName].Nodes.IndexOfKey(tbl.TableName) == -1) {
                                    //Add Table to Treeview
                                    DatabaseTree.Nodes[db.DatabaseName].Nodes.Add(tbl.TableName, tbl.TableName);
                                    //Image
                                    DatabaseTree.Nodes[db.DatabaseName].Nodes[tbl.TableName].ImageIndex = 5;
                                    DatabaseTree.Nodes[db.DatabaseName].Nodes[tbl.TableName].SelectedImageIndex = 5;
                                    //AutoComplete
                                    acitems.Add(new AutocompleteItem(tbl.TableName) { ImageIndex = 5 });
                                } else {
                                    //Skip, Table is already in Treeview
                                }
                                if(tbl.Columns != null) {
                                    foreach(ColumnSchema col in tbl.Columns) {
                                        if(DatabaseTree.Nodes[db.DatabaseName].Nodes[tbl.TableName].Nodes.IndexOfKey(col.ColumnName) == -1) {
                                            //Add Column to Treeview
                                            DatabaseTree.Nodes[db.DatabaseName].Nodes[tbl.TableName].Nodes.Add(col.ColumnName, col.ColumnName + "   " + col.DataType + "");
                                            if(col.PrimaryKey == true) {
                                                //Image
                                                DatabaseTree.Nodes[db.DatabaseName].Nodes[tbl.TableName].Nodes[col.ColumnName].ImageIndex = 10;
                                                DatabaseTree.Nodes[db.DatabaseName].Nodes[tbl.TableName].Nodes[col.ColumnName].SelectedImageIndex = 10;
                                                //AutoComplete
                                                acitems.Add(new AutocompleteItem(col.ColumnName) { ImageIndex = 10 });
                                            } else {
                                                //Image
                                                DatabaseTree.Nodes[db.DatabaseName].Nodes[tbl.TableName].Nodes[col.ColumnName].ImageIndex = 6;
                                                DatabaseTree.Nodes[db.DatabaseName].Nodes[tbl.TableName].Nodes[col.ColumnName].SelectedImageIndex = 6;
                                                //AutoComplete
                                                acitems.Add(new AutocompleteItem("`" + col.ColumnName) { ImageIndex = 6 });
                                            }
                                        } else {
                                            //Skip, Column is already in Treeview
                                        }
                                    }//foreach Column
                                }
                            }//Foreach Table
                        }
                    }//Foreach Database
                }
                autocomplete.SetAutocompleteItems(acitems);
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        public void reloadSchema2() {
            try {
                /*
                var acitems = new List<AutocompleteItem>();
                Array.Sort(SQLSyntax.SQLblue);
                foreach(var key in SQLSyntax.SQLblue) {
                    acitems.Add(new AutocompleteItem(key.ToString()) { ImageIndex = 0 });
                }
                Array.Sort(SQLSyntax.SQLmagenta);
                foreach(var key in SQLSyntax.SQLmagenta) {
                    acitems.Add(new AutocompleteItem(key.ToString()) { ImageIndex = 0 });
                }
                if(QDS.databases.Rows.Count > 0) {
                    string database = QDS.database;
                    foreach(DataRow r in QDS.databases.Rows) {
                        //QDS.executeSql("USE " + r.ItemArray[0].ToString());
                        //QDS.getSchema();
                        if(DatabaseTree.Nodes.IndexOfKey(r.ItemArray[0].ToString()) == -1) {
                            DatabaseTree.Nodes.Add(r.ItemArray[0].ToString(), r.ItemArray[0].ToString());
                            if(r.ItemArray[0].ToString() == database) {
                                DatabaseTree.Nodes[r.ItemArray[0].ToString()].NodeFont = new Font(DatabaseTree.Font, FontStyle.Bold);
                                DatabaseTree.Nodes[r.ItemArray[0].ToString()].Text = DatabaseTree.Nodes[r.ItemArray[0].ToString()].Text;
                            }
                            if(QDS.conectionString.Contains("Microsoft Text Driver")) {
                                DatabaseTree.Nodes[r.ItemArray[0].ToString()].ImageIndex = 3;
                                DatabaseTree.Nodes[r.ItemArray[0].ToString()].SelectedImageIndex = 3;
                            } else {
                                DatabaseTree.Nodes[r.ItemArray[0].ToString()].ImageIndex = 4;
                                DatabaseTree.Nodes[r.ItemArray[0].ToString()].SelectedImageIndex = 4;
                            }
                        }
                    }
                    foreach(DataRow row in QDS.tables.Rows) {
                        if(DatabaseTree.Nodes[QDS.database.ToString()].Nodes.IndexOfKey(row["TABLE_NAME"].ToString()) == -1) {
                            DatabaseTree.Nodes[QDS.database.ToString()].Nodes.Add(row["TABLE_NAME"].ToString(), row["TABLE_NAME"].ToString());
                            DatabaseTree.Nodes[QDS.database.ToString()].Nodes[row["TABLE_NAME"].ToString()].ImageIndex = 5;
                            DatabaseTree.Nodes[QDS.database.ToString()].Nodes[row["TABLE_NAME"].ToString()].SelectedImageIndex = 5;
                            acitems.Add(new AutocompleteItem(row["TABLE_NAME"].ToString()) { ImageIndex = 5 });
                            foreach(DataRow col in QDS.columns.Rows) {
                                if(col["TABLE_NAME"].ToString() == row["TABLE_NAME"].ToString()) {

                                    DatabaseTree.Nodes[QDS.database.ToString()].Nodes[row["TABLE_NAME"].ToString()].Nodes.Add(col["COLUMN_NAME"].ToString(), col["COLUMN_NAME"].ToString() + " (" + col["DATA_TYPE"].ToString() + ")");
                                    if(QDS.columns.Columns.Contains("COLUMN_KEY") == true) {

                                        if(col["COLUMN_KEY"].ToString() == "PRI") {
                                            DatabaseTree.Nodes[QDS.database.ToString()].Nodes[row["TABLE_NAME"].ToString()].Nodes[col["COLUMN_NAME"].ToString()].ImageIndex = 10;
                                            DatabaseTree.Nodes[QDS.database.ToString()].Nodes[row["TABLE_NAME"].ToString()].Nodes[col["COLUMN_NAME"].ToString()].SelectedImageIndex = 10;
                                            acitems.Add(new AutocompleteItem(col["COLUMN_NAME"].ToString()) { ImageIndex = 10 });
                                        } else {
                                            DatabaseTree.Nodes[QDS.database.ToString()].Nodes[row["TABLE_NAME"].ToString()].Nodes[col["COLUMN_NAME"].ToString()].ImageIndex = 6;
                                            DatabaseTree.Nodes[QDS.database.ToString()].Nodes[row["TABLE_NAME"].ToString()].Nodes[col["COLUMN_NAME"].ToString()].SelectedImageIndex = 6;
                                            acitems.Add(new AutocompleteItem("`" + col["COLUMN_NAME"].ToString()) { ImageIndex = 6 });
                                        }
                                    } else {
                                        DatabaseTree.Nodes[QDS.database.ToString()].Nodes[row["TABLE_NAME"].ToString()].Nodes[col["COLUMN_NAME"].ToString()].ImageIndex = 6;
                                        DatabaseTree.Nodes[QDS.database.ToString()].Nodes[row["TABLE_NAME"].ToString()].Nodes[col["COLUMN_NAME"].ToString()].SelectedImageIndex = 6;
                                        acitems.Add(new AutocompleteItem(col["COLUMN_NAME"].ToString()) { ImageIndex = 6 });
                                    }
                                }
                            }
                        }
                    }
                    //QDS.executeSql("USE " + database);
                } else {
                    if(DatabaseTree.Nodes.IndexOfKey(QDS.database.ToString()) == -1) {
                        DatabaseTree.Nodes.Add(QDS.database.ToString(), QDS.database.ToString());
                        DatabaseTree.Nodes[QDS.database.ToString()].NodeFont = new Font(DatabaseTree.Font, FontStyle.Bold);
                        DatabaseTree.Nodes[QDS.database.ToString()].Text = DatabaseTree.Nodes[QDS.database.ToString()].Text;
                        if(QDS.conectionString.Contains("Microsoft Text Driver")) {
                            DatabaseTree.Nodes[QDS.database.ToString()].ImageIndex = 3;
                            DatabaseTree.Nodes[QDS.database.ToString()].SelectedImageIndex = 3;
                        } else {
                            DatabaseTree.Nodes[QDS.database.ToString()].ImageIndex = 4;
                            DatabaseTree.Nodes[QDS.database.ToString()].SelectedImageIndex = 4;
                        }
                    }
                    foreach(DataRow row in QDS.tables.Rows) {
                        if(DatabaseTree.Nodes[QDS.database.ToString()].Nodes.IndexOfKey(row["TABLE_NAME"].ToString()) == -1) {
                            DatabaseTree.Nodes[QDS.database.ToString()].Nodes.Add(row["TABLE_NAME"].ToString(), row["TABLE_NAME"].ToString());
                            DatabaseTree.Nodes[QDS.database.ToString()].Nodes[row["TABLE_NAME"].ToString()].ImageIndex = 5;
                            DatabaseTree.Nodes[QDS.database.ToString()].Nodes[row["TABLE_NAME"].ToString()].SelectedImageIndex = 5;
                            acitems.Add(new AutocompleteItem(row["TABLE_NAME"].ToString()) { ImageIndex = 5 });
                            foreach(DataRow col in QDS.columns.Rows) {
                                if(col["TABLE_NAME"].ToString() == row["TABLE_NAME"].ToString()) {
                                    DatabaseTree.Nodes[QDS.database.ToString()].Nodes[row["TABLE_NAME"].ToString()].Nodes.Add(col["COLUMN_NAME"].ToString(), col["COLUMN_NAME"].ToString() + " (" + col["DATA_TYPE"].ToString() + ")");
                                    if(QDS.columns.Columns.Contains("COLUMN_KEY") == true) {
                                        if(col["COLUMN_KEY"].ToString() == "PRI") {
                                            DatabaseTree.Nodes[QDS.database.ToString()].Nodes[row["TABLE_NAME"].ToString()].Nodes[col["COLUMN_NAME"].ToString()].ImageIndex = 10;
                                            DatabaseTree.Nodes[QDS.database.ToString()].Nodes[row["TABLE_NAME"].ToString()].Nodes[col["COLUMN_NAME"].ToString()].SelectedImageIndex = 10;
                                            acitems.Add(new AutocompleteItem(col["COLUMN_NAME"].ToString()) { ImageIndex = 10 });
                                        } else {
                                            DatabaseTree.Nodes[QDS.database.ToString()].Nodes[row["TABLE_NAME"].ToString()].Nodes[col["COLUMN_NAME"].ToString()].ImageIndex = 6;
                                            DatabaseTree.Nodes[QDS.database.ToString()].Nodes[row["TABLE_NAME"].ToString()].Nodes[col["COLUMN_NAME"].ToString()].SelectedImageIndex = 6;
                                            acitems.Add(new AutocompleteItem(col["COLUMN_NAME"].ToString()) { ImageIndex = 6 });
                                        }
                                    } else {
                                        DatabaseTree.Nodes[QDS.database.ToString()].Nodes[row["TABLE_NAME"].ToString()].Nodes[col["COLUMN_NAME"].ToString()].ImageIndex = 6;
                                        DatabaseTree.Nodes[QDS.database.ToString()].Nodes[row["TABLE_NAME"].ToString()].Nodes[col["COLUMN_NAME"].ToString()].SelectedImageIndex = 6;
                                        acitems.Add(new AutocompleteItem(col["COLUMN_NAME"].ToString()) { ImageIndex = 6 });
                                    }
                                }
                            }
                        }
                    }
                }
                //acitems = acitems.Distinct().ToList();
                autocomplete.SetAutocompleteItems(acitems);           
                */
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
   
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                QDS.connect();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                QDS.disconnect();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            try {
                if(QDS.isConnected() == true) {
                    connectionToolStripMenuItem.Image = QueryIcons.Images[1];
                } else {
                    connectionToolStripMenuItem.Image = QueryIcons.Images[2];
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                TabPage qTab = getSelectedTab();
                RichTextBox qBox = getSelectedQueryBox(qTab);
                using(var sfd = new SaveFileDialog()) {
                    sfd.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;

                    if(sfd.ShowDialog() == DialogResult.OK) {
                        sqlfilepath = sfd.FileName;
                        File.WriteAllText(sfd.FileName, qBox.Text.ToString());
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void saveSQLToolStripMenuItem1_Click(object sender, EventArgs e) {
            /*
            try {
                
                TabPage qTab = getSelectedTab();
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                //RichTextBox rtBox = getSelectedResultTextBox(qTab);
                //RichTextBox rhBox = getSelectedResultHistoryBox(qTab);

                string querys = "";
                string queryUValues = "SET ";
                string queryIValues = "";
                string pri = "id";
                int pripos = 0;
                int pripostmp = 0;
                //Primary Key
                foreach(DataRow col in QDS.columns.Rows) {
                    if(col["TABLE_NAME"].ToString() == QDS.table.ToString()) {
                        if(col.ItemArray.Contains("COLUMN_KEY") == true) {
                            if(col["COLUMN_KEY"].ToString() == "PRI") {
                                pri = col["COLUMN_NAME"].ToString();
                                pripos = pripostmp;
                                break;
                            }
                        }
                        pripostmp++;
                    }
                }
                //build insert header
                string queryI = "INSERT INTO `" + QDS.table + "` (";
                foreach(DataRow col in QDS.columns.Rows) {
                    if(col["TABLE_NAME"].ToString() == QDS.table.ToString()) {
                        if(col.ItemArray.Contains("COLUMN_KEY") == true) {
                            if(col["COLUMN_KEY"].ToString() != "PRI") {
                                queryI += "`" + col["COLUMN_NAME"].ToString() + "`,";
                            }
                        } else {
                            queryI += "`" + col["COLUMN_NAME"].ToString() + "`,";
                        }
                    }
                }
                queryI = queryI.Substring(0, queryI.Length - 1);
                queryI += ") ";
                //update changes
                string queryU = "UPDATE `" + QDS.table + "` ";
                foreach(DataGridViewRow r in rBox.Rows) {
                    if(r.Index < QDS.result.Rows.Count) {
                        //Updates
                        queryUValues = "SET ";
                        foreach(DataGridViewCell c in r.Cells) {
                            if(QDS.result.Rows[c.RowIndex].ItemArray[c.ColumnIndex].ToString() != c.Value.ToString()) {
                                queryUValues += "`" + QDS.result.Columns[c.ColumnIndex].ColumnName.ToString() + "` = '" + c.Value + "',";
                            }
                            if(DT.Rows[c.RowIndex].ItemArray[c.ColumnIndex].ToString() != c.Value.ToString()) {
                                queryUValues += "`" + DT.Columns[c.ColumnIndex].ColumnName.ToString() + "` = '" + c.Value + "',";
                            }
                        }
                        if(queryUValues.ToString() != "SET ") {
                            queryUValues = queryUValues.Substring(0, queryUValues.Length - 1);
                            queryUValues += " WHERE `" + pri + "` = " + r.Cells[pripos].Value.ToString() + ";\n";
                            querys += queryU + queryUValues;
                        }
                    } else {
                        //Inserts
                        queryIValues = "VALUES(";
                        foreach(DataGridViewCell c in r.Cells) {
                            if(c.Value != null) {
                                queryIValues += "'" + c.Value + "',";
                            }
                        }
                        if(queryIValues.ToString() != "VALUES(") {
                            queryIValues = queryIValues.Substring(0, queryIValues.Length - 1);
                            queryIValues += ");";
                            querys += queryI + queryIValues;
                        }
                    }
                }
                //delete
                //bool deleted = true;
                //foreach(DataRow rdb in QDS.result.Rows) {
                //    deleted = true;
                //    foreach(DataGridViewRow r in resultGrid.Rows)
                //        if(r.ToString() == resultGrid.Rows[r.Index].ToString()) {
                //            deleted = false;
                //        }
                //        if(deleted == true) {

                //        }
                //}
                if(querys.Trim().ToString() != "") {
                    queryBox.Text = querys + "\n" + queryBox.Text.ToString();
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
            */
        }

        private void setAsSourceToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                MainForm parent = this.MdiParent as MainForm;
                parent.openSource(QDS.conectionString.ToString());
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void newQueryerToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                MainForm parent = this.MdiParent as MainForm;
                parent.openQueryer(QDS.conectionString.ToString());
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void setAsDestinationToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                MainForm parent = this.MdiParent as MainForm;
                parent.openDestination(QDS.conectionString.ToString());
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                TabPage qTab = getSelectedTab();
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                //RichTextBox rtBox = getSelectedResultTextBox(qTab);
                //RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                SearchForm searchfrm = new SearchForm(rBox);
                searchfrm.Show();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        public int doAutocase(string Autocase, int offset = 0, string[] columns = null) {
            try {
                int match = 0;
                int loops = 0;
                DateTime utcStart;
                DateTime utcStop;
                TabPage qTab = getSelectedTab();
                ProgressForm pform = new ProgressForm(this, "Progress [AutoCase - " + qTab.Text + "]");
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                RichTextBox rtBox = getSelectedResultTextBox(qTab);
                RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                search = true;
                run = true;
                queryRunMenu.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                resultGrid.CurrentCell = null;
                utcStart = DateTime.UtcNow;
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                rBox.CurrentCell = null;
                foreach(DataGridViewRow r in rBox.Rows) {
                    if(r.IsNewRow == false) {
                        foreach(DataGridViewCell c in r.Cells) {
                            if(columns.Contains(c.OwningColumn.Name.ToString())) {
                                if(c.Value != null) {
                                    if(Autocase == "to lower") {
                                        c.Value = c.Value.ToString().ToLowerInvariant();
                                    } else if(Autocase == "to UPPER") {
                                        c.Value = c.Value.ToString().ToUpperInvariant();
                                    } else if(Autocase == "to Title Case") {
                                        c.Value = textInfo.ToTitleCase(c.Value.ToString());
                                    }
                                    match++;
                                }
                            }
                        }
                    }
                    loops++;
                    if(loops % 250 == 0) {
                        Application.DoEvents();
                    }
                }
                utcStop = DateTime.UtcNow;
                search = false;
                run = false;
                queryRunMenu.Enabled = true;
                killToolStripMenuItem.Enabled = false;
                rtBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                 "Result: " + match.ToString() + " Changed Records\n" +
                                 "Tool: AutoCase(" + Autocase.ToString() + ")\n";

                rhBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                  "Result: " + match.ToString() + " Changed Records\n" +
                                  "Tool: AutoCase(" + Autocase.ToString() + ")\n" +
                                  "\n" + rhBox.Text.ToString();
                return match;
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                run = false;
                queryRunMenu.Enabled = true;
                killToolStripMenuItem.Enabled = false;
                return 0;
            }
        }

        public int doHash(string Hash, int offset = 0, string[] columns = null) {
            try {
                int match = 0;
                int loops = 0;
                DateTime utcStart;
                DateTime utcStop;
                TabPage qTab = getSelectedTab();
                ProgressForm pform = new ProgressForm(this, "Progress [Hash - " + qTab.Text + "]");
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                RichTextBox rtBox = getSelectedResultTextBox(qTab);
                RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                search = true;
                run = true;
                queryRunMenu.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                resultGrid.CurrentCell = null;
                utcStart = DateTime.UtcNow;
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                rBox.CurrentCell = null;
                foreach(DataGridViewRow r in rBox.Rows) {
                    if(r.IsNewRow == false) {
                        foreach(DataGridViewCell c in r.Cells) {
                            if(columns.Contains(c.OwningColumn.Name.ToString())) {
                                if(c.Value != null) {
                                    if(Hash == "MD5") {
                                        c.Value = c.Value.ToString().checksum();
                                    } else if(Hash == "SHA-1") {
                                        c.Value = c.Value.ToString().checksum();
                                    }
                                    match++;
                                }
                            }
                        }
                    }
                    loops++;
                    if(loops % 250 == 0) {
                        Application.DoEvents();
                    }
                }
                utcStop = DateTime.UtcNow;
                search = false;
                run = false;
                queryRunMenu.Enabled = true;
                killToolStripMenuItem.Enabled = false;
                rtBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                 "Result: " + match.ToString() + " Hashed Records\n" +
                                 "Tool: AutoCase(" + Hash.ToString() + ")\n";

                rhBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                  "Result: " + match.ToString() + " Hashed Records\n" +
                                  "Tool: AutoCase(" + Hash.ToString() + ")\n" +
                                  "\n" + rhBox.Text.ToString();
                return match;
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                run = false;
                queryRunMenu.Enabled = true;
                killToolStripMenuItem.Enabled = false;
                return 0;
            }
        }

        public int doConcat(string column, int offset = 0, string before = "", string after = "") {
            try {
                int match = 0;
                int loops = 0;
                DateTime utcStart;
                DateTime utcStop;
                TabPage qTab = getSelectedTab();
                ProgressForm pform = new ProgressForm(this, "Progress [Concat - " + qTab.Text + "]");
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                RichTextBox rtBox = getSelectedResultTextBox(qTab);
                RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                search = true;
                run = true;
                queryRunMenu.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                resultGrid.CurrentCell = null;
                utcStart = DateTime.UtcNow;
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

                foreach(DataGridViewRow r in rBox.Rows) {
                    if(r.IsNewRow == false) {
                        foreach(DataGridViewCell c in r.Cells) {
                            if(column.Equals(c.OwningColumn.Name.ToString())) {
                                if(c.Value != null) {
                                    c.Value = before.ToString() + c.Value.ToString() + after.ToString();
                                    match++;
                                }
                            }
                        }
                    }
                    loops++;
                    if(loops % 250 == 0) {
                        Application.DoEvents();
                    }
                }
                utcStop = DateTime.UtcNow;
                search = false;
                run = false;
                queryRunMenu.Enabled = true;
                killToolStripMenuItem.Enabled = false;
                rtBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                 "Result: " + match.ToString() + " Changed Records\n" +
                                 "Tool: Concat(" + column.ToString() + ", " + before.ToString() + ", " + after.ToString() + ")\n";

                rhBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                  "Result: " + match.ToString() + " Changed Records\n" +
                                  "Tool: Concat(" + column.ToString() + ", " + before.ToString() + ", " + after.ToString() + ")\n" +
                                  "\n" + rhBox.Text.ToString();
                return match;
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                run = false;
                queryRunMenu.Enabled = true;
                killToolStripMenuItem.Enabled = false;
                return 0;
            }
        }

        public int doReplace(string searchstring, string replacestring, int offset = 0, bool exact = false, bool casesensetive = false, string[] columns = null) {
            try {
                int match = 0;
                int loops = 0;
                DateTime utcStart;
                DateTime utcStop;
                TabPage qTab = getSelectedTab();
                ProgressForm pform = new ProgressForm(this, "Progress [Replace - " + qTab.Text + "]");
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                RichTextBox rtBox = getSelectedResultTextBox(qTab);
                RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                search = true;
                run = true;
                queryRunMenu.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                resultGrid.CurrentCell = null;
                utcStart = DateTime.UtcNow;
                foreach(DataGridViewRow r in rBox.Rows) {
                    if(r.IsNewRow == false) {
                        foreach(DataGridViewCell c in r.Cells) {
                            if(columns.Contains(c.OwningColumn.Name.ToString())) {
                                if(c.Value != null) {
                                    if(casesensetive == true) {
                                        if(exact == true) {
                                            if(c.Value.ToString().Equals(searchstring.ToString(), StringComparison.CurrentCulture) == true) {
                                                c.Value = replacestring.ToString();
                                                match++;
                                            }
                                        } else {
                                            if(c.Value.ToString().IndexOf(searchstring.ToString(), StringComparison.CurrentCulture) >= 0) {
                                                c.Value = c.Value.ToString().Replace(searchstring.ToString(), replacestring.ToString());
                                                match++;
                                            }
                                        }
                                    } else {
                                        if(exact == true) {
                                            if(c.Value.ToString().Equals(searchstring.ToString(), StringComparison.CurrentCultureIgnoreCase) == true) {
                                                c.Value = replacestring.ToString();
                                                match++;
                                            }
                                        } else {
                                            if(c.Value.ToString().IndexOf(searchstring.ToString(), StringComparison.CurrentCultureIgnoreCase) >= 0) {
                                                c.Value = c.Value.ToString().Replace(searchstring.ToString(), replacestring.ToString());
                                                match++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    loops++;
                    if(loops % 250 == 0) {
                        Application.DoEvents();
                    }
                }
                utcStop = DateTime.UtcNow;
                search = false;
                run = false;
                queryRunMenu.Enabled = true;
                killToolStripMenuItem.Enabled = false;
                rtBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                 "Result: " + match.ToString() + " Replaced Records\n" +
                                 "Tool: Filter(" + searchstring.ToString() + ", " + replacestring.ToString() + ")\n";

                rhBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                  "Result: " + match.ToString() + " Replaced Records\n" +
                                  "Tool: Filter(" + searchstring.ToString() + ", " + replacestring.ToString() + ")\n" +
                                  "\n" + rhBox.Text.ToString();
                return match;
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                run = false;
                queryRunMenu.Enabled = true;
                killToolStripMenuItem.Enabled = false;
                return 0;
            }
        }

        public int doFilter(string searchstring, int offset = 0, bool exact = false, bool casesensetive = false, string[] columns = null) {
            try {
                int match = 0;
                int loops = 0;
                DateTime utcStart;
                DateTime utcStop;
                search = true;
                run = true;
                queryRunMenu.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                TabPage qTab = getSelectedTab();
                ProgressForm pform = new ProgressForm(this, "Progress [Filter - " + qTab.Text + "]");
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                RichTextBox rtBox = getSelectedResultTextBox(qTab);
                RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                pform.update(0, rBox.Rows.Count, 0);
                pform.Show();
                utcStart = DateTime.UtcNow;
                rBox.CurrentCell = null;
                foreach(DataGridViewRow r in rBox.Rows) {
                    if(r.IsNewRow == false) {
                        r.Visible = false;
                        foreach(DataGridViewCell c in r.Cells) {
                            if(columns.Contains(c.OwningColumn.Name.ToString())) {
                                if(c.Value != null) {
                                    if(casesensetive == true) {
                                        if(exact == true) {
                                            if(c.Value.ToString().Equals(searchstring.ToString(), StringComparison.CurrentCulture) == true) {
                                                r.Visible = true;
                                                match++;
                                            }
                                        } else {
                                            if(c.Value.ToString().IndexOf(searchstring.ToString(), StringComparison.CurrentCulture) >= 0) {
                                                r.Visible = true;
                                                match++;
                                            }
                                        }
                                    } else {
                                        if(exact == true) {
                                            if(c.Value.ToString().Equals(searchstring.ToString(), StringComparison.CurrentCultureIgnoreCase) == true) {
                                                r.Visible = true;
                                                match++;
                                            }
                                        } else {
                                            if(c.Value.ToString().IndexOf(searchstring.ToString(), StringComparison.CurrentCultureIgnoreCase) >= 0) {
                                                r.Visible = true;
                                                match++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    loops++;
                    if(loops % 250 == 0) {
                        pform.update(0, rBox.Rows.Count, loops);
                        Application.DoEvents();
                        rBox.Refresh();
                    }
                }
                utcStop = DateTime.UtcNow;
                pform.Hide();
                pform.Dispose();
                search = false;
                run = false;
                queryRunMenu.Enabled = true;
                killToolStripMenuItem.Enabled = false;

                rtBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                 "Result: " + match.ToString() + " Filtered Records\n" +
                                 "Tool: Filter(" + searchstring.ToString() + ")\n";

                rhBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                  "Result: " + match.ToString() + " Filtered Records\n" +
                                  "Tool: Filter(" + searchstring.ToString() + ")\n" +
                                  "\n" + rhBox.Text.ToString();
                return match;
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                run = false;
                queryRunMenu.Enabled = true;
                killToolStripMenuItem.Enabled = false;
                return 0;
            }
        }

        public int doSearch(string searchstring, int offset = 0, bool exact = false, bool casesensetive = false, string[] columns = null) {
            try {
                int match = 0;
                int loops = 0;
                DateTime utcStart;
                DateTime utcStop;
                TabPage qTab = getSelectedTab();
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                //RichTextBox rtBox = getSelectedResultTextBox(qTab);
                //RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                search = true;
                run = true;
                queryRunMenu.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                utcStart = DateTime.UtcNow;
                foreach(DataGridViewRow r in rBox.Rows) {
                    if(r.IsNewRow == false) {
                        foreach(DataGridViewCell c in r.Cells) {
                            if(columns.Contains(c.OwningColumn.Name.ToString())) {
                                if(c.Value != null) {
                                    if(casesensetive == true) {
                                        if(exact == true) {
                                            if(c.Value.ToString().Equals(searchstring.ToString(), StringComparison.CurrentCulture) == true) {
                                                if(match == offset) {
                                                    rBox.CurrentCell = rBox.Rows[c.RowIndex].Cells[c.ColumnIndex];
                                                    search = false;
                                                    match++;
                                                    break;
                                                } else {
                                                    match++;
                                                }
                                            }
                                        } else {
                                            if(c.Value.ToString().IndexOf(searchstring.ToString(), StringComparison.CurrentCulture) >= 0) {
                                                if(match == offset) {
                                                    rBox.CurrentCell = rBox.Rows[c.RowIndex].Cells[c.ColumnIndex];
                                                    search = false;
                                                    match++;
                                                    break;
                                                } else {
                                                    match++;
                                                }
                                            }
                                        }
                                    } else {
                                        if(exact == true) {
                                            if(c.Value.ToString().Equals(searchstring.ToString(), StringComparison.CurrentCultureIgnoreCase) == true) {
                                                if(match == offset) {
                                                    rBox.CurrentCell = rBox.Rows[c.RowIndex].Cells[c.ColumnIndex];
                                                    search = false;
                                                    match++;
                                                    break;
                                                } else {
                                                    match++;
                                                }
                                            }
                                        } else {
                                            if(c.Value.ToString().IndexOf(searchstring.ToString(), StringComparison.CurrentCultureIgnoreCase) >= 0) {
                                                if(match == offset) {
                                                    rBox.CurrentCell = rBox.Rows[c.RowIndex].Cells[c.ColumnIndex];
                                                    search = false;
                                                    match++;
                                                    break;
                                                } else {
                                                    match++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    loops++;
                    if(loops % 250 == 0) {
                        Application.DoEvents();
                    }
                    if(search == false || run == false) {
                        break;
                    }
                }
                utcStop = DateTime.UtcNow;
                run = false;
                queryRunMenu.Enabled = true;
                killToolStripMenuItem.Enabled = false;
                return match;
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                run = false;
                queryRunMenu.Enabled = true;
                killToolStripMenuItem.Enabled = false;
                return 0;
            }
        }

        public int doUniq() {
            try {
                int match = 0;
                int loops = 0;
                int indexS = 0;
                int indexD = 0;
                DateTime utcStart;
                DateTime utcStop;
                TabPage qTab = getSelectedTab();
                ProgressForm pform = new ProgressForm(this, "Progress [Unique - " + qTab.Text + "]");
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                RichTextBox rtBox = getSelectedResultTextBox(qTab);
                RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                pform.update(0, rBox.Rows.Count, 0);
                pform.Show();
                run = true;
                queryRunMenu.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                utcStart = DateTime.UtcNow;
                while(indexS < rBox.Rows.Count && run == true) {
                    indexD = 0;
                    while(indexD < rBox.Rows.Count && run == true) {
                        if(indexS != indexD) {
                            if(indexS < rBox.Rows.Count && indexD < rBox.Rows.Count) {
                                if(rBox.Rows[indexS].IsNewRow == false && rBox.Rows[indexD].IsNewRow == false) {
                                    if(rBox.Rows[indexS].ItemArray().arrEquals(rBox.Rows[indexD].ItemArray()) == true) {
                                        rBox.Rows.RemoveAt(indexD);
                                        match++;
                                    } else {
                                        indexD++;
                                    }
                                } else {
                                    indexD++;
                                }
                            } else {
                                indexD++;
                            }
                        } else {
                            indexD++;
                        }
                        loops++;
                        if(loops % 250 == 0) {
                            pform.update(0, rBox.Rows.Count, indexS);
                            Application.DoEvents();
                        }
                    }
                    if(indexD == rBox.Rows.Count) {
                        indexS++;
                    }
                }
                utcStop = DateTime.UtcNow;
                pform.Hide();
                pform.Dispose();
                run = false;
                queryRunMenu.Enabled = true;
                killToolStripMenuItem.Enabled = false;
                rtBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                "Result: " + rBox.Rows.Count.ToString() + " Unique Records\n" +
                "Tool: Unique()\n";
                rhBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                "Result: " + rBox.Rows.Count.ToString() + " Unique Records\n" +
                "Tool: Unique()\n" +
                "\n" + rhBox.Text.ToString();
                return match;
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                run = false;
                queryRunMenu.Enabled = true;
                killToolStripMenuItem.Enabled = false;
                return 0;
            }
        }


        public int doDouble() {
            try {
                int match = 0;
                int keep = 0;
                int loops = 0;
                int indexS = 0;
                int indexD = 0;
                DateTime utcStart;
                DateTime utcStop;
                TabPage qTab = getSelectedTab();
                ProgressForm pform = new ProgressForm(this, "Progress [Double - " + qTab.Text + "]");
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                RichTextBox rtBox = getSelectedResultTextBox(qTab);
                RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                pform.update(0, rBox.Rows.Count, 0);
                pform.Show();
                run = true;
                queryRunMenu.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                utcStart = DateTime.UtcNow;
                while(indexS < rBox.Rows.Count && run == true) {
                    indexD = 0;
                    match = 0;
                    while(indexD < rBox.Rows.Count && run == true) {
                        if(rBox.Rows[indexS].IsNewRow == false && rBox.Rows[indexD].IsNewRow == false) {
                            if(indexS != indexD) {
                                if(indexS < rBox.Rows.Count && indexD < rBox.Rows.Count) {
                                    if(rBox.Rows[indexS].ItemArray().arrEquals(rBox.Rows[indexD].ItemArray()) == true) {
                                        match++;
                                    }
                                }
                            }
                        }
                        indexD++;
                        loops++;
                        if(loops % 250 == 0) {
                            pform.update(0, rBox.Rows.Count, indexS + keep);
                            Application.DoEvents();
                        }
                    }

                    if(match == 0) {
                        if(rBox.Rows[indexS].IsNewRow == false) {
                            rBox.Rows.RemoveAt(indexS);
                        }
                    } else {
                        keep++;
                        if(indexD == rBox.Rows.Count) {
                            indexS++;
                        }
                        if(rBox.Rows[indexS].IsNewRow == true) {
                            indexS++;
                        }
                    }
                }
                utcStop = DateTime.UtcNow;
                pform.Hide();
                pform.Dispose();
                run = false;
                queryRunMenu.Enabled = true;
                killToolStripMenuItem.Enabled = false;

                rtBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                         "Result: " + keep.ToString() + " Doublicate Records\n" +
                                         "Tool: Double()\n";

                rhBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                         "Result: " + keep.ToString() + " Doublicate Records\n" +
                                         "Tool: Double()\n" +
                                         "\n" + rhBox.Text.ToString();

                return match;
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                run = false;
                queryRunMenu.Enabled = true;
                killToolStripMenuItem.Enabled = false;
                return 0;
            }
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                TabPage qTab = getSelectedTab();
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                //RichTextBox rtBox = getSelectedResultTextBox(qTab);
                //RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                FilterForm filterfrm = new FilterForm(rBox);
                filterfrm.Show();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                TabPage qTab = getSelectedTab();
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                //RichTextBox rtBox = getSelectedResultTextBox(qTab);
                //RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                ReplaceForm replacefrm = new ReplaceForm(rBox);
                replacefrm.Show();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void resultGrid_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void uniqToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                doUniq();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void doubleToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                doDouble();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void autoCaseToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                TabPage qTab = getSelectedTab();
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                //RichTextBox rtBox = getSelectedResultTextBox(qTab);
                //RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                AutoCaseForm casefrm = new AutoCaseForm(rBox);
                casefrm.Show();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void resultGrid_CellClick(object sender, DataGridViewCellEventArgs e) {
            cellColumn = e.ColumnIndex;
            cellRow = e.RowIndex;
        }

        private void filterToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                TabPage qTab = getSelectedTab();
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                //RichTextBox rtBox = getSelectedResultTextBox(qTab);
                //RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                FilterForm filterfrm = new FilterForm(rBox);
                filterfrm.Show();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                TabPage qTab = getSelectedTab();
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                //RichTextBox rtBox = getSelectedResultTextBox(qTab);
                //RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                SearchForm searchfrm = new SearchForm(rBox);
                searchfrm.Show();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void replaceToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                TabPage qTab = getSelectedTab();
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                //RichTextBox rtBox = getSelectedResultTextBox(qTab);
                //RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                ReplaceForm replacefrm = new ReplaceForm(rBox);
                replacefrm.Show();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void autoCaseToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                TabPage qTab = getSelectedTab();
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                //RichTextBox rtBox = getSelectedResultTextBox(qTab);
                //RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                AutoCaseForm casefrm = new AutoCaseForm(rBox);
                casefrm.Show();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void uniqueToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                doUniq();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void doubleToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                doDouble();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void concatToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                TabPage qTab = getSelectedTab();
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                //RichTextBox rtBox = getSelectedResultTextBox(qTab);
                //RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                ConcatForm concatfrm = new ConcatForm(rBox);
                concatfrm.Show();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void concatToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                TabPage qTab = getSelectedTab();
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                //RichTextBox rtBox = getSelectedResultTextBox(qTab);
                //RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                ConcatForm concatfrm = new ConcatForm(rBox);
                concatfrm.Show();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void alterTableToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if(DatabaseTree.SelectedNode.ImageIndex == 5 || DatabaseTree.SelectedNode.ImageIndex == 5) {
                    if(DatabaseTree.SelectedNode != null) {
                        TableForm tablefrm = new TableForm(QDS, DatabaseTree.SelectedNode.Text.ToString(), "alter");
                        tablefrm.Show();
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        public void errorLog(string origin, Exception e) {
            try {
                parent.errorLog(origin, e);
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void QueryTabs_DrawItem(object sender, DrawItemEventArgs e) {
            if(this.QueryTabs.TabPages[e.Index].Text != "Query") {
                e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
                e.Graphics.DrawString(this.QueryTabs.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            } else {
                e.Graphics.DrawString(this.QueryTabs.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 20, e.Bounds.Top + 4);
                Rectangle rct = new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + 2, 16, 16);
                e.Graphics.DrawIcon(Icon.FromHandle(((Bitmap)QueryIcons.Images[this.QueryTabs.TabPages[e.Index].ImageIndex]).GetHicon()), rct);
            }
            e.DrawFocusRectangle();
        }

        private void QueryTabs_MouseDown(object sender, MouseEventArgs e) {
            Rectangle r = QueryTabs.GetTabRect(this.QueryTabs.SelectedIndex);
            Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 10, 10);
            if(this.QueryTabs.TabPages[this.QueryTabs.SelectedIndex].Text != "Query") {
                if(closeButton.Contains(e.Location)) {
                    this.QueryTabs.TabPages.Remove(this.QueryTabs.SelectedTab);
                }
            }
        }

        private void saveHistoryhstToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        public TabPage getSelectedTab() {
            try {
                return QueryTabs.SelectedTab;
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                return null;
            }
        }

        public RichTextBox getSelectedQueryBox(TabPage qTab) {
            try {
                foreach(SplitContainer qSplit in qTab.Controls) {
                    foreach(RichTextBox qBox in qSplit.Panel1.Controls) {
                        if(qBox.Focused == true || QueryTabs.SelectedTab == qTab) {
                            return qBox;
                        }
                    }
                }
                return null;
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                return null;
            }
        }

        public DataGridView getSelectedResultGridBox(TabPage qTab) {
            try {
                foreach(SplitContainer qSplit in qTab.Controls) {
                    foreach(TabControl rTabsC in qSplit.Panel2.Controls) {
                        foreach(TabPage rTab in rTabsC.TabPages) {
                            foreach(object rGVo in rTab.Controls) {
                                if(rGVo.GetType() == typeof(DataGridView)) {
                                    DataGridView rGV = (DataGridView)rGVo;
                                    if(rGV.Name.Contains("resultGrid")) {
                                        return rGV;
                                    }
                                }
                            }
                        }
                    }
                }
                return null;
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                return null;
            }
        }

        public TabControl getSelectedResultTabs(TabPage qTab) {
            try {
                foreach(SplitContainer qSplit in qTab.Controls) {
                    foreach(TabControl rTabsC in qSplit.Panel2.Controls) {
                        return rTabsC;
                    }
                }
                return null;
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                return null;
            }
        }

        public RichTextBox getSelectedResultTextBox(TabPage qTab) {
            try {
                foreach(SplitContainer qSplit in qTab.Controls) {
                    foreach(TabControl rTabsC in qSplit.Panel2.Controls) {
                        foreach(TabPage rTab in rTabsC.TabPages) {
                            foreach(object rRTFo in rTab.Controls) {
                                if(rRTFo.GetType() == typeof(RichTextBox)) {
                                    RichTextBox rRTF = (RichTextBox)rRTFo;
                                    if(rRTF.Name.Contains("resultTextBox")) {
                                        return rRTF;
                                    }
                                }
                            }
                        }
                    }
                }
                return null;
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                return null;
            }
        }

        public RichTextBox getSelectedResultHistoryBox(TabPage qTab) {
            try {
                foreach(SplitContainer qSplit in qTab.Controls) {
                    foreach(TabControl rTabsC in qSplit.Panel2.Controls) {
                        foreach(TabPage rTab in rTabsC.TabPages) {
                            foreach(object rRTFo in rTab.Controls) {
                                if(rRTFo.GetType() == typeof(RichTextBox)) {
                                    RichTextBox rRTF = (RichTextBox)rRTFo;
                                    if(rRTF.Name.Contains("resultHistoryTextBox")) {
                                        return rRTF;
                                    }
                                }
                            }
                        }
                    }
                }
                return null;
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                return null;
            }
        }

        private void resultToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void hashToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                TabPage qTab = getSelectedTab();
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                //RichTextBox rtBox = getSelectedResultTextBox(qTab);
                //RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                HashForm hashFrm = new HashForm(rBox);
                hashFrm.Show();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void hashToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                TabPage qTab = getSelectedTab();
                //RichTextBox qBox = getSelectedQueryBox(qTab);
                DataGridView rBox = getSelectedResultGridBox(qTab);
                //RichTextBox rtBox = getSelectedResultTextBox(qTab);
                //RichTextBox rhBox = getSelectedResultHistoryBox(qTab);
                HashForm hashFrm = new HashForm(rBox);
                hashFrm.Show();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void createTableToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if(DatabaseTree.SelectedNode.ImageIndex == 5 || DatabaseTree.SelectedNode.ImageIndex == 5) {
                    if(DatabaseTree.SelectedNode != null) {
                        TableForm tablefrm = new TableForm(QDS, "", "create");
                        tablefrm.Show();
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void truncateTableToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if(DatabaseTree.SelectedNode.ImageIndex == 5 || DatabaseTree.SelectedNode.ImageIndex == 5) {
                    if(DatabaseTree.SelectedNode != null) {
                        TableForm tablefrm = new TableForm(QDS, DatabaseTree.SelectedNode.Text.ToString(), "truncate");
                        tablefrm.Show();
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void dropTableToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if(DatabaseTree.SelectedNode.ImageIndex == 5 || DatabaseTree.SelectedNode.ImageIndex == 5) {
                    if(DatabaseTree.SelectedNode != null) {
                        TableForm tablefrm = new TableForm(QDS, DatabaseTree.SelectedNode.Text.ToString(), "drop");
                        tablefrm.Show();
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e) {
            if(DatabaseTree.SelectedNode.ImageIndex == 5 || DatabaseTree.SelectedNode.ImageIndex == 5) {
                if(DatabaseTree.SelectedNode != null) {
                    ExportForm tablefrm = new ExportForm(QDS, DatabaseTree.SelectedNode.Text.ToString());
                    tablefrm.Show();
                }
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e) {
            if(DatabaseTree.SelectedNode.ImageIndex == 5 || DatabaseTree.SelectedNode.ImageIndex == 5) {
                if(DatabaseTree.SelectedNode != null) {
                    ImportForm tablefrm = new ImportForm(QDS, DatabaseTree.SelectedNode.Text.ToString());
                    tablefrm.Show();
                }
            }
        }

    }
}
