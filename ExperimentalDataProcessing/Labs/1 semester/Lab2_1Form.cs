using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab2_1Form : Form
	{
		public Lab2_1Form()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Constants

		private const int N = 1000;

		#endregion

		private void btnPlot_Click(object sender, EventArgs e)
		{
			if (double.TryParse(txtR.Text, out var r))
			{
				Chart[] charts = { chart1, chart2 };

				foreach (var chart in charts)
				{
					chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
					chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();

					chart.Series.Clear();
				}

				var model = new Model();

				var noise = model.Noise(r, N);
				var myNoise = model.MyNoise(r, N);

				chart1.AddDataSeries(noise);
				chart2.AddDataSeries(myNoise);

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
