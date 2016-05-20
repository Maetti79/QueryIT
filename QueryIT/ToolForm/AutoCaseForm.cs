using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QueryIT
{
    public partial class AutoCaseForm : Form
    {

        DataGridView FilterGrid;
        public int offset = 0;
        string[] searchColumns;

        public AutoCaseForm() {
            InitializeComponent();
        }

        public AutoCaseForm(DataGridView p) {
            FilterGrid = p;
            InitializeComponent();
        }

        private void SearchForm_Load(object sender, EventArgs e) {
            foreach(DataGridViewColumn col in FilterGrid.Columns) {
                if(FilterGrid.SelectedCells.Count == 0) {
                    columnBox.Items.Add(col.Name.ToString(), true);
                } else {
                    if(FilterGrid.SelectedColumns.Contains(col)) {
                        columnBox.Items.Add(col.Name.ToString(), true);
                    } else {
                        columnBox.Items.Add(col.Name.ToString(), false);
                    }
                }
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e) {
            searchColumns = searchColumns.Clear();
            foreach(object col in columnBox.CheckedItems) {
                searchColumns = searchColumns.AddItemToArray(col.ToString());
            }
            Form f = FilterGrid.FindForm();
            if(f.GetType() == typeof(QueryForm)) {
                QueryForm FilterParent = (QueryForm)f;
                offset = FilterParent.doAutocase(caseBox.Text, offset, searchColumns);
            }
            if(f.GetType() == typeof(QueryerForm)) {
                QueryerForm FilterParent = (QueryerForm)f;
                offset = FilterParent.doAutocase(caseBox.Text, offset, searchColumns);
            }
        }

        private void SearchForm_KeyDown(object sender, KeyEventArgs e) {
            if(e.Control && e.KeyCode == Keys.R) {
                searchColumns = searchColumns.Clear();
                foreach(object col in columnBox.CheckedItems) {
                    searchColumns = searchColumns.AddItemToArray(col.ToString());
                }
                Form f = FilterGrid.FindForm();
                if(f.GetType() == typeof(QueryForm)) {
                    QueryForm FilterParent = (QueryForm)f;
                    offset = FilterParent.doAutocase(caseBox.Text, offset, searchColumns);
                }
                if(f.GetType() == typeof(QueryerForm)) {
                    QueryerForm FilterParent = (QueryerForm)f;
                    offset = FilterParent.doAutocase(caseBox.Text, offset, searchColumns);
                }
            } 
            if( e.KeyCode == Keys.Escape) {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e) {

        }

        private void exactChk_CheckedChanged(object sender, EventArgs e) {

        }

        private void caseBox_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}
