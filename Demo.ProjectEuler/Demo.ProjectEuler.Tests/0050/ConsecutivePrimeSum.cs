using System;
using System.Linq;
using Demo.ProjectEuler.Core;

namespace Demo.ProjectEuler.Tests._0050
{
	public class ConsecutivePrimeSum
	{
		private readonly ESieve _eSieve = new ESieve();

		public double GetLongestConsecutivePrimeSum(int upto)
		{
			var primes = _eSieve.GetPrimes(upto).ToArray();
			var maxSequence = 0;
			int maxSequencePrime = 0;

			int[] primeSums = new int[primes.Length + 1];
			primeSums[0] = 0;
			for (int a = 0; a < primes.Length; a++)
			{
				primeSums[a + 1] = primeSums[a] + primes[a];
			}

			for (int i = 0; i < primes.Length - 1; i++)
			{
				for (int j = 2; j <= primes.Length; j++)
				{
					int sum = primeSums[j] - primeSums[i];
					int rangeCount = j - i + 1;
					if (sum > upto) break;

					if (maxSequence < rangeCount &&
						Array.BinarySearch(primes, sum) >= 0)
					{
						maxSequence = rangeCount;
						maxSequencePrime = sum;
					}
				}
			}

			return maxSequencePrime;
		}
	}
}