﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using QueryIT.model;
using IPlugin;
using AutocompleteMenuNS;

namespace QueryIT {
    public partial class ForeachForm : Form {

        private MainForm parent;
        private String LicenseInformation = "";

        public PluginCore plugincore = new PluginCore(Environment.CurrentDirectory);
        public Datasource LDS;
        public Datasource RDS;
        public bool run = false;
        public bool isMoved = false;

        public DateTime utcStart;
        public DateTime utcStop;

        public int previewPos = 0;

        public ForeachForm() {
            InitializeComponent();
        }

        public ForeachForm(Datasource LeftDS, Datasource RightDS) {
            LDS = LeftDS;
            RDS = RightDS;
            InitializeComponent();
        }

        public void loadPlugins() {
            try {
                Array pls = plugincore.getPlugins(LicenseInformation);
                foreach(Object pl in pls) {
                    if(plugincore.Hook(pl.ToString()) == pluginHook.ForEach || plugincore.Hook(pl.ToString()) == pluginHook.All) {
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

        private void ForeachForm_Load(object sender, EventArgs e) {
            parent = this.MdiParent as MainForm;
            LicenseInformation = parent.LicenseInformation;
            try {
                loadPlugins();
                doLoad();
                reloadSchema();
                doResize();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void MenuItemClickHandler(object sender, EventArgs e) {
            try {
                ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
                if(plugincore.Type(clickedItem.Name.ToString()) == pluginType.Import) {
                    LDS.result = plugincore.Process(clickedItem.Name.ToString(), LDS.result, "");
                }
                if(plugincore.Type(clickedItem.Name.ToString()) == pluginType.Filter) {
                    LDS.result = plugincore.Process(clickedItem.Name.ToString(), LDS.result, "");
                }
                if(plugincore.Type(clickedItem.Name.ToString()) == pluginType.Export) {
                    LDS.result = plugincore.Process(clickedItem.Name.ToString(), LDS.result, "");
                }
                if(plugincore.Type(clickedItem.Name.ToString()) == pluginType.Other) {
                    LDS.result = plugincore.Process(clickedItem.Name.ToString(), LDS.result, "");
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        public void doLoad() {
            try {
                foreach(DataColumn col in LDS.result.Columns) {
                    placeholderList.Items.Add("#" + col.Caption.ToString() + "#");
                }
                previewPosLbl.Text = previewPos.ToString() + "/" + LDS.row_count.ToString();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), err);
            }
        }

        public void doResize() {
            try {
                if(this.WindowState == FormWindowState.Normal && isMoved == false) {
                    this.Top = 0;
                    this.Left = (this.Parent.Width / 4) - 5;
                    this.Height = this.Parent.Height - 5;
                    this.Width = (this.Parent.Width / 2) - 5;
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                run = true;
                runToolStripMenuItem.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                if(LicenseInformation.Contains("ForEach") == false) {
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
                utcStart = DateTime.UtcNow;
                loopHistoryBox.Text = "";
                loopResultBox.Text = "";

                ProgressForm pform = new ProgressForm(this, "Progress [ForEach]");
                pform.update(0, LDS.row_count, 0);
                pform.Show();

                string query = sqlBox.Text;
                string queryv = query;
                int pos = 0;
                foreach(DataRow row in LDS.result.Rows) {
                    queryv = query;
                    foreach(DataColumn col in LDS.result.Columns) {
                        if(queryv.ToLower().Contains("#" + col.Caption.ToString().ToLower() + "#")) {
                            queryv = queryv.Replace("#" + col.Caption.ToString().ToLower() + "#", row[col.Ordinal].ToString());
                        }
                    }

                    if(RDS.executeSql(queryv)) {
                        loopResultBox.Text = "Date: " + RDS.utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                             "Result: " + RDS.row_count.ToString() + " Records\n" +
                                             "Query: '" + RDS.sql.ToString() + "'\n";
                        loopHistoryBox.Text = "Date: " + RDS.utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                              "Result: " + RDS.row_count.ToString() + " Records\n" +
                                              "Query: '" + RDS.sql.ToString() + "'\n" +
                                              "\n" + loopHistoryBox.Text.ToString();

                    } else {
                        loopResultBox.Text = "Date: " + RDS.utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                             "Error: " + RDS.error.ToString() + "\n" +
                                             "Query: '" + RDS.sql.ToString() + "'\n";
                        loopHistoryBox.Text = "Date: " + RDS.utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                              "Error: " + RDS.error.ToString() + "\n" +
                                              "Query: '" + RDS.sql.ToString() + "'\n" +
                                              "\n" + loopHistoryBox.Text.ToString();
                        run = false;
                    }
                    pos++;
                    if(pos % 250 == 0) {
                        pform.update(0, LDS.row_count, pos);
                        Application.DoEvents();
                    }
                    if(run == false) {
                        break;
                    }
                }

                pform.Hide();
                pform.Dispose();
                run = false;
                runToolStripMenuItem.Enabled = true;
                killToolStripMenuItem.Enabled = false;
                utcStop = DateTime.UtcNow;
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                run = false;
                runToolStripMenuItem.Enabled = true;
                killToolStripMenuItem.Enabled = false;
            }
        }

        private void killToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                run = false;
                LDS.run = false;
                LDS.cancelSQL();
                RDS.run = false;
                RDS.cancelSQL();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                //if(File.Exists(qitfilepath) == true) {
                //    //File.WriteAllText(qitfilepath, queryBox.Text.ToString());
                //} else {
                //    using(var sfd = new SaveFileDialog()) {
                //        sfd.Filter = "QueryIT files (*.qit)|*.qit|All files (*.*)|*.*";
                //        sfd.FilterIndex = 1;

                //        if(sfd.ShowDialog() == DialogResult.OK) {
                //            //qitfilepath = sfd.FileName;
                //            //File.WriteAllText(sfd.FileName, queryBox.Text.ToString());
                //        }
                //    }
                //}
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                using(var sfd = new OpenFileDialog()) {
                    sfd.Filter = "QueryIT files (*.qit)|*.qit|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;

                    if(sfd.ShowDialog() == DialogResult.OK) {
                        //qitfilepath = sfd.FileName;
                        //queryBox.Text = File.ReadAllText(sfd.FileName);
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void ForeachForm_Resize(object sender, EventArgs e) {
            //isMoved = true;
            //doResize();
        }

        private void ForeachForm_Move(object sender, EventArgs e) {
            //isMoved = true;
        }

        private void ForeachForm_Activated(object sender, EventArgs e) {
            try {
                doLoad();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void ForeachForm_FormClosing(object sender, FormClosingEventArgs e) {
            try {
                run = false;
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                using(var sfd = new SaveFileDialog()) {
                    sfd.Filter = "QueryIT files (*.qit)|*.qit|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;

                    if(sfd.ShowDialog() == DialogResult.OK) {
                        //qitfilepath = sfd.FileName;
                        //File.WriteAllText(sfd.FileName, queryBox.Text.ToString());
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void sqlBox_TextChanged(object sender, EventArgs e) {
            try {
                sqlBox.SyntaxHighlight();
                doPreviewSQL();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void sqlPreviewBox_TextChanged(object sender, EventArgs e) {
            try {
                //sqlPreviewBox.SyntaxHighlight();
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
                Array.Sort(SQLSyntax.SQLdarkgreen);
                foreach(var key in SQLSyntax.SQLdarkgreen) {
                    acitems.Add(new AutocompleteItem(key.ToString()) { ImageIndex = 0 });
                }
                //TreeView
                string database = RDS.database;
                if(RDS.DBschema.Databases != null) {
                    foreach(DatabaseSchema db in RDS.DBschema.Databases) {
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
                            if(RDS.conectionString.Contains("Microsoft Text Driver")) {
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

        public void doPreviewSQL() {
            try {
                sqlPreviewBox.Text = sqlBox.Text;
                DataRow row = LDS.result.Rows[previewPos];
                foreach(DataColumn col in LDS.result.Columns) {
                    if(sqlPreviewBox.Text.ToLower().Contains("#" + col.Caption.ToString().ToLower() + "#")) {
                        sqlPreviewBox.Text = sqlPreviewBox.Text.Replace("#" + col.Caption.ToString().ToLower() + "#", row[col.Ordinal].ToString());
                    }
                }
                sqlPreviewBox.SyntaxHighlight();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void historyCheck_CheckedChanged(object sender, EventArgs e) {

        }

        private void placeholderList_SelectedIndexChanged(object sender, EventArgs e) {
            sqlBox.SelectedText = placeholderList.Items[placeholderList.SelectedIndex].ToString();
        }

        private void prevBtn_Click(object sender, EventArgs e) {
            if (previewPos <= 0) {
                previewPos = 0;
            } else {
                previewPos -=1;
            }
            previewPosLbl.Text = previewPos.ToString() + "/" + LDS.row_count.ToString();
            doPreviewSQL();
        }

        private void nextBtn_Click(object sender, EventArgs e) {
            if(previewPos >= LDS.row_count) {
                previewPos = LDS.row_count;
            } else {
                previewPos += 1;
            }
            previewPosLbl.Text = previewPos.ToString() + "/" + LDS.row_count.ToString();
            doPreviewSQL();
        }

    }
}
