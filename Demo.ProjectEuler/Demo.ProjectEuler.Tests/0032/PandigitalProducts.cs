using System;
using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;

namespace Demo.ProjectEuler.Tests._0032
{
	public class PandigitalProducts
	{
		public int GetDistinctSumOfSpecialPandigitalNumbers()
		{
			Permutation permutation = new Permutation();
			const string pandigital = "123456789";
			IEnumerable<IEnumerable<char>> permutations = permutation.GetPermutations(pandigital.ToCharArray().ToList());
			Tuple<int, int, int>[] pandigitalSlicingIndexes = GetPandigitalSlicingIndexes(pandigital.Length);

			List<int> products = new List<int>();
			Dictionary<Tuple<int, int>, int> distinctCombinations = new Dictionary<Tuple<int, int>, int>();

			foreach (IEnumerable<char> chars in permutations)
			{
				string text = new string(chars.ToArray());
				foreach (Tuple<int, int, int> indexes in pandigitalSlicingIndexes)
				{
					int multiplicand = Convert.ToInt32(text.Substring(0, indexes.Item1));
					int multiplier = Convert.ToInt32(text.Substring(indexes.Item1, indexes.Item2));
					int product = Convert.ToInt32(text.Substring(indexes.Item2 + indexes.Item1, indexes.Item3));

					if (multiplicand * multiplier == product)
					{
						var key = new Tuple<int, int>(multiplicand, multiplier);
						if (!distinctCombinations.ContainsKey(key))
							distinctCombinations.Add(key, product);
					}
				}
			}

			var result = distinctCombinations.Values.Distinct().Sum();
			return result;
		}

		public Tuple<int, int, int>[] GetPandigitalSlicingIndexes(int length)
		{
			var result = new List<Tuple<int, int, int>>();

			// leftIndex <= length - 2 because middle and right index must have at least length of 1.
			for (int leftIndex = 1; leftIndex <= length - 2; leftIndex++)
			{
				for (int middleIndex = 1; middleIndex <= length - leftIndex - 1; middleIndex++)
				{
					for (int rightIndex = length - leftIndex - middleIndex; rightIndex >= 1; rightIndex--)
					{
						var indexes = new Tuple<int, int, int>(leftIndex, middleIndex, rightIndex);
						if (leftIndex + middleIndex + rightIndex == 9)
							result.Add(indexes);
					}
				}
			}

			return result.ToArray();
		}

		public bool IsSpecialPandigital(Tuple<int, int, int> specialPandigitalCandidate)
		{
			int[] pandigitalSequence = {1, 2, 3, 4, 5, 6, 7, 8, 9};

			var candidateString = string.Format("{0}{1}{2}", 
				specialPandigitalCandidate.Item1, specialPandigitalCandidate.Item2, specialPandigitalCandidate.Item3);
			var candidateSequence = candidateString.Select(c => Convert.ToInt32(c.ToString())).ToList();
			candidateSequence.Sort();

			return candidateSequence.SequenceEqual(pandigitalSequence);
		}
	}
}