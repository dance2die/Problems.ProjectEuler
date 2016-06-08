using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0025
{
	public class ThousandDigitFibonacciTest : BaseTest
	{
		private readonly ThousandDigitFibonacci _sut = new ThousandDigitFibonacci();

		public ThousandDigitFibonacciTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(1, 1)]
		[InlineData(2, 1)]
		[InlineData(3, 2)]
		[InlineData(4, 3)]
		[InlineData(5, 5)]
		[InlineData(6, 8)]
		[InlineData(7, 13)]
		[InlineData(8, 21)]
		[InlineData(9, 34)]
		[InlineData(10, 55)]
		[InlineData(11, 89)]
		[InlineData(12, 144)]
		public void TestLowFibonacciSequences(int term, int expected)
		{
			BigInteger actual = _sut.GetFibonacciNumberAt(term);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(1, 1)]
		[InlineData(2, 7)]
		[InlineData(3, 12)]
		public void TestGettingFirstIndexOfSpecifiedDigitLength(int digits, int expected)
		{
			int actual = _sut.GetFirstIndexOfFibonacciDigit2(digits);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			const int digitLength = 1000;

			BigInteger result = _sut.GetFirstIndexOfFibonacciDigit2(digitLength);

			_output.WriteLine(result.ToString());
		}
	}
}
