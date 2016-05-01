using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0030
{
	public class DigitFifthPowersTest
	{ 
		private readonly ITestOutputHelper _output;
		private readonly DigitFifthPowers _sut;

		public DigitFifthPowersTest(ITestOutputHelper output)
		{
			_output = output;
			_sut = new DigitFifthPowers();
		}

		[Theory]
		[InlineData(new[] {1, 6, 3, 4}, 4, 1634)]
		[InlineData(new[] {8, 2, 0, 8}, 4, 8208)]
		[InlineData(new[] {9, 4, 7, 4}, 4, 9474)]
		public void TestFourthPowerCalculation(IEnumerable<int> digits, int power, int expectedValue)
		{
			int actualValue = _sut.GetPoweredNumber(digits, power);

			Assert.Equal(expectedValue, actualValue);
		}
	}

	public class DigitFifthPowers
	{
		public int GetPoweredNumber(IEnumerable<int> digits, int power)
		{
			return digits.Sum(digit => (int) Math.Pow(digit, power));
		}
	}
}
