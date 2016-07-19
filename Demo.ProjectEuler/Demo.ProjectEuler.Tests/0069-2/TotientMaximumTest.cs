using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0069
{
	public class TotientMaximumTest : BaseTest
	{
		private readonly TotientMaximum _sut = new TotientMaximum();

		public TotientMaximumTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(2, new[] {1})]
		[InlineData(3, new[] {1, 2})]
		[InlineData(4, new[] {1, 3})]
		[InlineData(5, new[] {1, 2, 3, 4})]
		[InlineData(6, new[] {1, 5})]
		[InlineData(7, new[] {1, 2, 3, 4, 5, 6})]
		[InlineData(8, new[] {1, 3, 5, 7})]
		[InlineData(9, new[] {1, 2, 4, 5, 7, 8})]
		[InlineData(10, new[] {1, 3, 7, 9})]
		public void TestRelativePrimeGenerations(int n, int[] expected)
		{
			var actual = _sut.GetRelativePrimes(n).ToList();

			Assert.True(expected.SequenceEqual(actual));
		}

		[Theory]
		[InlineData(2, 1)]
		[InlineData(3, 1.5)]
		[InlineData(4, 2)]
		[InlineData(5, 1.25)]
		[InlineData(6, 3)]
		[InlineData(7, 1.16666)]
		[InlineData(8, 2)]
		[InlineData(9, 1.5)]
		[InlineData(10, 2.5)]
		public void TestGeneratingTotientDivision(int n, double expected)
		{
			double actual = _sut.GetTotientDivision(n);

			const double precision = 0.00001;
			Assert.True(expected - actual < precision);
		}

		[Theory]
		[InlineData(2, 1)]
		[InlineData(3, 2)]
		[InlineData(4, 2)]
		[InlineData(5, 4)]
		[InlineData(6, 2)]
		[InlineData(7, 6)]
		[InlineData(8, 4)]
		[InlineData(9, 6)]
		[InlineData(10, 4)]
		public void TestRelativePrimeCount(int n, int expected)
		{
			int actual = _sut.GetRelativePrimeCount(n);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestGeneratingTotientDivisionsForSampleData()
		{
			const int upto = 10000;

			double actual = 0;
			Prime prime = new Prime();
			var numbers = Enumerable.Range(1, upto).Where(number => !prime.IsPrimeNumber(number));
			foreach (int number in numbers)
			{
				double value = _sut.GetTotientDivision(number);
				if (value > actual)
					actual = number;
			}

			//for (int n = 1; n <= upto; n++)
			//{
			//	double value = _sut.GetTotientDivision(n);
			//	if (value > actual)
			//		actual = n;
			//}

			_output.WriteLine("Result: {0}", actual);

			const int expected = 210;
			Assert.Equal(expected, actual);
		}
	}

	public class TotientMaximum
	{
		public double GetTotientDivision(int n)
		{
			//var relativePrimes = GetRelativePrimes(n).ToList();
			//return (double) n / relativePrimes.Count;

			return (double) n/GetRelativePrimeCount(n);
		}

		public int GetRelativePrimeCount(int n)
		{
			int result = 1;

			for (int i = 2; i < n; i++)
			{
				if (GreatestCommonDivisor(n, i) == 1)
					result++;
			}

			return result;
		}

		public IEnumerable<int> GetRelativePrimes(int n)
		{
			yield return 1;	// everything is divisible by 1.

			for (int i = 2; i < n; i++)
			{
				if (GreatestCommonDivisor(n, i) == 1)
					yield return i;
			}
		}

		/// <summary>
		/// <see cref="https://en.wikipedia.org/wiki/Euclidean_algorithm"/>
		/// </summary>
		private int GreatestCommonDivisor(int a, int b)
		{
			while (b != 0)
			{
				var temp = a;
				a = b;
				b = temp % b;
			}

			return a;
		}
	}
}
