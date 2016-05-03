using System;
using System.Collections.Generic;

namespace RemovingDuplicatesInList
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//GetNoneDupeWithoutSpaceLimit();
			GetNoneDupeWithSpaceLimit();
		}

		private static void GetNoneDupeWithSpaceLimit()
		{
			var dupeList = new List<int> { 2, 2, 1, 3, 4, 5, 3 };
			dupeList.Sort();

			// Starts with 1 because first element is always sorted.
			for (int i = 1; i < dupeList.Count; i++)
			{
				if (dupeList[i] == dupeList[i - 1])
				{
					dupeList.RemoveAt(i);
				}
			}

			foreach (int value in dupeList)
			{
				Console.Write("{0} ", value);
			}
			Console.WriteLine();
		}

		private static void GetNoneDupeWithoutSpaceLimit()
		{
			var dupeList = new List<int> {2, 2, 1, 3, 4, 5, 3};
			var set = new List<int>();

			dupeList.Sort();
			foreach (int value in dupeList)
			{
				int searchIndex = set.BinarySearch(value);
				if (searchIndex < 0)
				{
					Console.WriteLine("searchIndex: {0}, ~searchIndex: {1}", searchIndex, ~searchIndex);
					set.Insert(~searchIndex, value);
				}
			}

			foreach (int value in set)
			{
				Console.Write("{0} ", value);
			}
			Console.WriteLine();
		}
	}
}
