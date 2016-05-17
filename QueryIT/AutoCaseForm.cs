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

        QueryForm SearchParent;
        public int offset = 0;
        string[] searchColumns;

        public AutoCaseForm()
        {
            InitializeComponent();
        }

        public AutoCaseForm(QueryForm p)
        {
            SearchParent = p;
            InitializeComponent();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            foreach(DataColumn col in SearchParent.DT.Columns) {
                if(SearchParent.cellColumn <= 0) {
                    columnBox.Items.Add(col.Caption.ToString(), true);
                } else {
                    if(SearchParent.cellColumn == col.Ordinal) {
                        columnBox.Items.Add(col.Caption.ToString(), true);
                    } else {
                        columnBox.Items.Add(col.Caption.ToString(), false);
                    }
                }
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e) {
            searchColumns = searchColumns.Clear();
            foreach(object col in columnBox.CheckedItems) {
                searchColumns = searchColumns.AddItemToArray(col.ToString());
            }
            offset = SearchParent.doAutocase(caseBox.Text, offset, searchColumns);
        }

        private void SearchForm_KeyDown(object sender, KeyEventArgs e) {
            if(e.Control && e.KeyCode == Keys.R) {
                searchColumns = searchColumns.Clear();
                foreach(object col in columnBox.CheckedItems) {
                    searchColumns = searchColumns.AddItemToArray(col.ToString());
                }
                offset = SearchParent.doAutocase(caseBox.Text, offset, searchColumns);
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
