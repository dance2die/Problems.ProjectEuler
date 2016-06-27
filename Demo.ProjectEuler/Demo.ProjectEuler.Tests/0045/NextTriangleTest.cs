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

		[Fact]
		public void TestMatchTrianglePentagonalHexagonalMatch()
		{
			const int triangleIndex = 285;
			const int pentagonalIndex = 165;
			const int hexagonalIndex = 143;

			var numberGenerator = new NumberGenerator();
			int triangleNumber = numberGenerator.GetTriangleNumber(triangleIndex);
			int pentagonalNumber = numberGenerator.GetPentagonalNumber(pentagonalIndex);
			int hexagonalNumber = numberGenerator.GetHexagonalNumber(hexagonalIndex);

			Assert.Equal(triangleNumber, pentagonalNumber);
			Assert.Equal(hexagonalNumber, pentagonalNumber);
		}

		[Fact]
		public void FindFirstTriangleNumber()
		{
			const int expected = 285;
			const int oneBasedIndex = 280;

			int actual = _sut.GetNextTriangleNumberGreaterThan(oneBasedIndex);

			Assert.Equal(expected, actual);
		}
	}

	public class NextTriangle
	{
		private readonly NumberGenerator _numberGenerator = new NumberGenerator();

		public int GetNextTriangleNumberGreaterThan(int startIndex)
		{
			int triangleIndex = startIndex;

			while (true)
			{
				int triangleNumber = _numberGenerator.GetTriangleNumber(triangleIndex);
				bool hasMatchingPentagonalNumber = CheckPentagonalNumber(triangleIndex, triangleNumber);
				bool hasMatchingHexagonalNumber = CheckHexagonalNumber(triangleIndex, triangleNumber);
				if (hasMatchingPentagonalNumber && hasMatchingHexagonalNumber)
					break;

				triangleIndex++;
			}

			return triangleIndex;
		}

		private bool CheckPentagonalNumber(int triangleIndex, int triangleNumber)
		{
			for (int i = triangleIndex; i >= 1; i--)
			{
				var pentagonalNumber = _numberGenerator.GetPentagonalNumber(i);
				if (pentagonalNumber == triangleNumber)
					return true;
			}

			return false;
		}

		private bool CheckHexagonalNumber(int triangleIndex, int triangleNumber)
		{
			for (int i = triangleIndex; i >= 1; i--)
			{
				var hexagonalNumber = _numberGenerator.GetHexagonalNumber(i);
				if (hexagonalNumber == triangleNumber)
					return true;
			}

			return false;
		}
	}
}
