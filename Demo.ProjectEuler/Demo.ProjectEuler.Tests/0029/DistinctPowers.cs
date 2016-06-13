using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Demo.ProjectEuler.Tests._0029
{
	public class DistinctPowers
	{
		public List<double> GetDistinctPowers(int from, int to)
		{
			List<double> list = new List<double>();
			for (int i = from; i <= to; i++)
			{
				for (int j = from; j <= to; j++)
				{
					list.Add((double) Math.Pow(i, j));
				}
			}

			var result = list.Distinct().ToList();
			result.Sort();

			return result;
		}
	}
}