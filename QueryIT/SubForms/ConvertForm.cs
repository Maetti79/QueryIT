using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QueryIT {
    public partial class ConvertForm : Form {

        public string inputFile = "";
        public string outputFile = "";

        public ConvertForm() {
            InitializeComponent();
        }

        public ConvertForm(string filename) {
            inputFile = filename;
            outputFile = inputFile.Replace(".log",".csv");
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e) {
            tryConvert(true);
        }

        private void ConvertForm_Load(object sender, EventArgs e) {
            filename.Text = inputFile;
            tryConvert(true);
        }

        public void tryConvert(bool preview) {
            //try {
                string[] Columns = new string[0];
                object[] Rows = new string[0];
                string[] Row = new string[0];
                string lines = "";
                string trylines = "";
                string line = "";
                int maxtrylines = 1000 * 100000;
                int maxtryrecords = 100000;
                if(preview == true) {
                    maxtrylines = 1000;
                    maxtryrecords = 3;
                }
                int records = 0;
                int linenum = 0;
                int pos = 0;
                int startPos = 0;
                int endPos = 0;
                bool startFound = false;
                bool endFound = false;
                int ColumnsDone = 0;
                convertGrid.Rows.Clear();
                convertGrid.Columns.Clear();
                StreamReader tmpf = new StreamReader(filename.Text);
                StringBuilder sb = new StringBuilder();
                while(line != null && linenum < maxtrylines && records < maxtryrecords) {
                    string recordString = "";
                    line = tmpf.ReadLine();
                    lines += line + "\n";
                    trylines = lines;
                    if(trylines != "") {
                        if(prefix.Text.Length > 0) {
                            trylines = trylines.Replace(prefix.Text, "");
                        }
                        if(subfix.Text.Length > 0) {
                            trylines = trylines.Replace(subfix.Text, "");
                        }
                        if(strip.Text.Length > 0) {
                            trylines = trylines.Replace(strip.Text, "");
                        }
                        if(trylines.Contains(start.Text) && startFound == false) {
                            startFound = true;
                            startPos = trylines.IndexOf(start.Text, pos);
                            pos = startPos;
                        }
                        if(trylines.Contains(end.Text) && endFound == false && startFound == true) {
                            endFound = true;
                            endPos = trylines.IndexOf(end.Text, pos);
                            pos = endPos;
                        }
                        if(startFound == true && endFound == true) {
                            recordString = trylines.Substring(startPos, endPos - startPos + 1);
                            lines = "";
                            pos = 0;
                            startFound = false;
                            endFound = false;
                            startPos = 0;
                            endPos = 0;
                            records++;
                            Row = Row.Clear();
                            recordString = recordString.Replace(start.Text, "");
                            recordString = recordString.Replace(end.Text, "");
                            string[] rawlines = recordString.Split(seperator.Text.ToCharArray());
                            //Columns
                            if(Columns.Count() == 0) {
                                foreach(string rawline in rawlines) {
                                    string rline = rawline.Replace("\n", "");
                                    rline = rline.TrimEnd();
                                    rline = rline.TrimStart();
                                    string[] rawcol = rline.Split(delimiter.Text.ToCharArray());
                                    if(rawcol.Count() == 3) {
                                        if(Columns.Contains(rawcol[0].Trim()) == false) {
                                            Columns = Columns.AddItemToArray(rawcol[0].Trim());
                                        } else {
                                            break;
                                        }
                                    }
                                }
                                foreach(string col in Columns) {
                                    convertGrid.Columns.Add(col.ToString(), col.ToString());
                                }
                                if(ColumnsDone == 0) {
                                    ColumnsDone = 1;
                                }
                                if(preview == false && ColumnsDone == 1) {
                                    sb.AppendLine(string.Join(";", Columns));
                                    File.Delete(outputFile);
                                    File.WriteAllText(outputFile, sb.ToString());
                                    sb.Clear();
                                    ColumnsDone = 2;
                                }
                            }


                            //Rows
                            foreach(string rawline in rawlines) {
                                string rline = rawline.Replace("\n", "");
                                rline = rline.TrimEnd();
                                rline = rline.TrimStart();
                                string[] rawcol = rline.Split(delimiter.Text.ToCharArray());
                                if(rawcol == null) {
                                    rawcol.AddItemToArray("");
                                }
                                if(rawcol.Count() == 3) {
                                    Row = Row.AddItemToArray(rawcol[2].Trim());
                                    if(Row.Count() == Columns.Count()) {
                                        Rows = Rows.AddItemToArray(Row);
                                        DataGridViewRow gvrow = (DataGridViewRow)convertGrid.Rows[0].Clone();
                                        int i = 0;
                                        foreach(string rcol in Row) {
                                            if(gvrow.Cells.Count > i) {
                                                gvrow.Cells[i].Value = rcol.ToString();
                                            } else {
                                                gvrow.Cells[i].Value = rcol.ToString();
                                            }
                                            i++;
                                        }
                                        convertGrid.Rows.Add(gvrow);
                                        if(preview == false) {
                                            sb.AppendLine(string.Join(";", Row));
                                            File.AppendAllText(outputFile, sb.ToString());
                                            sb.Clear();
                                        }
                                        Row = Row.Clear();
                                    }
                                }
                            }

                        }
                    }
                    linenum++;
                    fileBox.Text = trylines;
                    Application.DoEvents();
                }
                fileBox.Text = trylines;
                tmpf.Close();
            //} catch(Exception err) {
            //    throw err;
            //}
        }

        private void ConvertBtn_Click(object sender, EventArgs e) {
            tryConvert(false);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
