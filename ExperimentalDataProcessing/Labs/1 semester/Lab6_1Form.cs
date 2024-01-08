using System;
using System.Windows.Forms;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab6_1Form : Form
	{
		public Lab6_1Form()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Constants

		private const int N = 10000;

		private const int M = 100;

		#endregion

		private void btnPlot_Click(object sender, EventArgs e)
		{
			chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();
			chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();

			chart1.Series.Clear();

			var model = new Model();
			var analysis = new Analysis();

			var data = new double[N];

			if (radioButton1.Checked)
			{
				data = model.TrendLinear(-0.01, -0.01, 1, N);
			}

			if (radioButton2.Checked)
			{
				data = model.TrendLinear(0.01, 0.01, 1, N);
			}

			if (radioButton3.Checked)
			{
				data = model.TrendNonLinear(0.01, -0.01, 1, N);
			}

			if (radioButton4.Checked)
			{
				data = model.TrendNonLinear(0.01, 0.01, 1, N);
			}

			if (radioButton5.Checked)
			{
				data = model.Noise(100, N);
			}

			if (radioButton6.Checked)
			{
				data = model.MyNoise(100, N);
			}

			if (radioButton7.Checked)
			{
				data = model.Harm(N, 100, 15, 0.001);
			}

			if (radioButton8.Checked)
			{
				var amplitudes = new double[]
				{
					100, 15, 20
				};

				var frequencies = new double[]
				{
					33, 5, 170
				};

				data = model.PolyHarm(N, amplitudes, frequencies, 0.001);
			}

			var hist = analysis.Hist(data, M);

			chart1.AddDataSeries(hist);

			chart1.ChartAreas[0].RecalculateAxesScale();
			chart1.Update();
		}
	}
}
