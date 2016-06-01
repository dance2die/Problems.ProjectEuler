﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0011
{
	public class LargestProductInAGridTest : BaseTest
	{
		private const string INPUT =
		  @"08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08
			49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00
			81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65
			52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91
			22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80
			24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50
			32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70
			67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21
			24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72
			21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95
			78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92
			16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57
			86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58
			19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40
			04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66
			88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69
			04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36
			20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16
			20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54
			01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48";

		private readonly LargestProductInAGrid _sut = new LargestProductInAGrid();

		public LargestProductInAGridTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void GetLargestProductInAGrid()
		{
			//const string input = @"08 02 22 97
			//					   49 49 99 40
			//					   81 49 31 73
			//					   52 70 95 23";
			//const int expected = 24468444;

			int result = _sut.GetLargestFourByFourProduct(INPUT);

			//Assert.Equal(expected, actual);

			_output.WriteLine(result.ToString());
		}
	}

	internal class LargestProductInAGrid
	{
		const int LIMIT = 4; // 4 x 4

		public int GetLargestFourByFourProduct(string input)
		{
			string[] rows = input.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
			int maxRowLength = rows.Length;
			int maxColLength = rows[0].Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Length;
			List<int[,]> matrices = GetMatrices(input, maxRowLength, maxColLength).ToList();

			int maxProduct = 0;
			foreach (int[,] matrix in matrices)
			{
				int maxMatrixProduct = GetMaxMatrixProduct(matrix);
				if (maxMatrixProduct > maxProduct)
					maxProduct = maxMatrixProduct;
			}

			return maxProduct;
		}

		private int GetMaxMatrixProduct(int[,] matrix)
		{
			// Get max row product
			int maxRowProduct = GetMaxRowProduct(matrix);

			// Get max column product
			int maxColumnProduct = GetMaxColumnProduct(matrix);

			// Get max diagonal product
			int maxDiagonalProduct = GetMaxDiagonalProduct(matrix);

			return Math.Max(maxRowProduct, Math.Max(maxColumnProduct, maxDiagonalProduct));
		}

		private int GetMaxRowProduct(int[,] matrix)
		{
			
		}

		private int GetMaxColumnProduct(int[,] matrix)
		{
			
		}

		private int GetMaxDiagonalProduct(int[,] matrix)
		{
			
		}

		private IEnumerable<int[,]> GetMatrices(string input, int rowLength, int colLength)
		{
			var lines = input.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
			int[,] matrix = BuildMatrix(input);

			for (int rowIndex = 0; rowIndex < rowLength - LIMIT; rowIndex++)
			{
				for (int colIndex = 0; colIndex < colLength - LIMIT; colIndex++)
				{
					int[,] smallMatrix = new int[LIMIT, LIMIT];
					for (int matrixRowIndex = 0; matrixRowIndex < LIMIT; matrixRowIndex++)
					{
						for (int matrixColIndex = 0; matrixColIndex < LIMIT; matrixColIndex++)
						{
							smallMatrix[matrixRowIndex, matrixColIndex] = matrix[rowIndex + matrixRowIndex, colIndex + matrixColIndex];
						}
					}
					yield return smallMatrix;
				}
			}
		}

		private int[,] BuildMatrix(string input)
		{
			var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			var columnLength = lines[0].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length;
			int[,] result = new int[lines.Length, columnLength];

			for (int rowIndex = 0; rowIndex < lines.Length; rowIndex++)
			{
				string line = lines[rowIndex];
				string[] columns = line.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
				for (int colIndex = 0; colIndex < columns.Length; colIndex++)
				{
					string value = columns[colIndex];
					result[rowIndex, colIndex] = Convert.ToInt32(value);
				}
			}

			return result;
		}
	}
}
