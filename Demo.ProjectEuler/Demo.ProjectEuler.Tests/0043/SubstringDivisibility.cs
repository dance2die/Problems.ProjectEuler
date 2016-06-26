using System;
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
			var permutations = perm.GetPermutations(Enumerable.Range(0, 10).ToList()).ToList();

			long result = 0;
			foreach (IEnumerable<int> permutation in permutations)
			{
				string numberText = string.Join("", permutation.Select(n => n.ToString()).ToArray());
				if (numberText.StartsWith("0")) continue;

				long number = Convert.ToInt64(numberText);

				if (HasSpecialProperties(number))
					result += number;
			}

			return result;
		}

		public bool HasSpecialProperties(long input)
		{
			string inputText = input.ToString();
			for (int i = 0; i < inputText.Length - 3; i++)
			{
				var digit1 = inputText[i + 1];
				var digit2 = inputText[i + 2];
				var digit3 = inputText[i + 3];

				string substring = $"{digit1}{digit2}{digit3}";
				int number = Convert.ToInt32(substring);

				if (number % _primes[i] != 0)
					return false;
			}

			return true;
		}
	}
}