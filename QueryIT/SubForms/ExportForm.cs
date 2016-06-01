using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using QueryIT.model;

namespace QueryIT {
    public partial class ExportForm : Form {

        public Datasource DS;
        public string table;
        public string database;
        public bool run = false;
        public DateTime utcStart;
        public DateTime utcStop;

        public ExportForm() {
            InitializeComponent();
        }

        public ExportForm(Datasource QDS, string t) {
            DS = QDS;
            table = t;
            database = DS.database;
            InitializeComponent();
        }

        private void selectFileBtn_Click(object sender, EventArgs e) {
            try {
                using(var sfd = new SaveFileDialog()) {
                    sfd.Filter = "All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    if(sfd.ShowDialog() == DialogResult.OK) {
                        exportFile.Text = sfd.FileName;
                    }
                }
            } catch(Exception err) {
                throw err;
            }
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                run = true;
                runToolStripMenuItem.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                utcStart = DateTime.UtcNow;

                int chunk = 1000;
                int offset = 0;
                bool header = true;
                StringBuilder sb = new StringBuilder();
                if(File.Exists(exportFile.Text.ToString())) {
                    File.Delete(exportFile.Text.ToString());
                }
                while(DS.executeSql("SELECT * FROM `" + table + "` LIMIT " + offset + "," + chunk) && run == true) {
                    if(DS.hasResult() == false) {
                        run = false;
                    }
                    if(DS.hasErrors() == true) {
                        run = false;
                    }
                    if(header == true) {
                        string line = "";
                        foreach(DataGridViewRow col in fileGrid.Rows) {
                            if(col.Cells[0].Value != null) {
                                if(col.Cells[0].Value.ToString() != "(skip column)") {
                                    line += col.Cells[0].Value.ToString() + ",";
                                }
                            }
                        }
                        line = line.Substring(0, line.Length - 1);
                        sb.Append(line + "\r\n");
                        //IEnumerable<string> columnNames = DS.result.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
                        //sb.AppendLine(string.Join(",", columnNames));
                        header = false;
                    }
                    if(DS.row_count > 0) {
                        foreach(DataRow row in DS.result.Rows) {
                            string line = "";
                            foreach(DataGridViewRow col in fileGrid.Rows) {
                                if(col.Cells[0].Value != null) {
                                    if(col.Cells[0].Value.ToString() != "(skip column)") {
                                        line += row[col.Cells[0].Value.ToString()].ToString() + ",";
                                    }
                                }
                            }
                            line = line.Substring(0, line.Length - 1);
                            sb.Append(line + "\r\n");
                            //IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                            //sb.AppendLine(string.Join(",", fields));
                            offset++;
                        }
                        File.AppendAllText(exportFile.Text.ToString(), sb.ToString());
                    } else {
                        run = false;
                    }
                }
                runToolStripMenuItem.Enabled = true;
                killToolStripMenuItem.Enabled = false;
                utcStop = DateTime.UtcNow;
                this.Close();
            } catch(Exception err) {
                run = false;
                runToolStripMenuItem.Enabled = true;
                killToolStripMenuItem.Enabled = false;
                throw err;
            }
        }



        private void killToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                run = false;
            } catch(Exception err) {
                throw err;
            }
        }

        private void ExportForm_Load(object sender, EventArgs e) {
            doLoad();
        }

        public void doLoad() {
            try {
                tableBox.Items.Clear();
                foreach(TableSchema tbl in DS.DBschema.D[database].Tables) {
                    tableBox.Items.Add(tbl.TableName);
                }
                tableBox.Text = table.ToString();
                tableGrid.Columns.Clear();
                tableGrid.Rows.Clear();
                tableGrid.Columns.Add("Source", "Column Name");
                tableGrid.Columns.Add("Datatype", "Data Type");
                runToolStripMenuItem.Enabled = true;
                foreach(ColumnSchema col in DS.DBschema.D[database].T[table].Columns) {
                    DataGridViewRow row = (DataGridViewRow)tableGrid.Rows[0].Clone();
                    row.Cells[0].Value = col.ColumnName;
                    row.Cells[1].Value = col.DataType;
                    tableGrid.Rows.Add(row);
                }
                fileGrid.Columns.Clear();
                fileGrid.Rows.Clear();
                fileGrid.Columns.Add("Destination", "Column Name");
                foreach(ColumnSchema col in DS.DBschema.D[database].T[table].Columns) {
                    DataGridViewRow row = (DataGridViewRow)fileGrid.Rows[0].Clone();
                    row.Cells[0].Value = col.ColumnName;
                    DataGridViewComboBoxCell vComboCell = new DataGridViewComboBoxCell();
                    vComboCell.Items.Add("(skip column)");
                    foreach(ColumnSchema lcol in DS.DBschema.D[database].T[table].Columns) {
                        vComboCell.Items.Add(lcol.ColumnName);
                    }
                    if(vComboCell.Items.IndexOf(col.ColumnName) != -1) {
                        vComboCell.Value = vComboCell.Items[vComboCell.Items.IndexOf(col.ColumnName)];
                    } else {
                        vComboCell.Value = vComboCell.Items[0];
                    }
                    vComboCell.FlatStyle = FlatStyle.Standard;
                    vComboCell.MaxDropDownItems = vComboCell.Items.Count;
                    // Datentyp festlegen
                    row.Cells[0].Value = vComboCell.Value;
                    // ComboBox - Zelle setzen
                    row.Cells[0] = vComboCell;
                    fileGrid.Rows.Add(row);
                }
            } catch(Exception err) {
                run = false;
                runToolStripMenuItem.Enabled = false;
                killToolStripMenuItem.Enabled = false;
                throw err;
            }
        }

        private void tableBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(tableBox.Text.ToString() != table.ToString()) {
                table = tableBox.Text.ToString();
                doLoad();
            }
        }

    }
}
