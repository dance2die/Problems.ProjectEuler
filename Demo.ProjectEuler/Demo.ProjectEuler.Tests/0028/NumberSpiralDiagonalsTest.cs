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

		[Fact]
		public void TestGettingDiagonalNumbersFromSpiralList()
		{
			var expected = new List<int>{21, 25, 7, 9, 1, 3, 5, 13, 17};

			const int dimension = 5;
			var actual = _sut.GetDiagonalNumbers(dimension);

			Assert.True(expected.SequenceEqual(actual));
		}

		[Fact]
		public void TestSumOfDiagonalNumbersFromSpiralList()
		{
			const int expected = 101;

			const int dimension = 5;
			int actual = _sut.GetDiagonalNumbers(dimension).Sum();

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			const int dimension = 1001;
			int result = _sut.GetDiagonalNumbers(dimension).Sum();

			_output.WriteLine(result.ToString());
		}
	}
}
