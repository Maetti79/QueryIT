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

namespace PluginCSV {
    public class ExportCSV : IPlugin.IPlugin {
        #region IPlugin Members

        public Image Icon() {
            return PluginCSV.Properties.Resources.pluginImage;
        }

        public string Name {
            get { return "ExportCSV"; }
            set { ; }
        }

        public string Description {
            get { return "Export to *.csv"; }
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
            get { return pluginType.Export; }
            set { ; }
        }

        public pluginHook Hook {
            get { return pluginHook.Queryer; }
            set { ; }
        }

        public DataTable Process(DataTable Data, String Arg) {

            using(var sfd = new SaveFileDialog()) {
                sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                sfd.FilterIndex = 1;
                if(sfd.ShowDialog() == DialogResult.OK) {
                    try {
                        StringBuilder sb = new StringBuilder();

                        IEnumerable<string> columnNames = Data.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
                        sb.AppendLine(string.Join(",", columnNames));

                        foreach(DataRow row in Data.Rows) {
                            IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                            sb.AppendLine(string.Join(",", fields));
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString());

                    } catch(Exception e) {


                    }
                }
            }
            return Data;
        }

        #endregion
    }
}
