using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0024
{
	public class LexicographicPermutationsTest : BaseTest
	{
		private readonly LexicographicPermutations _sut = new LexicographicPermutations();
		private readonly Factors _factors = new Factors();

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

			var actual = _factors.GetPermutations(new List<int> {0, 1, 2}).ToList();

			Assert.True(IsMultidimensionalArraySequenceEqual<int>(expected, actual));
		}
	}

	public class LexicographicPermutations
	{
	}
}
