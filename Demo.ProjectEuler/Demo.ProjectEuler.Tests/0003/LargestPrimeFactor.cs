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
			if (value <= 1) return false;   // by definion of Prime Number

			// http://stackoverflow.com/a/15743238/4035
			double boundary = Math.Floor(Math.Sqrt(value));
			for (int i = 2; i <= boundary; i++)
			{
				if (Math.Abs(value % i) < 0.001) return false;
			}

			return true;
		}
	}
}