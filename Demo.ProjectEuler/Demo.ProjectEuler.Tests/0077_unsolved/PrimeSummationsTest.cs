using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0077
{
	public class PrimeSummationsTest : BaseTest
	{
		private readonly PrimeSummations _sut = new PrimeSummations();

		public PrimeSummationsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(10, 5)]
		public void TestSampleData(int n, int expected)
		{
			int actual = _sut.GetPrimeSummations(n);

			Assert.Equal(expected, actual);
		}
	}

	public class PrimeSummations
	{
		private const int PRIME_COUNT = 100;

		private readonly Prime _primeManager = new Prime();
		private readonly ESieve _eSieve = new ESieve();
		private readonly List<int> _primeNumbers = new List<int>(PRIME_COUNT);

		public PrimeSummations()
		{
			_primeNumbers = _eSieve.GetPrimes(PRIME_COUNT).ToList();
		}

		public int GetPrimeSummations(int n)
		{
			return GetPrimeSummations(n, n) - 1;
		}

		private int GetPrimeSummations(int n, int k)
		{
			if (_primeManager.IsPrimeNumber(n) && _primeManager.IsPrimeNumber(k))
			{
				
			}

			if (k == 0) return 0;
			if (n < 0) return 0;
			if (n == 0) return 1;

			var left = GetPrimeSummations(n, k - 1);
			var right = GetPrimeSummations(n - k, k);

			if (_primeManager.IsPrimeNumber(n) && _primeManager.IsPrimeNumber(k))
				return left + right;
			return 0;
		}
	}
}
