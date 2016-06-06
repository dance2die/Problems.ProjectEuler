using System;
using System.Collections.Generic;
using System.Linq;

namespace CombinationDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			//GetCombination(new List<int> { 1, 2, 3 });
			var list = new List<int> { 1, 2, 3 };
			IEnumerable<IEnumerable<int>> combinations = GetCombination2(list).ToList();
			foreach (IEnumerable<int> combination in combinations)
			{
				foreach (int number in combination)
				{
					Console.Write("{0} ", number);
				}
				Console.WriteLine();
			}
		}

		// http://stackoverflow.com/a/7802892/4035
		private static IEnumerable<IEnumerable<T>> GetCombination2<T>(List<T> list)
		{
			double count = Math.Pow(2, list.Count);
			for (int i = 1; i <= count - 1; i++)
			{
				yield return GetNumbers2(list, i);
			}
		}

		private static IEnumerable<T> GetNumbers<T>(List<T> list, int bitIndex)
		{
			// Explanation http://stackoverflow.com/a/19891145/4035
			string str = Convert.ToString(bitIndex, 2).PadLeft(list.Count, '0');
			for (int j = 0; j < str.Length; j++)
			{
				if (str[j] == '1')
					yield return list[j];
			}
		}

		private static IEnumerable<T> GetNumbers2<T>(List<T> list, int index)
		{
			for (int j = 0; j < list.Count; j++)
			{
				// http://stackoverflow.com/a/19891145/4035
				if ((index & (1 << j)) > 0)
					yield return list[j];
			}
		}
	}
}
