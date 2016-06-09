using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QueryIT.model;
using AutocompleteMenuNS;

namespace QueryIT {
    public partial class TableForm : Form {

        public Datasource DS;
        public string table;
        public TableSchema tmptbl;
        public TableSchema orgtbl;
        public string database;
        public string command;

        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;

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
                tableSchemaGrid.RowHeadersWidth = 65;
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
                 
                } else {
                    foreach(ColumnSchema col in tmptbl.Columns) {
                        DataGridViewRow row = (DataGridViewRow)tableSchemaGrid.Rows[0].Clone();
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
                            col.ColumnPosition = row.Index + 1;
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
                            col.ColumnPosition = row.Index+1;
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
            Dictionary<string, string> TA = reloadAutocomplete(sqlRtf);
            sqlRtf.SyntaxHighlight(TA);
        }

        public Dictionary<string, string> reloadAutocomplete(RichTextBox rtfin) {
            //AutoComplete
            string[] wordsraw = rtfin.Text.Replace("\n", " ").Split(" ".ToCharArray());
            string[] words = new string[0];
            Dictionary<string, string> TA = new Dictionary<string, string>();
            Dictionary<string, string> HL = new Dictionary<string, string>();
            foreach(string rawword in wordsraw) {
                if(rawword != "" && rawword != "\n") {
                    words = words.AddItemToArray(rawword.Replace("\n", ""));
                }
            }
            var acitems = new List<AutocompleteItem>();
            Array.Sort(SQLSyntax.SQLblue);
            foreach(var key in SQLSyntax.SQLblue) {
                acitems.Add(new AutocompleteItem(key.ToString(), 0));
                // words = words.RemoveIfExists(key);
            }
            Array.Sort(SQLSyntax.SQLdarkgreen);
            foreach(var key in SQLSyntax.SQLdarkgreen) {
                acitems.Add(new AutocompleteItem(key.ToString(), 0));
                //words = words.RemoveIfExists(key);
            }
            //build Table aliases
            for(int i = 0; i < words.Length - 1; i++) {
                if(words[i].ToString() != "") {
                    if((words[i].ToString().ToLower() == "from" || words[i].ToString().ToLower() == "join") && i + 2 < words.Length) {
                        if(words[i + 2].ToString().ToLower() != "where" &&
                            words[i + 2].ToString().ToLower() != "on" &&
                            words[i + 2].ToString().ToLower() != "order" &&
                            words[i + 2].ToString().ToLower() != "limit") {
                            if(TA.ContainsKey(words[i + 2]) == false) {
                                TA.Add(words[i + 2], words[i + 1].Replace("`", ""));
                            }
                            if(HL.ContainsKey(words[i + 2]) == false) {
                                HL.Add(words[i + 2], words[i + 1].Replace("`", ""));
                            }
                        }
                    }
                }
            }
            //Build live Autocomplete List
            if(DS.DBschema.Databases != null) {
                foreach(DatabaseSchema db in DS.DBschema.Databases) {
                    if(HL.ContainsKey(db.DatabaseName) == false) {
                        HL.Add(db.DatabaseName, db.DatabaseName);
                    }
                    if(db.Tables != null) {
                        foreach(TableSchema tbl in db.Tables) {
                            acitems.Add(new AutocompleteItem(db.DatabaseName + "." + tbl.TableName, 5, db.DatabaseName + "." + tbl.TableName));
                            acitems.Add(new AutocompleteItem(tbl.TableName, 5, tbl.TableName));
                            //Hightlight table
                            if(HL.ContainsKey(db.DatabaseName + "." + tbl.TableName) == false) {
                                HL.Add(db.DatabaseName + "." + tbl.TableName, tbl.TableName);
                            }
                            //acitems.Add(new AutocompleteItem(db.DatabaseName + "." + tbl.TableName, 5, db.DatabaseName + "." + tbl.TableName));
                            if(tbl.Columns != null) {
                                if(rtfin.Text.Contains(tbl.TableName)) {
                                    foreach(ColumnSchema col in tbl.Columns) {
                                        //Database.Table.Column
                                        string dbtblname = db.DatabaseName + "." + tbl.TableName;
                                        if(TA.ContainsValue(dbtblname)) {
                                            foreach(string vkey in TA.Keys) {
                                                if(TA[vkey] == dbtblname) {
                                                    if(col.PrimaryKey == true) {
                                                        acitems.Add(new AutocompleteItem(vkey + "." + col.ColumnName, 10, vkey + "." + col.ColumnName));
                                                    } else {
                                                        acitems.Add(new AutocompleteItem(vkey + "." + col.ColumnName, 6, vkey + "." + col.ColumnName));
                                                    }
                                                }
                                            }
                                        }
                                        //Table.Column 
                                        string tblname = tbl.TableName;
                                        if(TA.ContainsValue(tblname)) {
                                            foreach(string vkey in TA.Keys) {
                                                if(TA[vkey] == tblname) {
                                                    if(col.PrimaryKey == true) {
                                                        acitems.Add(new AutocompleteItem(vkey + "." + col.ColumnName, 10, vkey + "." + col.ColumnName));
                                                    } else {
                                                        acitems.Add(new AutocompleteItem(vkey + "." + col.ColumnName, 6, vkey + "." + col.ColumnName));
                                                    }
                                                }
                                            }
                                        }
                                        //Column
                                        if(col.PrimaryKey == true) {
                                            acitems.Add(new AutocompleteItem(tbl.TableName + "." + col.ColumnName, 10, tbl.TableName + "." + col.ColumnName));
                                        } else {
                                            acitems.Add(new AutocompleteItem(tbl.TableName + "." + col.ColumnName, 6, tbl.TableName + "." + col.ColumnName));
                                        }
                                        //Hightlight Column
                                        if(HL.ContainsKey(tbl.TableName + "." + col.ColumnName) == false) {
                                            HL.Add(tbl.TableName + "." + col.ColumnName, col.ColumnName);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            acitems = acitems.Distinct().ToList();
            autocomplete.SetAutocompleteItems(acitems);
            autocomplete.SetAutocompleteMenu(rtfin, autocomplete);
            return HL;
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



        private void tableSchemaGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e) {

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

        private void tableSchemaGrid_MouseMove(object sender, MouseEventArgs e) {
            if((e.Button & MouseButtons.Left) == MouseButtons.Left) {
                // If the mouse moves outside the rectangle, start the drag.
                if(dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y)) {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = tableSchemaGrid.DoDragDrop( tableSchemaGrid.Rows[rowIndexFromMouseDown], DragDropEffects.Move);
                }
            }
        }

        private void tableSchemaGrid_MouseDown(object sender, MouseEventArgs e) {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = tableSchemaGrid.HitTest(e.X, e.Y).RowIndex;
            if(rowIndexFromMouseDown != -1) {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
            } else {
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
            }
        }

        private void tableSchemaGrid_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        private void tableSchemaGrid_DragDrop(object sender, DragEventArgs e) {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = tableSchemaGrid.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop = tableSchemaGrid.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drag operation was a move then remove and insert the row.
            if(e.Effect == DragDropEffects.Move) {
                if(tableSchemaGrid.Rows[rowIndexFromMouseDown].IsNewRow == false && tableSchemaGrid.Rows[rowIndexOfItemUnderMouseToDrop].IsNewRow == false) {
                DataGridViewRow rowToMove = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
                tableSchemaGrid.Rows.RemoveAt(rowIndexFromMouseDown);
                tableSchemaGrid.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);
                }
            }
        }

        private void tableSchemaGrid_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e) {
                e.Row.Cells[0].Value = "";
                DataGridViewComboBoxCell vCellComboDataType = new DataGridViewComboBoxCell();
                foreach(string dst in Datasource.DBDataTypes) {
                    vCellComboDataType.Items.Add(dst.ToString());
                }
                vCellComboDataType.Value = vCellComboDataType.Items[0];
                vCellComboDataType.FlatStyle = FlatStyle.Standard;
                vCellComboDataType.MaxDropDownItems = vCellComboDataType.Items.Count;
                e.Row.Cells[1].Value = vCellComboDataType.Value;
                e.Row.Cells[1] = vCellComboDataType;
                DataGridViewCheckBoxCell vCheckPKey = new DataGridViewCheckBoxCell();
                vCheckPKey.Value = false;
                e.Row.Cells[2] = vCheckPKey;
                DataGridViewCheckBoxCell vCheckNN = new DataGridViewCheckBoxCell();
                vCheckNN.Value = false;
                e.Row.Cells[3] = vCheckNN;
                DataGridViewCheckBoxCell vCheckUN = new DataGridViewCheckBoxCell();
                vCheckUN.Value = false;
                e.Row.Cells[4] = vCheckUN;
                DataGridViewCheckBoxCell vCheckAI = new DataGridViewCheckBoxCell();
                vCheckAI.Value = false;
                e.Row.Cells[5] = vCheckAI;
                e.Row.Cells[6].Value = "";
        }

        private void sqlRtf_TextChanged_1(object sender, EventArgs e) {
            try {
                Dictionary<string, string> TA = reloadAutocomplete(sqlRtf);
                sqlRtf.SyntaxHighlight(TA);
            } catch(Exception err) {
                throw err;
            }
        }

        private void resultBox_TextChanged(object sender, EventArgs e) {

        }

        private void sqlRtf_SelectionChanged(object sender, EventArgs e) {
            try {
                if(sender.GetType() == typeof(RichTextBox)) {
                    RichTextBox tb = (RichTextBox)sender;
                    tb.SyntaxHighlightBrackets();
                }
            } catch(Exception err) {
                throw err;
            }
        }
    }
}
