using System.Collections.Generic;

namespace Demo.ProjectEuler.Tests._0028
{
	public class NumberSpiralDiagonals
	{
		public int GetDiagonalSum(int dimension)
		{
			int nextNumber = 1;
			int result = 1;

			for (int i = 2; i <= dimension; i += 2)
			{
				for (int j = 0; j <= 3; j++)
				{
					nextNumber += i;
					result += nextNumber;
				}
			}

			return result;
		}

		public List<int> GetDiagonalNumbers(int dimension)
		{
			int[,] sprialNumbers = GetSpiralNumbers(dimension);
			List<int> result = new List<int>();

			const int firstRowIndex = 0;
			int width = sprialNumbers.GetLength(firstRowIndex);

			for (int i = 0; i < width; i++)
			{
				// Get left to right (\) diagonal numbers
				var left = sprialNumbers[i, i];

				// Get Right to left (/) diagonal numbers
				var right = sprialNumbers[i, width - i - 1];

				if (left == right) // add only one middle index number
				{
					result.Add(left);
				}
				else
				{
					result.Add(left);
					result.Add(right);
				}
			}

			return result;
		}

		public int[,] GetSpiralNumbers(int dimension)
		{
			int[,] result = new int[dimension, dimension];
			int startIndex = dimension/2;
			int rowIndex = startIndex;
			int colIndex = startIndex;
			int currentValue = 1;

			int prevRowLength = 2;
			int prevColLength = 2;

			result[rowIndex, colIndex] = currentValue;

			do
			{
				// +col until prevRowLength - 1
				for (int i = 0; i < prevColLength - 1; i++)
				{
					++colIndex;
					if (colIndex >= dimension) return result;
					result[rowIndex, colIndex] = ++currentValue;
				}
				prevColLength++;

				// +row until prevColLength - 1
				for (int j = 0; j < prevRowLength - 1; j++)
				{
					result[++rowIndex, colIndex] = ++currentValue;
				}
				prevRowLength++;

				// -col until prevRowLength - 1
				for (int i2 = 0; i2 < prevColLength - 1; i2++)
				{
					result[rowIndex, --colIndex] = ++currentValue;
				}
				prevColLength++;

				// -row until prevColLength - 1
				for (int j2 = 0; j2 < prevRowLength - 1; j2++)
				{
					result[--rowIndex, colIndex] = ++currentValue;
				}
				prevRowLength++;
			} while (prevRowLength <= dimension + 1 && prevColLength <= dimension + 1);

			return result;
		}
	}
}