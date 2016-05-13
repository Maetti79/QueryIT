using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using QueryIT;

namespace QueryIT
{
    public partial class AboutForm : Form
    {
        public String SerialManager = Serial.GetSerialNumber();
        
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            VersionLbl.Text = "Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            SerialLbl.Text = "Serial: " + SerialManager.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void aboutGroup_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("http://queryit.purepix.net/");
        }
    }
}
