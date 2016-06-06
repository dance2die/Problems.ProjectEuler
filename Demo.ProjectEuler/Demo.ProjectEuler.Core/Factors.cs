using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

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

		public IEnumerable<int> GetDivisors(int value)
		{
			//for (int i = 1; i <= value; i++)
			//{
			//	if (value % i == 0)
			//		yield return i;
			//}

			int sqrt = (int)Math.Ceiling(Math.Sqrt(value));
			List<double> primeFactors = new Prime().GetPrimeFactors(value).ToList();
			List<int[]> primeFactorPermutations = GetCombinations(primeFactors.Select(n => (int)n).ToArray()).ToList();

			yield return 1;
		}

		private IEnumerable<int[]> GetCombinations(int[] array)
		{
			int count = 2 << array.Length;	// combination count
			for (int i = 1; i < count; i++)
			{
				var itemString = Convert.ToString(i, 2).PadLeft(array.Length - 1, '0');
				for (int j = 0; j < itemString.Length; j++)
				{
					if (itemString[j] == '1')
						//yield return itemString.Select(c => Convert.ToInt32(c.ToString())).ToArray();
						yield return array[j];
				}
			}
		}

		/// <summary>
		/// Divisors excluding itself (value)
		/// </summary>
		/// <remarks>
		/// For value 220,
		/// 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110 (which excludes 220 from divisor)
		/// </remarks>
		public IEnumerable<int> GetProperDivisors(BigInteger value)
		{
			for (int i = 1; i <= value; i++)
			{
				if (value % i == 0 && value != i)
					yield return i;
			}
		}
	}
}
