using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab6_2Form : Form
	{
		public Lab6_2Form()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		private void btnPlot_Click(object sender, EventArgs e)
		{
			if (int.TryParse(txtN.Text, out var n))
			{
				Chart[] charts = { chart1, chart2 };

				foreach (var chart in charts)
				{
					chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
					chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();

					chart.Series.Clear();
				}

				var model = new Model();
				var analysis = new Analysis();

				var data = new double[n];

				if (radioButton1.Checked)
				{
					data = model.Noise(100, n);
				}

				if (radioButton2.Checked)
				{
					data = model.MyNoise(100, n);
				}

				if (radioButton3.Checked)
				{
					data = model.Harm(n, 100, 15, 0.001);
				}

				if (radioButton4.Checked)
				{
					var amplitudes = new double[]
					{
						100, 15, 20
					};

					var frequencies = new double[]
					{
						33, 5, 170
					};

					data = model.PolyHarm(n, amplitudes, frequencies, 0.001);
				}

				var autoCorrelation = analysis.AutoCorrelation(data);
				var covariance = analysis.Covariance(data);

				chart1.AddDataSeries(autoCorrelation);
				chart2.AddDataSeries(covariance);

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
