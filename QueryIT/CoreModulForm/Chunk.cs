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
using AutocompleteMenuNS;

namespace QueryIT {
    public partial class ChunkForm : Form {

        private MainForm parent;
        private String LicenseInformation = "";

        public PluginCore plugincore = new PluginCore(Environment.CurrentDirectory);
        public Datasource LDS;
        public Datasource RDS;
        public DataTable DT;

        public bool run = false;
        public bool isMoved = false;

        public DateTime utcStart;
        public DateTime utcStop;

        public ChunkForm() {
            InitializeComponent();
        }

        public ChunkForm(Datasource LeftDS, Datasource RightDS) {
            LDS = LeftDS;
            RDS = RightDS;
            InitializeComponent();
        }

        public void loadPlugins() {
            try {
                Array pls = plugincore.getPlugins(LicenseInformation);
                foreach(Object pl in pls) {
                    if(plugincore.Hook(pl.ToString()) == pluginHook.ForEach || plugincore.Hook(pl.ToString()) == pluginHook.All) {
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
                    LDS.result = plugincore.Process(clickedItem.Name.ToString(), LDS.result, "");
                }
                if(plugincore.Type(clickedItem.Name.ToString()) == pluginType.Filter) {
                    LDS.result = plugincore.Process(clickedItem.Name.ToString(), LDS.result, "");
                }
                if(plugincore.Type(clickedItem.Name.ToString()) == pluginType.Export) {
                    LDS.result = plugincore.Process(clickedItem.Name.ToString(), LDS.result, "");
                }
                if(plugincore.Type(clickedItem.Name.ToString()) == pluginType.Other) {
                    LDS.result = plugincore.Process(clickedItem.Name.ToString(), LDS.result, "");
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

        
        private void ChunkForm_Load(object sender, EventArgs e) {
            parent = this.MdiParent as MainForm;
            LicenseInformation = parent.LicenseInformation;
            try {
                loadPlugins();
                doResize();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void killToolStripMenuItem_Click_1(object sender, EventArgs e) {
            try {
                run = false;
                LDS.run = false;
                LDS.cancelSQL();
                RDS.run = false;
                RDS.cancelSQL();
            } catch(Exception err) {
                parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e) {
              try {
                run = true;
                runToolStripMenuItem.Enabled = false;
                killToolStripMenuItem.Enabled = true;
                if(LicenseInformation.Contains("Chunk") == false) {
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
                utcStart = DateTime.UtcNow;
                ProgressForm pform = new ProgressForm(this, "Progress [Chunk]");
                pform.update(0, LDS.row_count, 0);
                pform.Show();

                string query = selectSQL.Text.Replace("%limit%", "LIMIT " + chunk.Text.ToString() + "," + offset.Text.ToString());
                string queryv = insertupdateSQL.Text.ToString();
                int pos = 0;
                while(LDS.executeSql(query) && LDS.hasResult() == true && LDS.hasErrors() == false && run == true) {
                    DT = new DataTable();
                    DT.Clear();
                    chunkResultGrid.Columns.Clear();
                    chunkResultGrid.DataSource = null;
                    if(LDS.hasResult() == true) {
                        //Needed to Copy for Cell Edit
                        DT = LDS.result.Copy();
                    } else {
                        run = false;
                    }
                    chunkResultGrid.DataSource = DT;
                    chunkResultGrid.Refresh();
                    foreach(DataRow row in LDS.result.Rows) {
                        queryv = insertupdateSQL.Text.ToString();
                        foreach(DataColumn col in LDS.result.Columns) {
                            if(queryv.ToLower().Contains("#" + col.Caption.ToString().ToLower() + "#")) {
                                queryv = queryv.Replace("#" + col.Caption.ToString().ToLower() + "#", row[col.Ordinal].ToString());
                            }
                        }
                        pos++;
                        if(pos % 250 == 0) {
                            offset.Text = pos.ToString();
                            pform.update(0, LDS.row_count, pos);
                            Application.DoEvents();
                        }
                        if(run == false) {
                            break;
                        }
                    }
                }

                pform.Hide();
                pform.Dispose();
                run = false;
                runToolStripMenuItem.Enabled = true;
                killToolStripMenuItem.Enabled = false;
                utcStop = DateTime.UtcNow;
              } catch(Exception err) {
                  parent.errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                  run = false;
                  runToolStripMenuItem.Enabled = true;
                  killToolStripMenuItem.Enabled = false;
              }
        }

        private void runinChunksToolStripMenuItem_Click(object sender, EventArgs e) {

        }

    }
}
