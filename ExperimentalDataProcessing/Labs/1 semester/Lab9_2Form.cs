using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab9_2Form : Form
	{
		public Lab9_2Form()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Constants

		private const int N = 1000;

		private const int R = 30;

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
			var processing = new Processing();

			var data = new double[N];

			if (radioButton1.Checked)
			{
				var noise = model.Noise(5, N);

				data = model.Spikes(noise,0.5, R, 1);
			}

			if (radioButton2.Checked)
			{
				var harm = model.Harm(N, 5, 15, 0.001);

				data = model.Spikes(harm,0.5, R, 1);
			}

			var antiSpikesSeries = processing.AntiSpike(data, R);

			chart1.AddDataSeries(data);
			chart2.AddDataSeries(antiSpikesSeries);

			foreach (var chart in charts)
			{
				chart.ChartAreas[0].RecalculateAxesScale();
				chart.Update();
			}
		}
	}
}
