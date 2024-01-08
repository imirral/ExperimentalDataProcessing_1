using System;
using System.Windows.Forms;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab3_2Form : Form
	{
		public Lab3_2Form()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Constants

		private const int N = 1000;

		#endregion

		private void btnPlot_Click(object sender, EventArgs e)
		{
			if (double.TryParse(txtM.Text, out var m) &&
			    double.TryParse(txtR.Text, out var r) &&
			    double.TryParse(txtRs.Text, out var rs))
			{
				chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();
				chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();

				chart1.Series.Clear();

				var model = new Model();

				var data = new double[N];

				var spikes = model.Spikes(data, m, r, rs);

				chart1.AddDataSeries(spikes);

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
