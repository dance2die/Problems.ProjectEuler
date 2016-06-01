using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.ProjectEuler.Tests._0011
{
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
			int maxProduct = 0;
			for (int rowIndex = 0; rowIndex < LIMIT; rowIndex++)
			{
				int product = 1;
				for (int colIndex = 0; colIndex < LIMIT; colIndex++)
				{
					product *= matrix[rowIndex, colIndex];
				}

				if (product > maxProduct)
					maxProduct = product;
			}

			return maxProduct;
		}

		private int GetMaxColumnProduct(int[,] matrix)
		{
			int maxProduct = 0;
			for (int colIndex = 0; colIndex < LIMIT; colIndex++)
			{
				int product = 1;
				for (int rowIndex = 0; rowIndex < LIMIT; rowIndex++)
				{
					product *= matrix[colIndex, rowIndex];
				}

				if (product > maxProduct)
					maxProduct = product;
			}

			return maxProduct;
		}

		private int GetMaxDiagonalProduct(int[,] matrix)
		{
			int rightDiagonalProduct = 1;
			for (int i = 0; i < LIMIT; i++)
			{
				rightDiagonalProduct *= matrix[i, i];
			}

			int leftDiagonalProduct = 1;
			for (int i = LIMIT - 1; i >= 0; i--)
			{
				leftDiagonalProduct *= matrix[i, LIMIT - i - 1];
			}

			return Math.Max(rightDiagonalProduct, leftDiagonalProduct);
		}

		private IEnumerable<int[,]> GetMatrices(string input, int rowLength, int colLength)
		{
			var lines = input.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
			int[,] matrix = BuildMatrix(input);

			for (int rowIndex = 0; rowIndex <= rowLength - LIMIT; rowIndex++)
			{
				for (int colIndex = 0; colIndex <= colLength - LIMIT; colIndex++)
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
				string[] columns = line.Split(new[] {" ", "\t"}, StringSplitOptions.RemoveEmptyEntries);
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