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

			List<double> primeNumbers = GetUsablePrimeNumbersUnder(value);

			double dividedValue = value;
			foreach (var primeNumber in primeNumbers)
			{
				int remainder;
				do
				{
					remainder = (int)(dividedValue % primeNumber);
					double tempDividedValue = dividedValue / primeNumber;
					if (remainder == 0)
					{
						result.Add(primeNumber);
						dividedValue = tempDividedValue;
					}
				} while (remainder == 0 && dividedValue > 1);

				if (dividedValue <= 1)
					break;
			}

			//double dividedValue = value;
			//for (int i = 2; i < value / 2; i++)
			//{
			//	if (IsPrimeNumber(i))
			//	{
			//		int remainder;
			//		do
			//		{
			//			remainder = (int)(dividedValue % i);
			//			double tempDividedValue = dividedValue / i;
			//			if (remainder == 0)
			//			{
			//				result.Add(i);
			//				dividedValue = tempDividedValue;
			//			}
			//		} while (remainder == 0 && dividedValue > 1);
			//	}

			//	if (dividedValue <= 1)
			//		break;
			//}

			//for (int i = 2; i < primeNumbers; i++)
			//{
			//	if (IsPrimeNumber(i))
			//	{
			//		int remainder;
			//		double dividedValue = value;
			//		do
			//		{
			//			remainder = (int) (dividedValue % i);
			//			dividedValue = dividedValue / i;
			//			if (remainder == 0)
			//			{
			//				result.Add(i);
			//			}
			//		} while (remainder % i == 0);
			//	}
			//}

			return result;
		}

		/// <summary>
		/// Get all prime numbers between 2 and half of the size of value.
		/// When we calculate prime factors, we don't need prime numbers more than 1/2 of value.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public List<double> GetUsablePrimeNumbersUnder(double value)
		{
			var result = new List<double>();
			if (Math.Abs(value - 2.0D) < 0.0001 || Math.Abs(value - 3.0D) < 0.0001)
			{
				result.Add(2.0D);
				return result;
			}

			for (double i = 2; i <= value / 2; i++)
			{
				if (IsPrimeNumber(i))
				{
					result.Add(i);
				}
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