using ExperimentalDataProcessing.Extensions;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab15_1Form : Form
	{
		public Lab15_1Form()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Сonstants

		private const string FilePath = "D:\\Magistracy\\1.2\\Методы обработки экспериментальных данных\\ExperimentalDataProcessing\\ExperimentalDataProcessing\\Data\\";

		private const double Rate = 22050;

		private const double Dt = 1 / Rate;

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

			var inOut = new InOut();
			var analysis = new Analysis();

			var fileData = inOut.ReadWavFile(FilePath + "Wav\\MyVoice.wav", out var rate, out var n);

			var x1 = 3500;
			var x2 = 11100;
			var x3 = 11101;
			var x4 = 28799;

			if (radioButton1.Checked)
			{
				var fourier = analysis.Fourier(fileData);
				var fourierXn = analysis.SpectrumFourier(fourier, Dt);

				chart1.AddDataSeries(fileData);
				chart2.AddDataSeries(fourierXn.Item1, fourierXn.Item2, fourierXn.Item1.Length / 2);

				textBox1.Text = $@"{Rate}";
				textBox2.Text = $@"{n}";
			}

			if (radioButton2.Checked)
			{
				var stressedSyllable = new double[x2 - x1];
				Array.Copy(fileData, x1, stressedSyllable, 0, x2 - x1);

				var fourier = analysis.Fourier(stressedSyllable);
				var fourierXn = analysis.SpectrumFourier(fourier, Dt);

				chart1.AddDataSeries(stressedSyllable);
				chart2.AddDataSeries(fourierXn.Item1, fourierXn.Item2, fourierXn.Item1.Length / 2);

				textBox1.Text = $@"{Rate}";
				textBox2.Text = $@"{stressedSyllable.Length}";
			}

			if (radioButton3.Checked)
			{
				var unstressedSyllable = new double[x4 - x3];
				Array.Copy(fileData, x3, unstressedSyllable, 0, x4 - x3);

				var fourier = analysis.Fourier(unstressedSyllable);
				var fourierXn = analysis.SpectrumFourier(fourier, Dt);

				chart1.AddDataSeries(unstressedSyllable);
				chart2.AddDataSeries(fourierXn.Item1, fourierXn.Item2, fourierXn.Item1.Length / 2);

				textBox1.Text = $@"{Rate}";
				textBox2.Text = $@"{unstressedSyllable.Length}";
			}

			foreach (var chart in charts)
			{
				chart.ChartAreas[0].RecalculateAxesScale();
				chart.Update();
			}
		}
	}
}
