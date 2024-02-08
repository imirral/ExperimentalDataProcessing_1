using System;
using System.Drawing;
using System.Windows.Forms;
using ExperimentalDataProcessing.Classes;

namespace ExperimentalDataProcessing.Labs._2_semester
{
	public partial class Lab1_1Form : Form
	{
		public Lab1_1Form()
		{
			InitializeComponent();
		}

		#region Constants

		private const string FilePath = "D:\\Magistracy\\1.2\\Методы обработки экспериментальных данных\\ExperimentalDataProcessing\\ExperimentalDataProcessing\\Data\\";

		#endregion

		private void Lab1_1Form_Load(object sender, EventArgs e)
		{
			var inOut = new InOut();
			var model = new Model();

			var img = inOut.ReadJpg(FilePath + "Jpg\\Grace\\Grace.jpg", out var width, out var height);

			textBox1.Text = $@"{width}";
			textBox2.Text = $@"{height}";

			pictureBox1.Image = Image.FromFile(FilePath + "Jpg\\Grace\\Grace.jpg");

			var imgShift = model.Shift2D(img, 30);
			inOut.WriteJpg(FilePath + "Jpg\\Grace\\GraceShift.jpg", imgShift);

			pictureBox2.Image = Image.FromFile(FilePath + "Jpg\\Grace\\GraceShift.jpg");

			var imgMult = model.MultModel2D(img, 1.3);
			inOut.WriteJpg(FilePath + "Jpg\\Grace\\GraceMult.jpg", imgMult);

			pictureBox3.Image = Image.FromFile(FilePath + "Jpg\\Grace\\GraceMult.jpg");
		}
	}
}
