using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Win32;
using QueryIT.model;

namespace QueryIT
{
    public partial class ConnectionsForm : Form
    {
        public ConnectionsForm()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var rform = new ConnectForm(true))
            {
                var result = rform.ShowDialog();
                if (result == DialogResult.OK)
                {
                    
                }
            }
            loadConnections();
        }

        public void loadConnections() {
            connectionsView.Clear();
            Microsoft.Win32.RegistryKey key;
            string rootKey = "SOFTWARE\\" + Assembly.GetExecutingAssembly().GetName().Name + "\\Connections";
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(rootKey);
            if (key == null)
            {
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
            }
            foreach (var v in key.GetSubKeyNames())
            {
                connectionsView.Items.Add(v.ToString(), v.ToString(), 0);
            }
            key.Close();
        }

        public void deleteConnection(string connectionname) {
            Microsoft.Win32.RegistryKey key;
            string rootKey = "SOFTWARE\\" + Assembly.GetExecutingAssembly().GetName().Name + "\\Connections";
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
            key.DeleteSubKeyTree(connectionname.ToString());
            key.Close();
            loadConnections();
        }

        private void ConnectionsForm_Load(object sender, EventArgs e)
        {
            loadConnections();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(var rform = new ConnectForm(true, connectionsView.SelectedItems[0].Text.ToString()))
            {
                var result = rform.ShowDialog();
                if(result == DialogResult.OK)
                {

                }
            }
            loadConnections();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteConnection(connectionsView.SelectedItems[0].Text.ToString());
        }

        private void connectionsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(connectionsView.SelectedItems.Count > 0) {
                if(connectionsView.SelectedItems[0].Text.ToString() != "") {
                    editToolStripMenuItem.Enabled = true;
                    deleteToolStripMenuItem.Enabled = true;
                } else {
                    editToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = false;
                }
            }
        }
    }
}
