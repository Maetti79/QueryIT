using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QueryIT.model;

namespace QueryIT {
    public partial class TableForm : Form {

        public Datasource DS;
        public string table;
        public string command;

        public TableForm() {
            InitializeComponent();
        }

        public TableForm(Datasource QDS, string tbl) {
            DS = QDS;
            table = tbl;
            InitializeComponent();
        }

        public TableForm(Datasource QDS, string tbl, string cmd) {
            DS = QDS;
            table = tbl;
            command = cmd;
            InitializeComponent();
             if(command.ToString() == "truncate") {
                 tableTab.SelectedTab = sqlPage;
             } else if(command.ToString() == "drop") {
                 tableTab.SelectedTab = sqlPage;
             } else if(command.ToString() == "create") {
                 tableTab.SelectedTab = tablePage;
             } else if(command.ToString() == "alter") {
                 tableTab.SelectedTab = tablePage;
             } else {
                 tableTab.SelectedTab = tablePage;
             }
        }

        private void Table_Load(object sender, EventArgs e) {
            doLoad();
            buildSQL();
        }

        public void doLoad() {
            try {
                if(tableSchemaGrid.Columns.Count != DS.columns.Rows.Count) {
                    tableBox.Text = table.ToString();
                    tableSchemaGrid.Columns.Clear();
                    tableSchemaGrid.Rows.Clear();
                    tableSchemaGrid.Columns.Add("Index", "Position");    //0
                    tableSchemaGrid.Columns.Add("Name", "Column Name");  //1
                    tableSchemaGrid.Columns.Add("DT", "Data Type");      //2
                    tableSchemaGrid.Columns.Add("PKey", "Primary Key");  //3
                    tableSchemaGrid.Columns.Add("NN", "Not Null");       //4
                    tableSchemaGrid.Columns.Add("Unique", "UN");         //5
                    tableSchemaGrid.Columns.Add("AI", "Auto Increment"); //6

                    //Width
                    DataGridViewColumn column = tableSchemaGrid.Columns[0];
                    column.Width = 40;
                    column = tableSchemaGrid.Columns[1];
                    column.Width = 120;
                    column = tableSchemaGrid.Columns[2];
                    column.Width = 90;
                    column = tableSchemaGrid.Columns[3];
                    column.Width = 40;
                    column = tableSchemaGrid.Columns[4];
                    column.Width = 40;
                    column = tableSchemaGrid.Columns[5];
                    column.Width = 40;
                    column = tableSchemaGrid.Columns[6];
                    column.Width = 40;

                    foreach(DataRow lcol in DS.columns.Rows) {
                        if(lcol["TABLE_NAME"].ToString() == table.ToString()) {
                            DataGridViewRow row = (DataGridViewRow)tableSchemaGrid.Rows[0].Clone();
                            //Cell 1
                            row.Cells[0].Value = lcol["ORDINAL_POSITION"].ToString();
                            //Cell 1
                            row.Cells[1].Value = lcol["COLUMN_NAME"].ToString();
                            //Cell 2
                            DataGridViewComboBoxCell vCellComboDataType = new DataGridViewComboBoxCell();
                            foreach(string dst in Datasource.DBDataTypes) {
                                vCellComboDataType.Items.Add(dst.ToString());
                            }
                            if(vCellComboDataType.Items.Contains(lcol["COLUMN_TYPE"].ToString()) == false) {
                                vCellComboDataType.Items.Add(lcol["COLUMN_TYPE"].ToString());
                            }
                            if(vCellComboDataType.Items.IndexOf(lcol["COLUMN_TYPE"].ToString()) != -1) {
                                vCellComboDataType.Value = vCellComboDataType.Items[vCellComboDataType.Items.IndexOf(lcol["COLUMN_TYPE"].ToString())];
                            } else {
                                vCellComboDataType.Value = vCellComboDataType.Items[0];
                            }
                            vCellComboDataType.FlatStyle = FlatStyle.Standard;
                            vCellComboDataType.MaxDropDownItems = vCellComboDataType.Items.Count;

                            row.Cells[2].Value = vCellComboDataType.Value;
                            row.Cells[2] = vCellComboDataType;
                            //Cell 3
                            DataGridViewCheckBoxCell vCheckPKey = new DataGridViewCheckBoxCell();
                            if(DS.columns.Columns.Contains("COLUMN_KEY") == true) {
                                if(lcol["COLUMN_KEY"].ToString() == "PRI") {
                                    vCheckPKey.Value = 1;
                                } else {
                                    vCheckPKey.Value = 0;
                                }
                            } else {
                                vCheckPKey.Value = 0;
                            }
                            row.Cells[3] = vCheckPKey;
                            //Cell 4
                            DataGridViewCheckBoxCell vCheckNN = new DataGridViewCheckBoxCell();
                            if(DS.columns.Columns.Contains("IS_NULLABLE") == true) {
                                if(lcol["IS_NULLABLE"].ToString() == "YES") {
                                    vCheckNN.Value = 1;
                                } else {
                                    vCheckNN.Value = 0;
                                }
                            } else {
                                vCheckNN.Value = 0;
                            }
                            row.Cells[4] = vCheckNN;
                            //Cell 5
                            DataGridViewCheckBoxCell vCheckUN = new DataGridViewCheckBoxCell();
                            if(DS.columns.Columns.Contains("UNIQUE") == true) {
                                if(lcol["UNIQUE"].ToString() == "YES") {
                                    vCheckUN.Value = 1;
                                } else {
                                    vCheckUN.Value = 0;
                                }
                            } else {
                                vCheckUN.Value = 0;
                            }
                            row.Cells[5] = vCheckUN;
                            //Cell 6
                            DataGridViewCheckBoxCell vCheckAI = new DataGridViewCheckBoxCell();
                            if(DS.columns.Columns.Contains("EXTRA") == true) {
                                if(lcol["EXTRA"].ToString() == "auto_increment") {
                                    vCheckAI.Value = 1;
                                } else {
                                    vCheckAI.Value = 0;
                                }
                            } else {
                                vCheckAI.Value = 0;
                            }
                            row.Cells[6] = vCheckAI;

                            tableSchemaGrid.Rows.Add(row);
                        }
                    }
                }
            } catch(Exception err) {

            }

        }

        public void buildSQL() {
            string sql = "";
            if(command.ToString() == "truncate") {
                sql = "TRUNCATE `" + DS.database + "`.`" + table + "`\n";
            } else if(command.ToString() == "drop") {
                sql = "DROP TABLE `" + DS.database + "`.`" + table + "`\n";
            } else if(command.ToString() == "create") {
                sql = "CREATE TABLE `" + DS.database + "`.`" + tableBox.Text.ToString() + "` (\n";
                foreach(DataGridViewRow col in tableSchemaGrid.Rows) {
                    if(col.Cells[1].Value != null) {
                        if(col.Cells[1].Value.ToString() != DS.columns.Rows[col.Index]["COLUMN_NAME"].ToString()) {
                            sql += "`" + DS.columns.Rows[col.Index]["COLUMN_NAME"].ToString() + "` ";
                            sql += "`" + col.Cells[1].Value.ToString() + "` ";
                            sql += col.Cells[2].Value.ToString() + " ";
                            if(col.Cells[4].Value.ToString() == "1") {
                                sql += "NULL ";
                            } else {
                                sql += "NOT NULL ";
                            }
                            if(col.Cells[6].Value.ToString() == "1") {
                                sql += "AUTO INCREMENT ";
                            }
                            sql += ",\n";
                        }
                    }
                }
                foreach(DataGridViewRow col in tableSchemaGrid.Rows) {
                    if(col.Cells[1].Value != null) {
                        if(col.Cells[3].Value.ToString() == "1") {
                            sql += "PRIMARY KEY (`" + col.Cells[1].Value.ToString() + "`),\n";
                        }
                        if(col.Cells[5].Value.ToString() == "1") {
                            sql += "UNIQUE KEY `" + col.Cells[1].Value.ToString() + "`,\n";
                        }
                    }
                }
                sql = sql.Substring(0, sql.Length - 2);
                sql += ") ENGINE=MyISAM DEFAULT CHARSET=latin1;\n";
            } else if(command.ToString() == "alter" || command.ToString() == "") {
                if(tableBox.Text != table) {
                    sql = "RENAME TABLE `" + DS.database + "`.`" + table + "` TO `" + DS.database + "`.`" + tableBox.Text.ToString() + "`\n";
                } else {
                    sql = "ALTER TABLE `" + DS.database + "`.`" + table + "`\n";
                    foreach(DataGridViewRow col in tableSchemaGrid.Rows) {
                        if(col.Cells[1].Value != null) {
                            if(col.Cells[1].Value.ToString() != DS.columns.Rows[col.Index]["COLUMN_NAME"].ToString()) {
                                sql += "CHANGE COLUMN ";
                                sql += "`" + DS.columns.Rows[col.Index]["COLUMN_NAME"].ToString() + "` ";
                                sql += "`" + col.Cells[1].Value.ToString() + "` ";
                                sql += col.Cells[2].Value.ToString() + " ";
                                if(col.Cells[4].Value.ToString() == "1") {
                                    sql += "NULL ";
                                } else {
                                    sql += "NOT NULL ";
                                }
                                if(col.Cells[6].Value.ToString() == "1") {
                                    sql += "AUTO INCREMENT ";
                                }
                                sql += "\n";
                            }
                        }
                    }
                }
            }
            sqlRtf.Text = sql.ToString();
            sqlRtf.SyntaxHighlight();
        }

        private void tableSchemaGrid_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            buildSQL();
        }

        private void sqlRtf_TextChanged(object sender, EventArgs e) {

        }

        public void typeColumnDataGridView_OnCurrentCellDirtyStateChanged(object sender, EventArgs e) {
            DataGridView dataGridView = sender as DataGridView;
            if(dataGridView == null || dataGridView.CurrentCell.ColumnIndex != 0) {
                return;
            }
            var dataGridViewComboBoxCell = dataGridView.CurrentCell as DataGridViewComboBoxCell;
            if(dataGridViewComboBoxCell != null) {
                if(dataGridViewComboBoxCell.EditedFormattedValue.ToString() == "Custom") {
                    //Here we move focus to second cell of current row
                    dataGridView.CurrentCell = dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells[1];
                    //Return focus to Combobox cell
                    dataGridView.CurrentCell = dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells[0];
                    //Initiate Edit mode
                    dataGridView.BeginEdit(true);
                    return;
                }
            }
            dataGridView.CurrentCell = dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells[1];
            dataGridView.BeginEdit(true);
        }

        public void typeColumnDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            if(e.Control.GetType() != typeof(DataGridViewComboBoxEditingControl)) {
                return;
            }
            if(((ComboBox)e.Control).SelectedIndex == 0) {
                //If user selected first combobox value "Custom", make control editable
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
            } else {
                if(((ComboBox)e.Control).DropDownStyle != ComboBoxStyle.DropDown) {
                    return;
                }
                //If different value and combobox was set to editable, disable editing
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        public void typeColumnDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            DataGridView dataGridView = sender as DataGridView;
            if(dataGridView == null) {
                return;
            }
            if(!dataGridView.CurrentCell.IsInEditMode) {
                return;
            }
            if(dataGridView.CurrentCell.GetType() != typeof(DataGridViewComboBoxCell)) {
                return;
            }
            DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if(cell.Items.Contains(e.FormattedValue.ToString())) {
                return;
            }
            cell.Items.Add(e.FormattedValue.ToString());
            cell.Value = e.FormattedValue.ToString();
        }

        private void tableBox_TextChanged(object sender, EventArgs e) {
            buildSQL();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if(DS.executeSql(sqlRtf.Text.ToString())) {
                    resultBox.Text = "Date: " + DS.utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                             "Result: " + DS.row_count.ToString() + " Records\n" +
                                             "Query: '" + DS.sql.ToString() + "'\n";
                } else {
                    resultBox.Text = "Date: " + DS.utcStart.ToString("yyyy-MM-dd HH':'mm':'ss") + " - " +
                                          "Result: " + DS.row_count.ToString() + " Records\n" +
                                          "Query: '" + DS.sql.ToString() + "'\n";
                }
                tableTab.SelectedTab = sqlPage;
            } catch(Exception err) {

            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
