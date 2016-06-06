using System.Collections.Generic;
using Demo.ProjectEuler.Core;

namespace Demo.ProjectEuler.Tests._0021
{
	public class AmicableNumbers
	{
		private readonly Factors _factors = new Factors();
		private const int LIMIT = 10000;

		public int GetAmicableNumberSum()
		{
			//checked
			//{
			//	int result = 0;
			//	var lookup = GetDivisorSumDictionary(Enumerable.Range(1, LIMIT));

			//	var query = from pair1 in lookup
			//		from pair2 in lookup
			//		where pair1.Key != pair2.Key
			//		      && pair1.Key == pair2.Value
			//		      && pair1.Value == pair2.Key
			//		select pair1;
			//	foreach (KeyValuePair<int, int> pair in query)
			//	{
			//		result += pair.Key + pair.Value;
			//	}

			//	result /= 2;

			//	return result;
			//}

			// https://projecteuler.net/thread=21;page=8
			int x = 0;
			for (int i = 1; i < LIMIT; i++)
			{
				var sum1 = GetDivisorSum(i);
				var sum2 = GetDivisorSum(sum1);

				if (sum2 == i && sum1 != sum2)
					x += i;
			}
			return x;
		}

		public int GetDivisorSum(int value)
		{
			//return _factors.GetProperDivisors(value).Sum();
			int count = 0;
			for (int i = 1; i < (value / 2) + 1; i++)
			{
				if (value % i == 0) { count += i; }
			}
			return count;
		}

		public Dictionary<int, int> GetDivisorSumDictionary(IEnumerable<int> values)
		{
			Dictionary<int, int> result = new Dictionary<int, int>();
			foreach (int value in values)
			{
				KeyValuePair<int, int> pairOfNumberSum = GetPairOfNumberSum(value);
				result.Add(pairOfNumberSum.Key, pairOfNumberSum.Value);
			}

			return result;
		}

		public KeyValuePair<int, int> GetPairOfNumberSum(int value)
		{
			var divisorSum = GetDivisorSum(value);
			return new KeyValuePair<int, int>(value, divisorSum);
		}
	}
}