using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs.CourceWork
{
	public partial class DopplerForm : Form
	{
		public DopplerForm()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Сonstants

		private const int N = 1000;

		private const double A = 100;

		private const double Dt = 0.001;

		#endregion

		private void btnPlot_Click(object sender, EventArgs e)
		{
			if (double.TryParse(txtf.Text, out var f) &&
			    double.TryParse(txtVo.Text, out var vo) &&
			    double.TryParse(txtVs.Text, out var vs))
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

				var (fo, fs) = model.Doppler(f, vo, vs);

				var harmDataObserver = model.Harm(N, A, fo, Dt);
				var harmDataSource = model.Harm(N, A, fs, Dt);

				var fourierDataObserver = analysis.Fourier(harmDataObserver);
				var fourierDataSource = analysis.Fourier(harmDataSource);

				var spectrumDataObserver = analysis.SpectrumFourier(fourierDataObserver, Dt);
				var spectrumDataSource = analysis.SpectrumFourier(fourierDataSource, Dt);

				double amplitudeObserver = double.MinValue;
				double frequencyObserver = 0;

				for (var i = 0; i < spectrumDataObserver.Item2.Length / 2; i++)
				{
					if (spectrumDataObserver.Item2[i] > amplitudeObserver)
					{
						amplitudeObserver = spectrumDataObserver.Item2[i];
						frequencyObserver = spectrumDataObserver.Item1[i];
					}
				}

				double amplitudeSource = double.MinValue;
				double frequencySource = 0;

				for (var i = 0; i < spectrumDataSource.Item2.Length / 2; i++)
				{
					if (spectrumDataSource.Item2[i] > amplitudeSource)
					{
						amplitudeSource = spectrumDataSource.Item2[i];
						frequencySource = spectrumDataSource.Item1[i];
					}
				}

				textBox1.Text = $@"{frequencyObserver}";
				textBox2.Text = $@"{Math.Round(amplitudeObserver, 3)}";
				textBox3.Text = $@"{frequencySource}";
				textBox4.Text = $@"{Math.Round(amplitudeSource, 3)}";

				chart1.AddDataSeries(harmDataObserver);
				chart2.AddDataSeries(harmDataSource);
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
