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
    public partial class ConcatForm : Form
    {

        QueryForm SearchParent;
        public int offset = 0;

        public ConcatForm()
        {
            InitializeComponent();
        }

        public ConcatForm(QueryForm p)
        {
            SearchParent = p;
            InitializeComponent();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            foreach(DataColumn col in SearchParent.DT.Columns) {
                columnList.Items.Add(col.Caption.ToString());
            }
            if(SearchParent.cellColumn != -1) {
                columnList.SelectedIndex = SearchParent.cellColumn;
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e) {
            offset = SearchParent.doConcat(columnList.Text.ToString(), offset, beforeTxt.Text.ToString(), afterTxt.Text.ToString());
        }

        private void SearchForm_KeyDown(object sender, KeyEventArgs e) {
            if(e.Control && e.KeyCode == Keys.R) {
                offset = SearchParent.doConcat(columnList.Text.ToString(), offset, beforeTxt.Text.ToString(), afterTxt.Text.ToString());
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

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }
    }
}
