using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0124
{
	public class OrderedRadicalsTest : BaseTest
	{
		private readonly OrderedRadicals _sut = new OrderedRadicals();

		public OrderedRadicalsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(504, 42)]
		[InlineData(1, 1)]
		[InlineData(2, 2)]
		[InlineData(4, 2)]
		[InlineData(8, 2)]
		[InlineData(3, 3)]
		[InlineData(9, 3)]
		[InlineData(5, 5)]
		[InlineData(6, 6)]
		[InlineData(7, 7)]
		[InlineData(10, 10)]
		public void TestGettingRadValue(int n, int expected)
		{
			long actual = _sut.GetRadValue(n);

			Assert.Equal(expected, actual);
		}
	}

	public class OrderedRadicals
	{
		private readonly Prime _primeManager = new Prime();

		public long GetRadValue(int n)
		{
			var result = _primeManager
				.GetPrimeFactors(n)
				.Distinct()
				// Cast double list to integer list because "GetPrimeFactors" return a list of doubles
				.Select(value => (int)value)
				.Aggregate(1, (x, y) => x * y);
			return result;
		}
	}
}
