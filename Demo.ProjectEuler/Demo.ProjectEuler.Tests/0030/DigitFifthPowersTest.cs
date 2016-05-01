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
		[InlineData(4, new[] { 1634, 8208, 9474 })]
		public void TestGetFourthPowerNumbers(int power, IEnumerable<int> expectedValues)
		{
			IEnumerable<int> actualValues = _sut.GetDigitPoweredNumbers(power);

			var expectedValueList = expectedValues as IList<int> ?? expectedValues.ToList();
			var actualValueList = actualValues as IList<int> ?? actualValues.ToList();
			Assert.Equal(expectedValueList.Count, actualValueList.Count);
			Assert.True(expectedValueList.SequenceEqual(actualValueList));
		}
	}

	public class DigitFifthPowers
	{
		public IEnumerable<int> GetDigitPoweredNumbers(int power)
		{
			int rowCount = (int)Math.Pow(10, power) - 1;
			const int valueCount = 10;
			int[,,] values = new int[rowCount, power, valueCount];

			for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
			{
				for (int valIndex = 0; valIndex < valueCount; valIndex++)
				{
					List<int> tempResult = new List<int>(power);
					for (int colIndex = 0; colIndex < power; colIndex++)
					{
						values[rowIndex, colIndex, valIndex] = valIndex;

						//tempResult.Add(valIndex);
					}

					//int poweredNumber = GetPoweredNumber(tempResult, power);
					//int combinedValue = CombineToValue(tempResult);
					//if (poweredNumber == combinedValue)
					//	yield return combinedValue;
				}
			}

			//Dictionary<int, IEnumerable<int>> map = new Dictionary<int, IEnumerable<int>>(rowCount);
			//for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
			//{
			//	int[] mapValues = new int[power];
			//	for (int powerIndex = 0; powerIndex < power; powerIndex++)
			//	{

			//		map.Add(rowIndex, mapValues);
			//	}
			//}

			//var result = Permutations(Enumerable.Range(0, 4).ToArray());


			yield break;
		}

		//// http://stackoverflow.com/a/13022090/4035
		//public static IEnumerable<T[]> Permutations<T>(T[] values, int fromInd = 0)
		//{
		//	if (fromInd + 1 == values.Length)
		//		yield return values;
		//	else
		//	{
		//		foreach (var v in Permutations(values, fromInd + 1))
		//			yield return v;

		//		for (var i = fromInd + 1; i < values.Length; i++)
		//		{
		//			SwapValues(values, fromInd, i);
		//			foreach (var v in Permutations(values, fromInd + 1))
		//				yield return v;
		//			SwapValues(values, fromInd, i);
		//		}
		//	}
		//}

		//private static void SwapValues<T>(T[] values, int pos1, int pos2)
		//{
		//	if (pos1 != pos2)
		//	{
		//		T tmp = values[pos1];
		//		values[pos1] = values[pos2];
		//		values[pos2] = tmp;
		//	}
		//}

		//// http://stackoverflow.com/a/10630026/4035
		//public IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
		//{
		//	if (length == 1)
		//		return list.Select(t => new [] { t });

		//	return GetPermutations(list, length - 1)
		//		.SelectMany(t => list.Where(e => !t.Contains(e)), (t1, t2) => t1.Concat(new [] { t2 }));
		//}

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
