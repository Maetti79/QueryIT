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
    public partial class DateTimeForm : Form
    {

        public string DateTimeStr = "";

        public DateTimeForm()
        {
            InitializeComponent();
        }

        private void DateTimeForm_Load(object sender, EventArgs e)
        {
            TimeBox.Text = "00:00:00";
            DateTimeStr = dtm.SelectionStart.ToString("yyyy-MM-dd") + " " + TimeBox.Text;
        }

        private void nowBtn_Click(object sender, EventArgs e)
        {
            TimeBox.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            DateTimeStr = dtm.SelectionStart.ToString("yyyy-MM-dd") + " " + TimeBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
