using System.Collections.Generic;
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

		[Fact]
		public void TestGettingRadValue()
		{
			// example given on ProjectEuler.net
			const int n = 504;
			long actual = _sut.GetRadValue(n);

			// expected value given on ProjectEuler.net
			const long expected = 42;
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
