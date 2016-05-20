using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using QueryIT.model;
using IPlugin;

namespace QueryIT {
    public partial class CrossJoin : Form {

        private MainForm parent;
        private String LicenseInformation = "";

        public PluginCore plugincore = new PluginCore(Environment.CurrentDirectory);
        public Datasource LDS;
        public Datasource RDS;
        public Datasource DS;
        public DataTable DT;
        //public Datasource[] JDS;
        public bool run = false;
        public bool isMoved = false;

        public CrossJoin() {
            InitializeComponent();
        }

        public CrossJoin(Datasource leftDS, Datasource rightDS) {
            LDS = leftDS;
            RDS = rightDS;
            InitializeComponent();
        }

        public void loadPlugins() {
            try {
                Array pls = plugincore.getPlugins(LicenseInformation);
                foreach(Object pl in pls) {
                    if(plugincore.Hook(pl.ToString()) == pluginHook.CrossJoin || plugincore.Hook(pl.ToString()) == pluginHook.All) {
                        ToolStripMenuItem item = new ToolStripMenuItem();
                        item.Text = plugincore.Description(pl.ToString());
                        item.Name = pl.ToString();
                        item.Image = plugincore.Icon(pl.ToString());
                        item.Click += new EventHandler(MenuItemClickHandler);
                        pluginsToolStripMenuItem.DropDownItems.Insert(pluginsToolStripMenuItem.DropDownItems.Count, item);
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void MenuItemClickHandler(object sender, EventArgs e) {
            try {
                ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
                if(plugincore.Type(clickedItem.Name.ToString()) == pluginType.Import) {
                    //LDS.result = plugincore.Process(clickedItem.Name.ToString(), LDS.result, "");
                }
                if(plugincore.Type(clickedItem.Name.ToString()) == pluginType.Filter) {
                    // LDS.result = plugincore.Process(clickedItem.Name.ToString(), LDS.result, "");
                }
                if(plugincore.Type(clickedItem.Name.ToString()) == pluginType.Export) {
                    // LDS.result = plugincore.Process(clickedItem.Name.ToString(), LDS.result, "");
                }
                if(plugincore.Type(clickedItem.Name.ToString()) == pluginType.Other) {
                    // LDS.result = plugincore.Process(clickedItem.Name.ToString(), LDS.result, "");
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        public void doResize() {
            try {
                if(this.WindowState == FormWindowState.Normal && isMoved == false) {
                    this.Top = 0;
                    this.Left = (this.Parent.Width / 4) - 5;
                    this.Height = this.Parent.Height - 5;
                    this.Width = (this.Parent.Width / 2) - 5;
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        public void doLoad() {
            try {
                SourceSelect.Items.Clear();
                foreach(DataColumn lcol in LDS.result.Columns) {
                    SourceSelect.Items.Add(lcol.Caption.ToString());
                }
                DestinationSelect.Items.Clear();
                foreach(DataColumn rcol in RDS.result.Columns) {
                    DestinationSelect.Items.Add(rcol.Caption.ToString());
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void CrossJoinForm_Load(object sender, EventArgs e) {
            parent = this.MdiParent as MainForm;
            LicenseInformation = parent.LicenseInformation;
            try {
                loadPlugins();
                doLoad();
                doResize();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void killToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                run = false;
                DS.cancelSQL();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void crossJoinToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                run = true;
                crossJoinToolStripMenuItem.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                if(LicenseInformation.Contains("CrossJoin") == false) {
                    try {
                        using(var sform = new LicenseForm(parent)) {
                            var result = sform.ShowDialog();
                            if(result == DialogResult.OK) {

                            }
                        }
                    } catch(Exception err) {
                        parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                    }
                }
                if(Directory.Exists(Path.GetTempPath() + "Queryit") == false) {
                    Directory.CreateDirectory(Path.GetTempPath() + "Queryit");
                }
                if(File.Exists(Path.GetTempPath() + "Queryit\\l.csv")) {
                    File.Delete(Path.GetTempPath() + "Queryit\\l.csv");
                }
                LDS.exportCSV(Path.GetTempPath() + "Queryit\\l.csv");

                if(File.Exists(Path.GetTempPath() + "Queryit\\r.csv")) {
                    File.Delete(Path.GetTempPath() + "Queryit\\r.csv");
                }
                RDS.exportCSV(Path.GetTempPath() + "Queryit\\r.csv");
                string conStr = "Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" + Path.GetTempPath() + "Queryit;Extensions=asc,csv,tab,txt;";
                DT = new DataTable();
                DT.Clear();
                DS = new Datasource(conStr);
                string sqlQuery = "SELECT ";
                foreach(DataColumn lcol in LDS.result.Columns) {
                    sqlQuery += "l." + lcol.Caption.ToString() + " as source_" + lcol.Caption.ToString() + ",";
                }
                foreach(DataColumn rcol in RDS.result.Columns) {
                    sqlQuery += "r." + rcol.Caption.ToString() + " as destination_" + rcol.Caption.ToString() + ",";
                }
                sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 1);
                sqlQuery += " FROM l.csv l LEFT JOIN r.csv r ON l." + SourceSelect.Items[0].ToString() + " = r." + DestinationSelect.Items[0].ToString() + ";";
                if(DS.executeSql(sqlQuery.ToString())) {
                    crossjoinView.Columns.Clear();
                    crossjoinView.DataSource = null;
                    crossjoinView.DataSource = DS.result;
                    crossjoinView.Refresh();
                }

                DS.disconnect();
                if(File.Exists(Path.GetTempPath() + "Queryit\\l.csv")) {
                    File.Delete(Path.GetTempPath() + "Queryit\\l.csv");
                }
                if(File.Exists(Path.GetTempPath() + "Queryit\\r.csv")) {
                    File.Delete(Path.GetTempPath() + "Queryit\\r.csv");
                }
                run = false;
                crossJoinToolStripMenuItem.Enabled = true;
                killToolStripMenuItem.Enabled = false;
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void SourceSelect_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void exportcsvToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                using(var sfd = new SaveFileDialog()) {
                    sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    if(sfd.ShowDialog() == DialogResult.OK) {
                        DS.exportCSV(sfd.FileName);
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }


    }
}
