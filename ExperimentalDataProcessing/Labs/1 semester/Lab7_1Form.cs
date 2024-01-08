using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab7_1Form : Form
	{
		public Lab7_1Form()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Constants

		private const int N = 1024;

		private const double Dt = 0.001;

		#endregion

		private void btnPlot_Click(object sender, EventArgs e)
		{
			if (int.TryParse(txtL.Text, out var l))
			{
				Chart[] charts = { chart1, chart2 };

				foreach (var chart in charts)
				{
					chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
					chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();

					chart.Series.Clear();
				}

				var model = new Model();
				var analysis = new Analysis();

				var data1 = new double[N];
				var data2 = new double[N];

				if (radioButton1.Checked)
				{
					data1 = model.Harm(N, 100, 150, Dt);
				}

				if (radioButton2.Checked)
				{
					var amplitudes = new double[]
					{
						100, 15, 20
					};

					var frequencies = new double[]
					{
						33, 5, 170
					};

					data1 = model.PolyHarm(N, amplitudes, frequencies, Dt);
				}

				if (radioButton3.Checked)
				{
					data1 = model.Noise(100, N);
				}

				if (radioButton4.Checked)
				{
					data1 = model.MyNoise(100, N);
				}

				if (radioButton5.Checked)
				{
					data1 = model.Shift(data1, 100, 0, N);
				}

				if (radioButton6.Checked)
				{
					data1 = model.TrendLinear(-0.01, -0.01, 1, N);
				}

				if (radioButton7.Checked)
				{
					data1 = model.Spikes(data1, 0.1, 100, 10);
				}

				// Амплитудный спектр Фурье данных без прямоугольного окна

				var fourier1 = analysis.Fourier(data1);

				var spectrum1 = analysis.SpectrumFourier(fourier1, Dt);

				var length = spectrum1.Item1.Length / 2;

				chart1.AddDataSeries(spectrum1.Item1, spectrum1.Item2, length);

				// Амплитудный спектр Фурье данных с прямоугольным окном длины l

				Array.Copy(data1, data2, data1.Length - l);

				var fourier2 = analysis.Fourier(data2);

				var spectrum2 = analysis.SpectrumFourier(fourier2, Dt);

				chart2.AddDataSeries(spectrum2.Item1, spectrum2.Item2, length);

				foreach (var chart in charts)
				{
					chart.ChartAreas[0].RecalculateAxesScale();
					chart.Update();
				}
			}
			else
			{
				MessageBox.Show(@"Incorrect parameter values");
			}
		}
	}
}
