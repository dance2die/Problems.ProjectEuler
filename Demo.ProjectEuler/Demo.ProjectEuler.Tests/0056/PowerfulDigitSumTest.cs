using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0056
{
	public class PowerfulDigitSumTest : BaseTest
	{
		private readonly PowerfulDigitSum _sut = new PowerfulDigitSum();

		public PowerfulDigitSumTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(2, 2, 4)]
		[InlineData(2, 12, 19)]
		[InlineData(12, 12, 54)]
		[InlineData(33, 2, 18)]
		[InlineData(1, 100, 1)]
		[InlineData(10, 100, 1)]
		[InlineData(100, 100, 1)]
		public void TestSumOfPowerDigitSums(int a, int b, long expected)
		{
			long actual = _sut.GetPowerDigitSum(a, b);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			long actual = _sut.GetMaxDigitSum();
			_output.WriteLine(actual.ToString());

			const long expected = 972;
			Assert.Equal(expected, actual);
		}
	}
}
