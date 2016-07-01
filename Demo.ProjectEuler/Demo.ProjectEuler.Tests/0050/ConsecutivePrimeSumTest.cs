using System.Globalization;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0050
{
	/// <summary>
	/// Test Scenarios.
	/// </summary>
	public class ConsecutivePrimeSumTest : BaseTest
	{
		private readonly ConsecutivePrimeSum _sut = new ConsecutivePrimeSum();

		public ConsecutivePrimeSumTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		// 2 + 3 + 5 + 7 + 11 + 13
		[InlineData(100, 41)]
		// 7 + 11 + 13 + 17 + 19 + 23 + 29 + 31 + 37 + 41 + 43 + 47 + 53 + 59 + 61 + 67 + 71 + 73 + 79 + 83 + 89
		[InlineData(1000, 953)]
		public void TestSampleData(int upto, double expected)
		{
			double actual = _sut.GetLongestConsecutivePrimeSum(upto);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			const int upto = 1000000;
			double actual = _sut.GetLongestConsecutivePrimeSum(upto);

			_output.WriteLine(actual.ToString(CultureInfo.InvariantCulture));
			const int expected = 997651;
			Assert.Equal(expected, actual);
		}
	}
}
