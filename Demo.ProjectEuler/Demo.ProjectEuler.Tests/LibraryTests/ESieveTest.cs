using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests.LibraryTests
{
	public class ESieveTest : BaseTest
	{
		private readonly ESieve _sut = new ESieve();

		public ESieveTest(ITestOutputHelper output) : base(output)
		{
		}

		/// <remarks>
		/// Generated expected primes using 
		/// http://www.free-online-calculator-use.com/prime-number-generator.html
		/// </remarks>
		[Theory]
		[InlineData(2, new [] { 2 })]
		[InlineData(10, new [] { 2, 3, 5, 7 })]
		[InlineData(50, new [] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47 })]
		[InlineData(100, new [] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 })]
		[InlineData(200, new [] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199 })]
		public void TestGeneratingPrimes(int upto, int[] expected)
		{
			int[] actual = _sut.GetPrimes(upto).ToArray();

			Assert.True(expected.SequenceEqual(actual));
		}
	}

	public class ESieve
	{
		public IEnumerable<int> GetPrimes(int upto)
		{
			var primes = new bool[upto + 1];
			InitializePrimes(primes, true);

			for (int i = 2; i <= Math.Sqrt(upto); i++)
			{
				if (primes[i])
					MarkMultiplesAsFalse(primes, i, upto);
			}

			for (int j = 2; j <= upto; j++)
			{
				if (primes[j])
					yield return j;
			}
		}

		private void MarkMultiplesAsFalse(bool[] primes, int index, int upto)
		{
			for (int j = index * index; j <= upto; j += index)
			{
				primes[j] = false;
			}
		}

		private void InitializePrimes(bool[] primes, bool defaultValue)
		{
			primes[0] = false;
			primes[1] = false;

			for (int i = 2; i < primes.Length; i++)
			{
				primes[i] = defaultValue;
			}
		}
	}
}
