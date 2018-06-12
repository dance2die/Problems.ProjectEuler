using System.Linq;
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

			var expected1 = new[] { 3, 5, 6, 9, 10};
			var expected2 = new [] {3, 5, 6, 9, 10, 12, 15};

			var sut = new MultiplesOf3And5();

			var actual1 = sut.GetMultiplesOf3And5Set(below1);
			var actual2 = sut.GetMultiplesOf3And5Set(below2);

			Assert.True(actual1.SequenceEqual(expected1));
			Assert.True(actual2.SequenceEqual(expected2));
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
			var sut = new MultiplesOf3And5();
			var actualResult = sut.CalculateBelow(1000);
			_output.WriteLine($"Result Under 1000: {actualResult}");
		}
	}
}
