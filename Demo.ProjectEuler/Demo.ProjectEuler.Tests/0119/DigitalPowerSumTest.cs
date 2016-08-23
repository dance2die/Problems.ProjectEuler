using System.Numerics;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0119
{
	public class DigitalPowerSumTest : BaseTest
	{
		private readonly DigitalPowerSum _sut = new DigitalPowerSum();

		public DigitalPowerSumTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(1, false)]
		[InlineData(9, false)]
		[InlineData(512, true)]
		[InlineData(614656, true)]
		public void TestDigitPowerSum(long number, bool expected)
		{
			bool actual = _sut.IsDigitPower(number);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(512, 2)]
		[InlineData(614656, 10)]
		public void TestNthDigitPowerSum(long number, int expected)
		{
			int actual = _sut.GetPowerDigitSumIndex(number);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(2, 512)]
		[InlineData(10, 614656)]
		[InlineData(30, 248155780267521)]
		public void ShowResult(int position, long expected)
		{
			BigInteger actual = _sut.GetNthPowerDigitSum(position);
			_output.WriteLine(actual.ToString());

			Assert.Equal(expected, actual);
		}
	}
}
