using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QueryIT {
    public partial class FilterForm : Form {

        DataGridView FilterGrid;
        public int offset = 0;
        string[] searchColumns;

        public FilterForm() {
            InitializeComponent();
        }

        public FilterForm(DataGridView g) {
            FilterGrid = g;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            offset = 0;
        }

        private void SearchBtn_Click(object sender, EventArgs e) {
            searchColumns = searchColumns.Clear();
            foreach(object col in columnBox.CheckedItems) {
                searchColumns = searchColumns.AddItemToArray(col.ToString());
            }
            Form f = FilterGrid.FindForm();
            if(f.GetType() == typeof(QueryForm)) {
                QueryForm FilterParent = (QueryForm)f;
                offset = FilterParent.doFilter(searchBox.Text.ToString(), offset, exactChk.Checked, caseSensetiveChk.Checked, searchColumns);
            }
            if(f.GetType() == typeof(QueryerForm)) {
                QueryerForm FilterParent = (QueryerForm)f;
                offset = FilterParent.doFilter(searchBox.Text.ToString(), offset, exactChk.Checked, caseSensetiveChk.Checked, searchColumns);
            }
        }

        private void SearchForm_KeyDown(object sender, KeyEventArgs e) {
            if(e.Control && e.KeyCode == Keys.F) {
                searchColumns = searchColumns.Clear();
                foreach(object col in columnBox.CheckedItems) {
                    searchColumns = searchColumns.AddItemToArray(col.ToString());
                }
                Form f = FilterGrid.FindForm();
                if(f.GetType() == typeof(QueryForm)) {
                    QueryForm FilterParent = (QueryForm)f;
                    offset = FilterParent.doFilter(searchBox.Text.ToString(), offset, exactChk.Checked, caseSensetiveChk.Checked, searchColumns);
                }
                if(f.GetType() == typeof(QueryerForm)) {
                    QueryerForm FilterParent = (QueryerForm)f;
                    offset = FilterParent.doFilter(searchBox.Text.ToString(), offset, exactChk.Checked, caseSensetiveChk.Checked, searchColumns);
                }
            }
            if(e.KeyCode == Keys.Escape) {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void FilterForm_Load(object sender, EventArgs e) {
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

    }
}
