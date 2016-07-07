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
		[InlineData(47, true)]
		[InlineData(349, true)]
		[InlineData(196, false)]
		public void TestLychrelNumber(int number, bool expected)
		{
			bool actual = _sut.IsLychrelNumber(number);

			Assert.Equal(expected, actual);
		}
	}

	public class LychrelNumbers
	{
		private const int MAX_ITERATION = 50;	// given on the website.
		private readonly Palindrome _palindrome = new Palindrome();

		public bool IsLychrelNumber(BigInteger number)
		{
			BigInteger currentNumber = number;

			for (int i = 0; i < MAX_ITERATION; i++)
			{
				BigInteger reversedNumber = ReverseNumber(currentNumber);
				currentNumber += reversedNumber;

				if (_palindrome.IsPalindrome(currentNumber.ToString()))
					return true;
			}

			return false;
		}

		private BigInteger ReverseNumber(BigInteger number)
		{
			string reversedNumberString = new string(number.ToString().Reverse().ToArray());
			return BigInteger.Parse(reversedNumberString);
		}
	}
}
