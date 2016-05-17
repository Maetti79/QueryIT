using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QueryIT {
    public partial class TableForm : Form {

        QueryForm SchemaParent;

        public TableForm() {
            InitializeComponent();
        }

        public TableForm(QueryForm p) {
            SchemaParent = p;
            InitializeComponent();
        }

        private void Table_Load(object sender, EventArgs e) {
            doLoad();
        }

        public void doLoad() {
            try {
                if(tableSchemaGrid.Columns.Count != SchemaParent.QDS.columns.Rows.Count) {
                    tableSchemaGrid.Columns.Clear();
                    tableSchemaGrid.Rows.Clear();
                    tableSchemaGrid.Columns.Add("Column Name", "Name");
                    tableSchemaGrid.Columns.Add("Type", "DataType");
                    //if(SchemaParent.QDS.hasErrors() == false) {
                        foreach(DataRow lcol in SchemaParent.QDS.columns.Rows) {
                            if(lcol["TABLE_NAME"].ToString() == SchemaParent.table.ToString()) {
                                DataGridViewRow row = (DataGridViewRow)tableSchemaGrid.Rows[0].Clone();
                                row.Cells[0].Value = lcol["COLUMN_NAME"].ToString();
                                DataGridViewComboBoxCell vComboCell = new DataGridViewComboBoxCell();
                                vComboCell.Items.Add(lcol["DATA_TYPE"].ToString());
                                if(vComboCell.Items.IndexOf(lcol["DATA_TYPE"].ToString()) != -1) {
                                    vComboCell.Value = vComboCell.Items[vComboCell.Items.IndexOf(lcol["DATA_TYPE"].ToString())];
                                } else {
                                    vComboCell.Value = vComboCell.Items[0];
                                }
                                vComboCell.FlatStyle = FlatStyle.Standard;
                                vComboCell.MaxDropDownItems = vComboCell.Items.Count;
                                row.Cells[1].Value = vComboCell.Value;
                                row.Cells[1] = vComboCell;
                                tableSchemaGrid.Rows.Add(row);
                            }
                        }
                    }
                //}
            } catch(Exception err) {
               
            }
        
        }
    }
}
