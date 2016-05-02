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

		[Fact]
		public void FindLargestThreeDigitPalindromeNumbers()
		{
			const int power = 3;
			int actualValue = _sut.GetLargestPalindrome(power);

			_output.WriteLine("Result: {0}", actualValue);
		}
	}
}
