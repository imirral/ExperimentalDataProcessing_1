namespace ExperimentalDataProcessing.Classes
{
	public class RandomDoubleGenerator
	{
		#region Fields

		private ulong _seed;

		private const ulong A = 6364136223846793005;

		private const ulong C = 1442695040888963407;

		private const ulong M = 9223372036854775808;


		#endregion

		#region Methods

		public RandomDoubleGenerator(ulong seed)
		{
			_seed = seed;
		}

		public double GetRandomDouble()
		{
			_seed = (A * _seed + C) % M;

			return (double)_seed / M;
		}

		public double GetRandomDouble(double minValue, double maxValue)
		{
			var randomValue = GetRandomDouble();

			return minValue + randomValue * (maxValue - minValue);
		}

		#endregion
	}
}
