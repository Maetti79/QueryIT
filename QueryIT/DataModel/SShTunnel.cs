using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using FirebirdSql.Data.FirebirdClient;
using ADODB;
using FirebirdSql.Data.Client.Native.Handle;
using Renci.SshNet.Common;
using Renci.SshNet;

namespace QueryIT.model {

    public class SSHTunnel {

        public SshClient SSHClient;
        public ForwardedPortLocal SSHTunnelPort;
        public SSHConnectionSettings Settings;
       
        public string error = "";

        public SSHTunnel() { 
        }

        public SSHTunnel(SSHConnectionSettings SSHSettings) {
            try
            {
                Settings = SSHSettings;
                int p = 22;
                int.TryParse(Settings.SSHport.ToString(), out p);

               // IPHostEntry hostEntry;

                //hostEntry = Dns.GetHostEntry(SSHserver.ToString());

                ConnectionInfo connectionInfo = new ConnectionInfo(Settings.SSHserver, p, Settings.SSHusername, 
                    new AuthenticationMethod[]{
                        new PasswordAuthenticationMethod(Settings.SSHusername,Settings.SSHpassword)
                    }
                );

                SSHClient = new SshClient(connectionInfo);
                SSHClient.Connect();
                SSHTunnelPort = new ForwardedPortLocal("127.0.0.1", Settings.SSHserver.ToString(), Convert.ToUInt32(Settings.SSHremotePort));
                SSHClient.AddForwardedPort(SSHTunnelPort);
                SSHTunnelPort.Start();

                Settings.SSHlocalPort = SSHTunnelPort.BoundPort.ToString();
            }
            catch (Exception e)
            {
                error = e.Message.ToString();
            }
        }

        public Boolean isConnected() {
            if (SSHClient != null)
            {
                if (SSHClient.IsConnected == true) {
                    if (SSHTunnelPort.IsStarted == true) {
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        public void Close() {
            if (SSHTunnelPort != null)
            {
                SSHTunnelPort.Stop();
                SSHTunnelPort = null;
            }
            if (SSHClient != null)
            {
                SSHClient.Disconnect();
                SSHClient = null;
            }
        }

         ~SSHTunnel() {
            try
            {
                if (SSHTunnelPort != null) { 
                    SSHTunnelPort.Stop();
                    SSHTunnelPort = null;
                }
                if (SSHClient != null)
                {
                    SSHClient.Disconnect();
                    SSHClient = null;
                }
            }
            catch (Exception e)
            {
                error = e.Message.ToString();
            }
        }

    }
}
