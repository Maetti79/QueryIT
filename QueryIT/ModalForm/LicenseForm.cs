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
using Microsoft.Win32;
using System.Web.Script.Serialization;

namespace QueryIT {
    public partial class LicenseForm : Form {

        public PluginCore plugincore = new PluginCore(Environment.CurrentDirectory);
        public String SerialManager = Serial.GetSerialNumber();
        private MainForm parent;
        private String LicenseInformation = "";

        public LicenseForm() {
            InitializeComponent();
        }
        public LicenseForm(MainForm mainfrm) {
            parent = mainfrm;
            InitializeComponent();
        }

        public void loadPlugins() {
            try {
                LicenseBox.Clear();
                LicenseBox.Items.Add("Query", "Core: Queryer", 0);
                LicenseBox.Items.Add("Move", "Core: Mover", 0);
                LicenseBox.Items.Add("Compare", "Core: Compare", 0);
                LicenseBox.Items.Add("CrossJoin", "Core: CrossJoin", 0);
                LicenseBox.Items.Add("ForEach", "Core: ForEach", 0);
                Array pls = plugincore.getPlugins();
                foreach(Object pl in pls) {
                    LicenseBox.Items.Add(pl.ToString(), "Plugin: " + plugincore.Hook(pl.ToString()) + ", " + plugincore.Type(pl.ToString()) + ", " + plugincore.Description(pl.ToString()), 0);
                }
                var dict = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(LicenseInformation);

                Microsoft.Win32.RegistryKey key;
                string rootKey = "SOFTWARE\\" + Assembly.GetExecutingAssembly().GetName().Name;
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
                if(key == null) {
                    key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
                }
                key.SetValue("LicenseInformation", LicenseInformation);
                key.Close();
                foreach(ListViewItem item in LicenseBox.Items) {
                    if(LicenseInformation.Contains(item.Name)) {
                        item.ImageIndex = 1;
                    } else {
                        item.ImageIndex = 0;
                    }
                }

                if(dict["serial"] != null) {
                    SerialLbl.Text = "License Key: " + dict["serial"].ToString();
                }
                if(dict["license"] != null) {
                    LicenseLab.Text = "License Type: " + dict["license"].ToString();
                }
                if(dict["expires"] != null) {
                    ExpiresLbl.Text = "Expires: " + dict["expires"].ToString();
                }
            } catch(Exception licenseEx) {
                Console.Write(licenseEx.Message);
            }
        }

        private void LicenseForm_Load(object sender, EventArgs e) {
            LicenseInformation = parent.LicenseInformation;
            SerialLbl.Text = SerialManager;
            EulaRtf.Rtf = QueryIT.Properties.Resources.EULA;
            loadPlugins();
        }

        private void OkBtn_Click(object sender, EventArgs e) {
            LicenseInformation = Serial.CallWebservice("http://queryit.purepix.net/", Serial.GetSerialNumber());
            Microsoft.Win32.RegistryKey key;
            string rootKey = "SOFTWARE\\" + Assembly.GetExecutingAssembly().GetName().Name;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
            if(key == null) {
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
            }
            key.SetValue("LicenseInformation", LicenseInformation);
            key.Close();
            parent.LicenseInformation = LicenseInformation;
            loadPlugins();
        }

        private void cancelBtn_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void donateBtn_Click(object sender, EventArgs e) {
            string url = "";
            string business = "dennis@beerboys.de";
            string description = "QueryIT%20-%20Donation";
            string country = "DE";
            string currency = "EUR";
            string serial = SerialManager.ToString();
            url += "https://www.paypal.com/cgi-bin/webscr" +
                "?cmd=" + "_donations" +
                "&business=" + business +
                "&lc=" + country +
                "&item_name=" + description +
                "&item_number=" + serial +
                "&custom=" + serial + 
                "&currency_code=" + currency +
                "&amount=25.00" + 
                "&bn=" + "PP%2dDonationsBF";
            System.Diagnostics.Process.Start(url);
        }
    }
}
