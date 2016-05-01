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

		[Theory]
		[InlineData(-1)]
		[InlineData(11)]
		public void ThrowExceptionIfCombinedValueInputContainsValueBiggerThan10(int badInput)
		{
			List<int> badInputs = new List<int>(1) { badInput };

			Assert.Throws<ArgumentException>(() => _sut.CombineToValue(badInputs));
		}

		//[Theory]
		//[InlineData(new[] { 8, 2 }, 82)]
		//[InlineData(new[] { 1, 6, 3 }, 163)]
		//[InlineData(new[] { 1, 6, 3, 4 }, 1634)]
		//[InlineData(new[] { 9, 4, 7, 4 }, 9474)]
		//[InlineData(new[] { 9, 4, 7, 4, 5 }, 94745)]
		//public void TestConvertEnumValuesToStringThenNumber(IEnumerable<int> input, int expectedValue)
		//{
		//	int actualValue = _sut.CombineToValue(input);

		//	Assert.Equal(expectedValue, actualValue);
		//}

		//[Theory]
		//[InlineData(4, new[] { 1634, 8208, 9474 })]
		//public void TestGetFourthPowerNumbers(int power, IEnumerable<int> expectedValues)
		//{
		//	IEnumerable<int> actualValues = _sut.GetDigitPoweredNumbers(power);

		//	var expectedValueList = expectedValues as IList<int> ?? expectedValues.ToList();
		//	var actualValueList = actualValues as IList<int> ?? actualValues.ToList();
		//	Assert.Equal(expectedValueList.Count, actualValueList.Count);
		//	Assert.True(expectedValueList.SequenceEqual(actualValueList));
		//}
	}

	public class DigitFifthPowers
	{
		/// <summary>
		/// Given a list of values, convert each value to a character and then combine into string, then convert to integer.
		/// </summary>
		/// <remarks>
		/// Given 1, 2, 3, 4 => result is 1234
		/// Given 3, 2, 1, 4 => result is 3214
		/// </remarks>
		public int CombineToValue(IEnumerable<int> values)
		{
			foreach (int value in values)
			{
				if (value < 0 || value > 9)
					throw new ArgumentException();
			}

			return 0;
		}

		public IEnumerable<int> GetDigitPoweredNumbers(int power)
		{
			var result = new List<int>();

			int rowCount = (int) Math.Pow(10, power) - 1;
			const int valueCount = 10;
			int[,,] values = new int[rowCount, power, valueCount];

			for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
			{
				List<int> tempResult = new List<int>(power);
				for (int colIndex = 0; colIndex < power; colIndex++)
				{
					for (int valIndex = 0; valIndex < valueCount; valIndex++)
					{
						values[rowIndex, colIndex, valIndex] = valIndex;
						tempResult.Add(valIndex);
					}
				}
				var poweredNumber = GetPoweredNumber(tempResult, power);
			}


			return result;
		}

		public int GetPoweredNumber(IEnumerable<int> digits, int power)
		{
			return digits.Sum(digit => (int) Math.Pow(digit, power));
		}
	}
}
