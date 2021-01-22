using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using QueryIT;

namespace QueryIT
{
    public partial class AboutForm : Form
    {
        public String SerialManager = Serial.GetSerialNumber();
        
        public AboutForm() {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e) {
            var version = Assembly.GetEntryAssembly().GetName().Version;
            var buildDateTime = new DateTime(2000, 1, 1).Add(new TimeSpan(
            TimeSpan.TicksPerDay * version.Build +
            TimeSpan.TicksPerSecond * 2 * version.Revision));

            VersionLabel.Text = Application.ProductName + " Version: " + Application.ProductVersion;
            CopyrightLabel.Text = "Copyright © 2019 - 2021 " + Application.CompanyName;
            BuildLabel.Text = "Build: " + buildDateTime;
            BuildLabel.Text = "Serial: " + SerialManager.ToString();
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
          
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://queryit.compucampus.de");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
