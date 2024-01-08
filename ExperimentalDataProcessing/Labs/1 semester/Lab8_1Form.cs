using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab8_1Form : Form
	{
		public Lab8_1Form()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Constants

		private const int N = 1000;

		private const double Dt = 1;

		#endregion

		private void btnPlot_Click(object sender, EventArgs e)
		{
			Chart[] charts = { chart1, chart2 };

			foreach (var chart in charts)
			{
				chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
				chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();

				chart.Series.Clear();
			}

			var model = new Model();

			var data1 = new double[N];
			var data2 = new double[N];

			if (radioButton1.Checked)
			{
				data1 = model.TrendLinear(-0.3, -20, Dt, N);
				data2 = model.Harm(N, 5, 50, 0.001);
			}

			if (radioButton2.Checked)
			{
				data1 = model.TrendNonLinear(0.005, 10, Dt, N);
				data2 = model.Noise(10, N);
			}

			var addModel = model.AddModel(data1, data2, Dt);
			var multModel = model.MultModel(data1, data2, Dt);

			chart1.AddDataSeries(addModel);
			chart2.AddDataSeries(multModel);

			foreach (var chart in charts)
			{
				chart.ChartAreas[0].RecalculateAxesScale();
				chart.Update();
			}
		}
	}
}
