using System;
using System.Linq;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0081
{
	public class PathSumTwoWaysTest : BaseTest
	{
		private readonly PathSumTwoWays _sut = new PathSumTwoWays();

		public PathSumTwoWaysTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestParsingSampleData()
		{
			const string sampleData = 
@"131,673,234,103,18
201,96,342,965,150
630,803,746,422,111
537,699,497,121,956
805,732,524,37,331
";

			int[,] expected =
			{
				{131,673,234,103,18},
				{201,96,342,965,150},
				{630,803,746,422,111},
				{537,699,497,121,956},
				{805,732,524,37,331}
			};

			int[,] actual = _sut.ParseInput(sampleData);

			Assert.True(base.IsMultidimensionalArrayEqual(expected, actual));
		}
	}

	public class PathSumTwoWays
	{
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
