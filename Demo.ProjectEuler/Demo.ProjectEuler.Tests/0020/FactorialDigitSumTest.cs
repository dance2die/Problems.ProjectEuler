using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0020
{
	public class FactorialDigitSumTest
	{
		private readonly ITestOutputHelper _output;
		private readonly FactorialDigitSum _sut;

		public FactorialDigitSumTest(ITestOutputHelper output)
		{
			_output = output;
			_sut = new FactorialDigitSum();
		}

		[Theory]
		[InlineData(-100, 1)]
		[InlineData(0, 1)]
		[InlineData(1, 1)]
		[InlineData(2, 2)]
		[InlineData(3, 6)]
		[InlineData(4, 24)]
		[InlineData(5, 120)]
		[InlineData(6, 720)]
		[InlineData(10, 3628800)]
		public void TestFactorials(int input, double expectedResult)
		{
			BigInteger actualResult = _sut.GetFactorial(input);

			Assert.Equal(new BigInteger(expectedResult), actualResult);
		}

		[Theory]
		[InlineData(-100, new[] {'1'})]
		[InlineData(0, new[] {'1'})]
		[InlineData(1, new[] {'1'})]
		[InlineData(2, new[] {'2'})]
		[InlineData(3, new[] {'6'})]
		[InlineData(4, new[] {'2', '4'})]
		[InlineData(5, new[] {'1', '2', '0'})]
		[InlineData(6, new[] {'7', '2', '0'})]
		[InlineData(10, new[] { '3', '6', '2', '8', '8', '0', '0' })]
		public void TestEachDigit(int input, IEnumerable<char> expectedResult)
		{
			var actualResult = _sut.GetFactorialCharArray(input);

			Assert.True(actualResult.SequenceEqual(expectedResult));
		}

		[Theory]
		[InlineData(-100, 1)]
		[InlineData(0, 1)]
		[InlineData(1, 1)]
		[InlineData(2, 2)]
		[InlineData(3, 6)]
		[InlineData(4, 6)]
		[InlineData(5, 3)]
		[InlineData(6, 9)]
		[InlineData(10, 27)]
		public void SumEachDigit(int input, int expectedResult)
		{
			var actualResult = _sut.SumFactorialDigits(input);

			Assert.Equal(expectedResult, actualResult);
		}

		[Fact]
		public void ShowResult()
		{
			var result = _sut.SumFactorialDigits(100);

			_output.WriteLine("Factorial digit sum for 100!: {0}", result);
		}
	}
}
