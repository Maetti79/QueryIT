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

namespace PluginTAB {
    public class ExportTAB : IPlugin.IPlugin {
        #region IPlugin Members

        public Image Icon() {
            return PluginTAB.Properties.Resources.pluginImage;
        }

        public string Name {
            get { return "ExportTAB"; }
            set { ; }
        }

        public string Description {
            get { return "Export to *.*"; }
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
                sfd.Filter = "All files (*.*)|*.*";
                sfd.FilterIndex = 1;
                if(sfd.ShowDialog() == DialogResult.OK) {
                    try {
                        using(var exp = new ExportForm()) {
                            if(exp.ShowDialog() == DialogResult.OK) { 
                                            //exp.LineEnding
                                StringBuilder sb = new StringBuilder();
                                IEnumerable<string> columnNames = Data.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
                                if(exp.ColumnNames == true) {
                                    if(exp.Delemiter.ToString() == "\\t") {
                                        sb.Append(string.Join("\t", columnNames));
                                    } else {
                                        sb.Append(string.Join(exp.Delemiter.ToString(), columnNames));
                                    }
                                    if(exp.LineEnding.ToString() == "\\n") {
                                        sb.Append("\n");
                                    } else if(exp.LineEnding.ToString() == "\\r") {
                                        sb.Append("\r");
                                    } else if(exp.LineEnding.ToString() == "\\n\\r") {
                                        sb.Append("\n\r");
                                    } else if(exp.LineEnding.ToString() == "\\r\\n") {
                                        sb.Append("\r\n");
                                    } else {
                                        sb.Append(exp.LineEnding.ToString());
                                    }
                                }
                                foreach(DataRow row in Data.Rows) {
                                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                                    if(exp.Delemiter.ToString() == "\\t") {
                                         sb.Append(string.Join("\t", fields));
                                    } else {
                                     sb.Append(string.Join(exp.Delemiter.ToString(), fields));
                                    }
                                    if(exp.LineEnding.ToString() == "\\n") {
                                        sb.Append("\n");
                                    } else if(exp.LineEnding.ToString() == "\\r") {
                                        sb.Append("\r");
                                    } else if(exp.LineEnding.ToString() == "\\n\\r") {
                                        sb.Append("\n\r");
                                    } else if(exp.LineEnding.ToString() == "\\r\\n") {
                                        sb.Append("\r\n");
                                    } else {
                                        sb.Append(exp.LineEnding.ToString());
                                    }
                                }
                                File.WriteAllText(sfd.FileName, sb.ToString());
                            }
                        }
                    } catch(Exception e) {

                    }
                }
            }
            return Data;
        }

        #endregion
    }
}
