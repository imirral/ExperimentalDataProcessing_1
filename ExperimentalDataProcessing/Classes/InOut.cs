using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using NAudio.Wave;

namespace ExperimentalDataProcessing.Classes
{
	public class InOut
	{
		public double[] ReadDatFile(string filePath, int n)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				throw new Exception("Путь к файлу равен null или пуст");
			}

			if (n == 0)
			{
				throw new Exception("Количество элементов равно 0");
			}

			using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
			{
				var result = new double[n];

				var buffer = new byte[4];

				for (var i = 0; i < n; i++)
				{
					var bytesRead = fileStream.Read(buffer, 0, buffer.Length);

					if (bytesRead == 0)
					{
						break;
					}

					var floatValue = BitConverter.ToSingle(buffer, 0);

					result[i] = floatValue;
				}

				return result;
			}
		}

		public double[] ReadWavFile(string filePath, out double rate, out int n)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				throw new Exception("Путь к файлу равен null или пуст");
			}

			using (var reader = new WaveFileReader(filePath))
			{
				rate = reader.WaveFormat.SampleRate;

				n = (int)reader.SampleCount;

				if (n == 0)
				{
					throw new Exception("Количество элементов равно 0");
				}

				var result = new double[n];

				for (var i = 0; i < n; i++)
				{
					result[i] = reader.ReadNextSampleFrame()[0];
				}

				return result.ToArray();
			}
		}

		public void WriteWavFile(string filePath, double[] data, double rate)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				throw new Exception("Путь к файлу равен null или пуст");
			}

			if (data == null)
			{
				throw new Exception("Массив имеет значение null");
			}

			if (data.Length == 0)
			{
				throw new Exception("Массив не содержит элементов");
			}

			using (var writer = new WaveFileWriter(filePath + ".wav", new WaveFormat((int)rate, 16, 1)))
			{
				var length = data.Length;

				var result = new byte[length * 2];

				for (var i = 0; i < length; i++)
				{
					var normalizedValue = (short)(data[i] * double.MaxValue);

					result[i * 2] = (byte)(normalizedValue & 0xff);

					result[i * 2 + 1] = (byte)(normalizedValue >> 8);
				}

				writer.Write(result, 0, length);
			}
		}

		public double[,] ReadJpg(string fileName, out int width, out int height)
		{
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException("Файл не существует", fileName);
			}

			using (var img = new Bitmap(fileName))
			{
				width = img.Width;
				height = img.Height;

				var result = new double[width, height];

				for (var i = 0; i < width; i++)
				{
					for (var j = 0; j < height; j++)
					{
						var pixelColor = img.GetPixel(i, j);

						double grayValue = pixelColor.GetBrightness() * 255;

						result[i, j] = grayValue;
					}
				}

				return result;
			}
		}

		public void WriteJpg(string filePath, double[,] data)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				throw new ArgumentException("Путь к файлу не указан");
			}

			var height = data.GetLength(0);
			var width = data.GetLength(1);

			var newImage = new Bitmap(height, width);

			for (var j = 0; j < height; j++)
			{
				for (var i = 0; i < width; i++)
				{
					var grayValue = (int)data[j, i];

					if (grayValue > 255)
					{
						grayValue = 255;
					}

					var newColor = Color.FromArgb(grayValue, grayValue, grayValue);

					newImage.SetPixel(j, i, newColor);
				}
			}

			newImage.Save(filePath, ImageFormat.Jpeg);
		}
	}
}
