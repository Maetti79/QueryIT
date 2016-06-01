using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryIT.model {
    
    public class ColumnSchema {

        public string ConnectionName { get; set; }
        public string DatabaseName { get; set; }
        public string TableName { get; set; }
        public string ViewName { get; set; }
        public string ColumnName { get; set; }

        public int ColumnPosition { get; set; }
        public string DataType { get; set; }
        public string DataTypeSize { get; set; }
        public bool PrimaryKey { get; set; }
        public bool NotNull { get; set; }
        public bool Unique { get; set; }
        public bool Binary { get; set; }
        public bool UnSigned { get; set; }
        public bool ZeroFill { get; set; }
        public bool AutoIncrement { get; set; }
        public bool Generated { get; set; }
        public string DefaultValue { get; set; }
        public string Comment { get; set; }
        
        public ColumnSchema() {
            ConnectionName = "";
            DatabaseName = "";
            TableName = "";
            ViewName = "";
            ColumnName = "";
        }

        public ColumnSchema(string Name) {
            ConnectionName = "";
            DatabaseName = "";
            TableName = "";
            ViewName = "";
            ColumnName = Name;
        }

        public override int GetHashCode() {
            string hash = ConnectionName + "." + DatabaseName + "." + TableName + "." + ColumnName;
            return hash.GetHashCode();
        }

        public override bool Equals(object obj) {
            return Equals(obj as ColumnSchema);
        }

        public bool Equals(ColumnSchema obj) {
            return obj != null && obj.GetHashCode() == this.GetHashCode();
        }

    }

}
