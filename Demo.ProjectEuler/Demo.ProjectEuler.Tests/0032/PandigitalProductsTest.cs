using System;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0032
{
	public class PandigitalProductsTest : BaseTest
	{
		private readonly PandigitalProducts _sut = new PandigitalProducts();

		public PandigitalProductsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestIsSpecialPandigital()
		{
			var specialPandigitalCandidate = new Tuple<int, int, int>(39, 186, 7254);
			bool isSpecialPandigital = _sut.IsSpecialPandigital(specialPandigitalCandidate);

			Assert.True(isSpecialPandigital);
		}
	}

	public class PandigitalProducts
	{
		public bool IsSpecialPandigital(Tuple<int, int, int> specialPandigitalCandidate)
		{
			return false;
		}
	}
}
