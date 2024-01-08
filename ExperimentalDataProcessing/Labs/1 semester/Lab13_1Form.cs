using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab13_1Form : Form
	{
		public Lab13_1Form()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Сonstants

		private const int N = M * 2 + 1;

		private const string FilePath = "D:\\Magistracy\\1.2\\Методы обработки экспериментальных данных\\ExperimentalDataProcessing\\ExperimentalDataProcessing\\Data\\";
		
		private const double Fc1 = 15;

		private const double Fc2 = 100;

		private const double Dt = 0.002;

		private const int M = 64;

		#endregion

		private void btnPlot_Click(object sender, EventArgs e)
		{
			Chart[] charts = { chart1, chart2, chart3, chart4, chart5 };

			foreach (var chart in charts)
			{
				chart.Series.Clear();
			}

			var analysis = new Analysis();
			var inOut = new InOut();
			var processing = new Processing();
			var model = new Model();

			var fileData = inOut.ReadDatFile(FilePath + "Dat\\pgp_dt0005.dat", 1000);
			var dataLen = fileData.Length;
			var fileDataFourier = analysis.Fourier(fileData);
			var fileDataXn = analysis.SpectrumFourier(fileDataFourier, Dt);

			var indices = new double[N];

			for (var i = 0; i < N; i++)
			{
				indices[i] = i;
			}

			var newXn = analysis.SpectrumFourier(indices, Dt);

			if (radioButton1.Checked)
			{
				var lpw = processing.Lpf(Fc1, Dt, M);
				var refLpw = processing.ReflectLpf(lpw);
				var tfLpw = analysis.FrequencyResponse(refLpw);
				var convolutionLpf = model.ConvolutionModel(fileData, refLpw, N);

				var newConvolutionLpf = new double[dataLen - M];

				Array.Copy(convolutionLpf, M / 2,
					newConvolutionLpf, 0,
					dataLen - M);

				var convolutionLpfFourier = analysis.Fourier(newConvolutionLpf);
				var convolutionLpfXn = analysis.SpectrumFourier(convolutionLpfFourier, Dt);

				chart1.AddDataSeries(fileData);
				chart2.AddDataSeries(fileDataXn.Item1, fileDataXn.Item2, dataLen / 2);
				chart3.AddDataSeries(newXn.Item1, tfLpw, N / 2);
				chart4.AddDataSeries(newConvolutionLpf);
				chart5.AddDataSeries(convolutionLpfXn.Item1, convolutionLpfXn.Item2, convolutionLpfXn.Item1.Length / 2);
			}

			if (radioButton2.Checked)
			{
				var hpw = processing.Hpf(Fc2, Dt, M);
				var tfHpw = analysis.FrequencyResponse(hpw);
				var convolutionHpf = model.ConvolutionModel(fileData, hpw, N);

				var newConvolutionHpf = new double[dataLen - M];

				Array.Copy(convolutionHpf, M / 2,
					newConvolutionHpf, 0,
					dataLen - M);

				var convolutionHpfFourier = analysis.Fourier(newConvolutionHpf);
				var convolutionHpfXn = analysis.SpectrumFourier(convolutionHpfFourier, Dt);

				chart1.AddDataSeries(fileData);
				chart2.AddDataSeries(fileDataXn.Item1, fileDataXn.Item2, dataLen / 2);
				chart3.AddDataSeries(newXn.Item1, tfHpw, N / 2);
				chart4.AddDataSeries(newConvolutionHpf);
				chart5.AddDataSeries(convolutionHpfXn.Item1, convolutionHpfXn.Item2, convolutionHpfXn.Item1.Length / 2);
			}

			if (radioButton3.Checked)
			{
				var bpw = processing.Bpf(Fc1, Fc2, Dt, M);
				var tfBpw = analysis.FrequencyResponse(bpw);
				var convolutionBpf = model.ConvolutionModel(fileData, bpw, N);

				var newConvolutionBpf = new double[dataLen - M];

				Array.Copy(convolutionBpf, M / 2,
					newConvolutionBpf, 0,
					dataLen - M);

				var convolutionBpfFourier = analysis.Fourier(newConvolutionBpf);
				var convolutionBpfXn = analysis.SpectrumFourier(convolutionBpfFourier, Dt);

				chart1.AddDataSeries(fileData);
				chart2.AddDataSeries(fileDataXn.Item1, fileDataXn.Item2, dataLen / 2);
				chart3.AddDataSeries(newXn.Item1, tfBpw, N / 2);
				chart4.AddDataSeries(newConvolutionBpf);
				chart5.AddDataSeries(convolutionBpfXn.Item1, convolutionBpfXn.Item2, convolutionBpfXn.Item1.Length / 2);
			}

			if (radioButton4.Checked)
			{
				var bsw = processing.Bsf(Fc1, Fc2, Dt, M);
				var tfBsw = analysis.FrequencyResponse(bsw);
				var convolutionBsf = model.ConvolutionModel(fileData, bsw, N);

				var newConvolutionBsf = new double[dataLen - M];

				Array.Copy(convolutionBsf, M / 2,
					newConvolutionBsf, 0,
					dataLen - M);

				var convolutionBpfFourier = analysis.Fourier(newConvolutionBsf);
				var convolutionBpfXn = analysis.SpectrumFourier(convolutionBpfFourier, Dt);

				chart1.AddDataSeries(fileData);
				chart2.AddDataSeries(fileDataXn.Item1, fileDataXn.Item2, dataLen / 2);
				chart3.AddDataSeries(newXn.Item1, tfBsw, N / 2);
				chart4.AddDataSeries(newConvolutionBsf);
				chart5.AddDataSeries(convolutionBpfXn.Item1, convolutionBpfXn.Item2, convolutionBpfXn.Item1.Length / 2);
			}

			foreach (var chart in charts)
			{
				chart.ChartAreas[0].RecalculateAxesScale();
				chart.Update();
			}
		}
	}
}
