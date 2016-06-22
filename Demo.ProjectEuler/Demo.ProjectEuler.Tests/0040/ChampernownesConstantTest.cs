using System;
using System.Linq;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0040
{
	public class ChampernownesConstantTest : BaseTest
	{
		private readonly ChampernownesConstant _sut = new ChampernownesConstant();

		public ChampernownesConstantTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(1, "1")]
		[InlineData(2, "12")]
		[InlineData(10, "12345678910")]
		[InlineData(12, "123456789101112")]
		[InlineData(21, "123456789101112131415161718192021")]
		public void TestGeneratingNumberStringUpto(int upto, string expected)
		{
			string actual = _sut.GetNumberStringUpto(upto);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(21, 9, 9)]
		[InlineData(21, 10, 1)]
		[InlineData(21, 11, 0)]
		[InlineData(21, 12, 1)]
		public void TestGettingDigitAt(int upto, int oneBasedIndex, int expected)
		{
			string stringNumber = _sut.GetNumberStringUpto(upto);
			int actual = _sut.GetDigitValueAt(stringNumber, oneBasedIndex);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			const int upto = 1000000;
			string stringNumber = _sut.GetNumberStringUpto(upto);

			int value1 = _sut.GetDigitValueAt(stringNumber, 1);
			int value2 = _sut.GetDigitValueAt(stringNumber, 10);
			int value3 = _sut.GetDigitValueAt(stringNumber, 100);
			int value4 = _sut.GetDigitValueAt(stringNumber, 1000);
			int value5 = _sut.GetDigitValueAt(stringNumber, 10000);
			int value6 = _sut.GetDigitValueAt(stringNumber, 100000);
			int value7 = _sut.GetDigitValueAt(stringNumber, 1000000);

			int actual = value1 * value2 * value3 * value4 * value5 * value6 * value7;
			_output.WriteLine(actual.ToString());

			const int expected = 210;
			Assert.Equal(expected, actual);
		}
	}

	public class ChampernownesConstant
	{
		public int GetDigitValueAt(string stringNumber, int oneBasedIndex)
		{
			return Convert.ToInt32(stringNumber[oneBasedIndex - 1].ToString());
		}

		public string GetNumberStringUpto(int upto)
		{
			return string.Join("", Enumerable.Range(1, upto).Select(number => number.ToString()));
		}
	}
}
