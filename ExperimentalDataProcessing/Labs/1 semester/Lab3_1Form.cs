using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab3_1Form : Form
	{
		public Lab3_1Form()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Constants

		private const int N = 1000;

		#endregion

		private void btnPlot_Click(object sender, EventArgs e)
		{
			if (int.TryParse(txtN1.Text, out var n1) &&
			    int.TryParse(txtN2.Text, out var n2) &&
			    double.TryParse(txtC.Text, out var c))
			{
				chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();
				chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();

				chart1.Series.Clear();

				var model = new Model();

				var data = new double[N];

				var shift = model.Shift(data, c, n1, n2);

				chart1.AddDataSeries(shift);

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
