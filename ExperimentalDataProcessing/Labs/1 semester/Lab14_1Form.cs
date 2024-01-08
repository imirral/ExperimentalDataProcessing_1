using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab14_1Form : Form
	{
		public Lab14_1Form()
		{
			InitializeComponent();
		}

		#region Сonstants

		private const string FilePath = "D:\\Magistracy\\1.2\\Методы обработки экспериментальных данных\\ExperimentalDataProcessing\\ExperimentalDataProcessing\\Data\\";

		#endregion

		private void Lab14_1Form_Load(object sender, EventArgs e)
		{
			Chart[] charts = { chart1, chart2 };

			foreach (var chart in charts)
			{
				chart.Series.Clear();
			}

			var inOut = new InOut();
			var model = new Model();

			var fileData = inOut.ReadWavFile(FilePath + "Wav\\MyVoice.wav", out var rate, out var n);

			var x1 = 4000;
			var x2 = 7000;
			var x3 = 7001;
			var x4 = 28799;

			var stressedSyllable = new double[x2 - x1];
			Array.Copy(fileData, x1, stressedSyllable, 0, x2 - x1);

			var unstressedSyllable = new double[x4 - x3];
			Array.Copy(fileData, x3, unstressedSyllable, 0, x4 - x3);

			var stressedMax = stressedSyllable.Max();
			var unstressedMax = unstressedSyllable.Max();

			var c1 = stressedMax / unstressedMax;
			var c2 = unstressedMax / stressedMax;

			var rw = model.Rw(c1, c2, x1, x2, x3, x4, n);

			var newSound = model.MultModel(fileData, rw, n);

			inOut.WriteWavFile(FilePath + "Wav\\MyVoiceChanged", newSound, rate);

			chart1.AddDataSeries(fileData);
			chart2.AddDataSeries(newSound);
		}
	}
}
