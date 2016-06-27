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
			int actual = new NumberGenerator().GetPentagonalNumber(oneBasedIndex);

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
			int actual = new NumberGenerator().GetHexagonalNumber(oneBasedIndex);

			Assert.Equal(expected, actual);
		}
	}

	public class NextTriangle
	{
	}
}
