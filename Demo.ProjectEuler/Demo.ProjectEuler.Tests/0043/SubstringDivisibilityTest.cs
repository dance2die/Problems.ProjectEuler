using System;
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
			var permutations = permutation.GetPermutations(Enumerable.Range(0, 9).ToList()).ToList();
			_output.WriteLine("Count: {0}", permutations.Count);

			const int expected = 362880;
			Assert.Equal(expected, permutations.Count);
		}

		[Fact]
		public void TestSpecialProperties()
		{
			const int input = 1406357289;
			const bool expected = true;

			bool actual = _sut.HasSpecialProperties(input);

			Assert.Equal(expected, actual);
		}
	}

	public class SubstringDivisibility
	{
		private readonly int[] _primes = {2, 3, 5, 7, 11, 13, 17};

		public bool HasSpecialProperties(int input)
		{
			string inputText = input.ToString();
			for (int i = 0; i < inputText.Length - 3; i++)
			{
				string substring = $"{inputText[i + 1]}{inputText[i + 2]}{inputText[i + 3]}";
				int number = Convert.ToInt32(substring);

				if (number % _primes[i] != 0)
					return false;
			}

			return true;
		}
	}
}
