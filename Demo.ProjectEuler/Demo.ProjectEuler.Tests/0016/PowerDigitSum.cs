using System;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace Demo.ProjectEuler.Tests._0016
{
	internal class PowerDigitSum
	{
		public BigInteger GetPowerDigitSum(int power)
		{
			BigInteger product = (BigInteger) Math.Pow(2, power);
			string productString = product.ToString(CultureInfo.InvariantCulture);
			var result = productString.Select(c => Convert.ToInt32((string) c.ToString())).Sum();

			return result;
		}
	}
}