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
			long actual = _sut.GetCombinatoricsSelectionCount(n, r);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			const int startIndex = 1;
			const int endIndex = 100;
			long actual = _sut.GetRangeOfCombinatoricSelectionsOverOneMillion(startIndex, endIndex);

			_output.WriteLine(actual.ToString());
		}
	}

	public class CombinatoricSelections
	{
		public long GetRangeOfCombinatoricSelectionsOverOneMillion(int startIndex, int endIndex)
		{
			return -1;
		}

		public long GetCombinatoricsSelectionCount(int n, int r)
		{
			long numerator = GetNumerator(n, r);
			long denominator = GetDenominator(n, r);

			return numerator / denominator;
		}

		private long GetNumerator(int n, int r)
		{
			long result = 1;
			for (int i = n; i > r; i--)
			{
				result *= i;
			}

			return result;
		}

		private long GetDenominator(int n, int r)
		{
			long result = 1;
			for (int i = (n - r); i >= 2; i--)
			{
				result *= i;
			}

			return result;
		}
	}
}
