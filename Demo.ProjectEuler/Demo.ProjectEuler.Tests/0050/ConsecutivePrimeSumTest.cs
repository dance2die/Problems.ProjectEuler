using System.Globalization;
using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0050
{
	/// <summary>
	/// Test Scenarios.
	/// </summary>
	public class ConsecutivePrimeSumTest : BaseTest
	{
		private readonly ConsecutivePrimeSum _sut = new ConsecutivePrimeSum();

		public ConsecutivePrimeSumTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		// 2 + 3 + 5 + 7 + 11 + 13
		[InlineData(100, 41)]
		// 7 + 11 + 13 + 17 + 19 + 23 + 29 + 31 + 37 + 41 + 43 + 47 + 53 + 59 + 61 + 67 + 71 + 73 + 79 + 83 + 89
		[InlineData(1000, 953)]
		public void TestSampleData(int upto, double expected)
		{
			double actual = _sut.GetLongestConsecutivePrimeSum(upto);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			const int upto = 1000000;
			double actual = _sut.GetLongestConsecutivePrimeSum(upto);

			_output.WriteLine(actual.ToString(CultureInfo.InvariantCulture));
			const int expected = 997651;
			Assert.Equal(expected, actual);
		}
	}

	public class ConsecutivePrimeSum
	{
		private readonly ESieve _eSieve = new ESieve();
		private readonly Prime _prime = new Prime();

		public double GetLongestConsecutivePrimeSum(int upto)
		{
			var primes = _eSieve.GetPrimes(upto).ToList();
			var maxSequence = 0;
			double maxSequencePrime = 0;

			for (int i = 0; i < primes.Count - 1; i++)
			{
				for (int j = 2; j <= primes.Count; j++)
				{
					var range = primes.Skip(i).Take(j).ToList();
					double sum = range.Aggregate(0, (a, b) => a + b);
					if (sum > upto) break;

					if (maxSequence < range.Count &&
						_prime.IsPrimeNumber(sum))
					{
						maxSequence = range.Count;
						maxSequencePrime = sum;
					}
				}
			}

			return maxSequencePrime;
		}
	}
}
