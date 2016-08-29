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
			//int i = 2;

			//do
			//{
			//	int offset = 0;
			//	int currentValue = 0;
			//	while (currentValue <= n)
			//	{
					
			//	}

			//	i++;
			//} while (true);
			return false;
		}
	}
}
