using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab12_3Form : Form
	{
		public Lab12_3Form()
		{
			InitializeComponent();
		}

		#region Сonstants

		private const double Fc = 50;

		private const double Fc1 = 35;

		private const double Fc2 = 75;

		private const double Dt = 0.002;

		private const int M = 64;

		private const int N = 2 * M + 1;

		#endregion

		private void Lab12_3Form_Load(object sender, EventArgs e)
		{
			Chart[] charts = { chart1, chart2, chart3, chart4 };

			foreach (var chart in charts)
			{
				chart.Series.Clear();
			}

			var processing = new Processing();
			var analysis = new Analysis();

			var lpw = processing.Lpf(Fc, Dt, M);
			var refLpw = processing.ReflectLpf(lpw);

			var hpw = processing.Hpf(Fc, Dt, M);
			var bpw = processing.Bpf(Fc1, Fc2, Dt, M);
			var bsw = processing.Bsf(Fc1, Fc2, Dt, M);

			var tfLpw = analysis.FrequencyResponse(refLpw);
			var tfHpw = analysis.FrequencyResponse(hpw);
			var tfBpw = analysis.FrequencyResponse(bpw);
			var tfBsw = analysis.FrequencyResponse(bsw);

			var indices = new double[N];

			for (var i = 0; i < N; i++)
			{
				indices[i] = i;
			}

			var spectrum = analysis.SpectrumFourier(indices, Dt / 2);

			chart1.AddDataSeries(spectrum.Item2, tfLpw, N / 2);
			chart2.AddDataSeries(spectrum.Item2, tfHpw, N / 2);
			chart3.AddDataSeries(spectrum.Item2, tfBpw, N / 2);
			chart4.AddDataSeries(spectrum.Item2, tfBsw, N / 2);
		}
	}
}
