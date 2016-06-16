using System;
using System.Numerics;
using Demo.ProjectEuler.Core;

namespace Demo.ProjectEuler.Tests._0036
{
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