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
using QueryIT.model;
using IPlugin;

namespace QueryIT {
    public partial class MoveForm : Form {

        private MainForm parent;
        private String LicenseInformation = "";

        public Core plugincore = new Core(Environment.CurrentDirectory);
        public Datasource LDS;
        public Datasource RDS;
        public bool run = false;
        public bool isMoved = false;
        public string qitfilepath = "";

        public DateTime utcStart;
        public DateTime utcStop;
        int records_moved = 0;
        int rps = 0;

        public MoveForm() {
            InitializeComponent();
        }

        public MoveForm(Datasource leftDS, Datasource rightDS) {
            LDS = leftDS;
            RDS = rightDS;
            InitializeComponent();
        }

        public void loadPlugins() {
            try {
                Array pls = plugincore.getPlugins(LicenseInformation);
                foreach(Object pl in pls) {
                    if(plugincore.Hook(pl.ToString()) == pluginHook.Mover || plugincore.Hook(pl.ToString()) == pluginHook.All) {
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

        private void MoveForm_Load(object sender, EventArgs e) {
            parent = this.MdiParent as MainForm;
            LicenseInformation = parent.LicenseInformation;
            try {
                loadPlugins();
                doLoad();
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
                moveProgress.Minimum = 0;
                if(LDS.row_count > 0) {
                    moveProgress.Maximum = LDS.row_count;
                } else {
                    moveProgress.Maximum = LDS.result.Rows.Count;
                }
                recordsLbl.Text = LDS.result.Rows.Count.ToString() + " Records";
                if(moveMapGrid.Rows.Count != LDS.result.Rows.Count) {
                    moveMapGrid.Columns.Clear();
                    moveMapGrid.Rows.Clear();
                    moveMapGrid.Columns.Add("Source", "Name (Source)");
                    moveMapGrid.Columns.Add("Type", "DataType");
                    moveMapGrid.Columns.Add("Destination", "Name (Destination)");

                    if(LDS.hasErrors() == false && LDS.hasResult() == true && RDS.hasErrors() == false && RDS.hasResult() == true) {
                        runToolStripMenuItem.Enabled = true;
                        foreach(DataColumn lcol in LDS.result.Columns) {
                            DataGridViewRow row = (DataGridViewRow)moveMapGrid.Rows[0].Clone();
                            row.Cells[0].Value = lcol.Caption.ToString();
                            row.Cells[1].Value = lcol.DataType.ToString().Replace("System.", "");

                            DataGridViewComboBoxCell vComboCell = new DataGridViewComboBoxCell();
                            vComboCell.Items.Add("(skip column)");
                            foreach(DataColumn rcol in RDS.result.Columns) {
                                vComboCell.Items.Add(rcol.Caption.ToString());
                            }

                            if(vComboCell.Items.IndexOf(lcol.Caption.ToString()) != -1) {
                                vComboCell.Value = vComboCell.Items[vComboCell.Items.IndexOf(lcol.Caption.ToString())];
                            } else {
                                vComboCell.Value = vComboCell.Items[0];
                            }

                            vComboCell.FlatStyle = FlatStyle.Standard;
                            vComboCell.MaxDropDownItems = RDS.result.Columns.Count;
                            // Datentyp festlegen
                            row.Cells[2].Value = vComboCell.Value;
                            // ComboBox - Zelle setzen
                            row.Cells[2] = vComboCell;
                            moveMapGrid.Rows.Add(row);
                        }
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
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
                if(LicenseInformation.Contains("Move") == false) {
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
                string query = "";
                string queryV = "";
                moveHistoryBox.Text = "";
                moveResultBox.Text = "";
                moveProgress.Minimum = 0;
                records_moved = 0;
                rps = 0;
                statusTimer.Enabled = true;
                if(LDS.row_count > 0) {
                    moveProgress.Maximum = LDS.row_count;
                } else {
                    moveProgress.Maximum = LDS.result.Rows.Count;
                }
                recordsLbl.Text = LDS.result.Rows.Count.ToString() + " Records";
                if(truncateBox.Checked == true) {
                    RDS.executeSql("TRUNCATE `" + RDS.table + "`;");
                }
                query += "INSERT ";
                if(ignoreCheck.Checked == true) {
                    query += "IGNORE ";
                }
                query += "INTO `" + RDS.table + "` (";
                foreach(DataGridViewRow col in moveMapGrid.Rows) {
                    if(col.Cells[2].Value != null) {
                        if(col.Cells[2].Value.ToString() != "(skip column)") {
                            if(RDS.conectionString.Contains("csv") == true) {
                                query += "\"" + col.Cells[2].Value.ToString() + "\",";
                            } else {
                                query += "`" + col.Cells[2].Value.ToString() + "`,";
                            }
                        }
                    }
                }
                query = query.Substring(0, query.Length - 1);
                query += ") ";

                int pos = 0;
                foreach(DataRow row in LDS.result.Rows) {
                    string sqlStr;
                    queryV = "Values(";
                    int colpos = 0;
                    foreach(DataGridViewRow col in moveMapGrid.Rows) {
                        if(col.Cells[2].Value != null) {
                            if(col.Cells[2].Value.ToString() != "(skip column)") {
                                queryV += "'" + row.ItemArray[colpos].ToString() + "',";
                            }
                        }
                        colpos++;
                    }

                    queryV = queryV.Substring(0, queryV.Length - 1);
                    queryV += ");";
                    sqlStr = query + queryV;
                    moveResultBox.Text = sqlStr + "\n";

                    if(RDS.executeSql(sqlStr)) {
                        records_moved++;

                        if(historyCheck.Checked == true) {
                            moveHistoryBox.Text = sqlStr + "\n" + moveHistoryBox.Text;
                        }
                    } else {
                        moveResultBox.Text = RDS.error.ToString() + "\n" + moveResultBox.Text;
                        if(stopCheck.Checked == true) {
                            run = false;
                        }
                    }


                    pos++;
                    moveProgress.Value = pos;
                    posLbl.Text = records_moved.ToString();
                    moveProgress.Refresh();
                    Application.DoEvents();
                    if(run == false) {
                        break;
                    }
                }
                run = false;
                runToolStripMenuItem.Enabled = true;
                killToolStripMenuItem.Enabled = false;
                utcStop = DateTime.UtcNow;
                statusTimer.Enabled = false;
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
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
                if(File.Exists(qitfilepath) == true) {
                    //File.WriteAllText(qitfilepath, queryBox.Text.ToString());
                } else {
                    using(var sfd = new SaveFileDialog()) {
                        sfd.Filter = "QueryIT files (*.qit)|*.qit|All files (*.*)|*.*";
                        sfd.FilterIndex = 1;

                        if(sfd.ShowDialog() == DialogResult.OK) {
                            qitfilepath = sfd.FileName;
                            //File.WriteAllText(sfd.FileName, queryBox.Text.ToString());
                        }
                    }
                }
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
                        qitfilepath = sfd.FileName;
                        //queryBox.Text = File.ReadAllText(sfd.FileName);
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void MoveForm_Resize(object sender, EventArgs e) {
            //isMoved = true;
            //doResize();
        }

        private void MoveForm_Move(object sender, EventArgs e) {
            //isMoved = true;
        }

        private void MoveForm_Activated(object sender, EventArgs e) {
            try {
                doLoad();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void statusTimer_Tick(object sender, EventArgs e) {
            try {
                if(DateTime.UtcNow.Subtract(utcStart).Seconds > 0) {
                    rps = (records_moved / DateTime.UtcNow.Subtract(utcStart).Seconds);
                    statusLabel.Text = "~" + rps + " Records/s";
                    if(rps > 0) {
                        EsimateLbl.Text = "Time left: ~" + (LDS.result.Rows.Count - records_moved) / rps + "s";
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void MoveForm_FormClosing(object sender, FormClosingEventArgs e) {
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
                        qitfilepath = sfd.FileName;
                        //File.WriteAllText(sfd.FileName, queryBox.Text.ToString());
                    }
                }
             } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }
    }
}
