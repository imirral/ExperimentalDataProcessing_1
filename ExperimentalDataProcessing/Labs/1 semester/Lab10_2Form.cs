using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab10_2Form : Form
	{
		public Lab10_2Form()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Constants

		private const int N = 1000;

		private const int R = 30;

		#endregion

		private void btnPlot_Click(object sender, EventArgs e)
		{
			if (int.TryParse(txtM.Text, out var m))
			{
				Chart[] charts = { chart1, chart2 };

				foreach (var chart in charts)
				{
					chart.Series.Clear();
				}

				var model = new Model();
				var processing = new Processing();

				var data = new double[m][];

				if (radioButton1.Checked)
				{
					for (var i = 0; i < m; i++)
					{
						data[i] = model.Noise(R, N);
					}
				}

				if (radioButton2.Checked)
				{
					for (var i = 0; i < m; i++)
					{
						var data1 = model.Noise(R, N);
						var data2 = model.Harm(N, 10, 5, 0.001);

						data[i] = model.AddModel(data1, data2, 1);
					}
				}

				var antiNoiseData = processing.AntiNoise(data, out var dev);

				chart1.AddDataSeries(antiNoiseData);

				textBox1.Text = $@"{dev}";

				foreach (var chart in charts)
				{
					chart.Update();
				}
			}
			else
			{
				MessageBox.Show(@"Введено некорректное значение параметра");
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			chart2.ChartAreas[0].AxisY.ScaleView.ZoomReset();
			chart2.ChartAreas[0].AxisX.ScaleView.ZoomReset();

			chart2.Series.Clear();

			var model = new Model();
			var processing = new Processing();

			int[] mArray = { 1, 10, 50, 100, 500, 1000, 5000, 10000 };

			var deviations = new double[mArray.Length];

			for (var i = 0; i < mArray.Length; i++)
			{
				var data = new double[mArray[i]][];

				for (var j = 0; j < mArray[i]; j++)
				{
					data[j] = model.Noise(R, N);
				}

				processing.AntiNoise(data, out var dev);

				deviations[i] = dev;
			}

			chart2.AddDataSeries(deviations);

			chart2.ChartAreas[0].RecalculateAxesScale();
			chart2.Update();
		}
	}
}
