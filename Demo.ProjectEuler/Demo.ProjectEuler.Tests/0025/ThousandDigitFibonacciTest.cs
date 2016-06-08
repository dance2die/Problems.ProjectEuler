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

	public class ThousandDigitFibonacci
	{
		public int GetFirstIndexOfFibonacciDigit2(int targetDigitLength)
		{
			if (targetDigitLength == 1)
				return 1;

			int currentDigitLength = 0;
			int index = 2;
			BigInteger[] previousNumbers = { 1, 1 };
			while (currentDigitLength < targetDigitLength)
			{
				var fibonacciNumber = previousNumbers[0] + previousNumbers[1];
				previousNumbers[0] = previousNumbers[1];
				previousNumbers[1] = fibonacciNumber;

				currentDigitLength = fibonacciNumber.ToString().Length;
				index++;
			}

			return index;
		}

		public int GetFirstIndexOfFibonacciDigit(int targetDigitLength)
		{
			if (targetDigitLength == 1)
				return 1;

			int currentDigitLength = 0;
			int index = 0;
			while (currentDigitLength < targetDigitLength)
			{
				//var fibonacciNumber = Fibonacci(index);
				var fibonacciNumber = GetFibonacciNumberAt(index);

				currentDigitLength = fibonacciNumber.ToString().Length;
				index++;
			}

			return index;
		}

		// Fast doubling algorithm
		// https://www.nayuki.io/page/fast-fibonacci-algorithms
		// https://www.nayuki.io/res/fast-fibonacci-algorithms/fastfibonacci.cs
		private static BigInteger Fibonacci(int n)
		{
			BigInteger a = BigInteger.Zero;
			BigInteger b = BigInteger.One;
			for (int i = 31; i >= 0; i--)
			{
				BigInteger d = a * (b * 2 - a);
				BigInteger e = a * a + b * b;
				a = d;
				b = e;
				if ((((uint)n >> i) & 1) != 0)
				{
					BigInteger c = a + b;
					a = b;
					b = c;
				}
			}
			return a;
		}

		public BigInteger GetFibonacciNumberAt(int term)
		{
			if (term == 1 || term == 2)
				return 1;

			BigInteger result = 0;
			BigInteger[] previousNumbers = {1, 1};
			for (int i = 2; i < term; i++)
			{
				result = previousNumbers[0] + previousNumbers[1];
				previousNumbers[0] = previousNumbers[1];
				previousNumbers[1] = result;
			}

			return result;
		}
	}
}
