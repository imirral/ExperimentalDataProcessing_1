using System;

namespace ExperimentalDataProcessing.Extensions
{
	public static class DoubleArrayExtensions
	{
		public static double Min(this double[] data)
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

			double min = 0;

			for (var i = 1; i < length; i++)
			{
				if (data[i] < min)
				{
					min = data[i];
				}
			}

			return Math.Round(min, 3);
		}

		public static double Max(this double[] data)
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

			double max = 0;

			for (var i = 1; i < length; i++)
			{
				if (data[i] > max)
				{
					max = data[i];
				}
			}

			return max;
		}

		public static double Average(this double[] data)
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

			double sum = 0;

			for (var i = 0; i < length; i++)
			{
				sum += data[i];
			}

			return sum / length;
		}

		public static double Average(this double[] data, int start, int end)
		{
			if (data == null)
			{
				throw new Exception("Массив имеет значение null");
			}

			if (data.Length == 0)
			{
				throw new Exception("Массив не содержит элементов");
			}

			var length = end - start;

			double sum = 0;

			for (var i = start; i < end; i++)
			{
				sum += data[i];
			}

			return sum / length;
		}

		public static double Dispersion(this double[] data)
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

			double sum = 0;

			var average = data.Average();

			for (var i = 0; i < length; i++)
			{
				sum += Math.Pow(data[i] - average, 2);
			}

			return sum / length;
		}

		public static double StandardDeviation(this double[] data)
		{
			if (data == null)
			{
				throw new Exception("Массив имеет значение null");
			}

			if (data.Length == 0)
			{
				throw new Exception("Массив не содержит элементов");
			}

			return Math.Sqrt(data.Dispersion());
		}

		public static double StandardDeviation(this double[] data, int start, int end)
		{
			if (data == null)
			{
				throw new Exception("Массив имеет значение null");
			}

			if (data.Length == 0)
			{
				throw new Exception("Массив не содержит элементов");
			}

			var length = end - start;

			double sum = 0;

			var mean = data.Average(start, end);

			for (var i = start; i < end; i++)
			{
				sum += Math.Pow(data[i] - mean, 2);
			}

			var variance = sum / length;

			return Math.Sqrt(variance);
		}

		public static double Asymmetry(this double[] data)
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

			double sum = 0;

			var average = data.Average();

			for (var i = 0; i < length; i++)
			{
				sum += Math.Pow(data[i] - average, 3);
			}

			return sum / length;
		}

		public static double AsymmetryCoefficient(this double[] data)
		{
			if (data == null)
			{
				throw new Exception("Массив имеет значение null");
			}

			if (data.Length == 0)
			{
				throw new Exception("Массив не содержит элементов");
			}

			var asymmetry = data.Asymmetry();

			var standardDeviation = data.StandardDeviation();

			return asymmetry / Math.Pow(standardDeviation, 3);
		}

		public static double Excess(this double[] data)
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

			double sum = 0;

			var average = data.Average();

			for (var i = 0; i < length; i++)
			{
				sum += Math.Pow(data[i] - average, 4);
			}

			return sum / length;
		}

		// Куртозис

		public static double ExcessCoefficient(this double[] data)
		{
			if (data == null)
			{
				throw new Exception("Массив имеет значение null");
			}

			if (data.Length == 0)
			{
				throw new Exception("Массив не содержит элементов");
			}

			var excess = data.Excess();

			var standardDeviation = data.StandardDeviation();

			return excess / Math.Pow(standardDeviation, 3) - 3;
		}

		// Средний квадрат (СК)

		public static double MiddleSquare(this double[] data)
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

			double sum = 0;

			for (var i = 0; i < length; i++)
			{
				sum += Math.Pow(data[i], 2);
			}

			return sum / length;
		}

		// Среднеквадратическая ошибка (СО)

		public static double RootMeanSquareDeviation(this double[] data)
		{
			if (data == null)
			{
				throw new Exception("Массив имеет значение null");
			}

			if (data.Length == 0)
			{
				throw new Exception("Массив не содержит элементов");
			}

			return Math.Sqrt(data.MiddleSquare());
		}
	}
}
