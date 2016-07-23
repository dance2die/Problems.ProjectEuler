using System;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0071
{
	public class OrderedFractionsTest : BaseTest
	{
		private readonly OrderedFractions _sut = new OrderedFractions();

		public OrderedFractionsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestSampleData()
		{
			const int d = 8;

			Tuple<int, int> actual = _sut.GetPreviousNumberBefore3Over7(d);

			Tuple<int, int> expected = new Tuple<int, int>(2, 5);

			Assert.True(expected.Equals(actual));
		}
	}

	public class OrderedFractions
	{
		public Tuple<int, int> GetPreviousNumberBefore3Over7(int d)
		{
			return null;
		}
	}
}
