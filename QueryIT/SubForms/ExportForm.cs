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
                        runToolStripMenuItem.Enabled = true;
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
                int exported = 0;
                int chunk = 1000;
                int offset = 0;
                bool header = true;
                StringBuilder sb = new StringBuilder();
                if(File.Exists(exportFile.Text.ToString())) {
                    File.Delete(exportFile.Text.ToString());
                }
                ProgressForm pform = new ProgressForm(this, "Progress [Export - " + table + "]");
                pform.update(0, chunk, 0);
                pform.Show();
                while(DS.executeSql("SELECT * FROM `" + table + "` LIMIT " + offset + "," + chunk) && run == true) {
                    Application.DoEvents();
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
                            exported++;
                            offset++;
                        }
                        pform.update(0, offset, exported);
                        Application.DoEvents();
                        File.AppendAllText(exportFile.Text.ToString(), sb.ToString());
                    } else {
                        run = false;
                    }
                }
                pform.Hide();
                pform.Dispose();
                run = false;
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
                runToolStripMenuItem.Enabled = true;
                tableBox.Items.Clear();
                foreach(TableSchema tbl in DS.DBschema.D[database].Tables) {
                    tableBox.Items.Add(tbl.TableName);
                }
                tableBox.Text = table.ToString();
                tableGrid.Columns.Clear();
                tableGrid.Rows.Clear();
                //Column Mapping
                tableGrid.Columns.Add("Name", "Column Name");  //1
                tableGrid.Columns.Add("DT", "Data Type");      //2
                tableGrid.Columns.Add("PK", "PK");  //3
                tableGrid.Columns.Add("NN", "NN");       //4
                tableGrid.Columns.Add("UN", "UN");         //5
                tableGrid.Columns.Add("AI", "AI"); //6
                tableGrid.Columns.Add("DV", "Default");
                tableGrid.RowHeadersWidth = 65;
                //Width
                DataGridViewColumn column = tableGrid.Columns[0];
                column.Width = 120;
                column = tableGrid.Columns[1];
                column.Width = 100;
                column = tableGrid.Columns[2];
                column.Width = 25;
                column = tableGrid.Columns[3];
                column.Width = 25;
                column = tableGrid.Columns[4];
                column.Width = 25;
                column = tableGrid.Columns[5];
                column.Width = 25;
                column = tableGrid.Columns[6];
                column.Width = 120;
                foreach(ColumnSchema col in DS.DBschema.D[database].T[table].Columns) {
                    DataGridViewRow row = (DataGridViewRow)tableGrid.Rows[0].Clone();
                    row.HeaderCell.Value = col.ColumnPosition.ToString();
                    row.Cells[0].Value = col.ColumnName;
                    DataGridViewComboBoxCell vCellComboDataType = new DataGridViewComboBoxCell();
                    foreach(string dst in Datasource.DBDataTypes) {
                        vCellComboDataType.Items.Add(dst.ToString());
                    }
                    //Hack for custom Datatypes, fix this someday
                    if(vCellComboDataType.Items.Contains(col.DataType) == false) {
                        vCellComboDataType.Items.Add(col.DataType);
                    }
                    if(vCellComboDataType.Items.IndexOf(col.DataType) != -1) {
                        vCellComboDataType.Value = vCellComboDataType.Items[vCellComboDataType.Items.IndexOf(col.DataType)];
                    } else {
                        vCellComboDataType.Value = vCellComboDataType.Items[0];
                    }
                    vCellComboDataType.FlatStyle = FlatStyle.Standard;
                    vCellComboDataType.MaxDropDownItems = vCellComboDataType.Items.Count;
                    row.Cells[1].Value = vCellComboDataType.Value;
                    row.Cells[1] = vCellComboDataType;
                    DataGridViewCheckBoxCell vCheckPKey = new DataGridViewCheckBoxCell();
                    vCheckPKey.Value = col.PrimaryKey;
                    row.Cells[2] = vCheckPKey;
                    DataGridViewCheckBoxCell vCheckNN = new DataGridViewCheckBoxCell();
                    vCheckNN.Value = col.NotNull;
                    row.Cells[3] = vCheckNN;
                    DataGridViewCheckBoxCell vCheckUN = new DataGridViewCheckBoxCell();
                    vCheckUN.Value = col.Unique;
                    row.Cells[4] = vCheckUN;
                    DataGridViewCheckBoxCell vCheckAI = new DataGridViewCheckBoxCell();
                    vCheckAI.Value = col.AutoIncrement;
                    row.Cells[5] = vCheckAI;
                    row.Cells[6].Value = col.DefaultValue.ToString();
                    tableGrid.Rows.Add(row);
                }

                fileGrid.Columns.Clear();
                fileGrid.Rows.Clear();
                fileGrid.Columns.Add("Destination", "Column Name");
                fileGrid.RowHeadersWidth = 65;
                column = fileGrid.Columns[0];
                column.Width = 120;
                column = tableGrid.Columns[1];
                column.Width = 100;
                foreach(ColumnSchema col in DS.DBschema.D[database].T[table].Columns) {
                    DataGridViewRow row = (DataGridViewRow)fileGrid.Rows[0].Clone();
                    row.HeaderCell.Value = col.ColumnPosition.ToString();
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

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e) {

        }

    }
}
