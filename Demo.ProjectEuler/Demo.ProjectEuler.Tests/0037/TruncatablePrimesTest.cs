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

namespace Demo.ProjectEuler.Tests._0037
{
	public class TruncatablePrimesTest : BaseTest
	{
		private readonly TruncatablePrimes _sut = new TruncatablePrimes();

		public TruncatablePrimesTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(2, false)]
		[InlineData(3, false)]
		[InlineData(5, false)]
		[InlineData(7, false)]
		[InlineData(3797, true)]
		public void TestTruncablePrime(int prime, bool expected)
		{
			bool actual = _sut.IsTruncablePrime(prime);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			BigInteger result = _sut.GetTruncablePrimes();

			_output.WriteLine(result.ToString());
		}
	}

	public class TruncatablePrimes
	{
		private readonly Prime _prime = new Prime();
		private readonly List<int> _processedPrimes = new List<int>();

		public BigInteger GetTruncablePrimes()
		{
			const int primeCountTotal = 11;	// given on the problem page.

			int number = 22;
			int counter = 0;

			List<int> truncablePrimes = new List<int>();

			do
			{
				do
				{
					number++;
				} while (!IsTruncablePrime(number));

				_processedPrimes.Add(number);
				truncablePrimes.Add(number);

				counter++;
			} while (counter < primeCountTotal);

			return truncablePrimes.Sum();
		}

		public bool IsTruncablePrime(int prime)
		{
			if (prime < 10) return false;
			if (!_prime.IsPrimeNumber(prime)) return false;

			if (prime == 797)
			{
				Console.WriteLine(prime);
			}

			List<int> invalidNumbers = new List<int> {1, 4, 6, 8, 0};
			//foreach (char c in prime.ToString())
			//{
			//	if (invalidNumbers.Contains(Convert.ToInt32(c.ToString())))
			//		return false;
			//}
			var primeText = prime.ToString();
			if (invalidNumbers.Contains(Convert.ToInt32(primeText.Substring(0, 1))) ||
			    invalidNumbers.Contains(Convert.ToInt32(primeText.Substring(primeText.Length - 1, 1))))
			{
				return false;
			}

			string leftToRight = prime.ToString();
			string rightToLeft = leftToRight;
			// Remove number from left to right.
			// Remove number from right to left.
			for (int i = 0; i < prime.ToString().Length - 1; i++)
			{
				leftToRight = leftToRight.Substring(1);
				rightToLeft = rightToLeft.Substring(0, rightToLeft.Length - 1);

				int leftRightValue = Convert.ToInt32(leftToRight);
				int rightLeftValue = Convert.ToInt32(rightToLeft);

				if (_processedPrimes.Contains(leftRightValue) &&
					_processedPrimes.Contains(rightLeftValue))
					return true;

				if (!_prime.IsPrimeNumber(leftRightValue) || 
					!_prime.IsPrimeNumber(rightLeftValue))
					return false;

			}

			return true;
		}
	}
}
