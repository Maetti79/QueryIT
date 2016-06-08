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

namespace QueryIT {
    public partial class ConvertForm : Form {

        public string inputFile = "";
        public string outputFile = "";

        public ConvertForm() {
            InitializeComponent();
        }

        public ConvertForm(string filename) {
            inputFile = filename;
            outputFile = inputFile.Replace(".log", ".csv");
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e) {
            tryConvert(true);
        }

        public void tryConvert(bool go) {
            int startIndex = -1;
            int startNext = 0;
            int EndIndex = -1;
            int EndNext = 0;
            int pointer = -1;
            string rawRow = "";
            int rawlines = 0;
            string[] Columns = new string[0];
            string[] Row = new string[0];

            convertGrid.Columns.Clear();
            convertGrid.Rows.Clear();

            //Readfile
            if(File.Exists(filename.Text) == true) {
                StreamReader tmpf = new StreamReader(filename.Text);
                string lines = "";
                fileBox.Text = "";
                while(tmpf.EndOfStream == false && (go == true || (rawlines <= 100 && go == false))) {
                            lines += tmpf.ReadLine().ToString() + "\n";
                            rawlines++;
                } 
                fileBox.Text = lines;
                tmpf.Close();
            }



            if(File.Exists(filename.Text) == true) {
                StreamReader tmpf = new StreamReader(filename.Text);
                StringBuilder sb = new StringBuilder();
                if(fileBox.Text.IndexOf(start.Text.ToString(), 0) != -1) {
                    //Walk thru RAW Text
                    while(pointer <= fileBox.Text.Length) {
                        //Find Record Start
                        startIndex = findStart(startNext, start.Text.ToString());
                        startNext = startIndex + start.Text.Length;
                        if(startNext <= 0) {
                            startNext = 1;
                        }
                        //Find Record End
                        EndIndex = findEnd(EndNext, end.Text.ToString());
                        EndNext = EndIndex + end.Text.Length;
                        if(EndNext <= 0) {
                            EndNext = 1;
                        }
                        //get RAW Record
                        if(startIndex > -1 && EndIndex > -1) {
                            if(startIndex < EndIndex) {
                                rawRow = findRecord(startIndex + start.Text.Length, EndIndex);

                            } else {
                                rawRow = "";
                            }
                        } else {
                            rawRow = "";
                        }
                        //Cleanup
                        if(prefix.Text.Length > 0) {
                            rawRow = rawRow.Replace(prefix.Text, "");
                        }
                        if(subfix.Text.Length > 0) {
                            rawRow = rawRow.Replace(subfix.Text, "");
                        }
                        if(strip.Text.Length > 0) {
                            rawRow = rawRow.Replace(strip.Text, "");
                        }
                        rawRow = rawRow.Trim();
                        //get Columns, online once
                        if(Columns.Count() == 0) {
                            if(rawRow != "") {
                                Columns = findColumns(rawRow);
                            }
                        }
                        //Columns
                        if(Columns.Count() > 0 && convertGrid.Columns.Count == 0) {
                            foreach(string col in Columns) {
                                convertGrid.Columns.Add(col.ToString(), col.ToString());
                            }
                            if(go == true) {
                                sb.AppendLine(string.Join(";", Columns));
                                File.Delete(outputFile);
                                File.WriteAllText(outputFile, sb.ToString());
                                sb.Clear();
                            }
                        }
                        //Rows
                        if(Columns.Count() > 0) {
                            if(rawRow != "") {
                                Row = findValues(rawRow, Columns);
                                if(Row.Count() == Columns.Count()) {

                                    DataGridViewRow gvrawRow = (DataGridViewRow)convertGrid.Rows[0].Clone();
                                    int i = 0;
                                    foreach(string rcol in Row) {
                                        if(gvrawRow.Cells.Count > i) {
                                            gvrawRow.Cells[i].Value = rcol.ToString();
                                        } else {
                                            gvrawRow.Cells[i].Value = rcol.ToString();
                                        }
                                        i++;
                                    }
                                    convertGrid.Rows.Add(gvrawRow);
                                    if(go == true) {
                                        sb.AppendLine(string.Join(";", Row));
                                        File.AppendAllText(outputFile, sb.ToString());
                                        sb.Clear();
                                    }
                                }
                            }
                        }
                        //Update
                        Application.DoEvents();
                        if(EndIndex > pointer) {
                            pointer = EndIndex;
                        } else {
                            pointer += 1;
                        }
                    }
                }
            }
        }

        private void ConvertForm_Load(object sender, EventArgs e) {
            filename.Text = inputFile;
            tryConvert(false);
        }

        public int findStart(int offset, string start) {
            int index = -1;
            if(offset < 0) {
                offset = 0;
            }
            if(fileBox.Text.IndexOf(start, offset) != -1) {
                index = fileBox.Text.IndexOf(start, offset);
                int selectStart = fileBox.SelectionStart;
                fileBox.Select(index, start.Length);
                fileBox.SelectionColor = Color.Red;
                fileBox.SelectionFont = new Font(fileBox.Font, FontStyle.Bold);
                fileBox.Select(selectStart, 0);
                fileBox.SelectionFont = fileBox.Font;
                fileBox.SelectionColor = Color.Black;

            }
            return index;
        }

        public int findEnd(int offset, string end) {
            int index = -1;
            if(offset < 0) {
                offset = 0;
            }
            if(fileBox.Text.IndexOf(end, offset) != -1) {
                index = fileBox.Text.IndexOf(end, offset);
                int selectStart = fileBox.SelectionStart;
                fileBox.Select(index, end.Length);
                fileBox.SelectionColor = Color.Red;
                fileBox.SelectionFont = new Font(fileBox.Font, FontStyle.Bold);
                fileBox.Select(selectStart, 0);
                fileBox.SelectionFont = fileBox.Font;
                fileBox.SelectionColor = Color.Black;

            }
            return index;
        }

        public string findRecord(int start, int end) {
            string record = "";
            if(start < 0) {
                start = 0;
            }
            if(end < 0) {
                end = 0;
            }
            int selectStart = fileBox.SelectionStart;
            fileBox.Select(start, end - start);
            fileBox.SelectionColor = Color.Green;
            fileBox.SelectionFont = new Font(fileBox.Font, FontStyle.Bold);
            fileBox.Select(selectStart, 0);
            fileBox.SelectionFont = fileBox.Font;
            fileBox.SelectionColor = Color.Black;
            record = fileBox.Text.Substring(start, end - start);
            return record;
        }


        public void marker(int offset, int length,string k) {

        }

        public string[] findColumns(string rawrecord) {
            string[] Columns = new string[0];
            string[] rawlines = new string[0];
            rawlines = rawrecord.Split("\n".ToCharArray());
            if(rawlines != null) {
                if(rawlines.Count() == 0) {
                    rawlines = rawrecord.Split(seperator.Text.ToCharArray());
                }
            }
            foreach(string rawline in rawlines) {
                string rline = rawline.Replace("\n", "");
                rline = rline.Replace("\"", "");
                rline = rline.Replace(seperator.Text, "");
                rline = rline.Replace(strip.Text, "");
                rline = rline.TrimEnd();
                rline = rline.TrimStart();
                string[] rawcol = rline.Split(delimiter.Text.ToCharArray());
                if(rawcol.Count() == 2) {
                    if(Columns.Contains(rawcol[0].Trim()) == false) {
                        Columns = Columns.AddItemToArray(rawcol[0].Trim());
                    } else {
                        break;
                    }
                }
                if(rawcol.Count() == 3) {
                    if(Columns.Contains(rawcol[0].Trim()) == false) {
                        Columns = Columns.AddItemToArray(rawcol[0].Trim());
                    } else {
                        break;
                    }
                }
            }
            return Columns;
        }

        public string[] findValues(string rawrecord, string[] Columns) {
            string[] Row = new string[0];
            string[] rawlines = new string[0];
            rawlines = rawrecord.Split("\n".ToCharArray());
            foreach(string rawline in rawlines) {
                string rline = rawline.Replace("\n", "");
                rline = rline.Replace("\"", "");
                rline = rline.Replace(seperator.Text, "");
                rline = rline.Replace(strip.Text, "");
                rline = rline.TrimEnd();
                rline = rline.TrimStart();
                string[] rawcol = rline.Split(delimiter.Text.ToCharArray());
                if(rawcol.Count() == 2) {
                    if(Columns.Contains(rawcol[0].Trim()) == true) {
                        Row = Row.AddItemToArray(rawcol[1].Trim());
                    } else {
                        break;
                    }
                }
                if(rawcol.Count() == 3) {
                    if(Columns.Contains(rawcol[0].Trim()) == true) {
                        Row = Row.AddItemToArray(rawcol[2].Trim());
                    } else {
                        break;
                    }
                }
            }
            return Row;
        }


        public void tryConvert2(bool preview) {
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
                                    DataGridViewRow gvrawRow = (DataGridViewRow)convertGrid.Rows[0].Clone();
                                    int i = 0;
                                    foreach(string rcol in Row) {
                                        if(gvrawRow.Cells.Count > i) {
                                            gvrawRow.Cells[i].Value = rcol.ToString();
                                        } else {
                                            gvrawRow.Cells[i].Value = rcol.ToString();
                                        }
                                        i++;
                                    }
                                    convertGrid.Rows.Add(gvrawRow);
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
            //    thrawRow err;
            //}
        }

        private void ConvertBtn_Click(object sender, EventArgs e) {
            tryConvert(false);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void openBtn_Click(object sender, EventArgs e) {
            try {
                using(var sfd = new OpenFileDialog()) {
                    sfd.Filter = "All files (*.log)|*.*log";
                    sfd.FilterIndex = 1;
                    if(sfd.ShowDialog() == DialogResult.OK) {
                        inputFile = sfd.FileName;
                        outputFile = inputFile.Replace(".log", ".csv");
                        filename.Text = inputFile;
                        tryConvert(false);
                    }
                }
            } catch(Exception err) {
                throw err;
            }
        }

        private void Preset_SelectedIndexChanged(object sender, EventArgs e) {
            if(Preset.Text != "") {
                if(Preset.Text == "VAR_DUMP") {
                    start.Text = "(";
                    end.Text = ")";
                    delimiter.Text = "=>";
                    seperator.Text = "\n";
                }
                if(Preset.Text == "JSON") {
                    start.Text = "{";
                    end.Text = "}";
                    delimiter.Text = ",";
                    seperator.Text = "\n";
                }
                if(Preset.Text == "XML") {
                    start.Text = ">";
                    end.Text = "</";
                    delimiter.Text = "";
                    seperator.Text = "\n";

                }
            }
        }

        private void start_TextChanged(object sender, EventArgs e) {

        }

    }
}
