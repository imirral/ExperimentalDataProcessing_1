using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs.CourceWork
{
	public partial class DopplerWithNoiseForm : Form
	{
		public DopplerWithNoiseForm()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Сonstants

		private const int N = 1000;

		private const double A = 100;

		private const double Dt = 0.001;

		private const double R = 300;

		private const int M = 64;

		#endregion

		private void btnPlot_Click(object sender, EventArgs e)
		{
			if (double.TryParse(txtf.Text, out var f) &&
				double.TryParse(txtVo.Text, out var vo) &&
				double.TryParse(txtVs.Text, out var vs) &&
				int.TryParse(txtM.Text, out var m))
			{
				Chart[] charts = { chart1, chart2, chart4, chart3 };

				foreach (var chart in charts)
				{
					chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
					chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();

					chart.Series.Clear();
				}

				var model = new Model();
				var analysis = new Analysis();
				var processing = new Processing();

				var (fo, fs) = model.Doppler(f, vo, vs);

				var dataObserver = model.Harm(N, A, fo, Dt);
				var dataSource = model.Harm(N, A, fs, Dt);

				var noise = model.Noise(R, N);

				var dataObserverWithNoise = model.AddModel(dataObserver, noise, 1);
				var dataSourceWithNoise = model.AddModel(dataSource, noise, 1);

				if (checkBox1.Checked)
				{
					var observer = new double[m][];
					var source = new double[m][];

					for (var i = 0; i < m; i++)
					{
						dataObserver = model.Harm(N, A, fo, Dt);
						dataSource = model.Harm(N, A, fs, Dt);

						noise = model.Noise(R, N);

						observer[i] = model.AddModel(dataObserver, noise, 1);
						source[i] = model.AddModel(dataSource, noise, 1);
					}

					dataObserverWithNoise = processing.AntiNoise(observer, out var devObserver);
					dataSourceWithNoise = processing.AntiNoise(source, out var devSource);
				}

				if (checkBox2.Checked)
				{
					var bpw1 = processing.Bpf(fo - 1, fo + 1, Dt, M);

					var convolutionBpfObserver = model.ConvolutionModel(dataObserverWithNoise, bpw1, 2 * M + 1);

					dataObserverWithNoise = new double[convolutionBpfObserver.Length - M];

					Array.Copy(convolutionBpfObserver, M / 2,
						dataObserverWithNoise, 0,
						convolutionBpfObserver.Length - M);

					var bpw2 = processing.Bpf(fs - 1, fs + 1, Dt, M);

					var convolutionBpfOSource = model.ConvolutionModel(dataSourceWithNoise, bpw2, 2 * M + 1);

					dataSourceWithNoise = new double[convolutionBpfOSource.Length - M];

					Array.Copy(convolutionBpfOSource, M / 2,
						dataSourceWithNoise, 0,
						convolutionBpfOSource.Length - M);
				}

				var fourierDataObserver = analysis.Fourier(dataObserverWithNoise);
				var fourierDataSource = analysis.Fourier(dataSourceWithNoise);

				var spectrumDataObserver = analysis.SpectrumFourier(fourierDataObserver, Dt);
				var spectrumDataSource = analysis.SpectrumFourier(fourierDataSource, Dt);

				//for (var i = 0; i < dataObserverWithNoise.Length; i++)
				//{
				//	dataObserverWithNoise[i] *= 10;
				//	dataSourceWithNoise[i] *= 10;
				//	spectrumDataObserver.Item2[i] *= 10;
				//	spectrumDataSource.Item2[i] *= 10;
				//}

				chart1.AddDataSeries(dataObserverWithNoise);
				chart2.AddDataSeries(dataSourceWithNoise);
				chart3.AddDataSeries(spectrumDataObserver.Item1, spectrumDataObserver.Item2, N / 2);
				chart4.AddDataSeries(spectrumDataSource.Item1, spectrumDataSource.Item2, N / 2);

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
