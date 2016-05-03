using System;
using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;

namespace Demo.ProjectEuler.Tests._0005
{
	public class SmallestMultiple
	{
		/// <summary>
		/// Calculate smallest multiple
		/// </summary>
		/// <remarks>
		/// Smallest multiple is generated using compiled list of prime factors
		/// 
		/// Step 1) Calculate prime factors for each number up to Upper Bound.
		/// 1 2 3 4 5 6 7 8 9 10
		/// 1.) 1 => not a prime so skip
		/// 2.) 2 => 2
		/// 3.) 3 => 3
		/// 4.) 4 => 2 * 2
		/// 5.) 5 => 5
		/// 6.) 6 => 2 * 3
		/// 7.) 7 => 7
		/// 8.) 8 => 2 * 2 * 2
		/// 9.) 9 => 3 * 3
		/// 10.) 10 => 2 * 5
		/// 
		/// Step 2) Find the list of primes between 1 and upperBound
		/// 2 3 5 7
		/// 
		/// Step 3) Select the longest sequence of each prime.
		/// 2 => 2 * 2 * 2
		/// 3 => 3 * 3
		/// 5 => 5
		/// 7 => 7
		/// 
		/// Step 4) Multiply longest sequences.
		/// 2 * 2 * 2 * 3 * 3 * 5 * 7 => 2520
		/// </remarks>
		public int GetSmallestMultiple(int uppperBound)
		{
			Prime prime = new Prime();

			// Step 1
			var primeFactors = new Dictionary<int, List<double>>();
			// Skip 1 because it's not a prime number
			for (int i = 2; i < uppperBound; i++)
			{
				primeFactors.Add(i, prime.GetPrimeFactors(i));
			}

			// Step 2: Find the list of primes between 1 and upperBound within primeFactors
			var primeNumberCount = (
				from pair in primeFactors
				where prime.IsPrimeNumber(pair.Key)
				select new PrimeTuple(pair.Key, 1)).ToList();

			// Step 3
			var primeSequenceCounter = new Dictionary<int, int>();
			foreach (PrimeTuple tuple in primeNumberCount)
			{
				foreach (KeyValuePair<int, List<double>> factorPair in primeFactors)
				{
					int sequenceCount = factorPair.Value.Count(value => Math.Abs(value - tuple.PrimeNumber) < 0.001);
					if (sequenceCount > tuple.Power)
						tuple.Power = sequenceCount;
				}
			}

			// Step 4: Multiple longest sequences of prime numbers
			int product = 1;
			foreach (PrimeTuple tuple in primeNumberCount)
			{
				product *= (int) Math.Pow(tuple.PrimeNumber, tuple.Power);
			}

			return product;
		}
	}
}