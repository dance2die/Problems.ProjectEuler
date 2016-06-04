using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0018
{
	public class MaximumPathSumOneTest : BaseTest
	{
		private readonly MaximumPathSum _sut = new MaximumPathSum();
		private const string SAMPLE_DATA = 
@"3
7 4
2 4 6
8 5 9 3";

		public MaximumPathSumOneTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestParsingInput()
		{
			var expected = new List<IEnumerable<int>>
			{
				new[] {3},
				new[] {7, 4},
				new[] {2, 4, 6},
				new[] {8, 5, 9, 3}
			};

			IEnumerable<IEnumerable<int>> actual = _sut.ParseInput(SAMPLE_DATA);

			Assert.True(IsMultidimensionalArraySequenceEqual<int>(expected, actual));
		}
	}

	public class MaximumPathSum
	{
		public IEnumerable<IEnumerable<int>> ParseInput(string input)
		{
			var lines = input.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
			foreach (string line in lines)
			{
				yield return line.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(s => Convert.ToInt32(s));
			}
		}
	}
}
