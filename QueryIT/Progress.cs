using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QueryIT {
    public partial class ProgressForm : Form {

        QueryForm QParent;
        CompareForm CParent;
        DateTime utcStart;
        int rps = 0;
        string Error;

        public ProgressForm() {
            InitializeComponent();
        }

        public ProgressForm(QueryForm p) {
            QParent = p;
            utcStart = DateTime.UtcNow;
            InitializeComponent();
        }

        public ProgressForm(QueryForm p, string Name) {
            QParent = p;
            utcStart = DateTime.UtcNow;
            InitializeComponent();
            this.Text = Name;
        }

        public ProgressForm(CompareForm p) {
            CParent = p;
            utcStart = DateTime.UtcNow;
            InitializeComponent();
            this.Text = Name;
        }

        public ProgressForm(CompareForm p, string Name) {
            CParent = p;
            utcStart = DateTime.UtcNow;
            InitializeComponent();
            this.Text = Name;
        }

        public void update(int min, int max, int position) {
            try {
                if(progress.Maximum != min) {
                    progress.Minimum = min;
                }
                if(progress.Maximum != max) {
                    progress.Maximum = max;
                }
                if(position < min) {
                    progress.Value = min;
                } else if(position > max) {
                    progress.Value = max;
                } else {
                    progress.Value = position;
                }
                TimeLbl.Text = "Time: " + DateTime.UtcNow.Subtract(utcStart).Seconds.ToString();
                if(position > 0) {
                    rps = (position / (DateTime.UtcNow.Subtract(utcStart).Seconds + 1));
                }
                SpeedLbl.Text = "~" + rps + " Records/s";
                if(rps > 0) {
                    EstimationLbl.Text = "Time left: ~" + (max - position) / rps + "s";
                }
                //progress.Refresh();
                if(this.Focused == false) {
                    this.Focus();
                }
                //Application.DoEvents();
            } catch(Exception e) {
                Error = e.Message;
            }
        }

        private void ProgressForm_Load(object sender, EventArgs e) {

        }

        private void killBtn_Click(object sender, EventArgs e) {
            try {
                if(CParent != null) {
                    CParent.run = false;
                }
                if(QParent != null) {
                    QParent.run = false;
                }
            } catch(Exception err) {
                Error = err.Message;
            }
        }
    }
}
