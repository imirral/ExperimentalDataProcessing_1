using System;
using ExperimentalDataProcessing.Extensions;

namespace ExperimentalDataProcessing.Classes
{
	public class Processing
	{
		// Подавление смещения путем нахождения среднего значения (центра
		// рассеивания) и вычитания его из всех значений данных data

		public double[] AntiShift(double[] data)
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

			var average = data.Average();

			var result = new double[length];

			Array.Copy(data, result, length);

			for (var i = 0; i < length; i++)
			{
				result[i] -= average;
			}

			return result;
		}

		// Подавление неправдоподобных значений за пределами задаваемого диапазона R
		// с использованием простейшего 3-х точечного фильтра линейной интерполяции

		public double[] AntiSpike(double[] data, double r)
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

			for (var i = 1; i < length - 1; i++)
			{
				if (result[i] >= r || result[i] <= -r)
				{
					result[i] = (result[i - 1] + result[i + 1]) / 2;
				}
			}

			return result;
		}

		// Подавление линейного тренда путем вычисления первой производной данных data

		public double[] AntiTrendLinear(double[] data)
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

			var result = new double[length - 1];

			for (var i = 0; i < length - 1; i++)
			{
				result[i] = data[i + 1] - data[i];
			}

			return result;
		}

		// Подавление нелинейного тренда методом скользящего среднего из данных data

		public double[] AntiTrendNonLinear(double[] data, int w)
		{
			if (data == null)
			{
				throw new Exception("Массив имеет значение null");
			}

			if (data.Length == 0)
			{
				throw new Exception("Массив не содержит элементов");
			}

			if (w <= 0)
			{
				throw new Exception("Длина окна меньше либо равна 0");
			}

			var length = data.Length;

			var result = new double[length - w];

			for (var i = 0; i < length - w; i++)
			{
				double x = 0;

				for (var k = i; k < i + w; k++)
				{
					x += data[k];
				}

				result[i] = x / w;
			}

			return result;
		}

		// Подавление случайного шума методом накопления -
		// путем поэлементного сложения и осреднения m реализаций случайного шума data

		public double[] AntiNoise(double[][] data, out double deviation)
		{
			if (data == null)
			{
				throw new Exception("Массив имеет значение null");
			}

			if (data.Length == 0 || data[0].Length == 0)
			{
				throw new Exception("Массив не содержит элементов");
			}

			var m = data.Length;
			var n = data[0].Length;

			var result = new double[n];

			for (var i = 0; i < n; i++)
			{
				double element = 0;

				for (var j = 0; j < m; j++)
				{
					element += data[j][i];
				}

				element /= m;

				result[i] = element;
			}

			deviation = result.StandardDeviation();

			return result;
		}

		//  Импульсная реакция (весовая функция) фильтра низких частот (ФНЧ)
		// со сглаживающим окном Поттера

		public double[] Lpf(double fc, double dt, int m)
		{
			if (fc <= 0)
			{
				throw new Exception("Частота среза меньше либо равна 0");
			}

			if (dt <= 0)
			{
				throw new Exception("Период дискретизации меньше либо равен 0");
			}

			if (m <= 0)
			{
				throw new Exception("Количество коэффициентов меньше либо равно 0");
			}

			double[] d = { 0.35577019, 0.2436983, 0.07211497, 0.00630165 };

			var fact = 2 * fc * dt;

			var result = new double[m + 1];

			var arg = fact * Math.PI;

			result[0] = fact;

			for (var i = 1; i < result.Length; i++)
			{
				result[i] = Math.Sin(arg * i) / (Math.PI * i);
			}

			result[m] /= 2;

			var sumg = result[0];

			for (var i = 1; i < result.Length; i++)
			{
				var sum = d[0];

				arg = Math.PI * i / m;

				for (var k = 1; k <= 3; k++)
				{
					sum += 2 * d[k] * Math.Cos(arg * k);
				}

				result[i] *= sum;

				sumg += 2 * result[i];
			}

			for (var i = 0; i < result.Length; i++)
			{
				result[i] /= sumg;
			}

			return result;
		}

		// Зеркальное отражение асимметричной весовой функции относительно нулевого веса

		public double[] ReflectLpf(double[] lpw)
		{
			if (lpw == null)
			{
				throw new Exception("Массив имеет значение null");
			}

			if (lpw.Length == 0)
			{
				throw new Exception("Массив не содержит элементов");
			}

			var length = lpw.Length;

			var result = new double[length * 2 - 1];

			var j = 0;

			for (var i = length - 1; i > 0; i--)
			{
				result[j++] = lpw[i];
			}

			for (var i = 0; i < length; i++)
			{
				result[j++] = lpw[i];
			}

			return result;
		}

		// Фильтр высоких частот (ФВЧ)

		public double[] Hpf(double fc, double dt, int m)
		{
			if (fc <= 0)
			{
				throw new Exception("Частота среза меньше либо равна 0");
			}

			if (dt <= 0)
			{
				throw new Exception("Период дискретизации меньше либо равен 0");
			}

			if (m <= 0)
			{
				throw new Exception("Количество коэффициентов меньше либо равно 0");
			}

			var lpw = ReflectLpf(Lpf(fc, dt, m));

			var result = new double[lpw.Length];

			for (var k = 0; k < 2 * m + 1; k++)
			{
				if (k == m)
				{
					result[k] = 1 - lpw[k];
				}
				else
				{
					result[k] = -lpw[k];
				}
			}

			return result;
		}

		// Полосовой фильтр (ПФ)

		public double[] Bpf(double fc1, double fc2, double dt, int m)
		{
			if (fc2 <= 0 || fc1 <= 0 || fc1 >= fc2)
			{
				throw new Exception("Неверный диапазон частот среза");
			}

			if (dt <= 0)
			{
				throw new Exception("Период дискретизации меньше либо равен 0");
			}

			if (m <= 0)
			{
				throw new Exception("Количество коэффициентов меньше либо равно 0");
			}

			var lpw1 = ReflectLpf(Lpf(fc1, dt, m));
			var lpw2 = ReflectLpf(Lpf(fc2, dt, m));

			var result = new double[lpw1.Length];

			for (var k = 0; k < 2 * m + 1; k++)
			{
				result[k] = lpw2[k] - lpw1[k];
			}

			return result;
		}

		// Режектроный фильтр (РФ)

		public double[] Bsf(double fc1, double fc2, double dt, int m)
		{
			if (fc2 <= 0)
			{
				throw new Exception("Частота среза меньше либо равна 0");
			}

			if (dt <= 0)
			{
				throw new Exception("Период дискретизации меньше либо равен 0");
			}

			if (m <= 0)
			{
				throw new Exception("Количество коэффициентов меньше либо равно 0");
			}

			var lpw1 = ReflectLpf(Lpf(fc1, dt, m));
			var lpw2 = ReflectLpf(Lpf(fc2, dt, m));

			var result = new double[lpw1.Length];

			for (var k = 0; k < 2 * m + 1; k++)
			{
				if (k == m)
				{
					result[k] = 1 + lpw1[k] - lpw2[k];
				}
				else
				{
					result[k] = lpw1[k] - lpw2[k];
				}
			}

			return result;
		}
	}
}
