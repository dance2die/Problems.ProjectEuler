using System;
using System.Collections;
using System.Collections.Generic;
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
			const int input = 595;
			var actual = _sut.GetPalindromicSums(595);

			foreach (long value in actual)
			{
				_output.WriteLine("value = {0}", value);
			}

			//const long expected = input;
			//Assert.Equal(expected, actual);

			Assert.False(true);
		}
	}

	public class PalindromicSums
	{
		private readonly Palindrome _palindrome = new Palindrome();

		public IEnumerable<long> GetPalindromicSums(int n)
		{
			for (int i = 1; i <= n; i++)
			{
				if (i == 595)
					Console.WriteLine(i);

				var currentValue = GetPoweredValuesBetween(i, n);
				if (currentValue == n && _palindrome.IsPalindrome(currentValue.ToString()))
					yield return currentValue;
			}
		}

		private long GetPoweredValuesBetween(int from, int to)
		{
			long sum = 0;
			for (int i = from; i <= to; i++)
			{
				sum += i * i;
			}

			return sum;
		}
	}
}
