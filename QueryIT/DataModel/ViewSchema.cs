using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryIT.model {

    public class ViewSchema {

        public string ConnectionName { get; set; }
        public string DatabaseName { get; set; }
        public string ViewName { get; set; }
        public ColumnSchema[] Columns { get; set; }
        public Dictionary<string, ColumnSchema> C = new Dictionary<string, ColumnSchema>();

        //public string Collation { get; set; }
        //public string Comments { get; set; }

        public ViewSchema() {
            ConnectionName = "";
            DatabaseName = "";
            ViewName = "";
        }

        public ViewSchema(string Name) {
            ConnectionName = "";
            DatabaseName = "";
            ViewName = Name;
        }

        public override int GetHashCode() {
            string hash = ConnectionName + "." + DatabaseName + "." + ViewName;
            return hash.GetHashCode();
        }

        public override bool Equals(object obj) {
            return Equals(obj as ViewSchema);
        }

        public bool Equals(ViewSchema obj) {
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

    }

}
