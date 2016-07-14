using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.ProjectEuler.Tests._0062
{
	public class CubicPermutations
	{
		public long GetSmallestCubeWithin(int permutationCount)
		{
			for (int i = 1; ; i++)
			{
				var cubePermutations = GetCubesWithSamePermutations(i).ToList();
				if (cubePermutations.Count == permutationCount)
					return cubePermutations.Select(str => Convert.ToInt64(str)).Min();
			}
		}

		/// <param name="number">Number for which to cubes with same sequences for</param>
		/// <remarks>
		/// To do
		/// 
		/// Get the number sequence
		/// while length of "cubed number" is equal to the given "number",
		///		Increase number by one and get cube.
		///		If sequence is the same as cubed number sequence then yield.
		/// </remarks>
		public IEnumerable<string> GetCubesWithSamePermutations(int cubeRoot)
		{
			const int cubePower = 3;
			var cubed = (long)Math.Pow(cubeRoot, cubePower);

			var numberList1 = GetNumberList(cubed);
			for (long i = cubeRoot; ; i++)
			{
				cubed = (long)Math.Pow(i, cubePower);

				var numberList2 = GetNumberList(cubed);
				if (numberList2.Length > numberList1.Length)
					yield break;

				if (HasSameNumberSequence(numberList1, numberList2))
					//yield return ConvertSequenceToLong(numberList2);
					yield return new string(numberList2);
			}
		}

		public bool HasSameNumberSequence<T>(IList<T> list1, IList<T> list2)
		{
			var copy1 = list1.ToList();
			var copy2 = list2.ToList();

			copy1.Sort();
			copy2.Sort();

			return copy1.SequenceEqual(copy2);
		}

		public bool HasSameNumberSequence(long number1, long number2)
		{
			var list1 = GetNumberList(number1);
			var list2 = GetNumberList(number2);

			return HasSameNumberSequence(list1, list2);
		}

		private char[] GetNumberList(long number)
		{
			return number.ToString().ToCharArray();
		}
	}
}