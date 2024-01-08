using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab15_2Form : Form
	{
		public Lab15_2Form()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Сonstants

		private const string FilePath = "D:\\Magistracy\\1.2\\Методы обработки экспериментальных данных\\ExperimentalDataProcessing\\ExperimentalDataProcessing\\Data\\";

		private const double Rate = 22050;
		private const double Dt = 1 / Rate;

		private const int M = 256;
		private const int N = 2 * M + 1;

		private const int X1 = 3500;
		private const int X2 = 11100;

		private const int Fc0 = 250;
		private const int Fc1 = 450;
		private const int Fc2 = 600;
		private const int Fc3 = 800;
		private const int Fc4 = 1050;
		private const int Fc5 = 1250;

		#endregion

		private void btnPlot_Click(object sender, EventArgs e)
		{
			Chart[] charts = { chart1, chart2, chart3, chart4, chart5 };

			foreach (var chart in charts)
			{
				chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
				chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();

				chart.Series.Clear();
			}

			var inOut = new InOut();
			var model = new Model();
			var analysis = new Analysis();
			var processing = new Processing();

			var fileData = inOut.ReadWavFile(FilePath + "Wav\\MyVoice.wav", out var rate, out var n);

			var stressedSyllable = new double[X2 - X1];
			Array.Copy(fileData, X1, stressedSyllable, 0, X2 - X1);

			var fourier = analysis.Fourier(stressedSyllable);
			var fourierXn = analysis.SpectrumFourier(fourier, Dt);

			var indices = new double[stressedSyllable.Length];

			for (var i = 0; i < N; i++)
			{
				indices[i] = i;
			}

			if (radioButton1.Checked)
			{
				var bpw = processing.Bpf(Fc0, Fc1, Dt, M);

				var tfBpwX = analysis.SpectrumFourier(indices, Dt);
				var tfBpwY = analysis.FrequencyResponse(bpw);

				var convolutionBpf = model.ConvolutionModel(stressedSyllable, bpw, N);

				indices = new double[convolutionBpf.Length];

				for (var i = 0; i < convolutionBpf.Length; i++)
				{
					indices[i] = i;
				}

				var convolutionBpfFourierX = analysis.SpectrumFourier(indices, Dt);
				var convolutionBpfFourierY = analysis.Fourier(convolutionBpf);

				inOut.WriteWavFile(FilePath + "Wav\\MyVoiceFirstSyllableFT", convolutionBpf, Rate);

				chart1.AddDataSeries(stressedSyllable);
				chart2.AddDataSeries(fourierXn.Item1, fourierXn.Item2, fourierXn.Item1.Length / 2);
				chart3.AddDataSeries(tfBpwX.Item1, tfBpwY, N / 2);
				chart4.AddDataSeries(convolutionBpf);
				chart5.AddDataSeries(convolutionBpfFourierX.Item1, convolutionBpfFourierY, convolutionBpfFourierX.Item1.Length / 2);
			}

			if (radioButton2.Checked)
			{
				var bpw = processing.Bpf(Fc1, Fc2, Dt, M);

				var tfBpwX = analysis.SpectrumFourier(indices, Dt);
				var tfBpwY = analysis.FrequencyResponse(bpw);

				var convolutionBpf = model.ConvolutionModel(stressedSyllable, bpw, N);

				indices = new double[convolutionBpf.Length];

				for (var i = 0; i < convolutionBpf.Length; i++)
				{
					indices[i] = i;
				}

				var convolutionBpfFourierX = analysis.SpectrumFourier(indices, Dt);
				var convolutionBpfFourierY = analysis.Fourier(convolutionBpf);

				inOut.WriteWavFile(FilePath + "Wav\\MyVoiceFirstSyllableF1", convolutionBpf, Rate);

				chart1.AddDataSeries(stressedSyllable);
				chart2.AddDataSeries(fourierXn.Item1, fourierXn.Item2, fourierXn.Item1.Length / 2);
				chart3.AddDataSeries(tfBpwX.Item1, tfBpwY, N / 2);
				chart4.AddDataSeries(convolutionBpf);
				chart5.AddDataSeries(convolutionBpfFourierX.Item1, convolutionBpfFourierY, convolutionBpfFourierX.Item1.Length / 2);
			}

			if (radioButton3.Checked)
			{
				var bpw = processing.Bpf(Fc2, Fc3, Dt, M);

				var tfBpwX = analysis.SpectrumFourier(indices, Dt);
				var tfBpwY = analysis.FrequencyResponse(bpw);

				var convolutionBpf = model.ConvolutionModel(stressedSyllable, bpw, N);

				indices = new double[convolutionBpf.Length];

				for (var i = 0; i < convolutionBpf.Length; i++)
				{
					indices[i] = i;
				}

				var convolutionBpfFourierX = analysis.SpectrumFourier(indices, Dt);
				var convolutionBpfFourierY = analysis.Fourier(convolutionBpf);

				inOut.WriteWavFile(FilePath + "Wav\\MyVoiceFirstSyllableF2", convolutionBpf, Rate);

				chart1.AddDataSeries(stressedSyllable);
				chart2.AddDataSeries(fourierXn.Item1, fourierXn.Item2, fourierXn.Item1.Length / 2);
				chart3.AddDataSeries(tfBpwX.Item1, tfBpwY, N / 2);
				chart4.AddDataSeries(convolutionBpf);
				chart5.AddDataSeries(convolutionBpfFourierX.Item1, convolutionBpfFourierY, convolutionBpfFourierX.Item1.Length / 2);
			}

			if (radioButton4.Checked)
			{
				var bpw = processing.Bpf(Fc3, Fc4, Dt, M);

				var tfBpwX = analysis.SpectrumFourier(indices, Dt);
				var tfBpwY = analysis.FrequencyResponse(bpw);

				var convolutionBpf = model.ConvolutionModel(stressedSyllable, bpw, N);

				indices = new double[convolutionBpf.Length];

				for (var i = 0; i < convolutionBpf.Length; i++)
				{
					indices[i] = i;
				}

				var convolutionBpfFourierX = analysis.SpectrumFourier(indices, Dt);
				var convolutionBpfFourierY = analysis.Fourier(convolutionBpf);

				inOut.WriteWavFile(FilePath + "Wav\\MyVoiceFirstSyllableF3", convolutionBpf, Rate);

				chart1.AddDataSeries(stressedSyllable);
				chart2.AddDataSeries(fourierXn.Item1, fourierXn.Item2, fourierXn.Item1.Length / 2);
				chart3.AddDataSeries(tfBpwX.Item1, tfBpwY, N / 2);
				chart4.AddDataSeries(convolutionBpf);
				chart5.AddDataSeries(convolutionBpfFourierX.Item1, convolutionBpfFourierY, convolutionBpfFourierX.Item1.Length / 2);
			}

			if (radioButton5.Checked)
			{
				var bpw = processing.Bpf(Fc4, Fc5, Dt, M);

				var tfBpwX = analysis.SpectrumFourier(indices, Dt);
				var tfBpwY = analysis.FrequencyResponse(bpw);

				var convolutionBpf = model.ConvolutionModel(stressedSyllable, bpw, N);

				indices = new double[convolutionBpf.Length];

				for (var i = 0; i < convolutionBpf.Length; i++)
				{
					indices[i] = i;
				}

				var convolutionBpfFourierX = analysis.SpectrumFourier(indices, Dt);
				var convolutionBpfFourierY = analysis.Fourier(convolutionBpf);

				inOut.WriteWavFile(FilePath + "Wav\\MyVoiceFirstSyllableF4", convolutionBpf, Rate);

				chart1.AddDataSeries(stressedSyllable);
				chart2.AddDataSeries(fourierXn.Item1, fourierXn.Item2, fourierXn.Item1.Length / 2);
				chart3.AddDataSeries(tfBpwX.Item1, tfBpwY, N / 2);
				chart4.AddDataSeries(convolutionBpf);
				chart5.AddDataSeries(convolutionBpfFourierX.Item1, convolutionBpfFourierY, convolutionBpfFourierX.Item1.Length / 2);
			}

			foreach (var chart in charts)
			{
				chart.ChartAreas[0].RecalculateAxesScale();
				chart.Update();
			}
		}
	}
}
