using System;
using System.Collections.Generic;

namespace Demo.ProjectEuler.Core
{
	public class Prime
	{
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

		public List<double> GetPrimeFactors(double value)
		{
			ESieve eSieve = new ESieve();
			int upto = (int)value / 2;
			IEnumerable<int> primes = eSieve.GetPrimes(upto);

			return GetPrimeFactors(value, primes);
		}

		public List<double> GetPrimeFactors(double value, IEnumerable<int> primes)
		{
			var result = new List<double>();

			if (IsPrimeNumber(value))
			{
				result.Add(value);
				return result;
			}

			int upto = (int) value / 2;
			//ESieve eSieve = new ESieve();
			//IEnumerable<int> primes = eSieve.GetPrimes(upto);

			double dividedValue = value;
			//for (int i = 2; i <= upto; i++)
			foreach (var prime in primes)
			{
				//if (IsPrimeNumber(prime))
				//{
				int remainder;
				do
				{
					remainder = (int)(dividedValue % prime);
					double tempDividedValue = dividedValue / prime;
					if (remainder == 0)
					{
						result.Add(prime);
						dividedValue = tempDividedValue;
					}
				} while (remainder == 0 && dividedValue > 1);
				//}

				if (dividedValue <= 1)
					break;
			}

			return result;
		}

	}
}