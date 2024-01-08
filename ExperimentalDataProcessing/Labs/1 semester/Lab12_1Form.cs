using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab12_1Form : Form
	{
		public Lab12_1Form()
		{
			InitializeComponent();
		}

		#region Сonstants

		private const double Fc = 50;

		private const double Dt = 0.002;

		private const int M = 64;

		#endregion

		private void Lab12_1Form_Load(object sender, EventArgs e)
		{
			Chart[] charts = { chart1, chart2 };

			foreach (var chart in charts)
			{
				chart.Series.Clear();
			}

			var processing = new Processing();

			var lpw = processing.Lpf(Fc, Dt, M);

			var refLpw = processing.ReflectLpf(lpw);

			chart1.AddDataSeries(lpw);

			chart2.AddDataSeries(refLpw);
		}
	}
}
