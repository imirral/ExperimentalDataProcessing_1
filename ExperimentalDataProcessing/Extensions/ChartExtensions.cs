using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace ExperimentalDataProcessing.Extensions
{
	public static class ChartExtensions
	{
		public static void AddDataSeries(this Chart chart, double[] yValues)
		{
			if (yValues == null)
			{
				throw new Exception("Массив имеет значение null");
			}

			if (yValues.Length == 0)
			{
				throw new Exception("Массив не содержит элементов");
			}

			var series = new Series
			{
				ChartType = SeriesChartType.Line,
			};

			for (var i = 0; i < yValues.Length; i++)
			{
				series.Points.AddXY(i, yValues[i]);
			}

			chart.Series.Add(series);
		}

		public static void AddDataSeries(this Chart chart, double[] xValues, double[] yValues)
		{
			if (xValues == null || yValues == null)
			{
				throw new Exception("Массив/ы имеет/ют значение null");
			}

			if (xValues.Length == 0 || yValues.Length == 0)
			{
				throw new Exception("Массив/ы не содержит/ат элементов");
			}

			if (xValues.Length != yValues.Length)
			{
				throw new Exception("Количество элементов в массивах не совпадает");
			}

			var series = new Series
			{
				ChartType = SeriesChartType.Line,
			};

			for (var i = 0; i < xValues.Length; i++)
			{
				series.Points.AddXY(Math.Round(xValues[i]), yValues[i]);
			}

			chart.Series.Add(series);
		}

		public static void AddDataSeries(this Chart chart, double[] xValues, double[] yValues, int length)
		{
			if (xValues == null || yValues == null)
			{
				throw new Exception("Массив/ы имеет/ют значение null");
			}

			if (xValues.Length == 0 || yValues.Length == 0)
			{
				throw new Exception("Массив/ы не содержит/ат элементов");
			}

			if (length == 0)
			{
				throw new Exception("Количество элементов результирующей серии данных равно 0");
			}

			var series = new Series
			{
				ChartType = SeriesChartType.Line,
			};

			for (var i = 0; i < length; i++)
			{
				series.Points.AddXY(Math.Round(xValues[i]), yValues[i]);
			}

			chart.Series.Add(series);
		}
	}
}
