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
        QueryerForm Q2Parent;
        CompareForm CParent;
        ForeachForm FEParent;
        MoveForm MParent;
        CrossJoin CJParent;
        ChunkForm ChkParent;

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

        public ProgressForm(QueryerForm p, string Name) {
            Q2Parent = p;
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

        public ProgressForm(CrossJoin p, string Name) {
            CJParent = p;
            utcStart = DateTime.UtcNow;
            InitializeComponent();
            this.Text = Name;
        }

        public ProgressForm(ForeachForm p, string Name) {
            FEParent = p;
            utcStart = DateTime.UtcNow;
            InitializeComponent();
            this.Text = Name;
        }

        public ProgressForm(MoveForm p, string Name) {
            MParent = p;
            utcStart = DateTime.UtcNow;
            InitializeComponent();
            this.Text = Name;
        }


        public ProgressForm(ChunkForm p, string Name) {
            ChkParent = p;
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
                if(this.Focused == false) {
                    this.Focus();
                }
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
                if(Q2Parent != null) {
                    Q2Parent.run = false;
                }
                if(FEParent != null) {
                    FEParent.run = false;
                }
                if(CJParent != null) {
                    CJParent.run = false;
                }
                if(MParent != null) {
                    MParent.run = false;
                }
                if(ChkParent != null) {
                    ChkParent.run = false;
                }
            } catch(Exception err) {
                Error = err.Message;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            Application.DoEvents();
        }
    }
}
