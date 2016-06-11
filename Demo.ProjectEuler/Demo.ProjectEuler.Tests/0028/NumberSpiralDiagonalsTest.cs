using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0028
{
	public class NumberSpiralDiagonalsTest : BaseTest
	{
		private readonly NumberSpiralDiagonals _sut = new NumberSpiralDiagonals();

		public NumberSpiralDiagonalsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestGeneratingSpiralNumberList()
		{
			int[,] expected =
			{
				{21, 22, 23, 24, 25},
				{20,  7,  8,  9, 10},
				{19,  6,  1,  2, 11},
				{18,  5,  4,  3, 12},
				{17, 16, 15, 14, 13}
			};

			const int dimension = 5;
			var actual = _sut.GetSpiralNumbers(dimension);

			Assert.True(IsMultidimensionalArrayEqual(expected, actual));
		}
	}

	public class NumberSpiralDiagonals
	{
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
