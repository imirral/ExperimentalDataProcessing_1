using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab10_1Form : Form
	{
		public Lab10_1Form()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Constants

		private const int N = 1000;

		#endregion

		private void btnPlot_Click(object sender, EventArgs e)
		{
			if (int.TryParse(txtW.Text, out var w) && w != 0)
			{
				Chart[] charts = { chart1, chart2 };

				foreach (var chart in charts)
				{
					chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
					chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();

					chart.Series.Clear();
				}

				var model = new Model();
				var processing = new Processing();

				double[] data1;
				double[] data2;
				double[] data;

				if (radioButton1.Checked)
				{
					data1 = model.TrendLinear(-0.3, -20, 1, N);
					data2 = model.Harm(N, 10, 5, 0.001);

					data = model.AddModel(data1, data2, 1);

					var antiTrendData = processing.AntiTrendLinear(data);

					chart1.AddDataSeries(data);
					chart2.AddDataSeries(antiTrendData);
				}

				if (radioButton2.Checked)
				{
					data1 = model.TrendNonLinear(0.002, 101, 1, N);

					var amplitudes = new double[]
					{
						100, 15, 20
					};

					var frequencies = new double[]
					{
						33, 5, 170
					};

					data2 = model.PolyHarm(N, amplitudes, frequencies, 0.001);

					data = model.AddModel(data1, data2, 1);

					var antiTrendData = processing.AntiTrendNonLinear(data, w);

					chart1.AddDataSeries(data);
					chart2.AddDataSeries(antiTrendData);
				}

				foreach (var chart in charts)
				{
					chart.ChartAreas[0].RecalculateAxesScale();
					chart.Update();
				}
			}
			else
			{
				MessageBox.Show(@"Введено некорректное значение параметра");
			}
		}
	}
}
