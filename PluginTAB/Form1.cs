using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PluginTAB {
    public partial class ExportForm : Form {

        public string LineEnding { get; set; }
        public string Delemiter { get; set; }
        public bool ColumnNames { get; set; }

        public ExportForm() {
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, EventArgs e) {
            LineEnding = lineEndingBox.Text.ToString();
            Delemiter = fieldDelimiterBox.Text.ToString();
            ColumnNames = columnNamesChk.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
