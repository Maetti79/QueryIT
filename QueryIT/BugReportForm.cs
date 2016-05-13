using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Net.Mail;
using QueryIT;
using Microsoft.Win32;

namespace QueryIT
{
    public partial class BugReportForm : Form
    {


        public Core plugincore = new Core(Environment.CurrentDirectory);
        public String SerialManager = Serial.GetSerialNumber();

        public BugReportForm()
        {
            InitializeComponent();
        }

        public BugReportForm(String[] Errorlog)
        {
            InitializeComponent();
            foreach(String Error in Errorlog)
            {
                bugReportBox.Text = bugReportBox.Text + Error + "\n";
            }
        }

        private void BugReportForm_Load(object sender, EventArgs e)
        {

        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
                try {
                    SmtpClient client = new SmtpClient();
                    client.Port = 587;
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("dennismittmann79@gmail.com", "deltatbb12");

                    MailMessage mm = new MailMessage("dennismittmann79@gmail.com", "dennismittmann79@gmail.com");
                    mm.Subject = "QueryIT - BugReport";
                    mm.Body = bugReportBox.Text.ToString();
                    mm.BodyEncoding = UTF8Encoding.UTF8;
                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    client.Send(mm);
	            }  
	            catch (Exception ex) {
	              Console.WriteLine("Exception caught in CreateTestMessage2(): {0}", 
                              ex.ToString() );			  
                }              

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
