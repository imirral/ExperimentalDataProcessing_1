using System;
using System.Linq;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Classes
{
	public class Analysis
	{
		public bool Stationarity(double[] data, int m)
		{
			if (data == null)
			{
				throw new Exception("Массив имеет значение null");
			}

			if (data.Length == 0)
			{
				throw new Exception("Массив не содержит элементов");
			}

			if (m <= 0)
			{
				throw new Exception("Количество интервалов меньше либо равно 0");
			}

			var length = data.Length / m;

			var averageValues = new double[m];
			var stdDeviations = new double[m];

			for (var i = 0; i < m; i++)
			{
				double sum = 0;

				for (var j = i * length; j < (i + 1) * length; j++)
				{
					sum += data[j];
				}

				averageValues[i] = sum / length;

				stdDeviations[i] = data.StandardDeviation(i * length, (i + 1) * length);
			}

			for (var i = 0; i < m; i++)
			{
				for (var j = i + 1; j < m; j++)
				{
					var averageChange = Math.Abs(averageValues[i] - averageValues[j]);

					var stdDeviationChange = Math.Abs(stdDeviations[i] - stdDeviations[j]);

					var noiseRange = Math.Abs(data.Max() - data.Min());

					var averageChangePercentage = averageChange / noiseRange * 100;

					var stdDeviationChangePercentage = stdDeviationChange / noiseRange * 100;

					if (averageChangePercentage >= 5 || stdDeviationChangePercentage >= 5)
					{
						return false;
					}
				}
			}

			return true;
		}

		public double[] Hist(double[] data, int m)
		{
			if (data == null)
			{
				throw new Exception("Массив имеет значение null");
			}

			if (data.Length == 0)
			{
				throw new Exception("Массив не содержит элементов");
			}

			if (m <= 0)
			{
				throw new Exception("Количество интервалов меньше либо равно 0");
			}

			var length = data.Length;

			var min = data.Min();
			var max = data.Max();

			var intervalWidth = (max - min) / m;

			var counts = new int[m];

			foreach (var value in data)
			{
				var intervalIndex = (int)((value - min) / intervalWidth);

				if (intervalIndex >= m)
				{
					intervalIndex = m - 1;
				}

				counts[intervalIndex]++;
			}

			var result = new double[m];

			for (var i = 0; i < m; i++)
			{
				result[i] = counts[i] / (length * intervalWidth);
			}

			return result;
		}

		public double[] AutoCorrelation(double[] data)
		{
			if (data == null)
			{
				throw new Exception("Массив имеет значение null");
			}

			if (data.Length == 0)
			{
				throw new Exception("Массив не содержит элементов");
			}

			var length = data.Length;

			var result = new double[length];

			var average = data.Average();

			var denominator = data.Sum(x => Math.Pow(x - average, 2));

			for (var i = 0; i < length - 1; i++)
			{
				double numerator = 0;

				for (var j = 0; j < length - i - 1; j++)
				{
					numerator += (data[j] - average) * (data[j + i] - average);
				}

				result[i] = numerator / denominator;
			}

			return result;
		}

		public double[] Covariance(double[] data)
		{
			if (data == null)
			{
				throw new Exception("Массив имеет значение null");
			}

			if (data.Length == 0)
			{
				throw new Exception("Массив не содержит элементов");
			}

			var length = data.Length;

			var result = new double[length];

			var average = data.Average();

			for (var i = 0; i < length - 1; i++)
			{
				double sum = 0;

				for (var j = 0; j < length - i - 1; j++)
				{
					sum += (data[j] - average) * (data[j + i] - average);
				}

				result[i] = sum / length;
			}

			return result;
		}

		public double[] CrossCorrelation(double[] data1, double[] data2)
		{
			if (data1 == null || data2 == null)
			{
				throw new Exception("Массив/ы имеет/ют значение null");
			}

			if (data1.Length == 0 || data2.Length == 0)
			{
				throw new Exception("Массив/ы не содержит/ат элементов");
			}

			if (data1.Length != data2.Length)
			{
				throw new Exception("Количество элементов в массивах не совпадает");
			}

			var length = data1.Length;

			var result = new double[length];

			var average1 = data1.Average();
			var average2 = data2.Average();

			for (var i = 0; i < length - 1; i++)
			{
				double sum = 0;

				for (var j = 0; j < length - i - 1; j++)
				{
					sum += (data1[j] - average1) * (data2[j + i] - average2);
				}

				result[i] = sum / length;
			}

			return result;
		}

		public double[] Fourier(double[] data)
		{
			if (data == null)
			{
				throw new Exception("Массив имеет значение null");
			}

			if (data.Length == 0)
			{
				throw new Exception("Массив не содержит элементов");
			}

			var length = data.Length;

			var result = new double[length];

			for (var i = 0; i < length; i++)
			{
				double re = 0;
				double im = 0;

				for (var j = 0; j < length; j++)
				{
					re += data[j] * Math.Cos(2 * Math.PI * i * j / length);
					im += data[j] * Math.Sin(2 * Math.PI * i * j / length);
				}

				re /= length;
				im /= length;

				result[i] = Math.Sqrt(Math.Pow(re, 2) + Math.Pow(im, 2));
			}

			return result;
		}

		public Tuple<double[], double[]> SpectrumFourier(double[] data, double dt)
		{
			if (data == null)
			{
				throw new Exception("Массив имеет значение null");
			}

			if (data.Length == 0)
			{
				throw new Exception("Массив не содержит элементов");
			}

			var length = data.Length;

			var df = 1.0 / (length * dt);

			var xValues = new double[length];
			var yValues = new double[length];

			for (var i = 0; i < length; i++)
			{
				xValues[i] = Math.Round(i * df, 2);
				yValues[i] = data[i] * df;
			}

			return new Tuple<double[], double[]>(xValues, yValues);
		}

		public double[] FrequencyResponse(double[] data)
		{
			if (data == null)
			{
				throw new Exception("Массив имеет значение null");
			}

			if (data.Length == 0)
			{
				throw new Exception("Массив не содержит элементов");
			}

			var length = data.Length;

			var result = new double[length];

			var fourier = Fourier(data);

			for (var i = 0; i < length; i++)
			{
				result[i] = fourier[i] * length;
			}

			return result;
		}
	}
}
