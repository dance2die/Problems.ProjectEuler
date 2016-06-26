using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0043
{
	/// <summary>
	/// Test scenarios
	/// 
	/// Generate permutation of pandigital numbers using 0~9.
	/// 
	/// Test that 1406357289 has the special properties.
	/// </summary>
	public class SubstringDivisibilityTest : BaseTest
	{
		private readonly SubstringDivisibility _sut = new SubstringDivisibility();

		public SubstringDivisibilityTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestPermutationOfPandigitalNumbers()
		{
			Permutation permutation = new Permutation();
			var permutations = permutation.GetPermutations(Enumerable.Range(0, 10).ToList()).ToList();
			_output.WriteLine("Count: {0}", permutations.Count);

			const int expected = 3628800;
			Assert.Equal(expected, permutations.Count);
		}

		[Fact]
		public void TestSpecialProperties()
		{
			//const int input = 1406357289;
			var input = new[] {1, 4, 0, 6, 3, 5, 7, 2, 8, 9 };
			const bool expected = true;

			bool actual = _sut.HasSpecialProperties(input);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			long actual = _sut.GetNumbersWithSpecialProperties();

			_output.WriteLine(actual.ToString());
			Assert.Equal(16695334890, actual);
		}
	}
}
