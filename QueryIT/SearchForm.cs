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

        QueryForm SearchParent;
        public int offset = 0;

        public SearchForm()
        {
            InitializeComponent();
        }

        public SearchForm(QueryForm p)
        {
            SearchParent = p;
            InitializeComponent();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            offset = 0;
            if(searchBox.Text.Length > 2) {
                offset = SearchParent.doSearch(searchBox.Text.ToString(), offset, exactChk.Checked, caseSensetiveChk.Checked);
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e) {
            offset = SearchParent.doSearch(searchBox.Text.ToString(), offset, exactChk.Checked, caseSensetiveChk.Checked);
        }

        private void SearchForm_KeyDown(object sender, KeyEventArgs e) {
            if(e.Control && e.KeyCode == Keys.F) {
                offset = SearchParent.doSearch(searchBox.Text.ToString(), offset, exactChk.Checked, caseSensetiveChk.Checked);
            } 
            if( e.KeyCode == Keys.Escape) {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
