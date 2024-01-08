using System;
using System.Windows.Forms;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab6_3Form : Form
	{
		public Lab6_3Form()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Constants

		private const int N = 100000;

		#endregion

		private void btnPlot_Click(object sender, EventArgs e)
		{
			chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();
			chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();

			chart1.Series.Clear();

			var model = new Model();
			var analysis = new Analysis();

			var data = new double[N];

			if (radioButton1.Checked)
			{
				data = model.Noise(100, N);
			}

			if (radioButton2.Checked)
			{
				data = model.MyNoise(100, N);
			}

			if (radioButton3.Checked)
			{
				data = model.Harm(N, 100, 15, 0.001);
			}

			var crossCorrelation = analysis.CrossCorrelation(data, data);

			chart1.AddDataSeries(crossCorrelation);

			chart1.ChartAreas[0].RecalculateAxesScale();
			chart1.Update();
		}
	}
}
