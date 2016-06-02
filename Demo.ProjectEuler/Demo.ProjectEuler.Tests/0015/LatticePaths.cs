using System.Numerics;

namespace Demo.ProjectEuler.Tests._0015
{
	internal class LatticePaths
	{
		/// <summary>
		/// Combinations of walking lattice paths
		/// </summary>
		/// <remarks>
		/// http://math.stackexchange.com/a/636133
		/// </remarks>
		public BigInteger GetLatticePaths(int size)
		{
			int topValue = size * 2;
			int bottomValue = size;

			// Get factorial until size is reached.
			BigInteger result = 1;
			for (int i = topValue; i > size; i--)
			{
				result *= i;
			}

			var bottomFactorial = GetFactorial(bottomValue);
			result /= bottomFactorial;

			return result;
		}

		private BigInteger GetFactorial(int value)
		{
			BigInteger result = 1;
			for (int i = value; i > 1; i--)
			{
				result *= i;
			}

			return result;
		}
	}
}