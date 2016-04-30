using System.Collections.Generic;
using System.Linq;

namespace Demo.ProjectEuler.Tests._0001
{
	public class MultiplesOf3And5
	{
		public int CalculateBelow(int below)
		{
			//if (below <= 0) return 0;
			//if (below == 3) return 3;

			//return 23;

			var set = GetMultiplesOf3And5Set(below);
			return set.Sum();
		}

		public HashSet<int> GetMultiplesOf3And5Set(int below)
		{
			HashSet<int> result = new HashSet<int>();

			for (int i = 1; i < below; i++)
			{
				if (i % 3 == 0) result.Add(i);
				if (i % 5 == 0) result.Add(i);
			}

			return result;
		}
	}
}