using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0001
{
	public class MultiplesOf3And5Test
	{
		private readonly ITestOutputHelper _output;

		public MultiplesOf3And5Test(ITestOutputHelper output)
		{
			_output = output;
		}

		[Fact]
		public void TestMultiplesOf3And5Set()
		{
			const int below1 = 11;
			const int below2 = 16;

			HashSet<int> expectedSet1 = new HashSet<int> {3, 5, 6, 9, 10};
			HashSet<int> expectedSet2 = new HashSet<int> {3, 5, 6, 9, 10, 12, 15};

			var sut = new MultiplesOf3And5();

			HashSet<int> actualSet1 = sut.GetMultiplesOf3And5Set(below1);
			HashSet<int> actualSet2 = sut.GetMultiplesOf3And5Set(below2);

			Assert.True(actualSet1.SetEquals(expectedSet1));
			Assert.True(actualSet2.SetEquals(expectedSet2));
		}

		[Theory]
		[InlineData(-1, 0)]
		[InlineData(0, 0)]
		[InlineData(4, 3)]
		[InlineData(6, 8)]
		[InlineData(10, 23)]
		public void TestSumUpTo(int below, int expectedResult)
		{
			var sut = new MultiplesOf3And5();
			var actualResult = sut.CalculateBelow(below);

			Assert.Equal(expectedResult, actualResult);
		}

		[Fact]
		public void ShowResultBelow1000()
		{
			
		}
	}
}
