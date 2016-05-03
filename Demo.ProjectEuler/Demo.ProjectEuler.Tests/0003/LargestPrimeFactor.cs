using System.Collections.Generic;
using Demo.ProjectEuler.Core;

namespace Demo.ProjectEuler.Tests._0003
{
	public class LargestPrimeFactor
	{
		private readonly Prime _prime = new Prime();

		public List<double> GetPrimeFactors(double value)
		{
			return _prime.GetPrimeFactors(value);
		}

		public bool IsPrimeNumber(double value)
		{
			return _prime.IsPrimeNumber(value);
		}
	}
}