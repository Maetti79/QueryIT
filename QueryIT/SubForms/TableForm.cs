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
        public TableSchema tmptbl;
        public TableSchema orgtbl;
        public string database;
        public string command;

        public TableForm() {
            InitializeComponent();
        }

        public TableForm(Datasource QDS, string tbl) {
            DS = QDS;
            table = tbl;
            database = DS.database;
            tmptbl = DS.DBschema.D[database].T[table];
            orgtbl = DS.DBschema.D[database].T[table];
            InitializeComponent();
        }

        public TableForm(Datasource QDS, string tbl, string cmd) {
            DS = QDS;
            table = tbl;
            database = DS.database;
            if(table != "") {
                tmptbl = DS.DBschema.D[database].T[table];
                orgtbl = DS.DBschema.D[database].T[table];
            }
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
 
                tableBox.Text = table.ToString();
                tableSchemaGrid.Columns.Clear();
                tableSchemaGrid.Rows.Clear();
                tableSchemaGrid.Columns.Add("Name", "Column Name");  //1
                tableSchemaGrid.Columns.Add("DT", "Data Type");      //2
                tableSchemaGrid.Columns.Add("PK", "PK");  //3
                tableSchemaGrid.Columns.Add("NN", "NN");       //4
                tableSchemaGrid.Columns.Add("UN", "UN");         //5
                tableSchemaGrid.Columns.Add("AI", "AI"); //6
                tableSchemaGrid.Columns.Add("DV", "Default");

                //Width
                DataGridViewColumn column = tableSchemaGrid.Columns[0];
                column.Width = 120;
                column = tableSchemaGrid.Columns[1];
                column.Width = 100;
                column = tableSchemaGrid.Columns[2];
                column.Width = 25;
                column = tableSchemaGrid.Columns[3];
                column.Width = 25;
                column = tableSchemaGrid.Columns[4];
                column.Width = 25;
                column = tableSchemaGrid.Columns[5];
                column.Width = 25;
                column = tableSchemaGrid.Columns[6];
                column.Width = 120;
                if(command == "create") {
                    addEmtpyRow();
                } else {
                    foreach(ColumnSchema col in tmptbl.Columns) {
                        DataGridViewRow row = (DataGridViewRow)tableSchemaGrid.Rows[0].Clone();
                        row.HeaderCell.Value = col.ColumnPosition;
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
                        tableSchemaGrid.Rows.Add(row);
                    }
                }
        }

        public void buildSQL() {
            TableSchema tbl = new TableSchema(tableBox.Text.ToString());
            if(command == "create") {
                tbl.ConnectionName = DS.DBschema.ConnectionName;
                tbl.DatabaseName = database;
                foreach(DataGridViewRow row in tableSchemaGrid.Rows) {
                    if(row.Cells[0].Value != null) {
                        if(row.Cells[0].Value.ToString() != "") {
                            ColumnSchema col = new ColumnSchema(row.Cells[0].Value.ToString());
                            col.ConnectionName = tbl.ConnectionName;
                            col.DatabaseName = tbl.DatabaseName;
                            col.TableName = tbl.TableName;
                            col.ColumnPosition = int.Parse(row.HeaderCell.Value.ToString());
                            col.DataType = row.Cells[1].Value.ToString();
                            col.PrimaryKey = (bool)row.Cells[2].Value;
                            col.NotNull = (bool)row.Cells[3].Value;
                            col.Unique = (bool)row.Cells[4].Value;
                            col.AutoIncrement = (bool)row.Cells[5].Value;
                            col.DefaultValue = row.Cells[6].Value.ToString();
                            tbl.addColumn(col);
                        }
                    }
                }
            } else {
                tbl.ConnectionName = tmptbl.ConnectionName;
                tbl.DatabaseName = tmptbl.DatabaseName;
                foreach(DataGridViewRow row in tableSchemaGrid.Rows) {
                    if(row.Cells[0].Value != null) {
                        if(row.Cells[0].Value.ToString() != "") {
                            ColumnSchema col = new ColumnSchema(row.Cells[0].Value.ToString());
                            col.ConnectionName = tmptbl.ConnectionName;
                            col.DatabaseName = tmptbl.DatabaseName;
                            col.TableName = tmptbl.TableName;
                            col.ColumnPosition = int.Parse(row.HeaderCell.Value.ToString());
                            col.DataType = row.Cells[1].Value.ToString();
                            col.PrimaryKey = (bool)row.Cells[2].Value;
                            col.NotNull = (bool)row.Cells[3].Value;
                            col.Unique = (bool)row.Cells[4].Value;
                            col.AutoIncrement = (bool)row.Cells[5].Value;
                            col.DefaultValue = row.Cells[6].Value.ToString();
                            tbl.addColumn(col);
                        }
                    }
                }
            }

            string sql = "";
            if(command.ToString() == "truncate") {
                sql += orgtbl.SQLTruncateTable();
            } else if(command.ToString() == "drop") {
                sql += orgtbl.SQLDropTable();
            } else if(command.ToString() == "create") {
                sql += tbl.SQLCreateTable();
            } else if(command.ToString() == "alter" || command.ToString() == "") {
                if(tableBox.Text != table) {
                    sql += orgtbl.SQLRenameTable(tbl);
                }
                sql += orgtbl.SQLAlterTable(tbl);
            }
            sqlRtf.Text = sql.ToString();
            sqlRtf.SyntaxHighlight();
        }

        private void tableSchemaGrid_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            //buildSQL();
        }

        private void sqlRtf_TextChanged(object sender, EventArgs e) {
            //buildSQL();
        }

        public void typeColumnDataGridView_OnCurrentCellDirtyStateChanged(object sender, EventArgs e) {
        
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
                throw err;
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void addEmtpyRow() {
            DataGridViewRow row = (DataGridViewRow)tableSchemaGrid.Rows[0].Clone();
            row.HeaderCell.Value = row.Index.ToString();
            row.Cells[0].Value = "";
            DataGridViewComboBoxCell vCellComboDataType = new DataGridViewComboBoxCell();
            foreach(string dst in Datasource.DBDataTypes) {
                vCellComboDataType.Items.Add(dst.ToString());
            }
            vCellComboDataType.Value = vCellComboDataType.Items[0];
            vCellComboDataType.FlatStyle = FlatStyle.Standard;
            vCellComboDataType.MaxDropDownItems = vCellComboDataType.Items.Count;
            row.Cells[1].Value = vCellComboDataType.Value;
            row.Cells[1] = vCellComboDataType;
            DataGridViewCheckBoxCell vCheckPKey = new DataGridViewCheckBoxCell();
            vCheckPKey.Value = false;
            row.Cells[2] = vCheckPKey;
            DataGridViewCheckBoxCell vCheckNN = new DataGridViewCheckBoxCell();
            vCheckNN.Value = false;
            row.Cells[3] = vCheckNN;
            DataGridViewCheckBoxCell vCheckUN = new DataGridViewCheckBoxCell();
            vCheckUN.Value = false;
            row.Cells[4] = vCheckUN;
            DataGridViewCheckBoxCell vCheckAI = new DataGridViewCheckBoxCell();
            vCheckAI.Value = false;
            row.Cells[5] = vCheckAI;
            row.Cells[6].Value = "";
            tableSchemaGrid.Rows.Add(row);
        }

        private void tableSchemaGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e) {
            addEmtpyRow();
        }

        private void tableSchemaGrid_Click(object sender, EventArgs e) {
            //buildSQL();
        }

        private void tableSchemaGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            //buildSQL();
        }

        private void tableSchemaGrid_CellLeave(object sender, DataGridViewCellEventArgs e) {
            buildSQL();
        }
    }
}
