using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0004
{
	public class LargestPalindromeProductTest
	{
		private readonly ITestOutputHelper _output;
		private readonly LargestPalindromeProduct _sut;

		public LargestPalindromeProductTest(ITestOutputHelper output)
		{
			_output = output;
			_sut = new LargestPalindromeProduct();
		}

		[Fact]
		public void ReturnTrueIfInputLengthIsOne()
		{
			const int input = 1;

			bool actualValue = _sut.IsPalindrome(input);

			Assert.True(actualValue);
		}

		[Theory]
		[InlineData(0, true)]
		[InlineData(1, true)]
		[InlineData(12, false)]
		[InlineData(11, true)]
		[InlineData(121, true)]
		[InlineData(123, false)]
		[InlineData(1234, false)]
		[InlineData(1221, true)]
		[InlineData(12345, false)]
		[InlineData(12321, true)]
		public void TestPalindromeNumber(int input, bool expectedValue)
		{
			bool actualValue = _sut.IsPalindrome(input);

			Assert.Equal(expectedValue, actualValue);
		}

		[Theory]
		[InlineData(1, 1, 11)]
		[InlineData(1, 10, 110)]
		[InlineData(12, 34, 1234)]
		public void AppendTwoNumbersAsString(int n1, int n2, int expectedResult)
		{
			int actualResult = _sut.AppendTwoNumbersAsString(n1, n2);

			Assert.Equal(expectedResult, actualResult);
		}

		//[Fact]
		//public void FindLargestTwoDigitPalindromeNumbers()
		//{
		//	int actualValue = _sut.GetLargestTwoDigitPalindrome();

		//	Assert.Equal(9009, actualValue);
		//}
	}

	public class LargestPalindromeProduct
	{
		//public int GetLargestTwoDigitPalindrome()
		//{
		//	const int largeTwoDigitNumber = 99;
		//	for (int i = largeTwoDigitNumber; i > 0; i--)
		//	{
		//		for (int j = largeTwoDigitNumber; j > 0; j--)
		//		{
		//			if (IsPalindrome(i*j))
		//				return AppendTwoNumbersAsString(i, j);
		//		}
		//	}
		//}

		public int AppendTwoNumbersAsString(int n1, int n2)
		{
			string left = n1.ToString();
			string right = n2.ToString();
			return Convert.ToInt32(left + right);
		}


		public bool IsPalindrome(int input)
		{
			if (input.ToString().Length == 1) return true;

			string inputText = input.ToString();
			int midIndex = inputText.Length / 2;
			int leftEndIndex = midIndex;
			int rightStartIndex = midIndex;

			if (inputText.Length > 2 && inputText.Length % 2 == 1)
			{
				rightStartIndex++;
			}

			string leftText = inputText.Substring(0, leftEndIndex);
			string rightText = new string(inputText.Substring(rightStartIndex).ToCharArray().Reverse().ToArray());

			return leftText == rightText;
		}
	}
}
