using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.ProjectEuler.Core
{
	public class Factors
	{
		// http://stackoverflow.com/a/4549500/4035
		public int GetFactorCount(double numberToCheck)
		{
			int factorCount = 0;
			int sqrt = (int)Math.Ceiling(Math.Sqrt(numberToCheck));

			// Start from 1 as we want our method to also work when numberToCheck is 0 or 1.
			for (int i = 1; i < sqrt; i++)
			{
				if (numberToCheck % i == 0)
				{
					factorCount += 2; //  We found a pair of factors.
				}
			}

			// Check if our number is an exact square.
			if (sqrt * sqrt == numberToCheck)
			{
				factorCount++;
			}

			return factorCount;
		}

		/// <summary>
		/// Divisors excluding itself (value)
		/// </summary>
		/// <remarks>
		/// For value 220,
		/// 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110 (which excludes 220 from divisor)
		/// </remarks>
		public IEnumerable<int> GetProperDivisors(int value)
		{
			var divisors = GetDivisors(value).ToList();
			return divisors.Take(divisors.Count - 1);
		}

		public IEnumerable<int> GetDivisors(int value)
		{
			int sqrt = (int)Math.Ceiling(Math.Sqrt(value));
			List<double> primeFactors = new Prime().GetPrimeFactors(value).ToList();
			IEnumerable<IEnumerable<double>> primeFactorPermutations = GetCombinations(primeFactors);

			List<double> divisors = new List<double> { 1 };	// everything's divisible by 1
			foreach (IEnumerable<double> primeFactorPermutation in primeFactorPermutations)
			{
				double product = primeFactorPermutation.Aggregate((acct, val) => acct * val);
				if (!divisors.Contains(product))
					divisors.Add(product);
			}

			return divisors.Select(num => (int) num);
		}

		// http://stackoverflow.com/a/7802892/4035
		private static IEnumerable<IEnumerable<T>> GetCombinations<T>(List<T> list)
		{
			double count = Math.Pow(2, list.Count);
			for (int i = 1; i <= count - 1; i++)
			{
				yield return GetNumbers(list, i);
			}
		}

		private static IEnumerable<T> GetNumbers<T>(List<T> list, int index)
		{
			for (int j = 0; j < list.Count; j++)
			{
				// http://stackoverflow.com/a/19891145/4035
				if ((index & (1 << j)) > 0)
					yield return list[j];
			}
		}

		public IEnumerable<IEnumerable<T>> GetPermutations<T>(IList<T> list)
		{
			return GetPermutations(list, 0, list.Count - 1).ToList();
		}

		private IEnumerable<IEnumerable<T>> GetPermutations<T>(
			IList<T> list, int startIndex, int permutationCount)
		{
			if (startIndex == permutationCount)
			{
				yield return list;
			}
			else
			{
				for (int i = startIndex; i <= permutationCount; i++)
				{
					Swap(list, startIndex, i);

					List<T> listCopy = list.ToList();
					foreach (IEnumerable<T> permutation in GetPermutations(listCopy, startIndex + 1, permutationCount))
					{
						yield return permutation;
					}
				}
			}
		}

		private void Swap<T>(IList<T> list, int index1, int index2)
		{
			var temp = list[index1];
			list[index1] = list[index2];
			list[index2] = temp;
		}
	}
}
