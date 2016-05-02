using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests._0003;

namespace Demo.ProjectEuler.Tests._0010
{
	public class SummationOfPrimes : Prime
	{
		public double GetPrimeSumFor(double value)
		{
			return GetPrimeNumbersUnder(value).Sum();
		}

		public List<double> GetPrimeNumbersUnder(double value)
		{
			var result = new List<double>();

			for (double i = 2; i <= value; i++)
			{
				//if (result.Where(primeNumber => i % primeNumber == 0).Count() < 1 && IsPrimeNumber(i))
				if (IsPrimeNumber(i))
					result.Add(i);
			}

			return result;
		}
	}
}