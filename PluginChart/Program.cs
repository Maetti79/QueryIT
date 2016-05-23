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

namespace PluginChart {
    public class BuildChart : IPlugin.IPlugin {
        #region IPlugin Members

        public Image Icon() {
            return PluginChart.Properties.Resources.pluginImage;
        }

        public string Name {
            get { return "BuildChart"; }
            set { ; }
        }

        public string Description {
            get { return "Build Chart"; }
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

        public DataTable Process(DataTable Data, String Arg) {
            ChartForm crtFrm = new ChartForm(Data);
            crtFrm.Show();

            return Data;
        }

        #endregion
    }
}
