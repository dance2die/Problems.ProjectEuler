using System;
using System.Collections.Generic;

namespace Demo.ProjectEuler.Core
{
	public class ESieve
	{
		/// <summary>
		/// Get prime numbers "upto" specified number
		/// </summary>
		/// <param name="upto"></param>
		/// <returns></returns>
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