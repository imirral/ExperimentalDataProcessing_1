using System;
using System.Windows.Forms;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab4_2Form : Form
	{
		public Lab4_2Form()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Constants

		private const int N = 100000;

		private const int M = 50;

		#endregion

		private void btnPlot_Click(object sender, EventArgs e)
		{
			if (double.TryParse(txtR.Text, out var r))
			{
				chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();
				chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();

				chart1.Series.Clear();

				var model = new Model();
				var analysis = new Analysis();

				var data = new double[N];

				if (radioButton1.Checked)
				{
					data = model.Noise(r, N);
				}

				if (radioButton2.Checked)
				{
					data = model.MyNoise(r, N);
				}

				chart1.AddDataSeries(data);

				textBox1.Text = $@"{analysis.Stationarity(data, M)}";
				
				chart1.ChartAreas[0].RecalculateAxesScale();
				chart1.Update();
			}
			else
			{
				MessageBox.Show(@"Введено некорректное значение параметра");
			}
		}
	}
}
