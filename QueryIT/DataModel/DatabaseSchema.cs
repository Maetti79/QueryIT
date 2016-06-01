using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryIT.model {

    public class DatabaseSchema {

        public string ConnectionName { get; set; }
        public string DatabaseName { get; set; }

        public TableSchema[] Tables { get; set; }
        public Dictionary<string, TableSchema> T = new Dictionary<string, TableSchema>();
        public ViewSchema[] Views { get; set; }
        public Dictionary<string, ViewSchema> V = new Dictionary<string, ViewSchema>();

        //public string Collation { get; set; }
        //public string Comments { get; set; }
        //public string Engine { get; set; }

        public DatabaseSchema() {
            ConnectionName = "";
            DatabaseName = "";
        }

        public DatabaseSchema(string Name) {
            ConnectionName = "";
            DatabaseName = Name;
        }

        public override int GetHashCode() {
            string hash = ConnectionName + "." + DatabaseName;
            return hash.GetHashCode();
        }

        public override bool Equals(object obj) {
            return Equals(obj as DatabaseSchema);
        }

        public bool Equals(DatabaseSchema obj) {
            return obj != null && obj.GetHashCode() == this.GetHashCode();
        }

        public void addTable(TableSchema tbl) {
            if(T.ContainsKey(tbl.TableName)) {
                if(tbl.Columns != null) {
                    if(tbl.Columns.Count() > 0) {
                        Tables = Tables.Update(tbl);
                        T[tbl.TableName] = tbl;
                    }
                }
            } else {
                Tables = Tables.AddItemToArray(tbl);
                T.Add(tbl.TableName, tbl);
            }
        }

        public void addView(ViewSchema viw) {
            if(V.ContainsKey(viw.ViewName)) {
                if(viw.Columns != null) {
                    if(viw.Columns.Count() > 0) {
                        Views = Views.Update(viw);
                        V[viw.ViewName] = viw;
                    }
                }
            } else {
                Views = Views.AddItemToArray(viw);
                V.Add(viw.ViewName, viw);
            }
        }

    }

}
