using System;
using System.Linq;
using Demo.ProjectEuler.Core;

namespace Demo.ProjectEuler.Tests._0050
{
	public class ConsecutivePrimeSum
	{
		private readonly ESieve _eSieve = new ESieve();
		private readonly Prime _prime = new Prime();

		public double GetLongestConsecutivePrimeSum(int upto)
		{
			var primes = _eSieve.GetPrimes(upto).ToArray();
			var maxSequence = 0;
			int maxSequencePrime = 0;

			for (int i = 0; i < primes.Length - 1; i++)
			{
				for (int j = 2; j <= primes.Length; j++)
				{
					var range = primes.Skip(i).Take(j).ToList();
					int sum = range.Aggregate(0, (a, b) => a + b);
					if (sum > upto) break;

					if (maxSequence < range.Count &&
						Array.BinarySearch(primes, sum) >= 0)
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