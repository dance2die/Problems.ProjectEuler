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

		[Fact]
		public void TestNumberOfCominatoricSelectionCount()
		{
			const int input = 12345;
			const int expected = 10;

			int actual = _sut.GetCombinatoricsSelectionCount(input);

			Assert.Equal(expected, actual);
		}
	}

	public class CombinatoricSelections
	{
		public int GetCombinatoricsSelectionCount(int input)
		{
			return -1;
		}
	}
}
