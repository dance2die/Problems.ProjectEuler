using System;
using System.Linq;
using System.Numerics;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0055
{
	public class LychrelNumbersTest : BaseTest
	{
		private readonly LychrelNumbers _sut = new LychrelNumbers();

		public LychrelNumbersTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(47, false)]
		[InlineData(349, false)]
		[InlineData(196, true)]
		[InlineData(4994, true)]
		[InlineData(10677, true)]
		public void TestLychrelNumber(int number, bool expected)
		{
			bool actual = _sut.IsLychrelNumber(number);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			const int upto = 10000;

			int actual = _sut.GetLychrelNumberUpto(upto);
			_output.WriteLine(actual.ToString());
		}
	}

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
