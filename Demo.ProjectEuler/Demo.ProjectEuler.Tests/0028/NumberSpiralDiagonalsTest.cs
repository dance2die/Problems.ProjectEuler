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

			int prevRowLength = 0;
			int prevColLength = 0;

			do
			{

			} while (prevRowLength < dimension && prevColLength < dimension);

			return result;
		}
	}
}
