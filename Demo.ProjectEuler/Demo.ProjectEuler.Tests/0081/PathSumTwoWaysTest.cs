using System;
using System.IO;
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

		[Fact]
		public void ShowResult()
		{
			string input = File.ReadAllText("./0081/p081_matrix.txt");

			BigInteger actual = _sut.GetPathSumTwoWays(input);

			_output.WriteLine(actual.ToString());
		}
	}

	public class PathSumTwoWays
	{
		// @ToDo: Reimplement this using idea found 
		// in http://www.mathblog.dk/project-euler-81-find-the-minimal-path-sum-from-the-top-left-to-the-bottom-right-by-moving-right-and-down/
		public BigInteger GetPathSumTwoWays(string input)
		{
			int[,] matrix = ParseInput(input);

			int rowIndex = matrix.GetLength(0) - 1;
			int colIndex = matrix.GetLength(1) - 1;
			BigInteger sum = matrix[rowIndex, colIndex];

			// Start from Bottom up.
			while (rowIndex >= 0 && colIndex > 0)
			{
				// Get "Left" value
				var leftValue = matrix[rowIndex, colIndex - 1];
				// Get "Up" value
				var upValue = matrix[rowIndex - 1, colIndex];

				if (leftValue < upValue)
				{
					sum += leftValue;
					colIndex--;
				}
				else
				{
					sum += upValue;
					rowIndex--;
				}
			}

			if (colIndex == 0)
			{
				do
				{
					var value = matrix[rowIndex - 1, colIndex];
					sum += value;
					rowIndex--;
				} while (rowIndex > 0);
			}

			if (rowIndex == 0 && colIndex > 0)
			{
				do
				{
					var value = matrix[rowIndex, colIndex - 1];
					sum += value;
					colIndex--;
				} while (colIndex > 0);
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
