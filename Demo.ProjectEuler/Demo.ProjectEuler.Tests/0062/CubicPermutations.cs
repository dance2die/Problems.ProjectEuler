using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Demo.ProjectEuler.Tests._0062
{
	public class CubicPermutations
	{
		public long GetSmallestCubeWithin(int permutationCount)
		{
			for (int i = 1;; i++)
			{
				var cubePermutations = GetCubesWithSamePermutations(i).ToList();
				if (cubePermutations.Count == permutationCount)
					return cubePermutations.Min();
			}
		}

		public long GetSmallestCube(int cubeRoot)
		{
			return GetCubesWithSamePermutations(cubeRoot).Min();
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
		public IEnumerable<long> GetCubesWithSamePermutations(int cubeRoot)
		{
			const int cubePower = 3;
			var cubed = (long) Math.Pow(cubeRoot, cubePower);

			var numberList1 = GetNumberList(cubed);
			for (long i = cubeRoot;; i++)
			{
				cubed = (long)Math.Pow(i, cubePower);

				if (i == 384 || i == 405)
					Console.WriteLine(i);

				var numberList2 = GetNumberList(cubed);
				if (numberList2.Count > numberList1.Count)
					yield break;

				if (HasSameNumberSequence(numberList1, numberList2))
					yield return ConvertSequenceToLong(numberList2);
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

		private List<int> GetNumberList(long number)
		{
			List<int> list = new List<int>();
			foreach (char c in number.ToString(CultureInfo.InvariantCulture))
			{
				list.Add(Convert.ToInt32(c.ToString()));
			}

			return list;
		}

		private long ConvertSequenceToLong(IEnumerable<int> sequence)
		{
			string valueText = string.Join("", sequence.Select(i => i.ToString()));
			return Convert.ToInt64(valueText);
		}
	}
}