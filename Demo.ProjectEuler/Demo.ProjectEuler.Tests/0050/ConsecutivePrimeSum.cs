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
			var primes = _eSieve.GetPrimes(upto / 2).ToList();
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