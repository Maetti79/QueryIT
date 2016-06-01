using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryIT.model {

    public class ConnectionSchema {

        public string ConnectionName { get; set; }

        public DatabaseSchema[] Databases { get; set; }
        public Dictionary<string, DatabaseSchema> D = new Dictionary<string, DatabaseSchema>();

        public ConnectionSchema() {
            ConnectionName = "";
        }

        public ConnectionSchema(string Name) {
            ConnectionName = Name;
        }

        public override int GetHashCode() {
            string hash = ConnectionName;
            return hash.GetHashCode();
        }

        public override bool Equals(object obj) {
            return Equals(obj as ConnectionSchema);
        }

        public bool Equals(ConnectionSchema obj) {
            return obj != null && obj.GetHashCode() == this.GetHashCode();
        }

        public void addDatabase(DatabaseSchema db) {
            if(D.ContainsKey(db.DatabaseName)) {
                if(db.Tables != null) {
                    if(db.Tables.Count() > 0) {
                        Databases = Databases.Update(db);
                        D[db.DatabaseName] = db;
                    }
                }
            } else {
                Databases = Databases.AddItemToArray(db);
                D.Add(db.DatabaseName, db);
            }
        }

    }

}
