using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0125
{
	public class PalindromicSumsTest : BaseTest
	{
		private readonly PalindromicSums _sut = new PalindromicSums();

		public PalindromicSumsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestPalindromicSumForTestData()
		{
			const long input = 5;
			var actual = _sut.GetPalindromicSums(595).ToList();

			foreach (long value in actual)
			{
				_output.WriteLine("value = {0}", value);
			}

			const long expected = input;
			Assert.Equal(expected, actual.First());
		}

		[Fact]
		public void TestPalindromeSumsUpto1000()
		{
			const long input = 1000;
			var palindromicSums = _sut.GetPalindromicSums(input).ToList();
			long actual = palindromicSums.Sum();

			const long expected = 4164;
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			const long input = 10000000;
			var palindromicSums = _sut.GetPalindromicSums(input).ToList();
			long actual = palindromicSums.Sum();

			_output.WriteLine(actual.ToString());

			//const long expected = 4164;
			//Assert.Equal(expected, actual);
		}
	}

	public class PalindromicSums
	{
		private readonly Palindrome _palindrome = new Palindrome();

		public IEnumerable<long> GetPalindromicSums(long n)
		{
			List<long> palindromes = new List<long>();

			var limit = Math.Sqrt(n);
			for (int i = 1; i < limit; i++)
			{
				for (int j = i + 1; j <= limit; j++)
				{
					if (i == 6 && j == 12)
						Console.WriteLine(j);

					var currentValue = GetPoweredValuesBetween(i, j);
					if (palindromes.Contains(currentValue)) continue;
					if (currentValue > n) continue;

					if (_palindrome.IsPalindrome(currentValue.ToString()))
					{
						palindromes.Add(currentValue);
						//yield return currentValue;
					}
				}
			}

			return palindromes;
		}

		private long GetPoweredValuesBetween(int from, long to)
		{
			long sum = 0;
			for (long i = from; i <= to; i++)
			{
				sum += i * i;
				//if (sum == 595)
				//	Console.WriteLine(sum);

				//if (sum >= to)
				//	return sum;
			}

			return sum;
		}
	}
}
