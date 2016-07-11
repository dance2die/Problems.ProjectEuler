using System;
using System.Linq;
using System.Numerics;
using Demo.ProjectEuler.Core;

namespace Demo.ProjectEuler.Tests._0055
{
	public class LychrelNumbers
	{
		private const int MAX_ITERATION = 50;	// given on the website.

		public int GetLychrelNumberUpto(int upto)
		{
			int result = 0;
			for (int i = 0; i < upto; i++)
			{
				if (IsLychrelNumber(i))
					result++;
				else
					Console.WriteLine(i);
			}

			return result;
		}

		private readonly Palindrome _palindrome = new Palindrome();

		public bool IsLychrelNumber(BigInteger number)
		{
			BigInteger currentNumber = number;

			for (int i = 0; i < MAX_ITERATION; i++)
			{
				currentNumber += ReverseNumber(currentNumber);
				if (_palindrome.IsPalindrome(currentNumber.ToString()))
					return false;
			}

			return true;
		}

		private BigInteger ReverseNumber(BigInteger number)
		{
			string reversedNumberString = new string(number.ToString().Reverse().ToArray());
			return BigInteger.Parse(reversedNumberString);
		}
	}
}