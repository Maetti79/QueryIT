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
    public partial class QueryForm : Form {
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

        public QueryForm() {
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

        public QueryForm(Datasource ds, string a) {
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
                        if(queryBox.Text.Length == 0) {
                            if(table.Contains(".csv")) {
                                queryBox.Text = "SELECT * FROM `" + DatabaseTree.SelectedNode.Text.ToString() + "`;";
                            } else {
                                queryBox.Text = "SELECT * FROM `" + database + "`.`" + DatabaseTree.SelectedNode.Text.ToString() + "` LIMIT 100;";
                            }
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

        private void QueryForm_Load(object sender, EventArgs e) {
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

                if(queryBox.Text.Length > 0) {
                    DT = new DataTable();
                    DT.Clear();
                    cellRow = -1;
                    cellColumn = -1;
                    if(QDS.executeSql(queryBox.Text.ToString())) {
                        resultGrid.Columns.Clear();
                        resultGrid.DataSource = null;
                        if(QDS.hasResult() == true) {
                            //Needed to Copy for Cell Edit
                            DT = QDS.result.Copy();
                            QueryTabs.SelectTab(0);
                        } else {
                            QueryTabs.SelectTab(1);
                        }
                        resultGrid.DataSource = DT;
                        resultGrid.Refresh();

                        resultBox.Text = "Date: " + QDS.utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                          "Result: " + QDS.row_count.ToString() + " Records\n" +
                                          "Query: '" + QDS.sql.ToString() + "'\n";

                        historyBox.Text = "Date: " + QDS.utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                          "Result: " + QDS.row_count.ToString() + " Records\n" +
                                          "Query: '" + QDS.sql.ToString() + "'\n" +
                                          "\n" + historyBox.Text.ToString();

                        QueryTabs.SelectedTab = queryTab;
                    } else {
                        QueryTabs.SelectTab(1);
                        if(QDS.hasErrors() == true) {
                            resultBox.Text = "Date: " + QDS.utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + "\n" +
                                             "Query: '" + QDS.sql.ToString() + "'\n" +
                                             "Error: " + QDS.error.ToString() + "\n";
                            QueryTabs.SelectedTab = resultTab;
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

        private void QueryForm_Resize(object sender, EventArgs e) {
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
                queryBox.Text = "";
                sqlfilepath = "";
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void savesqlToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if(File.Exists(sqlfilepath) == true) {
                    File.WriteAllText(sqlfilepath, queryBox.Text.ToString());
                } else {
                    using(var sfd = new SaveFileDialog()) {
                        sfd.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*";
                        sfd.FilterIndex = 1;

                        if(sfd.ShowDialog() == DialogResult.OK) {
                            sqlfilepath = sfd.FileName;
                            File.WriteAllText(sfd.FileName, queryBox.Text.ToString());
                        }
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void loadsqlToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                using(var sfd = new OpenFileDialog()) {
                    sfd.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;

                    if(sfd.ShowDialog() == DialogResult.OK) {
                        sqlfilepath = sfd.FileName;
                        queryBox.Text = File.ReadAllText(sfd.FileName);
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void QueryForm_Move(object sender, EventArgs e) {
            //isMoved = true;
        }

        private void queryBox_TextChanged(object sender, EventArgs e) {
            try {
                queryBox.SyntaxHighlight();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }
        
        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                // if (e.Control && e.KeyCode == Keys.D)
                // {
                using(var sfd = new DateTimeForm()) {

                    if(sfd.ShowDialog() == DialogResult.OK) {
                        queryBox.SelectedText = "'" + sfd.DateTimeStr + "'";
                    }
                }
                // }
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

        private void QueryForm_FormClosing(object sender, FormClosingEventArgs e) {
            run = false;
            QDS.run = false;
            QDS.disconnect();
        }

        private void DatabaseTree_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                if(DatabaseTree.SelectedNode.ImageIndex == 1 || DatabaseTree.SelectedNode.ImageIndex == 2) {
                    database = DatabaseTree.SelectedNode.Text.ToString();
                    foreach(TreeNode node in DatabaseTree.Nodes) {
                        node.NodeFont = new Font(DatabaseTree.Font, FontStyle.Regular);
                    }
                    if(DatabaseTree.SelectedNode != null) {
                        DatabaseTree.SelectedNode.NodeFont = new Font(DatabaseTree.Font, FontStyle.Bold);
                    }
                }
                if(DatabaseTree.SelectedNode.ImageIndex == 3 || DatabaseTree.SelectedNode.ImageIndex == 4) {
                    database = DatabaseTree.SelectedNode.Text.ToString();
                    foreach(TreeNode node in DatabaseTree.Nodes) {
                        node.NodeFont = new Font(DatabaseTree.Font, FontStyle.Regular);
                    }
                    if(DatabaseTree.SelectedNode != null) {
                        DatabaseTree.SelectedNode.NodeFont = new Font(DatabaseTree.Font, FontStyle.Bold);
                    }
                }
                if(DatabaseTree.SelectedNode.ImageIndex == 5 ){
                    table =  DatabaseTree.SelectedNode.Text.ToString();
                }
                if(DatabaseTree.SelectedNode.ImageIndex == 6) {
                    column = DatabaseTree.SelectedNode.Text.ToString();
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        public void reloadSchema() {
            try {
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
                autocomplete.SetAutocompleteItems(acitems);
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
                using(var sfd = new SaveFileDialog()) {
                    sfd.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;

                    if(sfd.ShowDialog() == DialogResult.OK) {
                        sqlfilepath = sfd.FileName;
                        File.WriteAllText(sfd.FileName, queryBox.Text.ToString());
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void saveSQLToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
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
                foreach(DataGridViewRow r in resultGrid.Rows) {
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
                SearchForm searchfrm = new SearchForm(resultGrid);
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
                search = true;
                run = true;
                queryRunMenu.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                resultGrid.CurrentCell = null;
                utcStart = DateTime.UtcNow;
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

                foreach(DataGridViewRow r in resultGrid.Rows) {
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
                resultBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                 "Result: " + match.ToString() + " Changed Records\n" +
                                 "Tool: AutoCase(" + Autocase.ToString() + ")\n";

                historyBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                  "Result: " + match.ToString() + " Changed Records\n" +
                                  "Tool: AutoCase(" + Autocase.ToString() + ")\n" +
                                  "\n" + historyBox.Text.ToString();
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
                search = true;
                run = true;
                queryRunMenu.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                resultGrid.CurrentCell = null;
                utcStart = DateTime.UtcNow;
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

                foreach(DataGridViewRow r in resultGrid.Rows) {
                    if(r.IsNewRow == false) {
                        foreach(DataGridViewCell c in r.Cells) {
                            if(columns.Contains(c.OwningColumn.Name.ToString())) {
                                if(c.Value != null) {
                                    if(c.Value != null) {
                                        if(Hash == "MD5") {
                                            c.Value = c.Value.ToString().checksum();
                                        } else if(Hash == "SHA-1") {
                                            c.Value = c.Value.ToString().checksum();
                                        }
                                        match++;
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
                resultBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                 "Result: " + match.ToString() + " Hashed Records\n" +
                                 "Tool: AutoCase(" + Hash.ToString() + ")\n";

                historyBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                  "Result: " + match.ToString() + " Hashed Records\n" +
                                  "Tool: AutoCase(" + Hash.ToString() + ")\n" +
                                  "\n" + historyBox.Text.ToString();
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
                search = true;
                run = true;
                queryRunMenu.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                resultGrid.CurrentCell = null;
                utcStart = DateTime.UtcNow;
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

                foreach(DataGridViewRow r in resultGrid.Rows) {
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
                resultBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                 "Result: " + match.ToString() + " Changed Records\n" +
                                 "Tool: Concat(" + column.ToString() + ", " + before.ToString() + ", " + after.ToString() + ")\n";

                historyBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                  "Result: " + match.ToString() + " Changed Records\n" +
                                  "Tool: Concat(" + column.ToString() + ", " + before.ToString() + ", " + after.ToString() + ")\n" +
                                  "\n" + historyBox.Text.ToString();
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
                search = true;
                run = true;
                queryRunMenu.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                resultGrid.CurrentCell = null;
                utcStart = DateTime.UtcNow;
                foreach(DataGridViewRow r in resultGrid.Rows) {
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
                resultBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                 "Result: " + match.ToString() + " Replaced Records\n" +
                                 "Tool: Filter(" + searchstring.ToString() + ", " + replacestring.ToString() + ")\n";

                historyBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                  "Result: " + match.ToString() + " Replaced Records\n" +
                                  "Tool: Filter(" + searchstring.ToString() + ", " + replacestring.ToString() + ")\n" +
                                  "\n" + historyBox.Text.ToString();
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
                resultGrid.CurrentCell = null;
                ProgressForm pform = new ProgressForm(this, "Progress [Filter]");
                pform.update(0, resultGrid.Rows.Count, 0);
                pform.Show();
                utcStart = DateTime.UtcNow;
                foreach(DataGridViewRow r in resultGrid.Rows) {
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
                        pform.update(0, resultGrid.Rows.Count, loops);
                        Application.DoEvents();
                        resultGrid.Refresh();
                    }
                }
                utcStop = DateTime.UtcNow;
                pform.Hide();
                pform.Dispose();
                search = false;
                run = false;
                queryRunMenu.Enabled = true;
                killToolStripMenuItem.Enabled = false;

                resultBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                 "Result: " + match.ToString() + " Filtered Records\n" +
                                 "Tool: Filter(" + searchstring.ToString() + ")\n";

                historyBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                  "Result: " + match.ToString() + " Filtered Records\n" +
                                  "Tool: Filter(" + searchstring.ToString() + ")\n" +
                                  "\n" + historyBox.Text.ToString();
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
                search = true;
                run = true;
                queryRunMenu.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                utcStart = DateTime.UtcNow;
                foreach(DataGridViewRow r in resultGrid.Rows) {
                    if(r.IsNewRow == false) {
                        foreach(DataGridViewCell c in r.Cells) {
                            if(columns.Contains(c.OwningColumn.Name.ToString())) {
                                if(c.Value != null) {
                                    if(casesensetive == true) {
                                        if(exact == true) {
                                            if(c.Value.ToString().Equals(searchstring.ToString(), StringComparison.CurrentCulture) == true) {
                                                if(match == offset) {
                                                    resultGrid.CurrentCell = resultGrid.Rows[c.RowIndex].Cells[c.ColumnIndex];
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
                                                    resultGrid.CurrentCell = resultGrid.Rows[c.RowIndex].Cells[c.ColumnIndex];
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
                                                    resultGrid.CurrentCell = resultGrid.Rows[c.RowIndex].Cells[c.ColumnIndex];
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
                                                    resultGrid.CurrentCell = resultGrid.Rows[c.RowIndex].Cells[c.ColumnIndex];
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
                ProgressForm pform = new ProgressForm(this, "Progress [Unique]");
                pform.update(0, DT.Rows.Count, 0);
                pform.Show();
                run = true;
                queryRunMenu.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                utcStart = DateTime.UtcNow;
                while(indexS < DT.Rows.Count && run == true) {
                    indexD = 0;
                    while(indexD < DT.Rows.Count && run == true) {
                        if(indexS != indexD) {
                            if(indexS < DT.Rows.Count && indexD < DT.Rows.Count) {
                                if(DT.Rows[indexS].ItemArray.arrEquals(DT.Rows[indexD].ItemArray) == true) {
                                    DT.Rows[indexD].Delete();
                                    match++;
                                }
                            }
                        }
                        indexD++;
                        loops++;
                        if(loops % 250 == 0) {
                            pform.update(0, DT.Rows.Count, indexS);
                            Application.DoEvents();
                        }
                    }
                    if(indexD == DT.Rows.Count) {
                        indexS++;
                    }
                }
                utcStop = DateTime.UtcNow;
                pform.Hide();
                pform.Dispose();
                run = false;
                queryRunMenu.Enabled = true;
                killToolStripMenuItem.Enabled = false;

                resultBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                          "Result: " + DT.Rows.Count.ToString() + " Unique Records\n" +
                                          "Tool: Unique()\n";

                historyBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                         "Result: " + DT.Rows.Count.ToString() + " Unique Records\n" +
                                         "Tool: Unique()\n" +
                                         "\n" + historyBox.Text.ToString();
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
                ProgressForm pform = new ProgressForm(this, "Progress [Double]");
                pform.update(0, DT.Rows.Count, 0);
                pform.Show();
                run = true;
                queryRunMenu.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                utcStart = DateTime.UtcNow;
                while(indexS < DT.Rows.Count && run == true) {
                    indexD = 0;
                    match = 0;
                    while(indexD < DT.Rows.Count && run == true) {
                        if(indexS != indexD) {
                            if(indexS < DT.Rows.Count && indexD < DT.Rows.Count) {
                                if(DT.Rows[indexS].ItemArray.arrEquals(DT.Rows[indexD].ItemArray) == true) {
                                    match++;
                                }
                            }
                        }
                        indexD++;
                        loops++;
                        if(loops % 250 == 0) {
                            pform.update(0, DT.Rows.Count, indexS + keep);
                            Application.DoEvents();
                        }
                    }
                    if(match == 0) {
                        DT.Rows[indexS].Delete();
                    } else {
                        keep++;
                        if(indexD == DT.Rows.Count) {
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

                resultBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                         "Result: " + keep.ToString() + " Doublicate Records\n" +
                                         "Tool: Double()\n";

                historyBox.Text = "Date: " + utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                         "Result: " + keep.ToString() + " Doublicate Records\n" +
                                         "Tool: Double()\n" +
                                         "\n" + historyBox.Text.ToString();

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
                FilterForm filterfrm = new FilterForm(resultGrid);
                filterfrm.Show();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                ReplaceForm replacefrm = new ReplaceForm(resultGrid);
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
                AutoCaseForm casefrm = new AutoCaseForm(resultGrid);
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
                FilterForm filterfrm = new FilterForm(resultGrid);
                filterfrm.Show();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                SearchForm searchfrm = new SearchForm(resultGrid);
                searchfrm.Show();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void replaceToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                ReplaceForm replacefrm = new ReplaceForm(resultGrid);
                replacefrm.Show();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void autoCaseToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                AutoCaseForm casefrm = new AutoCaseForm(resultGrid);
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
                ConcatForm concatfrm = new ConcatForm(resultGrid);
                concatfrm.Show();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void concatToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                ConcatForm concatfrm = new ConcatForm(resultGrid);
                concatfrm.Show();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void alterTableToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if(DatabaseTree.SelectedNode.ImageIndex == 5 || DatabaseTree.SelectedNode.ImageIndex == 5) {
                    if(DatabaseTree.SelectedNode != null) {
                        TableForm tablefrm = new TableForm(this);
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

        private void hashToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                HashForm hashFrm = new HashForm(resultGrid);
                hashFrm.Show();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void hashToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                HashForm hashFrm = new HashForm(resultGrid);
                hashFrm.Show();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

    }
}
