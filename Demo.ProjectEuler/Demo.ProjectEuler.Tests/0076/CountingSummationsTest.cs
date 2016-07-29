using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0076
{
	public class CountingSummationsTest : BaseTest
	{
		private readonly CountingSummations _sut = new CountingSummations();

		public CountingSummationsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(2, 1)]
		[InlineData(3, 2)]
		[InlineData(5, 6)]
		[InlineData(100, 100)]
		public void TestSummationCounting(int n, int expected)
		{
			int actual = _sut.GetSummationCount(n);

			Assert.Equal(expected, actual);
		}
	}

	public class CountingSummations
	{
		private readonly Permutation _permutation = new Permutation();

		public int GetSummationCount(int n)
		{
			var permutations = _permutation.GetPermutations(Enumerable.Range(1, n).ToList());
			return permutations.Count();
		}
	}
}
