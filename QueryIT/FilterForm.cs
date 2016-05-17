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
    public partial class FilterForm : Form
    {

        QueryForm FilterParent;
        public int offset = 0;
        string[] searchColumns;

        public FilterForm()
        {
            InitializeComponent();
        }

        public FilterForm(QueryForm p)
        {
            FilterParent = p;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            offset = 0;
            //if(searchBox.Text.Length > 2) {
            //      searchColumns = searchColumns.Clear();
            //foreach(object col in columnBox.CheckedItems) {
            //    searchColumns = searchColumns.AddItemToArray(col.ToString());
            //}
            //    offset = FilterParent.doFilter(searchBox.Text.ToString(), offset, exactChk.Checked, caseSensetiveChk.Checked, searchColumns);
            //}
        }

        private void SearchBtn_Click(object sender, EventArgs e) {
            searchColumns = searchColumns.Clear();
            foreach(object col in columnBox.CheckedItems) {
                searchColumns = searchColumns.AddItemToArray(col.ToString());
            }
            offset = FilterParent.doFilter(searchBox.Text.ToString(), offset, exactChk.Checked, caseSensetiveChk.Checked, searchColumns);
        }

        private void SearchForm_KeyDown(object sender, KeyEventArgs e) {
            if(e.Control && e.KeyCode == Keys.F) {
                searchColumns = searchColumns.Clear();
                foreach(object col in columnBox.CheckedItems) {
                    searchColumns = searchColumns.AddItemToArray(col.ToString());
                }
                offset = FilterParent.doFilter(searchBox.Text.ToString(), offset, exactChk.Checked, caseSensetiveChk.Checked, searchColumns);
            } 
            if( e.KeyCode == Keys.Escape) {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void FilterForm_Load(object sender, EventArgs e) {
            foreach(DataColumn col in FilterParent.DT.Columns) {
                columnBox.Items.Add(col.Caption.ToString(), true);
            }
        }
    }
}
