using System;
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
		}
	}

	public class NextTriangle
	{
		private readonly NumberGenerator _numberGenerator = new NumberGenerator();

		public long GetNextTriangleNumberGreaterThan(long startIndex)
		{
			long triangleIndex = startIndex;
			long triangleNumber = 0;

			while (true)
			{
				triangleNumber = _numberGenerator.GetTriangleNumber(triangleIndex);
				//bool hasMatchingPentagonalNumber = CheckPentagonalNumber(triangleIndex, hexagonalNumber);

				//if (hasMatchingPentagonalNumber)
				//	break;
				if (IsPentagonal(triangleNumber) && IsHexagonal(triangleNumber))
				{
					var pIndex = CheckPentagonalNumber(triangleIndex, triangleNumber);
					var hIndex = CheckHexagonalNumber(triangleIndex, triangleNumber);
					break;
				}

				triangleIndex++;
			}

			return triangleNumber;
		}

		// http://www.mathblog.dk/project-euler-44-smallest-pair-pentagonal-numbers/
		private bool IsPentagonal(long number)
		{
			double penTest = (Math.Sqrt(1 + 24 * number) + 1.0) / 6.0;
			return penTest == (long)penTest;
		}

		private bool IsHexagonal(long number)
		{
			double hexTest = (Math.Sqrt(8 * number + 1) + 1) / 4.0;
			return hexTest == (long) hexTest;
		}

		private long CheckPentagonalNumber(long triangleIndex, long hexagonalNumber)
		{
			for (long i = triangleIndex;; i--)
			{
				var pentagonalNumber = _numberGenerator.GetPentagonalNumber(i);
				if (pentagonalNumber < hexagonalNumber) return -1;
				if (pentagonalNumber == hexagonalNumber) return i;
			}

			return -1;
		}

		private long CheckHexagonalNumber(long triangleIndex, long triangleNumber)
		{
			for (long i = triangleIndex; ; i--)
			{
				var hexagonalNumber = _numberGenerator.GetHexagonalNumber(i);
				if (hexagonalNumber < triangleNumber) return -1;
				if (hexagonalNumber == triangleNumber) return i;
			}

			return -1;
		}
	}
}
