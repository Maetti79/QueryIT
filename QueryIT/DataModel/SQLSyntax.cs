using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryIT.model {

    class SQLSyntax {

        public static string[] SQLblue = {
                "add",
                "after",
                "alter",
                "and",
                "as",
                "asc",
                "between",
                "change",
                "column",
                "create",
                "database",
                "date_add",
                "date_sub",
                "default",
                "delete",
                "desc",
                "distinct",
                "drop",
                "exec",
                "execute",
                "exists",
                "fetch",
                "first",
                "from",
                "group by",
                "having",
                "in",
                "index",
                "inner",
                "insert",
                "into",
                "is",
                "join",
                "last",
                "left",
                "like",
                "limit",
                "not",
                "null",
                "on",
                "only",
                "or",
                "order by",
                "outer",
                "rename",
                "right",
                "rows",
                "select",
                "set",
                "table",
                "to",
                "top",
                "truncate",
                "union",
                "unique",
                "update",
                "use",
                "values",
                "where"
            };

        public static string[] SQLdarkgreen = {
                "auto_increment",
                "avg",
                "binary_checksum",
                "car",
                "cast",
                "ceil",
                "checksum",
                "checksum_agg",
                "convert",
                "concat",
                "count",
                "current_timestamp",
                "date",
                "date_add",
                "date_format",
                "datediff",
                "datepart",
                "day",
                "first",
                "floor",
                "format",
                "hour",
                "if",
                "instr",
                "interval",
                "last",
                "lcase",
                "len",
                "max",
                "md5",
                "mid",
                "min",
                "minute",
                "mod",
                "month",
                "now",
                "rand",
                "replace",
                "round",
                "second",
                "stdev",
                "stdevp",
                "substr",
                "substring",
                "sum",
                "time",
                "ucase",
                "varp",
                "weekday",
                "year"   
            };

        public static string[] SQLsign = { "*", "%", "#", ";" };

        public static string[] SQLquote = { "'", "`", "´", "\"" };

        public static string[] SQLbrackets = { "(", ")", "[", "]", "{", "}" };

        public static string[] SQLoperator = { ".", ",", "=", "+", "-", "/", ">", "<" };

        public static string[] SQLDataTypes = { "int", "varchar", "datetime", "timestamp", "float" };

        public static string fixSQL(string sql) {
            return sql;
        }

    }
}
