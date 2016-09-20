using System;
using System.Collections.Generic;
using System.Linq;
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
		private readonly AbcHits _sut = new AbcHits();

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
	}

	public class AbcHits
	{
		private readonly Prime _prime = new Prime();
		private readonly Totient _totient = new	Totient();

		public bool IsAbcHit(int a, int b, int c)
		{
			bool gcdEqual = AreGcdEqual(a, b, c);
			bool aLessThanB = a < b;
			bool cValue = a + b == c;
			bool rad = IsRadLessThanC(a * b * c, c);

			return gcdEqual && aLessThanB && cValue && rad;
		}

		private bool IsRadLessThanC(int product, int c)
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

		public long GetRad(int n)
		{
			var distinctPrimeFactors = _prime.GetPrimeFactors(n).Distinct();
			var result = (long) distinctPrimeFactors.Aggregate((accu, val) => accu * val);

			return result;
		}
	}
}
