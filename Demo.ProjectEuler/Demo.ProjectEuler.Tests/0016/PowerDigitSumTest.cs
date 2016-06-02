using System;
using System.Globalization;
using System.Linq;
using System.Numerics;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0016
{
	public class PowerDigitSumTest : BaseTest
	{
		private readonly PowerDigitSum _sut = new PowerDigitSum();

		public PowerDigitSumTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestSampleData()
		{
			const int power = 15;
			BigInteger expected = 26;

			BigInteger actual = _sut.GetPowerDigitSum(power);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			const int power = 1000;
			BigInteger result = _sut.GetPowerDigitSum(power);

			_output.WriteLine(result.ToString(CultureInfo.InvariantCulture));
		}
	}

	internal class PowerDigitSum
	{
		public BigInteger GetPowerDigitSum(int power)
		{
			BigInteger product = (BigInteger) Math.Pow(2, power);
			string productString = product.ToString(CultureInfo.InvariantCulture);
			var result = productString.Select(c => Convert.ToInt32(c.ToString())).Sum();

			return result;
		}
	}
}
