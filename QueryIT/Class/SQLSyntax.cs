using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryIT.model {

    class SQLSyntax {

        public static string[] SQLblue = {
                "select", 
                "insert", 
                "update", 
                "delete", 
                "drop", 
                "from", 
                "set", 
                "where", 
                "group by", 
                "order by",
                "limit",
                "distinct", 
                "having", 
                "exists", 
                "null", 
                "not", 
                "top", 
                "like", 
                "between", 
                "add", 
                "alter", 
                "column", 
                "table", 
                "unique", 
                "create", 
                "database", 
                "index", 
                "into", 
                "values", 
                "truncate", 
                "desc", 
                "asc", 
                "on", 
                "or", 
                "and", 
                "in", 
                "as", 
                "use", 
                "exec", 
                "execute", 
                "join", 
                "left", 
                "right", 
                "inner", 
                "outer", 
                "fetch", 
                "first", 
                "last", 
                "rows", 
                "only",
                "union",
                "date_add",
                "date_sub"
            };

        public static string[] SQLmagenta = {
                "if",
                "sum", 
                "rand",
                "count", 
                "min", 
                "max", 
                "avg", 
                "replace", 
                "round", 
                "cast", 
                "convert", 
                "substring", 
                "substr", 
                "datepart", 
                "stdev", 
                "stdevp", 
                "binary_checksum", 
                "checksum", 
                "checksum_agg", 
                "first", 
                "last", 
                "car", 
                "varp", 
                "ucase", 
                "lcase", 
                "mid", 
                "len", 
                "instr", 
                "left", 
                "right", 
                "round", 
                "mod", 
                "now", 
                "format", 
                "datediff",
                "day",
                "month",
                "year",
                "hour",
                "minute",
                "second",
                "interval",
                "current_timestamp"
            };

        public static string[] SQLred = { "*", "%", "#" };

        public static string[] SQLgreen = { "'", "`", "(", ")", "[", "]" };

        public static string[] SQlgray = { ".", ",", "=", "+", "-", "/", ">", "<" };

    }
}
