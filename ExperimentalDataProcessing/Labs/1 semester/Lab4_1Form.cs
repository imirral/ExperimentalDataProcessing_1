using System;
using System.Windows.Forms;
using ExperimentalDataProcessing.Classes;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Labs._1_semester
{
	public partial class Lab4_1Form : Form
	{
		public Lab4_1Form()
		{
			InitializeComponent();
			AcceptButton = btnPlot;
		}

		#region Constants

		private const int N = 1000;

		#endregion

		private void btnPlot_Click(object sender, EventArgs e)
		{
			var model = new Model();

			var data = new double[N];

			if (radioButton1.Checked)
			{
				data = model.TrendLinear(-0.01, -0.01, 1, N);
			}

			if (radioButton2.Checked)
			{
				data = model.TrendLinear( 0.01, 0.01, 1, N);
			}

			if (radioButton3.Checked)
			{
				data = model.TrendNonLinear(-0.01, 0.01, 1, N);
			}

			if (radioButton4.Checked)
			{
				data = model.TrendNonLinear( 0.01, 0.01, 1, N);
			}

			if (radioButton5.Checked)
			{
				data = model.Noise(100, N);
			}

			textBox1.Text = $@"{data.Min()}";
			textBox2.Text = $@"{data.Max()}";
			textBox3.Text = $@"{data.Average()}";
			textBox4.Text = $@"{data.Dispersion()}";
			textBox5.Text = $@"{data.StandardDeviation()}";
			textBox6.Text = $@"{data.Asymmetry()}";
			textBox7.Text = $@"{data.AsymmetryCoefficient()}";
			textBox8.Text = $@"{data.Excess()}";
			textBox9.Text = $@"{data.ExcessCoefficient()}";
			textBox10.Text = $@"{data.MiddleSquare()}";
			textBox11.Text = $@"{data.RootMeanSquareDeviation()}";
		}
	}
}
