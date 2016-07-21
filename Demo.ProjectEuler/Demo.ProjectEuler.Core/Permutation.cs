using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Demo.ProjectEuler.Core
{
	public class Permutation
	{
		public bool IsPermutation(double value1, double value2)
		{
			var textList1 = value1.ToString(CultureInfo.InvariantCulture).ToCharArray();
			var textList2 = value2.ToString(CultureInfo.InvariantCulture).ToCharArray();

			Array.Sort(textList1);
			Array.Sort(textList2);

			return textList1.SequenceEqual(textList2);
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