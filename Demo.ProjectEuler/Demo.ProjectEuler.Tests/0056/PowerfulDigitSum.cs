using System;
using System.Linq;
using System.Numerics;

namespace Demo.ProjectEuler.Tests._0056
{
	public class PowerfulDigitSum
	{
		public long GetMaxDigitSum()
		{
			const int limit = 100;

			long maxDigitSum = 0;
			for (int a = 1; a < limit; a++)
			{
				for (int b = 1; b < limit; b++)
				{
					long digitSum = GetPowerDigitSum(a, b);
					if (digitSum > maxDigitSum)
						maxDigitSum = digitSum;
				}
			}

			return maxDigitSum;
		}

		public long GetPowerDigitSum(int a, int b)
		{
			BigInteger powered = BigInteger.One;
			for (int i = 0; i < b; i++)
			{
				powered *= a;
			}


			return powered.ToString().Select(c => Convert.ToInt32((string) c.ToString())).Sum();
		}
	}
}