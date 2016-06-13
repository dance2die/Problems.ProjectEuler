using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Demo.ProjectEuler.Tests._0029
{
	public class DistinctPowers
	{
		public List<BigInteger> GetDistinctPowers(int from, int to)
		{
			List<BigInteger> list = new List<BigInteger>();
			for (int i = from; i <= to; i++)
			{
				for (int j = from; j <= to; j++)
				{
					list.Add((BigInteger) Math.Pow(i, j));
				}
			}

			var result = list.Distinct(new BigIntegerComparer()).ToList();
			result.Sort();

			return result;
		}
	}
}