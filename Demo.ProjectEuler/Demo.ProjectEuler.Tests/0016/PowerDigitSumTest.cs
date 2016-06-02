using System.Globalization;
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
}
