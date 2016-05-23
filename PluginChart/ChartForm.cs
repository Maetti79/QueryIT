using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PluginChart
{
    public partial class ChartForm : Form
    {

        DataTable Data;
        string[] SeriesColumns;

        public ChartForm()
        {
            InitializeComponent();
        }

        public ChartForm(DataTable DT)
        {
            Data = DT;
            InitializeComponent();
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            xAxisBox.Items.Clear();
            foreach (DataColumn rcol in Data.Columns) {
                xAxisBox.Items.Add(rcol.Caption.ToString());
                if (rcol.Caption.ToString().Equals("id")){
                    YSeriesList.Items.Add(rcol.Caption.ToString(), false);
                } else {
                    YSeriesList.Items.Add(rcol.Caption.ToString(), true);
                }
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void xAxisBox_SelectedIndexChanged(object sender, EventArgs e) {
            doChart();
        }

        private void YSeriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            doChart();
        }

        public void doChart() { 
            try {
                foreach (object col in YSeriesList.CheckedItems)
                {
                    SeriesColumns = SeriesColumns.PAdd(col.ToString());
                }
                Chart1.DataSource = Data;
                foreach (DataColumn col in Data.Columns)
                {
                    if (col.Caption.ToString() == xAxisBox.Text.ToString())
                    {
                        //Skip
                    }
                    else
                    {
                        if (SeriesColumns.Contains(col.Caption.ToString()) == true)
                        {
                            Chart1.Series.Add(col.Caption.ToString());
                            Chart1.Series[col.Caption.ToString()].Name = col.Caption.ToString();
                            Chart1.Series[col.Caption.ToString()].AxisLabel = col.Caption.ToString();
                            Chart1.Series[col.Caption.ToString()].XValueMember = xAxisBox.Text.ToString();
                            Chart1.Series[col.Caption.ToString()].YValueMembers = col.Caption.ToString();
                            Chart1.Series[col.Caption.ToString()].ChartType = SeriesChartType.Line;
                        }
                    }
                }

                Chart1.DataBind();
            } catch (Exception e) {

            }
        }

    }
}
