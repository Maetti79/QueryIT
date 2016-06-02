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

        public string conectionString = "";
        public string connectionName = "";

        public ConnectionSchema DBschema = new ConnectionSchema();

        private OdbcConnection con = new OdbcConnection();
        private MySqlConnection mycon = new MySqlConnection();
        private ADODB.Connection adocon = new ADODB.Connection();

        private DataTable tables = new DataTable();
        private DataTable databases = new DataTable();
        private DataTable columns = new DataTable();

        public string database = "";
        public string table = "";
        public DataTable result = new DataTable();
        public string error = "";
        public string sql = "";
        public int row_count = 0;
        public int column_count = 0;

        public int index = 0;
        public bool run = false;
        public DateTime utcStart;
        public DateTime utcStop;
        
        public static string[] DBDataTypes = {
            "INT",
            "FLOAT",
            "DOUBLE",
            "DATETIME",
            "TIMESTAMP",
            "VARCHAR"
        };

        public static string[] DBCollations = {
            "ISO8859",
            "UTF-8"
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
                connectionName = "UNNAMEDDB";
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

        public Datasource(string conStr, string conName) {
            try {
                conectionString = conStr;
                connectionName = conName;
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
                    if(conectionString.Contains("Microsoft Text Driver")) {
                        databases.Columns.Add("Database");
                        databases.Rows.Add(database);
                    } else {
                        if(databases.Rows.Count <= 0) {
                            databases.Columns.Add("Database");
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

                if(conectionString.Contains("Microsoft Text Driver")) {
                    DBschema.ConnectionName = "QDSCSV";
                    //BEGIN SCHEMA INFO - own Classes Beta
                    foreach(DataRow bd in databases.Rows) {
                        //if(bd[0].ToString() == database) {
                        DatabaseSchema tmpDB = new DatabaseSchema(bd[0].ToString());
                        tmpDB.ConnectionName = DBschema.ConnectionName;
                        foreach(DataRow tbl in tables.Rows) {
                            if(tbl[0].ToString() == bd[0].ToString()) {
                                TableSchema tmpTable = new TableSchema(tbl[2].ToString());
                                tmpTable.ConnectionName = DBschema.ConnectionName;
                                tmpTable.DatabaseName = tmpDB.DatabaseName;
                                if(tables.Columns.Contains("ENGINE") == true) {
                                    tmpTable.Engine = "CSV";
                                }
                                foreach(DataRow col in columns.Rows) {
                                    if(tbl["TABLE_NAME"].ToString() == col["TABLE_NAME"].ToString()) {
                                        if(columns.Columns.Contains("COLUMN_NAME") == true) {
                                            ColumnSchema tmpCol = new ColumnSchema(col["COLUMN_NAME"].ToString());
                                            tmpCol.ConnectionName = DBschema.ConnectionName;
                                            tmpCol.DatabaseName = tmpDB.DatabaseName;
                                            tmpCol.TableName = tmpTable.TableName;
                                            if(columns.Columns.Contains("COLUMN_KEY") == true) {
                                                if(col["COLUMN_KEY"].ToString() == "PRI") {
                                                    tmpCol.PrimaryKey = true;
                                                } else {
                                                    tmpCol.PrimaryKey = false;
                                                }
                                            }
                                            if(columns.Columns.Contains("ORDINAL_POSITION") == true) {
                                                tmpCol.ColumnPosition = int.Parse(col["ORDINAL_POSITION"].ToString());
                                            }
                                            if(columns.Columns.Contains("TYPE_NAME") == true) {
                                                tmpCol.DataType = col["TYPE_NAME"].ToString();
                                            }
                                            if(columns.Columns.Contains("COLUMN_DEFAULT") == true) {
                                                tmpCol.DefaultValue = col["COLUMN_DEFAULT"].ToString();
                                            }
                                            if(columns.Columns.Contains("COLUMN_COMMENT") == true) {
                                                tmpCol.Comment = col["COLUMN_COMMENT"].ToString();
                                            }
                                            if(columns.Columns.Contains("IS_NULLABLE") == true) {
                                                if(col["IS_NULLABLE"].ToString() == "YES") {
                                                    tmpCol.NotNull = false;
                                                } else {
                                                    tmpCol.NotNull = true;
                                                }
                                            }
                                            if(columns.Columns.Contains("EXTRA") == true) {
                                                if(col["EXTRA"].ToString() == "auto_increment") {
                                                    tmpCol.AutoIncrement = true;
                                                } else {
                                                    tmpCol.AutoIncrement = false;
                                                }
                                            }

                                            tmpTable.addColumn(tmpCol);

                                        }
                                    }
                                }

                                tmpDB.addTable(tmpTable);

                            }//If Table = Table
                        }//Foreach Table

                        DBschema.addDatabase(tmpDB);

                        //}
                    }//Foreach Database
                    //END SCHEMA INFO

                } else {

                    DBschema.ConnectionName = "QDS";
                    //BEGIN SCHEMA INFO - own Classes Beta
                    foreach(DataRow bd in databases.Rows) {
                        //if(bd[0].ToString() == database) {
                        DatabaseSchema tmpDB = new DatabaseSchema(bd[0].ToString());
                        tmpDB.ConnectionName = DBschema.ConnectionName;
                        foreach(DataRow tbl in tables.Rows) {
                            if(tbl["TABLE_SCHEMA"].ToString() == bd[0].ToString()) {
                                TableSchema tmpTable = new TableSchema(tbl["TABLE_NAME"].ToString());
                                tmpTable.ConnectionName = DBschema.ConnectionName;
                                tmpTable.DatabaseName = tmpDB.DatabaseName;
                                if(tables.Columns.Contains("ENGINE") == true) {
                                    tmpTable.Engine = tbl["ENGINE"].ToString();
                                }
                                if(tables.Columns.Contains("AUTO_INCREMENT") == true) {
                                    int ai = 0;
                                    Int32.TryParse(tbl["AUTO_INCREMENT"].ToString(), out ai);
                                    tmpTable.AutoIncrement = ai;
                                }
                                foreach(DataRow col in columns.Rows) {
                                    if(tbl["TABLE_NAME"].ToString() == col["TABLE_NAME"].ToString()) {
                                        if(columns.Columns.Contains("COLUMN_NAME") == true) {
                                            ColumnSchema tmpCol = new ColumnSchema(col["COLUMN_NAME"].ToString());
                                            tmpCol.ConnectionName = DBschema.ConnectionName;
                                            tmpCol.DatabaseName = tmpDB.DatabaseName;
                                            tmpCol.TableName = tmpTable.TableName;
                                            if(columns.Columns.Contains("COLUMN_KEY") == true) {
                                                if(col["COLUMN_KEY"].ToString() == "PRI") {
                                                    tmpCol.PrimaryKey = true;
                                                } else {
                                                    tmpCol.PrimaryKey = false;
                                                }
                                            }
                                            if(columns.Columns.Contains("ORDINAL_POSITION") == true) {
                                                int idx = 0;
                                                Int32.TryParse(col["ORDINAL_POSITION"].ToString(), out idx);
                                                tmpCol.ColumnPosition = idx;
                                            }
                                            //if(columns.Columns.Contains("DATA_TYPE") == true) {
                                            //    tmpCol.DataType = col["DATA_TYPE"].ToString();
                                            //}
                                            if(columns.Columns.Contains("COLUMN_TYPE") == true) {
                                                tmpCol.DataType = col["COLUMN_TYPE"].ToString();
                                            }
                                            if(columns.Columns.Contains("COLUMN_DEFAULT") == true) {
                                                tmpCol.DefaultValue = col["COLUMN_DEFAULT"].ToString();
                                            }
                                            if(columns.Columns.Contains("COLUMN_COMMENT") == true) {
                                                tmpCol.Comment = col["COLUMN_COMMENT"].ToString();
                                            }
                                            if(columns.Columns.Contains("IS_NULLABLE") == true) {
                                                if(col["IS_NULLABLE"].ToString() == "YES") {
                                                    tmpCol.NotNull = false;
                                                } else {
                                                    tmpCol.NotNull = true;
                                                }
                                            }
                                            if(columns.Columns.Contains("EXTRA") == true) {
                                                if(col["EXTRA"].ToString() == "auto_increment") {
                                                    tmpCol.AutoIncrement = true;
                                                } else {
                                                    tmpCol.AutoIncrement = false;
                                                }
                                            }

                                            tmpTable.addColumn(tmpCol);

                                        }
                                    }
                                }

                                tmpDB.addTable(tmpTable);

                            }//If Table = Table
                        }//Foreach Table

                        DBschema.addDatabase(tmpDB);

                        //}
                    }//Foreach Database
                    //END SCHEMA INFO
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
