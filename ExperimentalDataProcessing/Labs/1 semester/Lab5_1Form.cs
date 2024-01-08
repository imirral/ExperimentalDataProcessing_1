using System;
using System.Windows.Forms;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab5_1Form : Form
	{
		public Lab5_1Form()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Constants

		private const int N = 1000;

		#endregion

		private void btnPlot_Click(object sender, EventArgs e)
		{
			if (double.TryParse(txtA0.Text, out var a0) &&
			    double.TryParse(txtf0.Text, out var f0) &&
			    double.TryParse(txtDt.Text, out var dt))
			{
				chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();
				chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();

				chart1.Series.Clear();

				var model = new Model();

				var data = new double[N];

				if (radioButton1.Checked)
				{
					data = model.Harm(N, a0, f0, dt);
				}

				if (radioButton2.Checked)
				{
					var amplitudes = new double[]
					{
						100, 15, 20
					};

					var frequencies = new double[]
					{
						33, 5, 170
					};

					data = model.PolyHarm(N, amplitudes, frequencies, dt);
				}

				chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
				chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();

				chart1.Series.Clear();

				chart1.AddDataSeries(data);

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
