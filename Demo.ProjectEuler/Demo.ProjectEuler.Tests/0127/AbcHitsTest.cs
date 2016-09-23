using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0127
{
	public class AbcHitsTest : BaseTest
	{
		private const int PRIME_COUNT_UPTO = 120000;
		private readonly AbcHits _sut = new AbcHits(PRIME_COUNT_UPTO);

		public AbcHitsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestForRadValue()
		{
			const int n = 504;
			long actual = _sut.GetRad(n);

			const int expected = 42;
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestAbcHit()
		{
			int a = 5, b = 27, c = 32;

			const bool expected = true;
			bool actual = _sut.IsAbcHit(a, b, c);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestCNumberPairCount()
		{
			// given on ProjectEuler.net
			const int c = 12523;
			var cNumberPairs = _sut.GenerateCNumberPairs(c).ToList();
			int actual = cNumberPairs.Count;

			const int expected = 6261;
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestAbcHitCount()
		{
			const int c = 12523;
			int actual = _sut.GetAbcHitCountFor(c);

			const int expected = 31;
			Assert.Equal(expected, actual);
		}
	}

	public class AbcHits
	{
		private readonly Prime _prime = new Prime();
		private readonly Totient _totient = new	Totient();
		private readonly int _primeCount;
		private IEnumerable<int> _primes;

		private IEnumerable<int> Primes => _primes ?? (_primes = new ESieve().GetPrimes(_primeCount));

		public AbcHits(int primeCount)
		{
			_primeCount = primeCount;
		}

		public int GetAbcHitCountFor(int c)
		{
			int counter = 0;
			foreach (Tuple<int, int> pair in GenerateCNumberPairs(c))
			{
				int a = pair.Item1;
				int b = pair.Item2;

				if (IsAbcHit(a, b, c))
					counter++;
			}

			return counter;
		}

		public IEnumerable<Tuple<int, int>> GenerateCNumberPairs(int c)
		{
			int j = c - 1;
			for (int i = 1; i < c; i++)
			{
				if (i >= j) yield break;

				yield return Tuple.Create(i, j);
				j--;
			}
		}

		public bool IsAbcHit(int a, int b, int c)
		{
			bool aLessThanB = a < b;
			if (!aLessThanB) return false;

			bool cValue = a + b == c;
			if (!cValue) return false;

			bool gcdEqual = AreGcdEqual(a, b, c);
			if (!gcdEqual) return false;

			// Most time consuming. Moved to the last.
			bool rad = IsRadLessThanC((double)a * b * c, c);
			if (!rad) return false;

			return true;
		}

		private bool IsRadLessThanC(double product, int c)
		{
			long rad = GetRad(product);
			return rad < c;
		}

		private bool AreGcdEqual(int a, int b, int c)
		{
			var gcd1 = _totient.GreatestCommonDivisor(a, b);
			var gcd2 = _totient.GreatestCommonDivisor(a, c);
			var gcd3 = _totient.GreatestCommonDivisor(b, c);

			return (gcd1 == gcd2 && gcd2 == gcd3);
		}

		public long GetRad(double n)
		{
			var distinctPrimeFactors = _prime.GetPrimeFactors(n, Primes).Distinct();
			var result = (long) distinctPrimeFactors.Aggregate((accu, val) => accu * val);

			return result;
		}
	}
}
