using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0127
{
	public class AbcHitsTest : BaseTest
	{
		private readonly AbcHits _sut = new AbcHits();

		public AbcHitsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestForRadValue()
		{
			const int n = 504;
			long actual = _sut.GetRad(n);

			const int expected = 42;
			Assert.Equal(expected, actual);
		}
	}

	public class AbcHits
	{
		private readonly Prime _prime = new Prime();

		public long GetRad(int n)
		{
			var distinctPrimeFactors = _prime.GetPrimeFactors(n).Distinct();
			var result = (long) distinctPrimeFactors.Aggregate((accu, val) => accu * val);

			return result;
		}
	}
}
