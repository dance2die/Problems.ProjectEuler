using System;

namespace Demo.ProjectEuler.Tests._0003
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
	}
}