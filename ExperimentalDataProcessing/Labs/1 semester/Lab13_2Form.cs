using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab13_2Form : Form
	{
		public Lab13_2Form()
		{
			InitializeComponent();
		}

		#region Сonstants

		private const string FilePath = "D:\\Magistracy\\1.2\\Методы обработки экспериментальных данных\\ExperimentalDataProcessing\\ExperimentalDataProcessing\\Data\\";

		#endregion

		private void Lab13_2Form_Load(object sender, EventArgs e)
		{
			Chart[] charts = { chart1, chart2 };

			foreach (var chart in charts)
			{
				chart.Series.Clear();
			}

			var inOut = new InOut();

			var data1 = inOut.ReadWavFile(FilePath + "Wav\\DogBarking.wav", out var rate1, out var n1);
			var data2 = inOut.ReadWavFile(FilePath + "Wav\\RetroGameAlarm.wav", out var rate2, out var n2);

			chart1.AddDataSeries(data1);
			chart2.AddDataSeries(data2);

			textBox1.Text = $@"{rate1}";
			textBox2.Text = $@"{n1}";

			textBox3.Text = $@"{rate2}";
			textBox4.Text = $@"{n2}";

			foreach (var chart in charts)
			{
				chart.ChartAreas[0].RecalculateAxesScale();
				chart.Update();
			}
		}
	}
}
