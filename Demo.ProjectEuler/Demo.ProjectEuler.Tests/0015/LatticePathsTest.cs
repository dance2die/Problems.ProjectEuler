using System.Numerics;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0015
{
	public class LatticePathsTest : BaseTest
	{
		private readonly LatticePaths _sut = new LatticePaths();

		public LatticePathsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(2, 6)]
		[InlineData(3, 20)]
		public void TestCombinations(int size, ulong expected)
		{
			BigInteger actual = _sut.GetLatticePaths(size);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			const int input = 20;
			BigInteger result = _sut.GetLatticePaths(input);

			_output.WriteLine(result.ToString());
		}
	}

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
