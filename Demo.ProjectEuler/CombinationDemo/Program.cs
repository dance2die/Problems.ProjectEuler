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
		static void GetCombination(List<int> list)
		{
			double count = Math.Pow(2, list.Count);
			for (int i = 1; i <= count - 1; i++)
			{
				string str = Convert.ToString(i, 2).PadLeft(list.Count, '0');
				for (int j = 0; j < str.Length; j++)
				{
					if (str[j] == '1')
					{
						Console.Write(list[j] + " " );
					}
				}
				Console.WriteLine();
			}
		}

		
		private static IEnumerable<IEnumerable<int>> GetCombination2(List<int> list)
		{
			double count = Math.Pow(2, list.Count);
			for (int i = 1; i <= count - 1; i++)
			{
				yield return GetNumbers(list, i).ToList();
			}
		}

		private static IEnumerable<int> GetNumbers(List<int> list, int bitIndex)
		{
			// Explanation http://stackoverflow.com/a/19891145/4035
			string str = Convert.ToString(bitIndex, 2).PadLeft(list.Count, '0');
			for (int j = 0; j < str.Length; j++)
			{
				if (str[j] == '1')
					yield return list[j];
			}
		}
	}
}
