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
    public partial class SearchForm : Form
    {

        DataGridView SearchGrid;
        public int offset = 0;
        string[] searchColumns;

        public SearchForm()
        {
            InitializeComponent();
        }

        public SearchForm(DataGridView p)
        {
            SearchGrid = p;
            InitializeComponent();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            foreach(DataGridViewColumn col in SearchGrid.Columns) {
                if(SearchGrid.SelectedCells.Count == 0) {
                    columnBox.Items.Add(col.Name.ToString(), true);
                } else {
                    if(SearchGrid.SelectedColumns.Contains(col)) {
                        columnBox.Items.Add(col.Name.ToString(), true);
                    } else {
                        columnBox.Items.Add(col.Name.ToString(), false);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            offset = 0;
            if(searchBox.Text.Length > 2) {
                searchColumns = searchColumns.Clear();
                foreach(object col in columnBox.CheckedItems) {
                    searchColumns = searchColumns.AddItemToArray(col.ToString());
                }
                Form f = SearchGrid.FindForm();
                if(f.GetType() == typeof(QueryForm)) {
                    QueryForm SearchParent = (QueryForm)f;
                    offset = SearchParent.doSearch(searchBox.Text.ToString(), offset, exactChk.Checked, caseSensetiveChk.Checked, searchColumns);
                }
                if(f.GetType() == typeof(QueryerForm)) {
                    QueryerForm SearchParent = (QueryerForm)f;
                    offset = SearchParent.doSearch(searchBox.Text.ToString(), offset, exactChk.Checked, caseSensetiveChk.Checked, searchColumns);
                }
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e) {
            searchColumns = searchColumns.Clear();
            foreach(object col in columnBox.CheckedItems) {
                searchColumns = searchColumns.AddItemToArray(col.ToString());
            }
            Form f = SearchGrid.FindForm();
            if(f.GetType() == typeof(QueryForm)) {
                QueryForm SearchParent = (QueryForm)f;
                offset = SearchParent.doSearch(searchBox.Text.ToString(), offset, exactChk.Checked, caseSensetiveChk.Checked, searchColumns);
            }
            if(f.GetType() == typeof(QueryerForm)) {
                QueryerForm SearchParent = (QueryerForm)f;
                offset = SearchParent.doSearch(searchBox.Text.ToString(), offset, exactChk.Checked, caseSensetiveChk.Checked, searchColumns);
            }
        }

        private void SearchForm_KeyDown(object sender, KeyEventArgs e) {
            if(e.Control && e.KeyCode == Keys.F) {
                searchColumns = searchColumns.Clear();
                foreach(object col in columnBox.CheckedItems) {
                    searchColumns = searchColumns.AddItemToArray(col.ToString());
                }
                Form f = SearchGrid.FindForm();
                if(f.GetType() == typeof(QueryForm)) {
                    QueryForm SearchParent = (QueryForm)f;
                    offset = SearchParent.doSearch(searchBox.Text.ToString(), offset, exactChk.Checked, caseSensetiveChk.Checked, searchColumns);
                }
                if(f.GetType() == typeof(QueryerForm)) {
                    QueryerForm SearchParent = (QueryerForm)f;
                    offset = SearchParent.doSearch(searchBox.Text.ToString(), offset, exactChk.Checked, caseSensetiveChk.Checked, searchColumns);
                }
            } 
            if( e.KeyCode == Keys.Escape) {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void columnBox_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}
