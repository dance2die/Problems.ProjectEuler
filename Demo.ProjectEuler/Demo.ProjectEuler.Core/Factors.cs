using System;
using System.Collections.Generic;
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

		public IEnumerable<int> GetDivisors(BigInteger value)
		{
			for (int i = 1; i <= value; i++)
			{
				if (value % i == 0)
					yield return i;
			}
		}
	}
}
