using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QueryIT.model;
using IPlugin;

namespace QueryIT {
    public partial class CompareForm : Form {
        private MainForm parent;
        private String LicenseInformation = "";

        public PluginCore plugincore = new PluginCore(Environment.CurrentDirectory);
        public Datasource LDS;
        public Datasource RDS;

        public DataTable Temp = new DataTable();
        public DataTable Source = new DataTable();
        public DataTable Both = new DataTable();
        public DataTable Destination = new DataTable();

        public bool run = false;
        public bool isMoved = false;
        public DateTime utcStart;
        public DateTime utcStop;

        public CompareForm() {
            InitializeComponent();
        }

        public CompareForm(Datasource leftDS, Datasource rightDS) {
            LDS = leftDS;
            RDS = rightDS;
            InitializeComponent();
        }

        public void loadPlugins() {
            try {
                Array pls = plugincore.getPlugins(LicenseInformation);
                foreach(Object pl in pls) {
                    if(plugincore.Hook(pl.ToString()) == pluginHook.Compare || plugincore.Hook(pl.ToString()) == pluginHook.All) {
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

        public void compareRaw() {
            try {
                bool limit = false;
                compareToolStripMenuItem.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                Source = LDS.result.Copy();
                Both = LDS.result.Clone();
                Destination = RDS.result.Copy();
                if(LicenseInformation.Contains("Compare") == false) {
                    limit = true;
                }
                DateTime utcStart;
                DateTime utcStop;
                ProgressForm pform = new ProgressForm(this, "Progress [Compare]");
                pform.update(0, Source.Rows.Count,0);
                pform.Show();
                int loops = 0;
                sourceGrid.DataSource = Source;
                bothGrid.DataSource = Both;
                destinationGrid.DataSource = Destination;
                run = true;
                int total = Source.Rows.Count;
                bool match = false;
                int matches = 0;
                int indexS = 0;
                int indexD = 0;
                utcStart = DateTime.UtcNow;
                while(indexS < Source.Rows.Count && run == true) {
                    indexD = 0;
                    while(indexD < Destination.Rows.Count && run == true) {
                        if(Source.Rows[indexS].ItemArray.arrEquals(Destination.Rows[indexD].ItemArray)) {
                            Both.ImportRow(Source.Rows[indexS]);
                            Source.Rows[indexS].Delete();
                            Destination.Rows[indexD].Delete();
                            matches++;
                            match = true;
                            break;
                        }
                        indexD++;
                    }
                    if(match == false || indexD == Destination.Rows.Count) {
                        indexS++;
                    }
                    loops++;
                    if(loops % 250 == 0) {
                        pform.update(0, Source.Rows.Count, indexS + matches);
                        Application.DoEvents();
                    }
                    if(limit == true && indexS + matches > 500) {
                        try {
                            using(var sform = new LicenseForm(parent)) {
                                var result = sform.ShowDialog();
                                if(result == DialogResult.OK) {

                                }
                            }
                        } catch(Exception err) {
                            parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                        }
                        break;
                    }
                }
                utcStop = DateTime.UtcNow;
                pform.Hide();
                pform.Dispose();
                run = false;
                compareToolStripMenuItem.Enabled = true;
                killToolStripMenuItem.Enabled = false;
                sourceGrid.Refresh();
                bothGrid.Refresh();
                destinationGrid.Refresh();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }


        private void MenuItemClickHandler(object sender, EventArgs e) {
            try {
                ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
                Both = plugincore.Process(clickedItem.Name.ToString(), Both, "");
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void CompareForm_Load(object sender, EventArgs e) {
            parent = this.MdiParent as MainForm;
            LicenseInformation = parent.LicenseInformation;
            try {
                loadPlugins();
                doResize();
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

        private void sourceOnlyToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                using(var sfd = new SaveFileDialog()) {
                    sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    if(sfd.ShowDialog() == DialogResult.OK) {
                        Temp = LDS.result;
                        LDS.result = Source;
                        LDS.exportCSV(sfd.FileName);
                        LDS.result = Temp;
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void destinationOnlyToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                using(var sfd = new SaveFileDialog()) {
                    sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    if(sfd.ShowDialog() == DialogResult.OK) {
                        Temp = LDS.result;
                        RDS.result = Destination;
                        RDS.exportCSV(sfd.FileName);
                        RDS.result = Temp;
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void matchesToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                using(var sfd = new SaveFileDialog()) {
                    sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    if(sfd.ShowDialog() == DialogResult.OK) {
                        Temp = LDS.result;
                        RDS.result = Both;
                        RDS.exportCSV(sfd.FileName);
                        RDS.result = Temp;
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void exportSourceToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if(tabCompare.SelectedTab == sourceTab) {
                    using(var sfd = new SaveFileDialog()) {
                        sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                        sfd.FilterIndex = 1;
                        if(sfd.ShowDialog() == DialogResult.OK) {
                            Temp = LDS.result;
                            LDS.result = Source;
                            LDS.exportCSV(sfd.FileName);
                            LDS.result = Temp;
                        }
                    }
                }
                if(tabCompare.SelectedTab == compareTab) {
                    using(var sfd = new SaveFileDialog()) {
                        sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                        sfd.FilterIndex = 1;
                        if(sfd.ShowDialog() == DialogResult.OK) {
                            Temp = LDS.result;
                            RDS.result = Both;
                            RDS.exportCSV(sfd.FileName);
                            RDS.result = Temp;
                        }
                    }
                }
                if(tabCompare.SelectedTab == destinationTab) {
                    using(var sfd = new SaveFileDialog()) {
                        sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                        sfd.FilterIndex = 1;
                        if(sfd.ShowDialog() == DialogResult.OK) {
                            Temp = LDS.result;
                            RDS.result = Destination;
                            RDS.exportCSV(sfd.FileName);
                            RDS.result = Temp;
                        }
                    }
                }
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void compareToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                compareRaw();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void killToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                run = false;
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

    }
}
