using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace QueryIT {

    class QLog {

        public static string LoadlogHistory(string connectionName, string tabname) {
            string history = "";
            try {
                string path = System.IO.Directory.GetCurrentDirectory();
                string connectionPath = path + "\\" + connectionName;
                string file = connectionPath + "\\" + tabname + "_history.log";
                if(Directory.Exists(connectionPath) == false) {
                    Directory.CreateDirectory(connectionPath);
                }
                if(File.Exists(file) == true) {
                    history = File.ReadAllText(file);
                }
            } catch(Exception err) {
                throw err;
            }
            return history;
        }

        public static void logHistory(string connectionName, string tabname, string text) {
            try {
                string path = System.IO.Directory.GetCurrentDirectory();
                string connectionPath = path + "\\" + connectionName;
                string file = connectionPath + "\\" + tabname + "_history.log";
                if(Directory.Exists(connectionPath) == false) {
                    Directory.CreateDirectory(connectionPath);
                }
                File.AppendAllText(file, text);
            } catch(Exception err) {
                throw err;
            }
        }

        public static void logError(string connectionName, string tabname, string text) {
            try {
                string path = System.IO.Directory.GetCurrentDirectory();
                string connectionPath = path + "\\" + connectionName;
                string file = connectionPath + "\\" + tabname + "_error.log";
                if(Directory.Exists(connectionPath) == false) {
                    Directory.CreateDirectory(connectionPath);
                }
                File.AppendAllText(file, text);
            } catch(Exception err) {
                throw err;
            }
        }

    }

}
