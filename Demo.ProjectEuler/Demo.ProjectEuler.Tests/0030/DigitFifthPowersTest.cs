using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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
		[InlineData(new[] { 1, 6, 3, 4 }, 4, 1634)]
		[InlineData(new[] { 8, 2, 0, 8 }, 4, 8208)]
		[InlineData(new[] { 9, 4, 7, 4 }, 4, 9474)]
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

		[Theory]
		[InlineData(new[] { 8, 2 }, 82)]
		[InlineData(new[] { 1, 6, 3 }, 163)]
		[InlineData(new[] { 1, 6, 3, 4 }, 1634)]
		[InlineData(new[] { 9, 4, 7, 4 }, 9474)]
		[InlineData(new[] { 9, 4, 7, 4, 5 }, 94745)]
		public void TestConvertEnumValuesToStringThenNumber(IEnumerable<int> input, int expectedValue)
		{
			int actualValue = _sut.CombineToValue(input);

			Assert.Equal(expectedValue, actualValue);
		}

		[Theory]
		[InlineData(new[] { 1634, 8208, 9474 })]
		public void TestGetFourthPowerNumbers(IEnumerable<int> expectedValues)
		{
			IEnumerable<int> actualValues = _sut.GetDigitFourthPoweredNumbers();

			var expectedValueList = expectedValues as IList<int> ?? expectedValues.ToList();
			var actualValueList = actualValues as IList<int> ?? actualValues.ToList();

			Assert.Equal(expectedValueList.Count, actualValueList.Count);
			Assert.True(expectedValueList.SequenceEqual(actualValueList));
			const int expectedValue = 19316;
			Assert.Equal(expectedValue, actualValueList.Sum());
		}

		[Fact]
		public void ShowResult()
		{
			//IEnumerable<int> actualValues = _sut.GetDigitFifthPoweredNumbers();
		}
	}

	public class DigitFifthPowers
	{
		public IEnumerable<int> GetDigitFourthPoweredNumbers()
		{
			const int power = 4;
			List<int> colList = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

			var query = (
				from c1 in colList
				from c2 in colList
				from c3 in colList
				from c4 in colList
				select new {c1, c2, c3, c4});

			foreach (var val in query)
			{
				Console.WriteLine("{0},{1},{2},{3}", val.c1, val.c2, val.c3, val.c4);

				List<int> tempResult = new List<int> { val.c1, val.c2, val.c3, val.c4 };
				int poweredNumber = GetPoweredNumber(tempResult, power);
				int combinedValue = CombineToValue(tempResult);
				if (poweredNumber == combinedValue && IsDigitCountSameAsPower(poweredNumber, power))
					yield return combinedValue;
			}

			yield break;
		}

		/// <summary>
		/// As 1 = 1^4 is not a sum it is not included
		/// </summary>
		private bool IsDigitCountSameAsPower(int value, int power)
		{
			return value.ToString(CultureInfo.InvariantCulture).Length == power;
		}
		

		/// <summary>
		/// Given a list of values, convert each value to a character and then combine into string, then convert to integer.
		/// </summary>
		/// <remarks>
		/// Given 1, 2, 3, 4 => result is 1234
		/// Given 3, 2, 1, 4 => result is 3214
		/// </remarks>
		public int CombineToValue(IEnumerable<int> values)
		{
			string valueBuffer = "";
			foreach (int value in values)
			{
				if (value < 0 || value > 9)
					throw new ArgumentException();

				string valueText = value.ToString(CultureInfo.InvariantCulture);
				valueBuffer += valueText;
			}

			return Convert.ToInt32(valueBuffer);
		}

		public int GetPoweredNumber(IEnumerable<int> digits, int power)
		{
			return digits.Sum(digit => (int)Math.Pow(digit, power));
		}
	}
}
