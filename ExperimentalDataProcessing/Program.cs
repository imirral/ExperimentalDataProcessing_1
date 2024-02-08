using System;
using System.Windows.Forms;
using ExperimentalDataProcessing.Labs._2_semester;

namespace ExperimentalDataProcessing
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();

			Application.SetCompatibleTextRenderingDefault(false);

			Application.Run(new Lab1_1Form());
		}
	}
}
