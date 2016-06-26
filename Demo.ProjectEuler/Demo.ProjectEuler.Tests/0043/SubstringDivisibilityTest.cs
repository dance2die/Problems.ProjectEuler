using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
			const int input = 1406357289;
			const bool expected = true;

			bool actual = _sut.HasSpecialProperties(input);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			BigInteger result = _sut.GetNumbersWithSpecialProperties();

			_output.WriteLine(result.ToString());
		}
	}

	public class SubstringDivisibility
	{
		private readonly int[] _primes = {2, 3, 5, 7, 11, 13, 17};

		public BigInteger GetNumbersWithSpecialProperties()
		{
			Permutation perm = new Permutation();
			var permutations = perm.GetPermutations(Enumerable.Range(0, 10).ToList()).ToList();

			BigInteger result = BigInteger.Zero;
			foreach (IEnumerable<int> permutation in permutations)
			{
				string numberText = string.Join("", permutation.Select(n => n.ToString()).ToArray());
				if (numberText.StartsWith("0")) continue;

				BigInteger number = BigInteger.Parse(numberText);

				if (HasSpecialProperties(number))
					result += number;
			}

			return result;
		}

		public bool HasSpecialProperties(BigInteger input)
		{
			string inputText = input.ToString();
			for (int i = 0; i < inputText.Length - 3; i++)
			{
				var digit1 = inputText[i + 1];
				var digit2 = inputText[i + 2];
				var digit3 = inputText[i + 3];

				string substring = $"{digit1}{digit2}{digit3}";
				int number = Convert.ToInt32(substring);

				if (number % _primes[i] != 0)
					return false;
			}

			return true;
		}
	}
}
