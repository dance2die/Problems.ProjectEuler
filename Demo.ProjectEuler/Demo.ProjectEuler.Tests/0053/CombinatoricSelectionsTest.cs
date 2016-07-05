using System;
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
		}
	}

	public class CombinatoricSelections
	{
		public long GetRangeOfCombinatoricSelectionsOverOneMillion(int startIndex, int endIndex)
		{
			const int boundary = 1000000;
			int totalCombinatoricSelectionCount = 0;

			for (int n = startIndex; n <= endIndex; n++)
			{
				for (int r = n - 1; r >= 1; r--)
				{
					BigInteger combinatoricSelectionCount = GetCombinatoricsSelectionCount(n, r);
					if (combinatoricSelectionCount >= boundary)
						totalCombinatoricSelectionCount++;
				}
			}

			return totalCombinatoricSelectionCount;
		}

		public BigInteger GetCombinatoricsSelectionCount(int n, int r)
		{
			BigInteger numerator = GetNumerator(n, r);
			BigInteger denominator = GetDenominator(n, r);

			if (denominator == 0)
			{
				Console.WriteLine("bad");
			}

			return numerator / denominator;
		}

		private BigInteger GetNumerator(int n, int r)
		{
			BigInteger result = 1;
			for (int i = n; i > r; i--)
			{
				result *= i;
			}

			return result;
		}

		private BigInteger GetDenominator(int n, int r)
		{
			BigInteger result = 1;
			for (int i = n - r; i >= 2; i--)
			{
				result *= i;
			}

			return result;
		}
	}
}
