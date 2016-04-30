using System;
using System.Collections.Generic;

namespace Demo.ProjectEuler.Tests._0003
{
	public class LargestPrimeFactor
	{
		public List<double> GetPrimeFactors(double value)
		{
			var result = new List<double>();

			if (IsPrimeNumber(value))
			{
				result.Add(value);
				return result;
			}

			for (int i = 2; i < value; i++)
			{
				if (IsPrimeNumber(i))
				{
					int remainder;
					double dividedValue = value;
					do
					{
						remainder = (int) (dividedValue % i);
						dividedValue = dividedValue / i;
						if (remainder == 0)
						{
							result.Add(i);
						}
					} while (remainder % i == 0);
				}
			}

			return result;
		}

		public bool IsPrimeNumber(double value)
		{
			if (value <= 1) return false;	// by definion of Prime Number

			for (int i = 2; i < value; i++)
			{
				if (Math.Abs(value % i) < 0.001) return false;
			}

			return true;
		}
	}
}