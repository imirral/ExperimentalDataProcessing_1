using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab9_1Form : Form
	{
		public Lab9_1Form()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Constants

		private const int N = 1000;

		#endregion

		private void btnPlot_Click(object sender, EventArgs e)
		{
			if (double.TryParse(txtA.Text, out var a) &&
			    double.TryParse(txtB.Text, out var b) &&
			    a != 0 && b != 0)
			{
				Chart[] charts = { chart1, chart2 };

				foreach (var chart in charts)
				{
					chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
					chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();

					chart.Series.Clear();
				}

				var model = new Model();
				var processing = new Processing();

				var data = model.TrendLinear(-a, -b, 1, N);

				var antiShiftData = processing.AntiShift(data);

				chart1.AddDataSeries(data);
				chart2.AddDataSeries(antiShiftData);

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
