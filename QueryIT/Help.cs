using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace QueryIT.model
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            VersionLbl.Text = "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
                        this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void aboutGroup_Enter(object sender, EventArgs e)
        {

        }
    }
}
