using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0024
{
	public class LexicographicPermutationsTest : BaseTest
	{
		private readonly Permutation _permutation = new Permutation();

		public LexicographicPermutationsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestPermutationOfNumbers()
		{
			// 012   021   102   120   201   210
			var expected = new List<List<int>>{
				new List<int> {0, 1, 2}, 
				new List<int> {0, 2, 1}, 
				new List<int> {1, 0, 2},
				new List<int> {1, 2, 0}, 
				new List<int> {2, 0, 1},
				new List<int> {2, 1, 0}
			};

			var actual = _permutation.GetPermutations(new List<int> {0, 1, 2});

			Assert.True(IsMultidimensionalArraySequenceEqual<int>(expected, actual));
		}

		[Fact]
		public void ShowResult()
		{
			var permutations = _permutation.GetPermutations(Enumerable.Range(0, 10).ToList());
			List<IEnumerable<int>> list = permutations.Skip(999999).Take(1).ToList();

			string result = "";
			foreach (int value in list[0])
			{
				result += value.ToString();
			}

			_output.WriteLine(result);
		}
	}
}
