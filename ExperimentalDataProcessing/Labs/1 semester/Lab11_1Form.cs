using ExperimentalDataProcessing.Extensions;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab11_1Form : Form
	{
		public Lab11_1Form()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Сonstants

		private const int N = 1000;

		private const int M = 200;

		private const double a = 30;

		private const double b = 1;

		private const double A = 1;

		private const double F = 7;

		private const double R = 1;

		private const double Rs = 0.1;

		private const double Dt = 0.005;

		#endregion

		#region Fields

		private static readonly Random Random = new Random();

		#endregion

		private void btnPlot_Click(object sender, EventArgs e)
		{
			Chart[] charts = { chart1, chart2, chart3 };

			foreach (var chart in charts)
			{
				chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
				chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();

				chart.Series.Clear();
			}

			var model = new Model();

			#region Heart

			var harm = model.Harm(N, A, F, Dt);

			var nonlinearTrend = model.TrendNonLinear(a, b, Dt, N);

			var mult = model.MultModel(harm, nonlinearTrend, 1);

			var h = new double[N];

			for (var i = 0; i < N; i++)
			{
				h[i] = mult[i] * 120 / mult.Max();
			}

			chart1.AddDataSeries(h);

			#endregion

			#region Rhythm

			var x = new double[N];

			if (radioButton1.Checked)
			{
				for (var i = 0; i < N; i++)
				{
					if (i % M == 0 && i != 0)
					{
						x[i] = Random.NextDouble() * 2 * Rs + (R - Rs);
					}
				}
			}

			if (radioButton2.Checked)
			{
				x = model.Spikes(x, 0.5, R, Rs, false);
			}

			chart2.AddDataSeries(x);

			#endregion

			#region Convolution

			var c = model.ConvolutionModel(x, h, M);

			chart3.AddDataSeries(c);

			#endregion

			foreach (var chart in charts)
			{
				chart.ChartAreas[0].RecalculateAxesScale();

				chart.Update();
			}
		}
	}
}
