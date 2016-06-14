using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0035
{
	public class CircularPrimesTest : BaseTest
	{
		private readonly CircularPrimes _sut = new CircularPrimes();

		public CircularPrimesTest(ITestOutputHelper output) : base(output)
		{
		}

		/// <remarks>
		/// Runs in 2 seconds
		/// </remarks>
		[Fact]
		public void TestGettingPrimesUnderOneMillion()
		{
			Prime prime = new Prime();
			List<int> primes = new List<int>();

			for (int i = 1; i <= 999999; i++)
			{
				if (prime.IsPrimeNumber(i))
					primes.Add(i);
			}

			_output.WriteLine(primes.Count.ToString());
		}

		[Theory]
		[InlineData(2, 2, true)]
		[InlineData(3, 3, true)]
		[InlineData(5, 5, true)]
		[InlineData(7, 7, true)]
		[InlineData(11, 11, true)]
		[InlineData(13, 31, true)]
		[InlineData(17, 71, true)]
		[InlineData(37, 73, true)]
		[InlineData(79, 97, true)]
		[InlineData(311, 113, true)]
		[InlineData(243, 342, true)]
		[InlineData(2, 12, false)]
		[InlineData(24, 48, false)]
		[InlineData(1234, 1253, false)]
		public void TestIsCircularPrime(int prime, int circularPrimeCandidate, bool expected)
		{
			var actual = _sut.IsCircularPrime(prime, circularPrimeCandidate);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestPrimesUnder100()
		{
			const int limit = 100;
			var actual = _sut.GetCircularPrimeCountUnder(limit);

			const int expected = 13;
			Assert.Equal(expected, actual);
		}
	}

	public class CircularPrimes
	{
		public int GetCircularPrimeCountUnder(int limit)
		{
			var primes = GetPrimesUnder(limit).ToList();
			//for (int i = 0; i < primes.Count; i++){}

			var distinctPrimes = new List<int>();
			foreach (int prime in primes.ToList())
			{
				if (prime < 10)
					distinctPrimes.Add(prime);
				else
				{
					var circularPrimes = GetCircularPrimes(prime, primes);
					primes.RemoveAll(p => circularPrimes.Contains(p) && p != prime);
				}
			}

			return primes.Count;
		}

		private IEnumerable<int> GetCircularPrimes(int prime, List<int> primes)
		{
			foreach (int circularPrimeCandidate in primes)
			{
				if (IsCircularPrime(prime, circularPrimeCandidate))
					yield return circularPrimeCandidate;
			}
		}

		public bool IsCircularPrime(int prime, int circularPrimeCandidate)
		{
			var circularPrimeCandidateText = circularPrimeCandidate.ToString();
			var primeText = prime.ToString();

			foreach (char c in circularPrimeCandidateText)
			{
				if (!primeText.Contains(c))
					return false;
			}

			return true;
		}

		private IEnumerable<int> GetPrimesUnder(int limit)
		{
			Prime prime = new Prime();
			for (int primeCandidate = 1; primeCandidate <= limit; primeCandidate++)
			{
				if (prime.IsPrimeNumber(primeCandidate))
					yield return primeCandidate;
			}
		}
	}
}
