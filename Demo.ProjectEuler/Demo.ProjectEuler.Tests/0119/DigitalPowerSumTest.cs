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

		[Fact]
		public void ShowResult()
		{
			const int position = 30;
			long number = _sut.GetNthPowerDigitSum(position);
			_output.WriteLine(number.ToString());
		}
	}

	public class DigitalPowerSum
	{
		private readonly NumberUtil _numberUtil = new NumberUtil();

		public long GetNthPowerDigitSum(int position)
		{
			int count = 0;
			int i = 1;

			do
			{
				if (IsDigitPower(i))
					count++;

				i++;
			} while (count <= 30);

			return count;
		}

		public int GetPowerDigitSumIndex(long number)
		{
			int count = 0;

			for (int i = 10; i <= number; i++)
			{
				if (IsDigitPower(i))
					count++;
			}

			return count;
		}

		public bool IsDigitPower(long number)
		{
			if (number < 10) return false;	// by definition

			var numberSequenceSum = _numberUtil.ToReverseSequence(number).Sum();
			int power = 1;

			do
			{
				if (numberSequenceSum == 1) return false;

				long powered = (long) Math.Pow(numberSequenceSum, power);
				if (powered == number) return true;
				if (powered > number) return false;

				power++;
			} while (true);
		}
	}
}
