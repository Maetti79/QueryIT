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
    public partial class ImportForm : Form {

        public Datasource DS;
        public string table;
        public string database;
        public bool run = false;
        public DateTime utcStart;
        public DateTime utcStop;

        public ImportForm() {
            InitializeComponent();
        }

        public ImportForm(Datasource QDS, string t) {
            DS = QDS;
            table = t;
            database = DS.database;
            InitializeComponent();
        }

        private void selectFileBtn_Click(object sender, EventArgs e) {
            try {
                using(var sfd = new OpenFileDialog()) {
                    sfd.Filter = "All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    if(sfd.ShowDialog() == DialogResult.OK) {
                        importFile.Text = sfd.FileName;
                    }
                    doLoad();
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
                int imported = 0;
                int chunk = 1000;
                //int offset = 0;
                ProgressForm pform = new ProgressForm(this, "Progress [Export - " + table + "]");
                pform.update(0, chunk, 0);
                pform.Show();

                if(tableExists(table.ToString()) == false) {
                    TableSchema newTbl = new TableSchema(table.ToString());
                    foreach(DataGridViewRow col in tableGrid.Rows) {
                        if(col.Cells[0].Value != null) {
                            ColumnSchema newCol = new ColumnSchema(col.Cells[0].Value.ToString());
                            newTbl.addColumn(newCol);
                        }
                    }
                    //Create Table SQL Statment
                    DS.executeSql(newTbl.SQLCreateTable());
                }

                System.IO.StreamReader tmpf = new System.IO.StreamReader(importFile.Text.ToString());
                string line = tmpf.ReadLine();
                string delimiter = "";
                if(line != "") {
                    if(line.Contains(" ")) {
                        delimiter = " ";
                    }
                    if(line.Contains(",")) {
                        delimiter = ",";
                    }
                    if(line.Contains("|")) {
                        delimiter = "|";
                    }
                    if(line.Contains("\t")) {
                        delimiter = "\t";
                    }
                    if(line.Contains(";")) {
                        delimiter = ";";
                    }
                }
                tmpf.Close();
                string[] words = line.Split(delimiter.ToCharArray());
                foreach(string columnname in words) {
 
                }



                imported++;

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

        private void ImportForm_Load(object sender, EventArgs e) {
            doLoad();
        }

        public void doLoad() {
            try {
                runToolStripMenuItem.Enabled = true;
                //Table Name
                tableBox.Items.Clear();
                tableBox.Items.Add("(new table)");
                foreach(TableSchema tbl in DS.DBschema.D[database].Tables) {
                    tableBox.Items.Add(tbl.TableName);
                }
                tableBox.Text = table.ToString();
                //File Columns
                fileGrid.Columns.Clear();
                fileGrid.Rows.Clear();
                fileGrid.Columns.Add("Source", "Column Name");
                fileGrid.RowHeadersWidth = 65;
                if(importFile.Text.ToString() != "") {
                    runToolStripMenuItem.Enabled = true;
                    System.IO.StreamReader tmpf = new System.IO.StreamReader(importFile.Text.ToString());
                    string line = tmpf.ReadLine();
                    string delimiter = "";
                    if(line != "") {
                        if(line.Contains(" ")) {
                            delimiter = " ";
                        }
                        if(line.Contains(",")) {
                            delimiter = ",";
                        }
                        if(line.Contains("|")) {
                            delimiter = "|";
                        }
                        if(line.Contains("\t")) {
                            delimiter = "\t";
                        }
                        if(line.Contains(";")) {
                            delimiter = ";";
                        }
                    }
                    tmpf.Close();
                    string[] words = line.Split(delimiter.ToCharArray());
                    foreach(string columnname in words) {
                        DataGridViewRow row = (DataGridViewRow)fileGrid.Rows[0].Clone();
                        row.HeaderCell.Value = row.Index.ToString();
                        row.Cells[0].Value = columnname.ToString();
                        fileGrid.Rows.Add(row);
                    }
                    //Column Mapping
                    tableGrid.Columns.Clear();
                    tableGrid.Rows.Clear();
                    tableGrid.Columns.Add("Name", "Column Name");  //1
                    tableGrid.Columns.Add("Import", "Mapping Name");  //2
                    tableGrid.Columns.Add("DT", "Data Type");      //3
                    tableGrid.Columns.Add("PK", "PK");  //4
                    tableGrid.Columns.Add("NN", "NN");       //5
                    tableGrid.Columns.Add("UN", "UN");         //6
                    tableGrid.Columns.Add("AI", "AI"); //7
                    tableGrid.Columns.Add("DV", "Default"); //8
                    tableGrid.RowHeadersWidth = 65;
                    //Width
                    DataGridViewColumn column = tableGrid.Columns[0];
                    column.Width = 120;
                    column = tableGrid.Columns[1];
                    column.Width = 120;
                    column = tableGrid.Columns[2];
                    column.Width = 100;
                    column = tableGrid.Columns[3];
                    column.Width = 25;
                    column = tableGrid.Columns[4];
                    column.Width = 25;
                    column = tableGrid.Columns[5];
                    column.Width = 25;
                    column = tableGrid.Columns[6];
                    column.Width = 25;
                    column = tableGrid.Columns[7];
                    column.Width = 120;
                    //Fill Data with Existing Columns
                    if(tableExists(table.ToString())) {
                        foreach(ColumnSchema col in DS.DBschema.D[database].T[table].Columns) {
                            DataGridViewRow row = (DataGridViewRow)tableGrid.Rows[0].Clone();
                            row.HeaderCell.Value = col.ColumnPosition.ToString();
                            row.Cells[0].Value = col.ColumnName;
                            DataGridViewComboBoxCell vComboCell = new DataGridViewComboBoxCell();
                            vComboCell.Items.Add("(skip column)");
                            foreach(string columnname in words) {
                                vComboCell.Items.Add(columnname.ToString());
                            }
                            if(vComboCell.Items.IndexOf(col.ColumnName) != -1) {
                                vComboCell.Value = vComboCell.Items[vComboCell.Items.IndexOf(col.ColumnName)];
                            } else {
                                vComboCell.Value = vComboCell.Items[0];
                            }
                            vComboCell.FlatStyle = FlatStyle.Standard;
                            vComboCell.MaxDropDownItems = vComboCell.Items.Count;
                            row.Cells[1].Value = vComboCell.Value;
                            row.Cells[1] = vComboCell;

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
                            row.Cells[2].Value = vCellComboDataType.Value;
                            row.Cells[2] = vCellComboDataType;
                            DataGridViewCheckBoxCell vCheckPKey = new DataGridViewCheckBoxCell();
                            vCheckPKey.Value = col.PrimaryKey;
                            row.Cells[3] = vCheckPKey;
                            DataGridViewCheckBoxCell vCheckNN = new DataGridViewCheckBoxCell();
                            vCheckNN.Value = col.NotNull;
                            row.Cells[4] = vCheckNN;
                            DataGridViewCheckBoxCell vCheckUN = new DataGridViewCheckBoxCell();
                            vCheckUN.Value = col.Unique;
                            row.Cells[5] = vCheckUN;
                            DataGridViewCheckBoxCell vCheckAI = new DataGridViewCheckBoxCell();
                            vCheckAI.Value = col.AutoIncrement;
                            row.Cells[6] = vCheckAI;
                            row.Cells[7].Value = col.DefaultValue.ToString();
                            tableGrid.Rows.Add(row);
                        }
                    } else {
                        //New Table Schema
                        foreach(string col in words) {
                            DataGridViewRow row = (DataGridViewRow)tableGrid.Rows[0].Clone();
                            row.Cells[0].Value = col.ToString();
                            DataGridViewComboBoxCell vComboCell = new DataGridViewComboBoxCell();
                            vComboCell.Items.Add("(skip column)");
                            foreach(string columnname in words) {
                                vComboCell.Items.Add(columnname.ToString());
                            }
                            if(vComboCell.Items.IndexOf(col.ToString()) != -1) {
                                vComboCell.Value = vComboCell.Items[vComboCell.Items.IndexOf(col.ToString())];
                            } else {
                                vComboCell.Value = vComboCell.Items[0];
                            }
                            vComboCell.FlatStyle = FlatStyle.Standard;
                            vComboCell.MaxDropDownItems = vComboCell.Items.Count;
                            row.Cells[1].Value = vComboCell.Value;
                            row.Cells[1] = vComboCell;
                            DataGridViewComboBoxCell vCellComboDataType = new DataGridViewComboBoxCell();
                            foreach(string dst in Datasource.DBDataTypes) {
                                vCellComboDataType.Items.Add(dst.ToString());
                            }
                            vCellComboDataType.Value = vCellComboDataType.Items[0];
                            vCellComboDataType.FlatStyle = FlatStyle.Standard;
                            vCellComboDataType.MaxDropDownItems = vCellComboDataType.Items.Count;
                            row.Cells[2].Value = vCellComboDataType.Value;
                            row.Cells[2] = vCellComboDataType;
                            DataGridViewCheckBoxCell vCheckPKey = new DataGridViewCheckBoxCell();
                            vCheckPKey.Value = false;
                            row.Cells[3] = vCheckPKey;
                            DataGridViewCheckBoxCell vCheckNN = new DataGridViewCheckBoxCell();
                            vCheckNN.Value = false;
                            row.Cells[4] = vCheckNN;
                            DataGridViewCheckBoxCell vCheckUN = new DataGridViewCheckBoxCell();
                            vCheckUN.Value = false;
                            row.Cells[5] = vCheckUN;
                            DataGridViewCheckBoxCell vCheckAI = new DataGridViewCheckBoxCell();
                            vCheckAI.Value = false;
                            row.Cells[6] = vCheckAI;
                            row.Cells[7].Value = "";
                            tableGrid.Rows.Add(row);
                        }
                    }
                }
            } catch(Exception err) {
                run = false;
                runToolStripMenuItem.Enabled = false;
                killToolStripMenuItem.Enabled = false;
                throw err;
            }
        }

        public bool tableExists(string tableName) {
            bool exists = false;
            foreach(TableSchema tbl in DS.DBschema.D[database].Tables) {
                if(tbl.TableName == tableName.ToString()) {
                    exists = true;
                    break;
                }
            }
            return exists;
        }

        private void tableBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(tableBox.Text.ToString() != table.ToString()) {
                table = tableBox.Text.ToString();
                runToolStripMenuItem.Enabled = true;
                doLoad();
            }
        }

    }
}