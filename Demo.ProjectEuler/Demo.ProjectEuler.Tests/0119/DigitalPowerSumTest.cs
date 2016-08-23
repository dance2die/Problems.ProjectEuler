using System;
using System.Linq;
using Demo.ProjectEuler.Core;
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
		public void TestDigitPowerSum(int number, bool expected)
		{
			bool actual = _sut.IsDigitPower(number);

			Assert.Equal(expected, actual);
		}
	}

	public class DigitalPowerSum
	{
		private readonly NumberUtil _numberUtil = new NumberUtil();

		public bool IsDigitPower(int number)
		{
			if (number < 10) return false;	// by definition

			var numberSequenceSum = _numberUtil.ToReverseSequence(number).Sum();
			int power = 1;

			do
			{
				long powered = (long) Math.Pow(numberSequenceSum, power);
				if (powered == number) return true;
				if (powered > number) return false;

				power++;
			} while (true);
		}
	}
}
