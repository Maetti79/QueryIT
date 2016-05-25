using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ADODB;

namespace QueryIT.model {

    public class Datasource {

        private OdbcConnection con = new OdbcConnection();
        private MySqlConnection mycon = new MySqlConnection();
        private ADODB.Connection adocon = new ADODB.Connection();
        public string database = "";
        public string conectionString = "";
        public DataTable tables = new DataTable();
        public DataTable databases = new DataTable();
        public DataTable columns = new DataTable();
        public DataTable result = new DataTable();
        public int index = 0;
        public bool run = false;
        public DateTime utcStart;
        public DateTime utcStop;
        public string error = "";
        public string sql = "";
        public string table = "";
        public int row_count = 0;
        public int column_count = 0;

        public static string[] DBDataTypes = {
            "INT(11)",
            "FLOAT",
            "DOUBLE",
            "DATETIME",
            "TIMESTAMP",
            "VARCHAR(45)"
        };

        public Datasource() {
            try {

            } catch(Exception e) {
                error = e.Message.ToString();
            }
        }

        public Datasource(string conStr) {
            try {
                conectionString = conStr;
                if(conectionString.Contains("Provider=") == true) {
                    adocon = new ADODB.Connection(conStr);
                    adocon.Open();
                } else if(conectionString.Contains("Driver=") == true) {
                    con = new OdbcConnection(conStr);
                    con.Open();
                } else {
                    mycon = new MySqlConnection(conStr);
                    mycon.Open();
                }
                this.getSchema();
            } catch(Exception e) {
                error = e.Message.ToString();
            }
        }

        public bool exportCSV(string path) {
            try {
                StringBuilder sb = new StringBuilder();

                IEnumerable<string> columnNames = result.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
                sb.AppendLine(string.Join(",", columnNames));

                foreach(DataRow row in result.Rows) {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    sb.AppendLine(string.Join(",", fields));
                }

                File.WriteAllText(path, sb.ToString());
                return true;
            } catch(Exception e) {
                error = e.Message.ToString();
                return false;
            }
        }

        public bool cancelSQL() {
            try {
                if(conectionString.Contains("Provider=") == true) {
                    adocon.Cancel();
                    return true;
                } else if(conectionString.Contains("Driver=") == true) {
                    return true;
                } else {
                    mycon.CancelQuery(0);
                    return true;
                }
            } catch(Exception e) {
                error = e.Message.ToString();
                return false;
            }
        }

        public bool executeSql(string sqlStr) {
            try {
                row_count = 0;
                column_count = 0;
                sql = sqlStr;
                utcStart = DateTime.UtcNow;
                run = true;
                error = "";
                if(isConnected() == true) {
                    if(conectionString.Contains("Provider=") == true) {
                        //add logic
                    } else if(conectionString.Contains("Driver=") == true) {
                        OdbcCommand oCmd = new OdbcCommand(sqlStr.ToString(), con);
                        OdbcDataReader oDR = oCmd.ExecuteReader();
                        //OdbcDataReader oDR = oCmd.ExecuteReaderAsync();
                        if(oDR.HasRows == true) {
                            row_count = oDR.RecordsAffected;
                            column_count = oDR.FieldCount;
                            result.Clear();
                            result.Columns.Clear();
                            //result.Load(oDR);
                            for(int i = 0; i < oDR.FieldCount; i++) {
                                result.Columns.Add(oDR.GetName(i));
                            }
                            while(oDR.Read()) {
                                DataRow row = result.NewRow();
                                for(int i = 0; i < oDR.FieldCount; i++) {
                                    row[oDR.GetName(i)] = oDR.GetValue(i);
                                }
                                result.Rows.Add(row);
                                Application.DoEvents();
                                if(run == false) {
                                    break;
                                }
                            }
                            if(row_count <= 0) {
                                row_count = result.Rows.Count;
                            }
                        }
                        oDR.Close();
                        oCmd.Dispose();
                    } else {
                        MySqlCommand oCmd = new MySqlCommand(sqlStr.ToString(), mycon);
                        MySqlDataReader oDR = oCmd.ExecuteReader();
                        if(oDR.HasRows == true) {
                            row_count = oDR.RecordsAffected;
                            column_count = oDR.FieldCount;
                            result.Clear();
                            result.Columns.Clear();
                            //result.Load(oDR);
                            for(int i = 0; i < oDR.FieldCount; i++) {
                                result.Columns.Add(oDR.GetName(i));
                            }
                            while(oDR.Read()) {
                                DataRow row = result.NewRow();
                                for(int i = 0; i < oDR.FieldCount; i++) {
                                    row[oDR.GetName(i)] = oDR.GetValue(i);
                                }
                                result.Rows.Add(row);
                                Application.DoEvents();
                                if(run == false) {
                                    break;
                                }
                            }
                            if(row_count <= 0) {
                                row_count = result.Rows.Count;
                            }
                        }
                        oDR.Close();
                        oCmd.Dispose();
                    }
                    run = false;
                    utcStop = DateTime.UtcNow;
                    return true;
                } else {
                    run = false;
                    utcStop = DateTime.UtcNow;
                    return false;
                }
            } catch(Exception e) {
                error = e.Message.ToString();
                utcStop = DateTime.UtcNow;
                return false;
            }
        }

        public void getSchema() {
            try {
                if(conectionString.Contains("Provider=") == true) {
                    //add logic
                } else if(conectionString.Contains("Driver=") == true) {
                    database = con.Database.ToString();
                    tables.Clear();
                    columns.Clear();
                    tables = con.GetSchema("Tables");
                    columns = con.GetSchema("Columns");
                    if(databases.Rows.Count <= 0) {
                        OdbcCommand oCmd = new OdbcCommand("SHOW DATABASES", con);
                        OdbcDataReader oDR = oCmd.ExecuteReader();
                        if(oDR.HasRows == true) {
                            while(oDR.Read()) {
                                for(int i = 0; i < oDR.FieldCount; i++) {
                                    databases.Rows.Add(oDR.GetValue(i).ToString());
                                }
                            }
                        }
                        oDR.Close();
                        oCmd.Dispose();
                    }
                } else {
                    database = mycon.Database.ToString();
                    tables.Clear();
                    columns.Clear();
                    tables = mycon.GetSchema("Tables");
                    columns = mycon.GetSchema("Columns");
                    if(databases.Rows.Count <= 0) {
                        databases.Columns.Add("Database");
                        MySqlCommand oCmd = new MySqlCommand("SHOW DATABASES", mycon);
                        MySqlDataReader oDR = oCmd.ExecuteReader();
                        if(oDR.HasRows == true) {
                            while(oDR.Read()) {
                                for(int i = 0; i < oDR.FieldCount; i++) {
                                    databases.Rows.Add(oDR.GetValue(i).ToString());
                                }
                            }
                        }
                        oDR.Close();
                        oCmd.Dispose();
                    }
                }
            } catch(Exception e) {
                error = e.Message.ToString();
            }
        }

        public bool isConnected() {
            try {
                if(conectionString.Contains("Provider=") == true) {
                    if(adocon.State == 0) {
                        return false;
                    } else if(adocon.State == 1) {
                        return true;
                    } else if(adocon.State == 2) {
                        return false;
                    } else if(adocon.State == 4) {
                        return true;
                    } else if(adocon.State == 8) {
                        return true;
                    } else {
                        return false;
                    }
                } else if(conectionString.Contains("Driver=") == true) {
                    if(con.State == System.Data.ConnectionState.Open) {
                        return true;
                    } else if(con.State == System.Data.ConnectionState.Executing) {
                        return true;
                    } else if(con.State == System.Data.ConnectionState.Fetching) {
                        return true;
                    } else if(con.State == System.Data.ConnectionState.Connecting) {
                        return false;
                    } else if(con.State == System.Data.ConnectionState.Closed) {
                        return false;
                    } else if(con.State == System.Data.ConnectionState.Broken) {
                        return false;
                    } else {
                        return false;
                    }
                } else {
                    if(mycon.State == System.Data.ConnectionState.Open) {
                        return true;
                    } else if(mycon.State == System.Data.ConnectionState.Executing) {
                        return true;
                    } else if(mycon.State == System.Data.ConnectionState.Fetching) {
                        return true;
                    } else if(mycon.State == System.Data.ConnectionState.Connecting) {
                        return false;
                    } else if(mycon.State == System.Data.ConnectionState.Closed) {
                        return false;
                    } else if(mycon.State == System.Data.ConnectionState.Broken) {
                        return false;
                    } else {
                        return false;
                    }
                }
            } catch(Exception e) {
                error = e.Message.ToString();
                return false;
            }
        }

        public bool hasErrors() {
            try {
                if(error.Length > 0) {
                    return true;
                } else {
                    return false;
                }
            } catch(Exception e) {
                error = e.Message.ToString();
                return true;
            }
        }

        public bool hasResult() {
            try {
                if(result.Rows.Count > 0) {
                    return true;
                } else {
                    return false;
                }
            } catch(Exception e) {
                error = e.Message.ToString();
                return true;
            }
        }


        public bool switchDatabase(string databasename) {
            try {
                disconnect();
                string conStr = conectionString.Replace(database, databasename);
                database = databasename;
                if(conectionString.Contains("Provider=") == true) {
                    adocon = new ADODB.Connection(conStr);
                    adocon.Open();
                } else if(conectionString.Contains("Driver=") == true) {
                    con = new OdbcConnection(conStr);
                    con.Open();
                } else {
                    mycon = new MySqlConnection(conStr);
                    mycon.Open();
                }
                connect();
                this.getSchema();
                return true;
            } catch(Exception e) {
                error = e.Message.ToString();
                return false;
            }
        }

        public bool connect() {
            try {
                if(conectionString.Contains("Provider=") == true) {
                    if(adocon.State == 0) {
                        adocon.Open();
                        return true;
                    } else if(adocon.State == 1) {
                        return true;
                    } else if(adocon.State == 2) {
                        return false;
                    } else if(adocon.State == 4) {
                        return true;
                    } else if(adocon.State == 8) {
                        return true;
                    } else {
                        return false;
                    }
                } else if(conectionString.Contains("Driver=") == true) {
                    if(con.State == System.Data.ConnectionState.Open) {
                        return true;
                    } else if(con.State == System.Data.ConnectionState.Executing) {
                        return true;
                    } else if(con.State == System.Data.ConnectionState.Fetching) {
                        return true;
                    } else if(con.State == System.Data.ConnectionState.Connecting) {
                        return false;
                    } else if(con.State == System.Data.ConnectionState.Closed) {
                        con.Open();
                        return true;
                    } else if(con.State == System.Data.ConnectionState.Broken) {
                        con.Open();
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    if(mycon.State == System.Data.ConnectionState.Open) {
                        return true;
                    } else if(mycon.State == System.Data.ConnectionState.Executing) {
                        return true;
                    } else if(mycon.State == System.Data.ConnectionState.Fetching) {
                        return true;
                    } else if(mycon.State == System.Data.ConnectionState.Connecting) {
                        return false;
                    } else if(mycon.State == System.Data.ConnectionState.Closed) {
                        mycon.Open();
                        return true;
                    } else if(mycon.State == System.Data.ConnectionState.Broken) {
                        mycon.Open();
                        return true;
                    } else {
                        return false;
                    }
                }
            } catch(Exception e) {
                error = e.Message.ToString();
                return false;
            }
        }

        public bool disconnect() {
            try {
                if(conectionString.Contains("Provider=") == true) {
                    if(adocon.State == 0) {
                        return true;
                    } else if(adocon.State == 1) {
                        adocon.Close();
                        return true;
                    } else if(adocon.State == 2) {
                        adocon.Close();
                        return true;
                    } else if(adocon.State == 4) {
                        adocon.Cancel();
                        adocon.Close();
                        return true;
                    } else if(adocon.State == 8) {
                        adocon.Cancel();
                        adocon.Close();
                        return true;
                    } else {
                        return false;
                    }
                } else if(conectionString.Contains("Driver=") == true) {
                    if(con.State == System.Data.ConnectionState.Open) {
                        con.Close();
                        return true;
                    } else if(con.State == System.Data.ConnectionState.Executing) {
                        con.Close();
                        return true;
                    } else if(con.State == System.Data.ConnectionState.Fetching) {
                        con.Close();
                        return true;
                    } else if(con.State == System.Data.ConnectionState.Connecting) {
                        con.Close();
                        return true;
                    } else if(con.State == System.Data.ConnectionState.Closed) {
                        return true;
                    } else if(con.State == System.Data.ConnectionState.Broken) {
                        con.Close();
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    if(mycon.State == System.Data.ConnectionState.Open) {
                        mycon.Close();
                        return true;
                    } else if(mycon.State == System.Data.ConnectionState.Executing) {
                        mycon.Close();
                        return true;
                    } else if(mycon.State == System.Data.ConnectionState.Fetching) {
                        mycon.Close();
                        return true;
                    } else if(mycon.State == System.Data.ConnectionState.Connecting) {
                        mycon.Close();
                        return true;
                    } else if(mycon.State == System.Data.ConnectionState.Closed) {
                        return true;
                    } else if(mycon.State == System.Data.ConnectionState.Broken) {
                        mycon.Close();
                        return true;
                    } else {
                        return false;
                    }
                }
            } catch(Exception e) {
                error = e.Message.ToString();
                return false;
            }
        }

    }
}
