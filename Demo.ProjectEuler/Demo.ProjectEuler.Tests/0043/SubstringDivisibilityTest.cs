using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			var permutations = permutation.GetPermutations(Enumerable.Range(0, 9).ToList()).ToList();
			_output.WriteLine("Count: {0}", permutations.Count);

			const int expected = 362880;
			Assert.Equal(expected, permutations.Count);
		}
	}

	public class SubstringDivisibility
	{
	}
}
