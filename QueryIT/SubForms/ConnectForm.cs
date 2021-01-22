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

namespace QueryIT {

    public partial class ConnectForm : Form {

        public string connectionName { get; set; }
        public string conStr { get; set; }
        public Boolean asyncCon { get; set; }
        public Boolean sshCon { get; set; }
        public SSHConnectionSettings SSHSettings { get; set; }
        public string Driver { get; set; }
        public string ServerIP { get; set; }
        public string FilePath { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
        public ConnectForm() {
            InitializeComponent();
            SSHSettings = new SSHConnectionSettings();
        }

        public ConnectForm(bool save)
        {
            InitializeComponent();
            SaveChk.Checked = true;
            SSHSettings = new SSHConnectionSettings();
        }

        public ConnectForm(bool save, string connection)
        {
            InitializeComponent();
            SaveChk.Checked = true;
            SSHSettings = new SSHConnectionSettings();
            connectionName = connection;
        }

        public void buildConnectionString() {
            // Folder with CSV
            if (DriverSel.SelectedItem.ToString() == "ODBC File (*.csv)") {
                Driver = "{Microsoft Text Driver (*.txt; *.csv)}";
                ServerIP = ServerTxt.Text.ToString();
                FilePath = ServerTxt.Text.ToString();
                Database = DatabaseTxt.Text.ToString();
                Username = UsernameTxt.Text.ToString();
                Password = PasswordTxt.Text.ToString();
                asyncCon = AsyncChk.Checked;
                conStr = "Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" + FilePath.ToString() + ";Extensions=asc,csv,tab,txt;";
            }
            //Excel 97/2000 File
            if(DriverSel.SelectedItem.ToString() == "ODBC Excel (*.xls)") {
                Driver = "Driver={Microsoft Excel Driver (*.xls)};";
                ServerIP = ServerTxt.Text.ToString();
                FilePath = ServerTxt.Text.ToString();
                Database = DatabaseTxt.Text.ToString();
                Username = UsernameTxt.Text.ToString();
                Password = PasswordTxt.Text.ToString();
                asyncCon = AsyncChk.Checked;
                conStr = "Driver={Microsoft Excel Driver (*.xls)};DriverId=790;Dbq=" + FilePath.ToString() + ";";
            }
            //MySQl Server
            if(DriverSel.SelectedItem.ToString() == "ODBC MySQL (IP)") {
                Driver = "{MySQL ODBC 8.0 Unicode Driver}";
                ServerIP = ServerTxt.Text.ToString();
                FilePath = ServerTxt.Text.ToString();
                Database = DatabaseTxt.Text.ToString();
                Username = UsernameTxt.Text.ToString();
                Password = PasswordTxt.Text.ToString();
                asyncCon = AsyncChk.Checked;
                conStr = "Driver={MySQL ODBC 8.0 Unicode Driver};Server=" + ServerIP.ToString() + ";Database=" + Database.ToString() + ";uid=" + Username.ToString() + ";pwd=" + Password.ToString() + ";";
            }
            //SQLite File
            if(DriverSel.SelectedItem.ToString() == "ODBC SQLite (*.db)") {
                Driver = "Driver=SQLite3 ODBC Driver;";
                ServerIP = ServerTxt.Text.ToString();
                FilePath = ServerTxt.Text.ToString();
                Database = DatabaseTxt.Text.ToString();
                Username = UsernameTxt.Text.ToString();
                Password = PasswordTxt.Text.ToString();
                asyncCon = AsyncChk.Checked;
                conStr = "DRIVER=SQLite3 ODBC Driver;Database=" + FilePath.ToString() + ";LongNames=0;Timeout=1000;NoTXN=0;SyncPragma=NORMAL;StepAPI=0;";
            }
            //PostgreSQL
            if(DriverSel.SelectedItem.ToString() == "ODBC PostgreSQL (IP)") {
                Driver = "Driver{PostgreSQL}";
                ServerIP = ServerTxt.Text.ToString();
                FilePath = ServerTxt.Text.ToString();
                Database = DatabaseTxt.Text.ToString();
                Username = UsernameTxt.Text.ToString();
                Password = PasswordTxt.Text.ToString();
                asyncCon = AsyncChk.Checked;
                conStr = "Driver={PostgreSQL};Server=" + ServerIP.ToString() + ";Port=5432;Database=" + Database.ToString() + ";Uid=" + Username.ToString() + ";Pwd=" + Password.ToString() + ";";
            }
            //MySQL Server
            if (DriverSel.SelectedItem.ToString() == "ADO MySQL (IP)") {
                Driver = "{MySQL ADO Driver}";
                ServerIP = ServerTxt.Text.ToString();
                FilePath = ServerTxt.Text.ToString();
                Database = DatabaseTxt.Text.ToString();
                Username = UsernameTxt.Text.ToString();
                Password = PasswordTxt.Text.ToString();
                asyncCon = AsyncChk.Checked;
                conStr = "SERVER=" + ServerIP.ToString() + ";DATABASE=" + Database.ToString() + ";UID=" + Username.ToString() + ";PASSWORD=" + Password.ToString() + ";PORT=3306;";
                
            }
            //Microsoft (Transakt) SQL Server (97/2000)
            if(DriverSel.SelectedItem.ToString() == "ADO Microsoft SQL (IP)") {
                Driver = "{SQL Server}";
                ServerIP = ServerTxt.Text.ToString();
                FilePath = ServerTxt.Text.ToString();
                Database = DatabaseTxt.Text.ToString();
                Username = UsernameTxt.Text.ToString();
                Password = PasswordTxt.Text.ToString();
                asyncCon = AsyncChk.Checked;
                conStr = "Driver={SQL Server};Server=" + ServerIP.ToString() + ";Database=" + Database.ToString() + ";Uid=" + Username.ToString() + ";Pwd=" + Password.ToString() + ";";
            }
            
            if (DriverSel.SelectedItem.ToString() == "ADO FireBird (IP)")
            {
                Driver = "{FireBird}";
                ServerIP = ServerTxt.Text.ToString();
                FilePath = ServerTxt.Text.ToString();
                Database = DatabaseTxt.Text.ToString();
                Username = UsernameTxt.Text.ToString();
                Password = PasswordTxt.Text.ToString();
                asyncCon = AsyncChk.Checked;
                conStr = "Provider={FireBird};database=" + ServerIP.ToString() + ":" + Database.ToString() + ";user=" + Username.ToString() + ";password=" + Password.ToString() + ";dialect=3;";
            }
            // Provider=MSDASQL;Driver=MySQL ODBC 5.1 Driver;Server=127.0.0.1;Database=datebank_name;Uid=mein_db_user;Pwd=pa_pa_passwort
            if (DriverSel.SelectedItem.ToString() == "ADODB MSDASQL/MYSQL (IP)") {
                Driver = "Provider=MSDASQL;Driver=MySQL ODBC 8.0 Unicode Driver";
                ServerIP = ServerTxt.Text.ToString();
                FilePath = ServerTxt.Text.ToString();
                Database = DatabaseTxt.Text.ToString();
                Username = UsernameTxt.Text.ToString();
                Password = PasswordTxt.Text.ToString();
                asyncCon = AsyncChk.Checked;
                conStr = "Provider=MSDASQL;Driver=MySQL ODBC 8.0 Unicode Driver;Server=" + ServerIP.ToString() + ";Database=" + Database.ToString() + ";Uid=" + Username.ToString() + ";Pwd=" + Password.ToString() + ";";
            }
            conStrBox.Text = conStr.ToString();
        }

        private void ODBCOkBtn_Click(object sender, EventArgs e) {
            buildConnectionString();
            TestConnectionBtn.ImageIndex = 0;

            if (sshChk.Checked == true) {
                //SSHTunnel TestSSH = new SSHTunnel(ss);
            }

            connectionName = ConnectionNameBox.Text.ToString();
            Datasource TestDS = new Datasource(conStr, connectionName);
            if(TestDS.isConnected() == true) {
                TestConnectionBtn.ImageIndex = 1;
                TestDS.disconnect();
                if(SaveChk.Checked == true) {
                    saveConnection();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else {
                errorTxt.Text = TestDS.error.ToString(); 
                TestConnectionBtn.ImageIndex = 2;
                TestDS.disconnect();
            }
        }

        private void selectDriver(object sender, EventArgs e) {
            if(DriverSel.SelectedItem.ToString().Contains("(IP)") == true) {
                BrowseFileBtn.Enabled = false;
                DatabaseTxt.Enabled = true;
                UsernameTxt.Enabled = true;
                PasswordTxt.Enabled = true;
            } else {
                BrowseFileBtn.Enabled = true;
                DatabaseTxt.Enabled = false;
                UsernameTxt.Enabled = false;
                PasswordTxt.Enabled = false;
            }
            buildConnectionString();
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {
            loadConnections();
        }

        private void ODBCCancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void loadConnections()
        {
            Microsoft.Win32.RegistryKey key;
            string rootKey = "SOFTWARE\\" + Assembly.GetExecutingAssembly().GetName().Name + "\\Connections";
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(rootKey);
            if (key == null)
            {
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
            }
            foreach (var v in key.GetSubKeyNames())
            {
                ConnectionNameBox.Items.Add(v);
            }
            key.Close();
            if (ConnectionNameBox.Items.Count == 1) {
                ConnectionNameBox.SelectedIndex = 0;
            }
            if(connectionName != null)
            {
                ConnectionNameBox.Text = connectionName;
                loadConnection();
            }
        }

        public void saveConnection()
        {
            if (ConnectionNameBox.Text.ToString() != "")
            {
                Microsoft.Win32.RegistryKey key;
                Microsoft.Win32.RegistryKey subkey;
                string rootKey = "SOFTWARE\\" + Assembly.GetExecutingAssembly().GetName().Name + "\\Connections";
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
                subkey = key.CreateSubKey(ConnectionNameBox.Text.ToString());

                if (sshCon == true) {
                    subkey.SetValue("SSHcon", "true");
                    subkey.SetValue("SSHUsername", sshUsernameTxt.Text.ToString());
                    subkey.SetValue("SSHPassword", sshPasswordTxt.Text.ToString());
                    subkey.SetValue("SSHServer", sshServerTxt.Text.ToString());
                } else {
                    subkey.SetValue("SSHcon", "false");
                    subkey.SetValue("SSHUsername", "");
                    subkey.SetValue("SSHPassword", "");
                    subkey.SetValue("SSHServer", "");
                }
        
                subkey.SetValue("Driver", DriverSel.SelectedItem.ToString());
                subkey.SetValue("ServerIP", ServerTxt.Text.ToString());
                subkey.SetValue("FilePath", ServerTxt.Text.ToString());
                subkey.SetValue("Database", DatabaseTxt.Text.ToString());
                subkey.SetValue("Username", UsernameTxt.Text.ToString());
                subkey.SetValue("Password", PasswordTxt.Text.ToString());
                if (asyncCon == true) {
                    subkey.SetValue("Async", "true");
                } else {
                    subkey.SetValue("Async", "false");
                }
                
                key.Close();
            }
        }

        public void loadConnection()
        {
            if (ConnectionNameBox.Text.ToString() != "")
            {
                Microsoft.Win32.RegistryKey key;
                Microsoft.Win32.RegistryKey subkey;
                string rootKey = "SOFTWARE\\" + Assembly.GetExecutingAssembly().GetName().Name + "\\Connections";
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(rootKey);
                subkey = key.OpenSubKey(ConnectionNameBox.Text.ToString());

                if (subkey.GetValue("SSHcon") != null)
                {

                    if (subkey.GetValue("SSHcon").ToString() == "true")
                    {
                        sshChk.Checked = true;
                        sshCon = true;
                        sshUsernameTxt.Text = subkey.GetValue("SSHUsername").ToString();
                        sshPasswordTxt.Text = subkey.GetValue("SSHPassword").ToString();
                        sshServerTxt.Text = subkey.GetValue("SSHServer").ToString();
                        sshPortTxt.Text = subkey.GetValue("SSHPort").ToString();
                    }
                    else
                    {
                        sshChk.Checked = false;
                        sshCon = false;
                        sshUsernameTxt.Text = "";
                        sshPasswordTxt.Text = "";
                        sshServerTxt.Text = "";
                        sshPortTxt.Text = "";
                    }

                } else {
                    sshUsernameTxt.Text = "";
                    sshPasswordTxt.Text = "";
                    sshServerTxt.Text = "";
                    sshPortTxt.Text = "";
                }
                
                DriverSel.Text = subkey.GetValue("Driver").ToString();
                if (subkey.GetValue("Driver").ToString() == "ODBC File (*.csv)" || subkey.GetValue("Driver").ToString() == "ODBC File (*.xls)")
                {
                    ServerTxt.Text = subkey.GetValue("FilePath").ToString();
                }
                else
                {
                    ServerTxt.Text = subkey.GetValue("ServerIP").ToString();
                }
                DatabaseTxt.Text = subkey.GetValue("Database").ToString();
                UsernameTxt.Text = subkey.GetValue("Username").ToString();
                PasswordTxt.Text = subkey.GetValue("Password").ToString();
                if (subkey.GetValue("Async") != null)
                {
                    if (subkey.GetValue("Async").ToString() == "true")
                    {
                        AsyncChk.Checked = true;
                        asyncCon = true;
                    }
                    else
                    {
                        AsyncChk.Checked = false;
                        asyncCon = false;
                    }
                }
                key.Close();

            }
        }

        private void ConnectionNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadConnection();
            buildConnectionString();
        }

        private void BrowseFileBtn_Click(object sender, EventArgs e) {
            try {
                if(DriverSel.SelectedItem.ToString().Contains("(IP)") == true) { 
                
                }
                if(DriverSel.SelectedItem.ToString().Contains("SQLite") == true) {
                    using(var sfd = new OpenFileDialog()) {
                        sfd.Filter = "SQLite files (*.db)|*.db|All files (*.*)|*.*";
                        sfd.FilterIndex = 1;
                        if(sfd.ShowDialog() == DialogResult.OK) {
                            ServerTxt.Text = sfd.FileName;
                        }
                    }
                }
                if(DriverSel.SelectedItem.ToString().Contains("*.xls") == true) {
                    using(var sfd = new OpenFileDialog()) {
                        sfd.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
                        sfd.FilterIndex = 1;
                        if(sfd.ShowDialog() == DialogResult.OK) {
                            ServerTxt.Text = sfd.FileName;
                        }
                    }
                }
                if(DriverSel.SelectedItem.ToString().Contains("*.csv") == true) {
                    using(var sfd = new FolderBrowserDialog()) {
                        if(sfd.ShowDialog() == DialogResult.OK) {
                            ServerTxt.Text = sfd.SelectedPath;
                        }
                    }
                }
            } catch(Exception err) {
                throw err;
            }
        }

        private void TestConnectionBtn_Click(object sender, EventArgs e) {
            TestConnectionBtn.ImageIndex = 0;
            if (sshChk.Checked == true) {
                connectionName = ConnectionNameBox.Text.ToString();
                Datasource TestDS = new Datasource(SSHSettings, conStr, connectionName, AsyncChk.Checked);
                if (TestDS.isConnected() == true)
                {
                    errorTxt.Text = "Server Version: " + TestDS.serverVersion;
                    TestConnectionBtn.ImageIndex = 1;
                }
                else
                {
                    errorTxt.Text = TestDS.error.ToString();
                    TestConnectionBtn.ImageIndex = 2;
                }
                TestDS.disconnect();
            } else {
                connectionName = ConnectionNameBox.Text.ToString();
                Datasource TestDS = new Datasource(conStr, connectionName, AsyncChk.Checked);
                if (TestDS.isConnected() == true)
                {
                    errorTxt.Text = "Server Version: " + TestDS.serverVersion;
                    TestConnectionBtn.ImageIndex = 1;
                }
                else
                {
                    errorTxt.Text = TestDS.error.ToString();
                    TestConnectionBtn.ImageIndex = 2;
                }
                TestDS.disconnect();
            }
        }

        private void ServerTxt_TextChanged(object sender, EventArgs e) {
            buildConnectionString();
        }

        private void DatabaseTxt_TextChanged(object sender, EventArgs e) {
            buildConnectionString();
        }

        private void UsernameTxt_TextChanged(object sender, EventArgs e) {
            buildConnectionString();
        }

        private void PasswordTxt_TextChanged(object sender, EventArgs e) {
            buildConnectionString();
        }

        private void conStrBox_TextChanged(object sender, EventArgs e) {

        }

        private void EditConStrBtn_Click(object sender, EventArgs e) {
            conStrBox.Enabled = true;
        }

        private void errorTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void AsyncChk_CheckedChanged(object sender, EventArgs e)
        {
            asyncCon = AsyncChk.Checked;
        }

        private void sshTextButton_Click(object sender, EventArgs e)
        {
            sshTextButton.ImageIndex = 0;
            SSHSettings.SSHlocalPort = "54321";
            if (sshChk.Checked == true)
            {
                sshCon = true;
                SSHSettings.SSHusername = sshUsernameTxt.Text.ToString();
                SSHSettings.SSHpassword = sshPasswordTxt.Text.ToString();
                SSHSettings.SSHserver = sshServerTxt.Text.ToString();
                SSHSettings.SSHremotePort = sshPortTxt.Text.ToString();
                SSHTunnel TestSH = new SSHTunnel(SSHSettings);
                if (TestSH.isConnected() == true)
                {
                    sshTextButton.ImageIndex = 1;
                }
                else {
                    sshTextButton.ImageIndex = 2;
                }
                TestSH.Close();
            }
        }

        private void sshChk_CheckedChanged_1(object sender, EventArgs e)
        {
            sshCon = sshChk.Checked;
            if (sshChk.Checked == true)
            {
                sshUsernameTxt.Enabled = true;
                sshPasswordTxt.Enabled = true;
                sshServerTxt.Enabled = true;
                sshPortTxt.Enabled = true;
            }
            else
            {
                sshUsernameTxt.Enabled = false;
                sshPasswordTxt.Enabled = false;
                sshServerTxt.Enabled = false;
                sshPortTxt.Enabled = false;
            }
        }
    }
}
