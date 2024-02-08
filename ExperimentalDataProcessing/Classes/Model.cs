using ExperimentalDataProcessing.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExperimentalDataProcessing.Classes
{
	public class Model
	{
		#region Fields

		private static readonly Random Random = new Random();

		private readonly RandomDoubleGenerator _generator = new RandomDoubleGenerator(1);

		#endregion

		#region Methods

		public double[] TrendLinear(double a, double b, double dt, int n)
		{
			if (n == 0)
			{
				throw new Exception("Количество элементов равно 0");
			}

			var result = new double[n];

			for (var i = 0; i < n; i++)
			{
				var k = i * dt;

				result[i] = -a * k + b;
			}

			return result;
		}

		public double[] TrendNonLinear(double a, double b, double dt, int n)
		{
			if (n == 0)
			{
				throw new Exception("Количество элементов равно 0");
			}

			var result = new double[n];

			for (var i = 0; i < n; i++)
			{
				var k = i * dt;

				result[i] = b * Math.Exp(-a * k);
			}

			return result;
		}

		public double[] Noise(double r, int n)
		{
			if (n == 0)
			{
				throw new Exception("Количество элементов равно 0");
			}

			var result = new double[n];

			for (var i = 0; i < n; i++)
			{
				result[i] = Random.NextDouble(-r, r);
			}

			var min = result.Min();
			var max = result.Max();

			for (var i = 0; i < n; i++)
			{
				result[i] = ((result[i] - min) / (max - min) - 0.5) * 2 * r;
			}

			return result;
		}

		public double[] MyNoise(double r, int n)
		{
			if (n == 0)
			{
				throw new Exception("Количество элементов равно 0");
			}

			var result = new double[n];

			for (var i = 0; i < n; i++)
			{
				result[i] = _generator.GetRandomDouble(-r, r);
			}

			return result;
		}

		public double[] Shift(double[] data, double c, int start, int end)
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
				if (i >= start && i <= end)
				{
					result[i] += c;
				}
			}

			return result;
		}

		public double[,] Shift2D(double[,] data, double c)
		{
			if (data == null)
			{
				throw new Exception("Массив имеет значение null");
			}

			if (data.GetLength(0) == 0 || data.GetLength(1) == 0)
			{
				throw new Exception("Массив не содержит элементов");
			}

			var height = data.GetLength(0);
			var width = data.GetLength(1);

			var result = new double[height, width];

			Array.Copy(data, result, data.Length);

			for (var i = 0; i < height; i++)
			{
				for (var j = 0; j < width; j++)
				{
					result[i, j] += c;
				}
			}

			return result;
		}

		public double[,] MultModel2D(double[,] data, double c)
		{
			if (data == null)
			{
				throw new Exception("Массив имеет значение null");
			}

			if (data.GetLength(0) == 0 || data.GetLength(1) == 0)
			{
				throw new Exception("Массив не содержит элементов");
			}

			var height = data.GetLength(0);
			var width = data.GetLength(1);

			var result = new double[height, width];

			Array.Copy(data, result, data.Length);

			for (var i = 0; i < height; i++)
			{
				for (var j = 0; j < width; j++)
				{
					result[i, j] *= c;
				}
			}

			return result;
		}

		public double[] Spikes(double[] data, double m, double r, double rs, bool isSigned = true)
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

			Array.Copy(data, result, length);

			var numSpikes = (int)(length * m / 100.0);

			for (var i = 0; i < numSpikes; i++)
			{
				var index = Random.Next(length);

				var sign = 1;

				if (isSigned)
				{
					sign = Random.NextDouble() < 0.5 ? -1 : 1;
				}

				var amplitude = (r + rs * Random.NextDouble()) * sign;

				result[index] = amplitude;
			}

			return result;
		}

		public double[] Harm(int n, double a, double f, double dt)
		{
			if (n == 0)
			{
				throw new Exception("Количество элементов равно 0");
			}

			var result = new double[n];

			for (var i = 0; i < n; i++)
			{
				result[i] = a * Math.Sin(2 * Math.PI * f * dt * i);
			}

			return result;
		}

		public double[] PolyHarm(int n, double[] a, double[] f, double dt)
		{
			if (a == null || f == null)
			{
				throw new Exception("Массив/ы имеет/ют значение null");
			}

			if (a.Length == 0 || f.Length == 0)
			{
				throw new Exception("Массив/ы не содержит/ат элементов");
			}

			if (n == 0)
			{
				throw new Exception("Количество элементов равно 0");
			}

			var result = new double[n];

			for (var i = 0; i < n; i++)
			{
				double xk = 0;

				for (var j = 0; j < a.Length; j++)
				{
					xk += a[j] * Math.Sin(2 * Math.PI * f[j] * dt * i);
				}

				result[i] = xk;
			}

			return result;
		}

		public double[] AddModel(double[] data1, double[] data2, double dt)
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

			for (var i = 0; i < length; i++)
			{
				result[i] = (data1[i] + data2[i]) * dt;
			}

			return result;
		}

		public double[] MultModel(double[] data1, double[] data2, double dt)
		{
			if (data1 == null || data2 == null)
			{
				throw new Exception("Массив/ы имеет/ют значение null");
			}

			if (data1.Length == 0 || data2.Length == 0)
			{
				throw new Exception("Массив/ы не содержит/ат элементов");
			}

			var length = data1.Length;

			var result = new double[length];

			for (var i = 0; i < length; i++)
			{
				result[i] = data1[i] * data2[i] * dt;
			}

			return result;
		}

		public double[] ConvolutionModel(double[] x, double[] h, int m)
		{
			if (x == null || h == null)
			{
				throw new Exception("Массив/ы имеет/ют значение null");
			}

			if (x.Length == 0 || h.Length == 0)
			{
				throw new Exception("Массив/ы не содержит/ат элементов");
			}

			var length = x.Length;

			var data = new double[length + m];

			for (var i = 0; i < length; i++)
			{
				for (var j = 0; j < m; j++)
				{
					data[i + j] += x[i] * h[j];
				}
			}

			var result = new double[length];

			for (var i = 0; i < length; i++)
			{
				result[i] = data[i + m / 2];
			}

			return result;
		}

		public Tuple<double, double> Doppler(double f, double vo, double vs, double v = 343)
		{
			if (v - vs == 0 || v - vo == 0)
			{
				throw new Exception("Разность скоростей равна 0");
			}

			var fo = f * (v + vo) / (v - vs);
			var fs = f * (v + vs) / (v - vo);

			return new Tuple<double, double>(fo, fs);
		}

		public double[] Rw(double c1, double c2, int n1, int n2, int n3, int n4, int n)
		{
			var pw = new List<double>(new double[n1]);

			pw.AddRange(Enumerable.Repeat(1.0, n1));
			pw.AddRange(Enumerable.Repeat(c1, n2 - n1 + 1));
			pw.AddRange(Enumerable.Repeat(1.0, n3 - n2 - 1));
			pw.AddRange(Enumerable.Repeat(c2, n4 - n3 + 1));
			pw.AddRange(Enumerable.Repeat(1.0, n - n4 - 1));

			return pw.ToArray();
		}

		#endregion
	}
}
