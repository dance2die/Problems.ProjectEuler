using System.Numerics;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0053
{
	public class CombinatoricSelectionsTest : BaseTest
	{
		private readonly CombinatoricSelections _sut = new CombinatoricSelections();

		public CombinatoricSelectionsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(5, 3, 10)]
		[InlineData(23, 10, 1144066)]
		public void TestNumberOfCominatoricSelectionCount(int n, int r, long expected)
		{
			BigInteger actual = _sut.GetCombinatoricsSelectionCount(n, r);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			const int startIndex = 23;
			const int endIndex = 100;
			long actual = _sut.GetRangeOfCombinatoricSelectionsOverOneMillion(startIndex, endIndex);

			_output.WriteLine(actual.ToString());
			const int expected = 4075;
			Assert.Equal(expected, actual);
		}
	}
}
