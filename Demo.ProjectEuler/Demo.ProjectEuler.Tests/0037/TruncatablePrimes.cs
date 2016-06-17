using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Demo.ProjectEuler.Core;

namespace Demo.ProjectEuler.Tests._0037
{
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

			List<int> invalidNumbers = new List<int> {1, 4, 6, 8, 0};
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