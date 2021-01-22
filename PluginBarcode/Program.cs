using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using System.Text;
using System.Data.Odbc;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using IPlugin;

namespace PluginBarcode {
    public class BuildBarcode : IPlugin.IPlugin {
        #region IPlugin Members

        private String iError;

        public Image Icon() {
            return PluginBarcode.Properties.Resources.pluginImage;
        }

        public string Name {
            get { return "BuildBarcode"; }
            set { ; }
        }

        public string Description {
            get { return "Build Barcode"; }
            set { ; }
        }

        public string Author {
            get { return "Dennis Mittmann"; }
            set { ; }
        }

        public string Version {
            get { return "Version 1.0"; }
            set { ; }
        }

        public pluginType Type {
            get { return pluginType.Other; }
            set { ; }
        }

        public pluginHook Hook {
            get { return pluginHook.Queryer; }
            set { ; }
        }

        public string Error
        {
            get { return iError; }
            set {; }
        }

        public DataTable Process(DataTable Data, String Arg) {
            BarcodeForm crtFrm = new BarcodeForm(Data);
            crtFrm.Show();
            iError = crtFrm.iError;
            return Data;
        }

        #endregion
    }
}
