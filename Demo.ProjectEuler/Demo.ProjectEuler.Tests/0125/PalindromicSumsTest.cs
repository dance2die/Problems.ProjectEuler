using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0125
{
	public class PalindromicSumsTest : BaseTest
	{
		private readonly PalindromicSums _sut = new PalindromicSums();

		public PalindromicSumsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestPalindromicSumForTestData()
		{
			const int input = 595;
			bool actual = _sut.IsPalindromicSum(595);

			const bool expected = true;
			Assert.Equal(expected, actual);
		}
	}

	public class PalindromicSums
	{
		private readonly Palindrome _palindrome = new Palindrome();

		public bool IsPalindromicSum(int n)
		{
			const int startingValue = 2;
			int i = startingValue;
			int currentValue = 0;

			do
			{
				currentValue = 0;
				int j = startingValue;

				while (currentValue <= n)
				{
					currentValue += j * j;
					if (currentValue == n && _palindrome.IsPalindrome(currentValue.ToString()))
						return true;
					j++;
				}

				i++;
			} while (currentValue < n);

			return false;
		}
	}
}
