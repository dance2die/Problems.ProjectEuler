using System;
using System.Numerics;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0036
{
	public class DoublebasePalindromesTest : BaseTest
	{
		private readonly DoublebasePalindromes _sut = new DoublebasePalindromes();

		public DoublebasePalindromesTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(585, "1001001001")]
		[InlineData(587, "1001001011")]
		public void TestBinaryString(int value, string expected)
		{
			string actual = _sut.GetBinaryString(value);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			BigInteger result = _sut.GetPalindromeNumberSumUnderOneMillion();

			_output.WriteLine(result.ToString());
		}
	}

	public class DoublebasePalindromes
	{
		private readonly Palindrome _palindrome = new Palindrome();

		public BigInteger GetPalindromeNumberSumUnderOneMillion()
		{
			BigInteger result = BigInteger.Zero;

			for (int i = 1; i <= 1000000; i++)
			{
				string base10Text = i.ToString();
				string base2Text = GetBinaryString(i);
				if (_palindrome.IsPalindrome(base10Text) && _palindrome.IsPalindrome(base2Text))
					result += i;
			}

			return result;
		}

		public string GetBinaryString(int value)
		{
			const int radix = 2;
			return Convert.ToString(value, radix);
		}
	}
}
