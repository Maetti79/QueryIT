using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QueryIT {
    public partial class ConcatForm : Form {

        DataGridView SearchGrid;
        public int offset = 0;

        public ConcatForm() {
            InitializeComponent();
        }

        public ConcatForm(DataGridView p) {
            SearchGrid = p;
            InitializeComponent();
        }

        private void SearchForm_Load(object sender, EventArgs e) {
            foreach(DataGridViewColumn col in SearchGrid.Columns) {
                    columnList.Items.Add(col.Name.ToString());
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e) {
            if(SearchGrid.Parent.GetType() == typeof(QueryForm)) {
                QueryForm SearchParent = (QueryForm)SearchGrid.Parent;
                offset = SearchParent.doConcat(columnList.Text.ToString(), offset, beforeTxt.Text.ToString(), afterTxt.Text.ToString());
            }
            if(SearchGrid.Parent.GetType() == typeof(QueryerForm)) {
                QueryerForm SearchParent = (QueryerForm)SearchGrid.Parent;
                offset = SearchParent.doConcat(columnList.Text.ToString(), offset, beforeTxt.Text.ToString(), afterTxt.Text.ToString());
            }
        }

        private void SearchForm_KeyDown(object sender, KeyEventArgs e) {
            if(e.Control && e.KeyCode == Keys.R) {
                if(SearchGrid.Parent.GetType() == typeof(QueryForm)) {
                    QueryForm SearchParent = (QueryForm)SearchGrid.Parent;
                    offset = SearchParent.doConcat(columnList.Text.ToString(), offset, beforeTxt.Text.ToString(), afterTxt.Text.ToString());
                }
                if(SearchGrid.Parent.GetType() == typeof(QueryerForm)) {
                    QueryerForm SearchParent = (QueryerForm)SearchGrid.Parent;
                    offset = SearchParent.doConcat(columnList.Text.ToString(), offset, beforeTxt.Text.ToString(), afterTxt.Text.ToString());
                }
            }
            if(e.KeyCode == Keys.Escape) {
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

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }
    }
}
