using System;
using System.Collections.Generic;
using System.Linq;
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

		[Fact]
		public void FindLargestTwoDigitPalindromeNumbers()
		{
			const int power = 2;
			int actualValue = _sut.GetLargestPalindrome(power);

			Assert.Equal(9009, actualValue);
		}
	}

	public class LargestPalindromeProduct
	{
		public int GetLargestPalindrome(int power)
		{
			int limit = (int) Math.Pow(10, power);
			List<int> twoDigitNumbers = Enumerable.Range(0, limit).Select(x => x++).Reverse().ToList();
			var query = (
				from row in twoDigitNumbers
				from col in twoDigitNumbers
				orderby row descending, col descending 
				select new { row, col });

			foreach (var value in query)
			{
				var product = value.row * value.col;
				if (IsPalindrome(product))
					return product;
			}

			return -1;
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
