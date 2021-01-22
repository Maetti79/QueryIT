using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using IPlugin;
using Microsoft.Win32;
using QueryIT.model;

namespace QueryIT {

    public partial class MainForm : Form {

        public PluginCore plugincore = new PluginCore(Environment.CurrentDirectory);
        public String SerialManager = Serial.GetSerialNumber();
        public String LicenseInformation = "";

        public ProcessorUsage pu = new ProcessorUsage();
        public Datasource[] QueryerADS;
        public QueryerForm[] QueryerQS;

        public Datasource LeftDS = new Datasource();
        public QueryerForm LeftQ;

        public Datasource RightDS = new Datasource();
        public QueryerForm RightQ;

        public MoveForm CenterQ;
        public CompareForm CenterC;
        public CrossJoin CenterCJ;
        public ForeachForm CenterFE;
        public ChunkForm CentercHK;

        public String[] Error;

        public MainForm() {
            InitializeComponent();
        }

        public bool loadLicense() {
            try {
                LicenseInformation = Serial.CallWebservice("https://queryit.purepix.net/", Serial.GetSerialNumber());
                Microsoft.Win32.RegistryKey key;
                string rootKey = "SOFTWARE\\" + Assembly.GetExecutingAssembly().GetName().Name;
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
                if(key == null) {
                    key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
                }
                key.SetValue("LicenseInformation", LicenseInformation);
                key.Close();
                return true;
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                return false;
            }
        }

        public void loadPlugins() {
            try {
                Array pls = plugincore.getPlugins(LicenseInformation);
                foreach(Object pl in pls) {
                    Console.WriteLine(pl.ToString());
                    if(plugincore.Hook(pl.ToString()) == pluginHook.Main || plugincore.Hook(pl.ToString()) == pluginHook.All) {
                        ToolStripMenuItem item = new ToolStripMenuItem();
                        item.Text = plugincore.Description(pl.ToString());
                        item.Name = pl.ToString();
                        item.Image = plugincore.Icon(pl.ToString());
                        item.Enabled = false;
                        //item.Click += new EventHandler(item_Click);
                        pluginsToolStripMenuItem.DropDownItems.Insert(pluginsToolStripMenuItem.DropDownItems.Count, item);
                    } else if(plugincore.Hook(pl.ToString()) != pluginHook.none) {
                        ToolStripMenuItem item = new ToolStripMenuItem();
                        item.Text = plugincore.Description(pl.ToString()) + " [" + plugincore.Hook(pl.ToString()) + ", " + plugincore.Type(pl.ToString()) + "]";
                        item.Name = pl.ToString();
                        item.Image = plugincore.Icon(pl.ToString());
                        item.Enabled = false;
                        //item.Click += new EventHandler(item_Click);
                        pluginsToolStripMenuItem.DropDownItems.Insert(pluginsToolStripMenuItem.DropDownItems.Count, item);
                    }
                }

                //errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.ArgumentException("Test Exception for Bug Report Testing", "original"));

            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        public void openQueryer(string conectionString, string conName) {
            try {
                Datasource QueryerDS = new Datasource(conectionString, conName);
                if(QueryerDS.isConnected() == true) {
                    QueryerForm QueryerQ = new QueryerForm(QueryerDS, "mid");
                    if(QueryerQS != null) {
                        QueryerQ.index = QueryerQS.Length;
                    }
                    if(QueryerADS != null) {
                        QueryerDS.index = QueryerADS.Length;
                    }
                    QueryerQ.nameindex = "Queryer" + QueryerQ.index;
                    QueryerQ.MdiParent = this;
                    QueryerQ.Show();
                    QueryerQ.Focus();
                    QueryerQS = QueryerQS.AddItemToArray(QueryerQ);
                    QueryerADS = QueryerADS.AddItemToArray(QueryerDS);
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        public void openSource(string conStr, string conName) {
            try {
                if(LeftDS.isConnected() == false) {
                    LeftDS = new Datasource(conStr, conName);
                    if(LeftDS.isConnected() == true) {
                        LeftQ = new QueryerForm(LeftDS, "left");
                        LeftQ.nameindex = "Source";
                        LeftQ.MdiParent = this;
                        LeftQ.Show();
                        LeftQ.Focus();
                    }
                } else {
                    if(LeftQ.Visible == false) {
                        LeftQ = new QueryerForm(LeftDS, "left");
                    }
                    LeftQ.MdiParent = this;
                    LeftQ.Show();
                    LeftQ.Focus();
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        public void openDestination(string conStr, string conName) {
            try {
                if(RightDS.isConnected() == false) {
                    RightDS = new Datasource(conStr, conName);
                    if(RightDS.isConnected() == true) {
                        RightQ = new QueryerForm(RightDS, "right");
                        RightQ.nameindex = "Destination";
                        RightQ.MdiParent = this;
                        RightQ.Show();
                        RightQ.Focus();
                    }
                } else {
                    if(RightQ.Visible == false) {
                        RightQ = new QueryerForm(RightDS, "right");
                    }
                    RightQ.MdiParent = this;
                    RightQ.Show();
                    RightQ.Focus();
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            try {
                Microsoft.Win32.RegistryKey key;
                string rootKey = "SOFTWARE\\" + Assembly.GetExecutingAssembly().GetName().Name;
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
                if(key == null) {
                    key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
                }
                key.SetValue("Serial", SerialManager.ToString());
                key.SetValue("Version", Assembly.GetExecutingAssembly().GetName().Version.ToString());
                if(key.GetValue("LicenseInformation") != null) {
                    LicenseInformation = key.GetValue("LicenseInformation").ToString();
                }
                key.Close();
                loadLicense();
                loadPlugins();
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }



        private void connectRightMenu_Click(object sender, EventArgs e) {
            try {
                if(RightDS.isConnected() == false) {
                    using(var lform = new ConnectForm()) {
                        var result = lform.ShowDialog();
                        if(result == DialogResult.OK) {
                            string conStr = lform.conStr;
                            string conName = lform.connectionName;
                            RightDS = new Datasource(conStr, conName);
                            if(RightDS.isConnected() == true) {
                                RightQ = new QueryerForm(RightDS, "right");
                                RightQ.nameindex = "Destination";
                                RightQ.MdiParent = this;
                                RightQ.Show();
                                RightQ.Focus();
                            }
                        }
                    }
                } else {
                    if(RightQ.Visible == false) {
                        RightQ = new QueryerForm(RightDS, "right");
                    }
                    RightQ.MdiParent = this;
                    RightQ.Show();
                    RightQ.Focus();
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void connectLeftMenu_Click(object sender, EventArgs e) {
            try {
                if(LeftDS.isConnected() == false) {
                    using(var rform = new ConnectForm()) {
                        var result = rform.ShowDialog();
                        if(result == DialogResult.OK) {
                            string conStr = rform.conStr;
                            string conName = rform.connectionName;
                            LeftDS = new Datasource(conStr, conName);
                            if(LeftDS.isConnected() == true) {
                                LeftQ = new QueryerForm(LeftDS, "left");
                                LeftQ.nameindex = "Source";
                                LeftQ.MdiParent = this;
                                LeftQ.Show();
                                LeftQ.Focus();
                            }
                        }
                    }
                } else {
                    if(LeftQ.Visible == false) {
                        LeftQ = new QueryerForm(LeftDS, "left");
                    }
                    LeftQ.MdiParent = this;
                    LeftQ.Show();
                    LeftQ.Focus();
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void configureMappingToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if(LeftDS.isConnected() == true && RightDS.isConnected() == true) {
                    if(CenterQ == null) {
                        CenterQ = new MoveForm(LeftDS, RightDS);
                    } else if(CenterQ.Visible == false) {
                        CenterQ = new MoveForm(LeftDS, RightDS);
                    }
                    CenterQ.MdiParent = this;
                    CenterQ.Show();
                    CenterQ.Focus();
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                AboutForm aform = new AboutForm();
                aform.Show();
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }

        }

        private void Main_Resize(object sender, EventArgs e) {
            foreach(QueryForm child in this.MdiChildren.OfType<QueryForm>()) {
                child.doResize();
            }
            foreach(MoveForm child in this.MdiChildren.OfType<MoveForm>()) {
                child.doResize();
            }
        }

        private void queryerToolStripMenuItem_Click(object sender, EventArgs e) {
            using(var rform = new ConnectForm()) {
                var result = rform.ShowDialog();
                if(result == DialogResult.OK) {
                    string conStr = rform.conStr;
                    string conName = rform.connectionName;
                    Datasource QueryerDS = new Datasource(conStr, conName);
                    if(QueryerDS.isConnected() == true) {
                        QueryerForm QueryerQ = new QueryerForm(QueryerDS, "mid");
                        if(QueryerQS != null) {
                            QueryerQ.index = QueryerQS.Length;
                        }
                        if(QueryerADS != null) {
                            QueryerDS.index = QueryerADS.Length;
                        }
                        QueryerQ.nameindex = "Queryer" + QueryerQ.index;
                        QueryerQ.MdiParent = this;
                        QueryerQ.Show();
                        QueryerQ.Focus();
                        QueryerQS = QueryerQS.AddItemToArray(QueryerQ);
                        QueryerADS = QueryerADS.AddItemToArray(QueryerDS);
                    }
                }
            }
        }

        private void statsTimer_Tick(object sender, EventArgs e) {
            try {
                Process currentProc = Process.GetCurrentProcess();
                memLbl.Text = "Memory: " + Math.Round((decimal)(currentProc.PrivateMemorySize64 / 1000 / 1000), 2).ToString() + "MB";
                cpuLbl.Text = "CPU: " + Math.Round((decimal)pu.GetCurrentValue(), 2).ToString() + "%";
                if(LeftDS.isConnected() == true && RightDS.isConnected() == true) {
                    moveColumnMappingToolStripMenuItem.Enabled = true;
                    compareToolStripMenuItem1.Enabled = true;
                    crossJoinToolStripMenuItem1.Enabled = true;
                    forEachToolStripMenuItem.Enabled = true;
                    chunkToolStripMenuItem.Enabled = true;
                } else {
                    moveColumnMappingToolStripMenuItem.Enabled = false;
                    compareToolStripMenuItem1.Enabled = false;
                    crossJoinToolStripMenuItem1.Enabled = false;
                    forEachToolStripMenuItem.Enabled = false;
                    chunkToolStripMenuItem.Enabled = false;
                }
                if(LeftDS.run == true && DateTime.UtcNow.Subtract(LeftDS.utcStart).Seconds > 0) {
                    leftStatus.Text = "Source [" + DateTime.UtcNow.Subtract(LeftDS.utcStart).Seconds + "s]";
                } else {
                    leftStatus.Text = "Source";
                }
                if(LeftDS.isConnected() == true) {
                    leftStatus.Image = MainIcons.Images[1];
                } else {
                    leftStatus.Image = MainIcons.Images[2];
                }
                if(RightDS.run == true && DateTime.UtcNow.Subtract(RightDS.utcStart).Seconds > 0) {
                    rightStatus.Text = "Destination [" + DateTime.UtcNow.Subtract(RightDS.utcStart).Seconds + "s]";
                } else {
                    rightStatus.Text = "Destination";
                }
                if(RightDS.isConnected() == true) {
                    rightStatus.Image = MainIcons.Images[1];
                } else {
                    rightStatus.Image = MainIcons.Images[2];
                }

                if(QueryerADS != null) {
                    foreach(Datasource QueryerDS in QueryerADS) {
                        if(MainStatus.Items.ContainsKey("Queryer" + QueryerDS.index.ToString()) == true) {
                            if(QueryerDS.run == true && DateTime.UtcNow.Subtract(QueryerDS.utcStart).Seconds > 0) {
                                MainStatus.Items[MainStatus.Items.IndexOfKey("Queryer" + QueryerDS.index.ToString())].Text = "Queryer" + QueryerDS.index.ToString() + " [" + DateTime.UtcNow.Subtract(QueryerDS.utcStart).Seconds + "s]";
                            } else {
                                MainStatus.Items[MainStatus.Items.IndexOfKey("Queryer" + QueryerDS.index.ToString())].Text = "Queryer" + QueryerDS.index.ToString();
                            }
                            if(QueryerDS.isConnected() == true) {
                                MainStatus.Items[MainStatus.Items.IndexOfKey("Queryer" + QueryerDS.index.ToString())].Image = MainIcons.Images[1];
                            } else {
                                MainStatus.Items[MainStatus.Items.IndexOfKey("Queryer" + QueryerDS.index.ToString())].Image = MainIcons.Images[2];
                            }
                        } else {
                            ToolStripLabel Qstatus = new ToolStripLabel("Queryer" + QueryerDS.index.ToString()) { Name = "Queryer" + QueryerDS.index.ToString() };
                            if(QueryerDS.isConnected() == true) {
                                Qstatus.Image = MainIcons.Images[1];
                            } else {
                                Qstatus.Image = MainIcons.Images[2];
                            }
                            MainStatus.Items.Add(Qstatus);
                        }
                    }
                }

                if(QueryerQS != null) {
                    foreach(QueryerForm qf in QueryerQS) {
                        if(qf.Visible == false) {
                            int idx = qf.index;
                            QueryerADS = QueryerADS.RemoveAt(idx);
                            for(int i = 0; i < QueryerADS.Length; i++) {
                                QueryerADS[i].index = i;
                            }
                            QueryerQS = QueryerQS.RemoveAt(idx);
                            for(int i = 0; i < QueryerQS.Length; i++) {
                                QueryerQS[i].index = i;
                            }
                            MainStatus.Items.RemoveByKey(qf.nameindex.ToString());
                            qf.Dispose();
                        }
                    }
                }
                if(Error != null) {
                    bugReportToolStripMenuItem.Enabled = true;
                } else {
                    bugReportToolStripMenuItem.Enabled = false;
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        public static bool? IsDirectory(string path) {
            if(Directory.Exists(path)) {
                return true;
            } else if(File.Exists(path)) {
                return false;
            } else {
                return null;
            }
        }

        private void Main_DragDrop(object sender, DragEventArgs e) {
           // try {
                string schema = "";
                string path = "";
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if(files.Count() == 1) {
                    if(IsDirectory(files[0]) == false) {
                        if(files[0].Contains(".log")) {
                            using(var rform = new ConvertForm(files[0])) {
                                var result = rform.ShowDialog();
                                if(result == DialogResult.OK) {

                                } else {
                                    files = null;
                                }
                            }
                        }
                    }
                }
                if(files != null) {
                    if(files.Count() > 0) {
                        if(IsDirectory(files[0]) == true) {
                            path = files[0];
                        } else {
                            path = Path.GetDirectoryName(files[0]);
                        }
                        if(File.Exists(path + "\\Schema.ini")) {
                            schema = File.ReadAllText(path + "\\Schema.ini");
                        }
                        foreach(string file in Directory.GetFiles(path)) {
                            if(file.Contains(".csv")) {
                                if(schema.Contains(Path.GetFileName(file).ToString()) == false) {
                                    System.IO.StreamReader tmpf = new System.IO.StreamReader(file);
                                    string line = tmpf.ReadLine();
                                    string delimiter = "";
                                    if(line != "") {
                                        if(line.Contains(" ")) {
                                            delimiter = "Delimited( )";
                                        }
                                        if(line.Contains("|")) {
                                            delimiter = "Delimited(|)";
                                        }
                                        if(line.Contains("\t")) {
                                            delimiter = "TabDelimited";
                                        }
                                        if(line.Contains(";")) {
                                            delimiter = "Delimited(;)";
                                        }

                                    }
                                    tmpf.Close();
                                    if(delimiter != "") {
                                        schema = schema + "[" + Path.GetFileName(file).ToString() + "]\r\n";
                                        schema = schema + "Format=" + delimiter + "\r\n\r\n";
                                    }
                                }
                            }
                        }
                        if(schema != "") {
                            File.WriteAllText(path + "\\Schema.ini", schema);
                        }

                        if(path != "") {
                            string conStr = "Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" + path + ";Extensions=asc,csv,tab,txt;";
                            Datasource QueryerDS = new Datasource(conStr, Path.GetFileName(path));
                            if(QueryerDS.isConnected() == true) {
                                QueryerForm QueryerQ = new QueryerForm(QueryerDS, "mid");
                                if(QueryerQS != null) {
                                    QueryerQ.index = QueryerQS.Length;
                                }
                                if(QueryerADS != null) {
                                    QueryerDS.index = QueryerADS.Length;
                                }
                                QueryerQ.nameindex = "Queryer" + QueryerQ.index;
                                QueryerQ.MdiParent = this;
                                QueryerQ.Show();
                                QueryerQ.Focus();
                                QueryerQS = QueryerQS.AddItemToArray(QueryerQ);
                                QueryerADS = QueryerADS.AddItemToArray(QueryerDS);
                            }
                        }
                    }
                }
           // } catch(Exception err) {
           //     errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
           // }
        }

        private void Main_DragEnter(object sender, DragEventArgs e) {
            try {
                if(e.Data.GetDataPresent(DataFormats.FileDrop)) {
                    e.Effect = DragDropEffects.Copy;
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                using(var aform = new AboutForm()) {
                    var result = aform.ShowDialog();
                    if(result == DialogResult.OK) {

                    }
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void licenseToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                using(var sform = new LicenseForm(this)) {
                    var result = sform.ShowDialog();
                    if(result == DialogResult.OK) {

                    }
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void compareToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if(LeftDS.isConnected() == true && RightDS.isConnected() == true) {
                    if(CenterC == null) {
                        CenterC = new CompareForm(LeftDS, RightDS);
                    } else if(CenterC.Visible == false) {
                        CenterC = new CompareForm(LeftDS, RightDS);
                    }
                    CenterC.MdiParent = this;
                    CenterC.Show();
                    CenterC.Focus();
                    CenterC.compareRaw();
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void connectionsToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                using(var cform = new ConnectionsForm()) {
                    var result = cform.ShowDialog();
                    if(result == DialogResult.OK) {
                        /*
                        string conStr = cform.conStr;
                        string conName = cform.connectionName;
                        Datasource QueryerDS = new Datasource(conStr, conName);
                        if (QueryerDS.isConnected() == true)
                        {
                            QueryerForm QueryerQ = new QueryerForm(QueryerDS, "mid");
                            if (QueryerQS != null)
                            {
                                QueryerQ.index = QueryerQS.Length;
                            }
                            if (QueryerADS != null)
                            {
                                QueryerDS.index = QueryerADS.Length;
                            }
                            QueryerQ.nameindex = "Queryer" + QueryerQ.index;
                            QueryerQ.MdiParent = this;
                            QueryerQ.Show();
                            QueryerQ.Focus();
                            QueryerQS = QueryerQS.AddItemToArray(QueryerQ);
                            QueryerADS = QueryerADS.AddItemToArray(QueryerDS);
                        }
                        */
                    }
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        public void errorLog(String Class, Exception ErrorMsg) {
            try {
                Error = Error.AddItemToArray(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") + " [" + Class + "] " + ErrorMsg.Message);
            } catch(Exception e) {
                Console.Write(e.Message);
            }

            try {
                using(var bugform = new BugReportForm(Error)) {
                    var result = bugform.ShowDialog();
                    if(result == DialogResult.OK) {

                    }
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void bugReportToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                using(var bugform = new BugReportForm(Error)) {
                    var result = bugform.ShowDialog();
                    if(result == DialogResult.OK) {

                    }
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void crossJoinToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if(LeftDS.isConnected() == true && RightDS.isConnected() == true) {
                    if(CenterCJ == null) {
                        CenterCJ = new CrossJoin(LeftDS, RightDS);
                    } else if(CenterCJ.Visible == false) {
                        CenterCJ = new CrossJoin(LeftDS, RightDS);
                    }
                    CenterCJ.MdiParent = this;
                    CenterCJ.Show();
                    CenterCJ.Focus();
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void moveColumnMappingToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if(LeftDS.isConnected() == true && RightDS.isConnected() == true) {
                    if(CenterQ == null) {
                        CenterQ = new MoveForm(LeftDS, RightDS);
                    } else if(CenterQ.Visible == false) {
                        CenterQ = new MoveForm(LeftDS, RightDS);
                    }
                    CenterQ.MdiParent = this;
                    CenterQ.Show();
                    CenterQ.Focus();
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void compareToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                if(LeftDS.isConnected() == true && RightDS.isConnected() == true) {
                    if(CenterC == null) {
                        CenterC = new CompareForm(LeftDS, RightDS);
                    } else if(CenterC.Visible == false) {
                        CenterC = new CompareForm(LeftDS, RightDS);
                    }
                    CenterC.MdiParent = this;
                    CenterC.Show();
                    CenterC.Focus();
                    //CenterC.compareRaw();
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void crossJoinToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                if(LeftDS.isConnected() == true && RightDS.isConnected() == true) {
                    if(CenterCJ == null) {
                        CenterCJ = new CrossJoin(LeftDS, RightDS);
                    } else if(CenterCJ.Visible == false) {
                        CenterCJ = new CrossJoin(LeftDS, RightDS);
                    }
                    CenterCJ.MdiParent = this;
                    CenterCJ.Show();
                    CenterCJ.Focus();
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void forEachToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if(LeftDS.isConnected() == true && RightDS.isConnected() == true) {
                    if(CenterFE == null) {
                        CenterFE = new ForeachForm(LeftDS, RightDS);
                    } else if(CenterFE.Visible == false) {
                        CenterFE = new ForeachForm(LeftDS, RightDS);
                    }
                    CenterFE.MdiParent = this;
                    CenterFE.Show();
                    CenterFE.Focus();
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void chunkToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if(LeftDS.isConnected() == true && RightDS.isConnected() == true) {
                    if(CentercHK == null) {
                        CentercHK = new ChunkForm(LeftDS, RightDS);
                    } else if(CenterFE.Visible == false) {
                        CentercHK = new ChunkForm(LeftDS, RightDS);
                    }
                    CentercHK.MdiParent = this;
                    CentercHK.Show();
                    CentercHK.Focus();
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void convertToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                string schema = "";
                string path = "";
                string[] files = new string[0];

                using(var rform = new ConvertForm()) {
                    var result = rform.ShowDialog();
                    if(result == DialogResult.OK) {
                        files = files.AddItemToArray(rform.outputFile);
                    }
                }

                if(files != null) {
                    if(files.Count() > 0) {
                        if(IsDirectory(files[0]) == true) {
                            path = files[0];
                        } else {
                            path = Path.GetDirectoryName(files[0]);
                        }
                        if(File.Exists(path + "\\Schema.ini")) {
                            schema = File.ReadAllText(path + "\\Schema.ini");
                        }
                        foreach(string file in Directory.GetFiles(path)) {
                            if(file.Contains(".csv")) {
                                if(schema.Contains(Path.GetFileName(file).ToString()) == false) {
                                    System.IO.StreamReader tmpf = new System.IO.StreamReader(file);
                                    string line = tmpf.ReadLine();
                                    string delimiter = "";
                                    if(line != "") {
                                        if(line.Contains(" ")) {
                                            delimiter = "Delimited( )";
                                        }
                                        if(line.Contains("|")) {
                                            delimiter = "Delimited(|)";
                                        }
                                        if(line.Contains("\t")) {
                                            delimiter = "TabDelimited";
                                        }
                                        if(line.Contains(";")) {
                                            delimiter = "Delimited(;)";
                                        }

                                    }
                                    tmpf.Close();
                                    if(delimiter != "") {
                                        schema = schema + "[" + Path.GetFileName(file).ToString() + "]\r\n";
                                        schema = schema + "Format=" + delimiter + "\r\n\r\n";
                                    }
                                }
                            }
                        }
                        if(schema != "") {
                            File.WriteAllText(path + "\\Schema.ini", schema);
                        }

                        if(path != "") {
                            string conStr = "Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" + path + ";Extensions=asc,csv,tab,txt;";
                            Datasource QueryerDS = new Datasource(conStr, Path.GetFileName(path));
                            if(QueryerDS.isConnected() == true) {
                                QueryerForm QueryerQ = new QueryerForm(QueryerDS, "mid");
                                if(QueryerQS != null) {
                                    QueryerQ.index = QueryerQS.Length;
                                }
                                if(QueryerADS != null) {
                                    QueryerDS.index = QueryerADS.Length;
                                }
                                QueryerQ.nameindex = "Queryer" + QueryerQ.index;
                                QueryerQ.MdiParent = this;
                                QueryerQ.Show();
                                QueryerQ.Focus();
                                QueryerQS = QueryerQS.AddItemToArray(QueryerQ);
                                QueryerADS = QueryerADS.AddItemToArray(QueryerDS);
                            }
                        }
                    }
                }
            } catch(Exception err) {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://queryit.compucampus.de");
        }
    }

}
