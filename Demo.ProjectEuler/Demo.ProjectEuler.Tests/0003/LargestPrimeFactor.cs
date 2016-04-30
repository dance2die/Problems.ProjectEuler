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

			double dividedValue = value;
			for (int i = 2; i <= value / 2; i++)
			{
				if (IsPrimeNumber(i))
				{
					int remainder;
					do
					{
						remainder = (int)(dividedValue % i);
						double tempDividedValue = dividedValue / i;
						if (remainder == 0)
						{
							result.Add(i);
							dividedValue = tempDividedValue;
						}
					} while (remainder == 0 && dividedValue > 1);
				}

				if (dividedValue <= 1)
					break;
			}

			return result;
		}

		public bool IsPrimeNumber(double value)
		{
			Prime prime = new Prime();
			return prime.IsPrimeNumber(value);
		}
	}
}