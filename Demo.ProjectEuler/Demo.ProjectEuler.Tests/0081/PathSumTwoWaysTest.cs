using System;
using System.Linq;
using System.Numerics;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0081
{
	public class PathSumTwoWaysTest : BaseTest
	{
		private readonly PathSumTwoWays _sut = new PathSumTwoWays();
		const string SAMPLE_DATA =
@"131,673,234,103,18
201,96,342,965,150
630,803,746,422,111
537,699,497,121,956
805,732,524,37,331
";

		public PathSumTwoWaysTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestParsingSampleData()
		{
			int[,] expected =
			{
				{131,673,234,103,18},
				{201,96,342,965,150},
				{630,803,746,422,111},
				{537,699,497,121,956},
				{805,732,524,37,331}
			};

			int[,] actual = _sut.ParseInput(SAMPLE_DATA);

			Assert.True(base.IsMultidimensionalArrayEqual(expected, actual));
		}

		[Fact]
		public void TestGettingResultUsingSampleData()
		{
			BigInteger expected = 2427;	// from the problem descripton.

			BigInteger actual = _sut.GetPathSumTwoWays(SAMPLE_DATA);

			Assert.Equal(expected, actual);
		}
	}

	public class PathSumTwoWays
	{
		public BigInteger GetPathSumTwoWays(string input)
		{
			int[,] matrix = ParseInput(input);

			int rowIndex = 0;
			int colIndex = 0;
			BigInteger sum = matrix[rowIndex, colIndex];

			while (rowIndex < matrix.GetLength(0) - 1 &&
				   colIndex < matrix.GetLength(1) - 1)
			{
				// Get "Right" value
				var rightValue = matrix[rowIndex, colIndex + 1];
				// Get "Bottom" value
				var bottomValue = matrix[rowIndex + 1, colIndex];

				if (bottomValue < rightValue)
				{
					sum += bottomValue;
					rowIndex++;
				}
				else
				{
					sum += rightValue;
					colIndex++;
				}
			}

			return sum;
		}

		public int[,] ParseInput(string input)
		{
			var rows = input.Split(new[] {Environment.NewLine, "\r", "\n"}, StringSplitOptions.RemoveEmptyEntries);
			var rowCount = rows.Length;
			var colCount = rows.First().Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Length;

			int[,] result = new int[rowCount, colCount];
			for (int i = 0; i < rowCount; i++)
			{
				string[] numberTexts = rows[i].Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
				for (int j = 0; j < numberTexts.Length; j++)
				{
					result[i, j] = Convert.ToInt32(numberTexts[j]);
				}
			}

			return result;
		}
	}
}
