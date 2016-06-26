using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;

namespace Demo.ProjectEuler.Tests._0043
{
	public class SubstringDivisibility
	{
		private readonly int[] _primes = {2, 3, 5, 7, 11, 13, 17};

		public long GetNumbersWithSpecialProperties()
		{
			Permutation perm = new Permutation();
			var permutations = perm.GetPermutations(Enumerable.Range(0, 10).ToList());

			long result = 0;
			foreach (IEnumerable<int> permutation in permutations.Where(n => n.First() != 0))
			{
				var permutationList = permutation.ToList();
				string numberText = string.Join("", permutationList.Select(n => n.ToString()).ToArray());

				if (HasSpecialProperties(permutationList))
					result += Convert.ToInt64(numberText);
			}

			return result;
		}

		public bool HasSpecialProperties(IList<int> numbers)
		{
			for (int i = 0; i < numbers.Count - 3; i++)
			{
				var digit1 = numbers[i + 1] * 100;
				var digit2 = numbers[i + 2] * 10;
				var digit3 = numbers[i + 3];
				var number = digit1 + digit2 + digit3;

				//string substring = $"{digit1}{digit2}{digit3}";
				//int number = Convert.ToInt32(substring);

				if (number % _primes[i] != 0)
					return false;
			}

			return true;
		}
	}
}