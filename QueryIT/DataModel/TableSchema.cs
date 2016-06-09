using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryIT.model {

    public class TableSchema {

        public string ConnectionName { get; set; }
        public string DatabaseName { get; set; }
        public string TableName { get; set; }
        public ColumnSchema[] Columns { get; set; }
        public Dictionary<string, ColumnSchema> C = new Dictionary<string, ColumnSchema>();

        public int AutoIncrement { get; set; }
        //public string Collation { get; set; }
        //public string Comments { get; set; }
        public string Engine { get; set; }

        public TableSchema() {
            ConnectionName = "";
            DatabaseName = "";
            TableName = "";
        }

        public TableSchema(string Name) {
            ConnectionName = "";
            DatabaseName = "";
            TableName = Name;
        }

        public override int GetHashCode() {
            string hash = ConnectionName + "." + DatabaseName + "." + TableName;
            return hash.GetHashCode();
        }

        public override bool Equals(object obj) {
            return Equals(obj as TableSchema);
        }

        public bool Equals(TableSchema obj) {
            return obj != null && obj.GetHashCode() == this.GetHashCode();
        }

        public void addColumn(ColumnSchema col) {
            if(C.ContainsKey(col.ColumnName)) {
                Columns = Columns.Update(col);
                C[col.ColumnName] = col;
            } else {
                Columns = Columns.AddItemToArray(col);
                C.Add(col.ColumnName, col);
            }
        }

        public bool hasPrimaryKey() {
            foreach(ColumnSchema Column in Columns) {
                if(Column.PrimaryKey == true) {
                    return true;
                }
            }
            return false;
        }

        public string getPrimaryKey() {
            string pkey = "";
            foreach(ColumnSchema Column in Columns) {
                if(Column.PrimaryKey == true) {
                    if(pkey.ToString() == "") {
                        pkey += Column.ColumnName;
                    } else {
                        pkey += "," + Column.ColumnName;
                    }
                }
            }
            return pkey;
        }

        public int getAutoIncrement() {
            return AutoIncrement;
        }

        public string SQLSelectTop() {
            string sql = "";
            if(TableName.Contains(".csv")) {
                sql = "SELECT * FROM  `" + TableName + "`;\n";
            } else {
                sql = "SELECT * FROM  `" + DatabaseName + "`.`" + TableName + "` LIMIT 100;\n";
            }
            return sql;
        }

        public string SQLInsert() {
            string sql = "";
            if(TableName.Contains(".csv")) {
                sql = "INSERT INTO TABLE `" + TableName + "` (";
                foreach(ColumnSchema col in Columns) {
                    sql += "`" + col.ColumnName + "`, ";
                }
                sql = sql.Substring(0, sql.Length - 2);
                sql += ")\n";
                sql += "VALUES(";
                foreach(ColumnSchema col in Columns) {
                    sql += "#" + col.ColumnName + "#, ";
                }
                sql = sql.Substring(0, sql.Length - 2);
                sql += ") ;\n";
            } else {
                sql = "INSERT INTO TABLE `" + DatabaseName + "`.`" + TableName + "` (";
                foreach(ColumnSchema col in Columns) {
                    sql += "`" + col.ColumnName + "`, ";
                }
                sql = sql.Substring(0, sql.Length - 2);
                sql += ")\n";
                sql += "VALUES(";
                foreach(ColumnSchema col in Columns) {
                    sql += "#" + col.ColumnName + "#, ";
                }
                sql = sql.Substring(0, sql.Length - 2);
                sql += ") ;\n";
            }
            return sql;
        }

        public string SQLUpdate() {
            string sql = "";
            if(TableName.Contains(".csv")) {
                sql = "UPDATE `" + TableName + "` SET #column# = #value# WHERE #condition#;\n";
            } else {
                sql = "UPDATE `" + DatabaseName + "`.`" + TableName + "` SET #column# = #value# WHERE #condition#;\n";
            }
            return sql;
        }

        public string SQLDelete() {
            string sql = "";
            if(TableName.Contains(".csv")) {
                sql = "DELETE FROM TABLE `" + TableName + "` WHERE #condition#;\n";
            } else {
                sql = "DELETE FROM TABLE `" + DatabaseName + "`.`" + TableName + "` WHERE #condition#;\n";
            }
            return sql;
        }

        public string SQLTruncateTable() {
            string sql = "";
            if(TableName.Contains(".csv")) {
                sql = "TRUNCATE `" + TableName + "`\n";
            } else {
                sql = "TRUNCATE `" + DatabaseName + "`.`" + TableName + "`;\n";
            }
            return sql;
        }

        public string SQLDropTable() {
            string sql = "";
            if(TableName.Contains(".csv")) {
                sql = "DROP TABLE `" + TableName + "`;\n";
            } else {
                sql = "DROP TABLE `" + DatabaseName + "`.`" + TableName + "`;\n";
            }
            return sql;
        }

        public string SQLRenameTable(TableSchema newSchema) {
            string sql = "";
            if(TableName.Contains(".csv")) {
                sql = "RENAME TABLE `" + TableName + "` TO `" + newSchema.TableName + "`;\n";
            } else {
                sql = "RENAME TABLE `" + DatabaseName + "`.`" + TableName + "` TO `" + DatabaseName + "`.`" + newSchema.TableName + "`;\n";
            }
            return sql;
        }

        public string SQLCreateTable() {
            string sql = "";
            if(Columns != null) {
                if(TableName.Contains(".csv")) {
                    sql = "CREATE TABLE `" + TableName.ToString() + "` (\n";
                } else {
                    sql = "CREATE TABLE `" + DatabaseName + "`.`" + TableName + "` (\n";
                }
                foreach(ColumnSchema Column in Columns) {
                    sql += "`" + Column.ColumnName + "` ";
                    sql += Column.DataType + " ";
                    if(Column.NotNull == true) {
                        sql += "NOT NULL ";
                    } else {
                        sql += "NULL ";
                    }
                    if(Column.AutoIncrement == true) {
                        sql += "AUTO INCREMENT ";
                    }
                    sql += ",\n";
                }
                if(hasPrimaryKey() == true) {
                    sql += "PRIMARY KEY (`" + getPrimaryKey() + "`),\n";
                }
                sql = sql.Substring(0, sql.Length - 2);
                sql += ");\n";
            }
            return sql;
        }

        public string SQLAlterTable(TableSchema newSchema) {
            string sqlh = "";
            string sql = "";
            int i = 0;
            if(Columns != null) {
                if(newSchema.Columns != null) {
                    sqlh += "ALTER TABLE `" + DatabaseName + "`.`" + TableName + "`\n";
                    for(i = 0; i < newSchema.Columns.Count(); i++) {
                        ColumnSchema col = newSchema.Columns[i];
                        if(C.ContainsKey(col.ColumnName) == false) {
                            //ADD NEW COLUMN
                            if(sql == "") {
                                sql += sqlh + "ADD COLUMN ";
                            } else {
                                sql += "ADD COLUMN ";
                            }
                            sql += "`" + col.ColumnName + "` ";
                            sql += col.DataType + " ";
                            //NN
                            if(col.NotNull == true) {
                                sql += "NOT NULL ";
                            } else {
                                sql += "NULL ";
                            }
                            //DV
                            if(col.DefaultValue == "") {
                                sql += "DEFAULT NULL ";
                            } else {
                                sql += "DEFAULT " + col.DefaultValue + " ";
                            }
                            //AI
                            if(col.AutoIncrement == true) {
                                sql += "AUTO_INCREMENT ";
                            }
                            //Position
                            if(col.ColumnPosition == 0) {
                                sql += "FIRST ";
                            } else {
                                sql += "AFTER `" + newSchema.Columns[col.ColumnPosition - 1].ColumnName + "`";
                            }
                            sql += "\n";
                        } else {
                            //CHANGE COLUMN
                            ColumnSchema oldcol = C[col.ColumnName];
                            if(col.ColumnName != oldcol.ColumnName
                                || col.PrimaryKey != oldcol.PrimaryKey
                                || col.DataType != oldcol.DataType
                                || col.AutoIncrement != oldcol.AutoIncrement
                                || col.NotNull != oldcol.NotNull
                                || col.Unique != oldcol.Unique
                                || col.UnSigned != oldcol.UnSigned
                                || col.Generated != oldcol.Generated
                                || col.DefaultValue != oldcol.DefaultValue
                                || col.ColumnPosition != oldcol.ColumnPosition
                              ) {
                                  if(sql == "") {
                                      sql += sqlh + "CHANGE COLUMN ";
                                  } else {
                                      sql += "CHANGE COLUMN ";
                                  }
                                sql += "`" + col.ColumnName + "` ";
                                sql += "`" + col.ColumnName + "` ";
                                sql += col.DataType + " ";
                                //NN
                                if(col.NotNull == true) {
                                    sql += "NOT NULL ";
                                } else {
                                    sql += "NULL ";
                                }
                                //DV
                                if(col.DefaultValue == "") {
                                    sql += "DEFAULT NULL ";
                                } else {
                                    sql += "DEFAULT " + col.DefaultValue + " ";
                                }
                                //AI
                                if(col.AutoIncrement == true) {
                                    sql += "AUTO_INCREMENT ";
                                }
                                //Position
                                if(col.ColumnPosition == oldcol.ColumnPosition) {
                                    sql += "FIRST ";
                                } else {
                                    sql += "AFTER `" + newSchema.Columns[col.ColumnPosition - 1].ColumnName + "`";
                                }
                                sql += "\n";
                            }
                        }
                    }
                    if(sql.Length > 0) {
                        sql = sql.Substring(0, sql.Length - 1);
                        sql += ";\n";
                    }
                }
            }
            return sql;
        }

    }

}
