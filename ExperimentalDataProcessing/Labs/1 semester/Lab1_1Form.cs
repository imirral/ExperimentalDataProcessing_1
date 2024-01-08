using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab1_1Form : Form
	{
		public Lab1_1Form()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Constants

		private const int Dt = 1;

		private const int N = 1000;

		#endregion

		private void btnPlot_Click(object sender, EventArgs e)
		{
			if (double.TryParse(txtA.Text, out var a) &&
			    double.TryParse(txtB.Text, out var b) &&
			    a != 0 && b != 0)
			{
				Chart[] charts = { chart1, chart2, chart3, chart4 };

				foreach (var chart in charts)
				{
					chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
					chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();

					chart.Series.Clear();
				}

				var model = new Model();

				var trendLinearAsc = model.TrendLinear(-a, -b, Dt, N);
				var trendLinearDesc = model.TrendLinear(a, b, Dt, N);
				var trendNonLinearAsc = model.TrendNonLinear(-a, b, Dt, N);
				var trendNonLinearDesc = model.TrendNonLinear(a, b, Dt, N);

				var xValues = new double[N];

				for (var i = 0; i < N; i++)
				{
					xValues[i] = i * Dt;
				}

				chart1.AddDataSeries(xValues, trendLinearAsc);
				chart2.AddDataSeries(xValues, trendLinearDesc);
				chart3.AddDataSeries(xValues, trendNonLinearAsc);
				chart4.AddDataSeries(xValues, trendNonLinearDesc);

				foreach (var chart in charts)
				{
					chart.ChartAreas[0].RecalculateAxesScale();
					chart.Update();
				}
			}
			else
			{
				MessageBox.Show(@"Введено некорректное значение параметра");
			}
		}
	}
}
