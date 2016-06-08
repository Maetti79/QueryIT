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
                "avg",
                "binary_checksum",
                "car",
                "cast",
                "checksum",
                "checksum_agg",
                "convert",
                "concat",
                "count",
                "current_timestamp",
                "datediff",
                "datepart",
                "day",
                "first",
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
                "ucase",
                "varp",
                "year"   
            };

        public static string[] SQLred = { "*", "%", "#", ";" };

        public static string[] SQLgreen = { "'", "`", "(", ")", "[", "]" };

        public static string[] SQlgray = { ".", ",", "=", "+", "-", "/", ">", "<" };

        public static string fixSQL(string sql) {
            return sql;
        }

    }
}
