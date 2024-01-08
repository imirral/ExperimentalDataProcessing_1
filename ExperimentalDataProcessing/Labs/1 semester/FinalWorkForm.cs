using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class FinalWorkForm : Form
	{
		public FinalWorkForm()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Constants

		private const string FilePath = "D:\\Magistracy\\1.2\\Методы обработки экспериментальных данных\\ExperimentalDataProcessing\\ExperimentalDataProcessing\\Data\\";
		
		private const double Fc1 = 70.01;

		private const double Fc2 = 70.02;

		private const double Dt = 0.002;

		private const int M = 128;

		private const int N = M * 2 + 1;

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

			var fileData = inOut.ReadDatFile(FilePath + "Bin\\v33.bin", 1000);

			var antiShiftData = processing.AntiShift(fileData);

			var antiTrendData = processing.AntiTrendLinear(antiShiftData);

			var antiTrendDataFourier = analysis.Fourier(antiTrendData);
			var antiTrendDataXn = analysis.SpectrumFourier(antiTrendDataFourier, Dt);

			var bpw = processing.Bpf(Fc1, Fc2, Dt, M);
			var convolutionBpf = model.ConvolutionModel(antiTrendData, bpw, N);

			var newConvolutionBpf = new double[antiTrendData.Length - M];

			Array.Copy(convolutionBpf, M / 2,
				newConvolutionBpf, 0,
				antiTrendData.Length - M);

			var convolutionBpfFourier = analysis.Fourier(newConvolutionBpf);
			var convolutionBpfXn = analysis.SpectrumFourier(convolutionBpfFourier, Dt);

			chart1.AddDataSeries(fileData);
			chart2.AddDataSeries(antiTrendData);
			chart3.AddDataSeries(antiTrendDataXn.Item1, antiTrendDataXn.Item2, antiTrendDataXn.Item1.Length / 2);
			chart4.AddDataSeries(convolutionBpfXn.Item1, convolutionBpfXn.Item2, convolutionBpfXn.Item1.Length / 2);
			chart5.AddDataSeries(newConvolutionBpf);

			foreach (var chart in charts)
			{
				chart.ChartAreas[0].RecalculateAxesScale();
				chart.Update();
			}
		}
	}
}
