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
			int n = 12345.ToString().ToCharArray().Length;
			const int r = 3;

			long actual = _sut.GetCombinatoricsSelectionCount(n, r);

			const long expected = 10;
			Assert.Equal(expected, actual);
		}
	}

	public class CombinatoricSelections
	{
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
