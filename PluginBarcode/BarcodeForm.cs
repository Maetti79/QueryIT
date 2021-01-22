using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Neodynamic.SDK.Barcode;

namespace PluginBarcode
{
    public partial class BarcodeForm : Form
    {

        DataTable Data;
        public String iError;
        public BarcodeForm()
        {
            InitializeComponent();
        }

        public BarcodeForm(DataTable DT)
        {
            Data = DT;
            InitializeComponent();
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            columnSelect.Items.Clear();
            foreach (DataColumn rcol in Data.Columns)
            {
                columnSelect.Items.Add(rcol.Caption.ToString());
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        public void doBarcode() { 
            try {
                DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
                iconColumn.Name = "Barcode";
                iconColumn.HeaderText = "Barcode";
                DataView.Columns.Clear();
                DataView.Columns.Add(iconColumn);
                foreach (DataRow row in Data.Rows) {
                    String code = row[columnSelect.SelectedIndex].ToString();
                    BarcodeProfessional myBarcode = new BarcodeProfessional();
                    myBarcode.Symbology = Symbology.Code128;
                    myBarcode.Code = code;
                  
                    DataView.Rows.Add(myBarcode.GetBarcodeImage());
                }
                DataView.Refresh();
            } catch (Exception e) {
                iError = e.Message;
            }
        }

        private void columnSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            doBarcode();
        }
    }
}
