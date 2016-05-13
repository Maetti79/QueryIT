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
            //    offset = FilterParent.doFilter(searchBox.Text.ToString(), offset, exactChk.Checked, caseSensetiveChk.Checked);
            //}
        }

        private void SearchBtn_Click(object sender, EventArgs e) {
            offset = FilterParent.doFilter(searchBox.Text.ToString(), offset, exactChk.Checked, caseSensetiveChk.Checked);
        }

        private void SearchForm_KeyDown(object sender, KeyEventArgs e) {
            if(e.Control && e.KeyCode == Keys.F) {
                offset = FilterParent.doFilter(searchBox.Text.ToString(), offset, exactChk.Checked, caseSensetiveChk.Checked);
            } 
            if( e.KeyCode == Keys.Escape) {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void FilterForm_Load(object sender, EventArgs e) {

        }
    }
}
