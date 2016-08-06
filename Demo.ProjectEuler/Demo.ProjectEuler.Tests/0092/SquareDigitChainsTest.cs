using System;
using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0092
{
	public class SquareDigitChainsTest : BaseTest
	{
		private readonly SquareDigitChains _sut = new SquareDigitChains();

		public SquareDigitChainsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(1, true)]
		[InlineData(2, false)]
		[InlineData(7, true)]
		[InlineData(10, true)]
		[InlineData(13, true)]
		[InlineData(20, false)]
		[InlineData(269, false)]
		[InlineData(339, false)]
		[InlineData(469, true)]
		[InlineData(900, false)]
		[InlineData(1000, true)]
		public void TestHappyNumberCheck(long n, bool expected)
		{
			bool actual = _sut.IsHappyNumber(n, new HashSet<long>());

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			const int upto = 10000000;

			HashSet<long> happyNumber = new HashSet<long>();
			for (int i = 1; i <= upto; i++)
			{
				if (_sut.IsHappyNumber(i, happyNumber))
					happyNumber.Add(i);
			}

			_output.WriteLine("Result: {0}", upto - happyNumber.Count);
		}
	}

	public class SquareDigitChains
	{
		/// <summary>
		/// Check happy number <see cref="https://en.wikipedia.org/wiki/Happy_number"/>
		/// </summary>
		public bool IsHappyNumber(long n, HashSet<long> globalSeenNumbers)
		{
			HashSet<long> seenNumbers = new HashSet<long>();

			long startingNumber = n;
			while (n > 1 && !seenNumbers.Contains(n))
			{
				if (n == 89) return false;
				if (globalSeenNumbers.Contains(n)) return true;

				seenNumbers.Add(n);
				n = MapSquare(n);
			}

			return n == 1;
		}

		private long MapSquare(long n)
		{
			return n.ToString().ToCharArray().Select(c => Square(Convert.ToInt64(c.ToString()))).Sum();
		}

		private long Square(long n)
		{
			return n * n;
		}
	}
}
