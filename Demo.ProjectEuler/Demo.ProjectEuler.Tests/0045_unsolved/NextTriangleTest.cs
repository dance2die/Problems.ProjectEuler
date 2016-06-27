using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0045
{
	public class NextTriangleTest : BaseTest
	{
		private readonly NextTriangle _sut = new NextTriangle();

		public NextTriangleTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(1, 1)]
		[InlineData(2, 5)]
		[InlineData(3, 12)]
		[InlineData(4, 22)]
		[InlineData(5, 35)]
		public void TestPentagonalNumberGeneration(int oneBasedIndex, int expected)
		{
			long actual = new NumberGenerator().GetPentagonalNumber(oneBasedIndex);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(1, 1)]
		[InlineData(2, 6)]
		[InlineData(3, 15)]
		[InlineData(4, 28)]
		[InlineData(5, 45)]
		public void TestHexagonalNumberGeneration(int oneBasedIndex, int expected)
		{
			long actual = new NumberGenerator().GetHexagonalNumber(oneBasedIndex);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestMatchTrianglePentagonalHexagonalMatch()
		{
			const int triangleIndex = 285;
			const int pentagonalIndex = 165;
			const int hexagonalIndex = 143;

			var numberGenerator = new NumberGenerator();
			long triangleNumber = numberGenerator.GetTriangleNumber(triangleIndex);
			long pentagonalNumber = numberGenerator.GetPentagonalNumber(pentagonalIndex);
			long hexagonalNumber = numberGenerator.GetHexagonalNumber(hexagonalIndex);

			Assert.Equal(triangleNumber, pentagonalNumber);
			Assert.Equal(hexagonalNumber, pentagonalNumber);
		}

		[Fact]
		public void FindFirstTriangleNumber()
		{
			const int expected = 40755;
			const int oneBasedIndex = 280;

			long actual = _sut.GetNextTriangleNumberGreaterThan(oneBasedIndex);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			const long startIndex = 286;

			long actual = _sut.GetNextTriangleNumberGreaterThan(startIndex);

			_output.WriteLine(actual.ToString());
			const long expected = 1533776805;
			Assert.Equal(expected, actual);
		}
	}
}
