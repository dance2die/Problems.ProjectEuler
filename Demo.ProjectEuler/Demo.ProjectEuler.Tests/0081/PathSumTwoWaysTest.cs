using System;
using System.Collections.Generic;
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
			BigInteger expected = 2427; // from the problem descripton.

			int[,] matrix = _sut.ParseInput(SAMPLE_DATA);
			int[,] summedMatrix = _sut.GetSummedMatrix(matrix);
			List<Tuple<int, int>> shortestPath = _sut.GetShortedPath(summedMatrix).ToList();

			BigInteger actual = _sut.GetShortedPathSum(matrix, shortestPath);
			_output.WriteLine(actual.ToString());

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestMatrixSumOfSampleData()
		{
			int[,] matrix = _sut.ParseInput(SAMPLE_DATA);

			int[,] summedMatrix = _sut.GetSummedMatrix(matrix);
			for (int i = 0; i < summedMatrix.GetLength(0); i++)
			{
				string line = "";
				for (int j = 0; j < summedMatrix.GetLength(1); j++)
				{
					line += summedMatrix[i, j] + " ";
				}
				_output.WriteLine(line);
			}


			List<Tuple<int, int>> shortestPath = _sut.GetShortedPath(summedMatrix).ToList();
			BigInteger actual = _sut.GetShortedPathSum(matrix, shortestPath);

			//BigInteger actual = _sut.GetPathSumTwoWays(summedMatrix);
			_output.WriteLine(actual.ToString());

			BigInteger expected = 2427; // from the problem descripton.
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			string input = File.ReadAllText("./0081/p081_matrix.txt");

			int[,] matrix = _sut.ParseInput(input);
			int[,] summedMatrix = _sut.GetSummedMatrix(matrix);
			List<Tuple<int, int>> shortestPath = _sut.GetShortedPath(summedMatrix).ToList();

			BigInteger actual = _sut.GetShortedPathSum(matrix, shortestPath);
			_output.WriteLine(actual.ToString());
		}
	}

	public class PathSumTwoWays
	{
		// @ToDo: Reimplement this using idea found 
		// in http://www.mathblog.dk/project-euler-81-find-the-minimal-path-sum-from-the-top-left-to-the-bottom-right-by-moving-right-and-down/
		public BigInteger GetShortedPathSum(int[,] matrix, List<Tuple<int, int>> shortestPath)
		{
			BigInteger result = BigInteger.Zero;
			foreach (Tuple<int, int> path in shortestPath)
			{
				result += matrix[path.Item1, path.Item2];
			}

			return result;
		}

		public IEnumerable<Tuple<int, int>> GetShortedPath(int[,] summedMatrix)
		{
			int rowLength = summedMatrix.GetLength(0) - 1;
			int colLength = summedMatrix.GetLength(1) - 1;

			int rowIndex = 0;
			int colIndex = 0;

			yield return Tuple.Create(rowIndex, colIndex);

			// Start from Top to bottom.
			while (rowIndex < rowLength && colIndex < colLength)
			{
				var rightValue = summedMatrix[rowIndex, colIndex + 1];
				var bottomValue = summedMatrix[rowIndex + 1, colIndex];

				if (rightValue < bottomValue)
					colIndex++;
				else
					rowIndex++;

				yield return Tuple.Create(rowIndex, colIndex);
			}

			yield return Tuple.Create(rowLength, colLength);
		}

		public int[,] GetSummedMatrix(int[,] matrix)
		{
			int rowLength = matrix.GetLength(0);
			int[,] summedMatrix = (int[,]) matrix.Clone();

			for (int i = rowLength - 2; i >= 0; i--)
			{
				summedMatrix[rowLength - 1, i] += summedMatrix[rowLength - 1, i + 1];
				summedMatrix[i, rowLength - 1] += summedMatrix[i + 1, rowLength - 1];
			}

			for (int i = rowLength - 2; i >= 0; i--)
			{
				for (int j = rowLength - 2; j >= 0; j--)
				{
					summedMatrix[i, j] += Math.Min(summedMatrix[i + 1, j], summedMatrix[i, j + 1]);
				}
			}

			return summedMatrix;
		}

		public BigInteger GetPathSumTwoWays2(string input)
		{
			int[,] matrix = ParseInput(input);

			int rowLength = matrix.GetLength(0);
			int colLength = matrix.GetLength(1);
			BigInteger sum = matrix[rowLength - 1, colLength - 1];

			// Start from Bottom up.
			int rowIndex = rowLength - 1;
			int colIndex = colLength - 1;
			while (rowIndex >= 0)
			{
				Tuple<Tuple<int, int>, BigInteger> sumIndex = GetLowestSum(matrix, rowIndex, colIndex);
				sum += sumIndex.Item2;

				rowIndex = sumIndex.Item1.Item1;
				colIndex = sumIndex.Item1.Item2;
			}

			return sum;
		}

		/// <returns>
		/// Tuple
		/// 1. new rowIndex
		/// 2. new colIndex
		/// 3. Sum
		/// </returns>
		private Tuple<Tuple<int, int>, BigInteger> GetLowestSum(int[,] matrix, int rowIndex, int colIndex)
		{
			Tuple<int, int> position = new Tuple<int, int>(rowIndex, colIndex);

			BigInteger previousSum = int.MaxValue;
			for (int currentColIndex = colIndex - 1; currentColIndex >= 0; currentColIndex--)
			{
				int leftValue;
				if (currentColIndex > 0)
					leftValue = matrix[rowIndex, currentColIndex - 1];
				else
					leftValue = matrix[rowIndex, currentColIndex];


				int upValue;
				if (rowIndex > 0)
					upValue = matrix[rowIndex - 1, currentColIndex];
				else
					upValue = matrix[rowIndex, currentColIndex];

				var currentValue = matrix[rowIndex, currentColIndex];

				BigInteger currentSum;
				if (leftValue < upValue)
					currentSum = currentValue + leftValue;
				else
					currentSum = currentValue + upValue;

				if (currentSum < previousSum)
				{
					position = Tuple.Create(rowIndex, currentColIndex);
					previousSum = currentSum;
				}
			}

			return Tuple.Create(position, previousSum);
		}

		public BigInteger GetPathSumTwoWays(string input)
		{
			return GetPathSumTwoWays(ParseInput(input));
		}

		public BigInteger GetPathSumTwoWays(int[,] matrix)
		{
			int rowIndex = matrix.GetLength(0) - 1;
			int colIndex = matrix.GetLength(1) - 1;
			BigInteger sum = matrix[rowIndex, colIndex];

			// Start from Bottom up.
			while (rowIndex > 0 && colIndex > 0)
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
