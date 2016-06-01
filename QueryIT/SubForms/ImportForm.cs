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
                    DataGridViewRow row = (DataGridViewRow)fileGrid.Rows[0].Clone();
                    row.Cells[0].Value = columnname.ToString();
                    fileGrid.Rows.Add(row);
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

        private void ImportForm_Load(object sender, EventArgs e) {
            doLoad();
        }

        public void doLoad() {
            try {
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
                        row.Cells[0].Value = columnname.ToString();
                        fileGrid.Rows.Add(row);
                    }
                    
                    //Column Mapping
                    tableGrid.Columns.Clear();
                    tableGrid.Rows.Clear();
                    tableGrid.Columns.Add("Index", "Position");    //0
                    tableGrid.Columns.Add("Name", "Column Name");  //1
                    tableGrid.Columns.Add("DT", "Data Type");      //2
                    tableGrid.Columns.Add("PKey", "Primary Key");  //3
                    tableGrid.Columns.Add("NN", "Not Null");       //4
                    tableGrid.Columns.Add("Unique", "UN");         //5
                    tableGrid.Columns.Add("AI", "Auto Increment"); //6
                    //Width
                    DataGridViewColumn column = tableGrid.Columns[0];
                    column.Width = 40;
                    column = tableGrid.Columns[1];
                    column.Width = 120;
                    column = tableGrid.Columns[2];
                    column.Width = 90;
                    column = tableGrid.Columns[3];
                    column.Width = 40;
                    column = tableGrid.Columns[4];
                    column.Width = 40;
                    column = tableGrid.Columns[5];
                    column.Width = 40;
                    column = tableGrid.Columns[6];
                    column.Width = 40;
                    //Fill Data with Existing Columns
                    if(tableExists(table.ToString())) {
                        foreach(ColumnSchema col in DS.DBschema.D[database].T[table].Columns) {
              
                                DataGridViewRow row = (DataGridViewRow)tableGrid.Rows[0].Clone();
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
                                // Datentyp festlegen
                                row.Cells[1].Value = vComboCell.Value;
                                // ComboBox - Zelle setzen
                                row.Cells[1] = vComboCell;
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
                            // Datentyp festlegen
                            row.Cells[1].Value = vComboCell.Value;
                            // ComboBox - Zelle setzen
                            row.Cells[1] = vComboCell;
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
                doLoad();
            }
        }

    }
}