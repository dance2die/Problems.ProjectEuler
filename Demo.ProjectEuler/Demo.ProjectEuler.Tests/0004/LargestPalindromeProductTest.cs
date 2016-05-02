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
	}

	public class LargestPalindromeProduct
	{
		public bool IsPalindrome(int input)
		{
			if (input.ToString().Length == 1) return true;

			return false;
		}
	}
}
