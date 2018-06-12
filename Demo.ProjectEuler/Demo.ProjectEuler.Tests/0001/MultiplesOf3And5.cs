using System.Collections.Generic;
using System.Linq;

namespace Demo.ProjectEuler.Tests._0001
{
	public class MultiplesOf3And5
	{
		public int CalculateBelow(int below)
		{
		    return GetMultiplesOf3And5Set(below).Sum();
        }

		public IEnumerable<int> GetMultiplesOf3And5Set(int below)
		{
		    return Enumerable
		        .Range(1, below < 1 ? 0 : below - 1)
		        .Where(i => i % 3 == 0 || i % 5 == 0);
		}
    }
}