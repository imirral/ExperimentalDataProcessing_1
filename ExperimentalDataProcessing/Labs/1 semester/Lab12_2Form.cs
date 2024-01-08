using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab12_2Form : Form
	{
		public Lab12_2Form()
		{
			InitializeComponent();
		}

		#region Сonstants

		private const double Fc = 50;

		private const double Fc1 = 35;

		private const double Fc2 = 75;

		private const double Dt = 0.002;

		private const int M = 64;

		#endregion

		private void Lab12_2Form_Load(object sender, EventArgs e)
		{
			Chart[] charts = { chart1, chart2, chart3, chart4 };

			foreach (var chart in charts)
			{
				chart.Series.Clear();
			}

			var processing = new Processing();

			var lpw = processing.Lpf(Fc, Dt, M);

			var refLpw = processing.ReflectLpf(lpw);

			var hpw = processing.Hpf(Fc, Dt, M);

			var bpw = processing.Bpf(Fc1, Fc2, Dt, M);

			var bsw = processing.Bsf(Fc1, Fc2, Dt, M);

			chart1.AddDataSeries(refLpw);

			chart2.AddDataSeries(hpw);

			chart3.AddDataSeries(bpw);

			chart4.AddDataSeries(bsw);
		}
	}
}
