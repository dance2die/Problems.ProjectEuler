using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0012
{
	/// <summary>
	/// 1. Generate Triangular Numbers
	/// 2. Find divisors for a number (regular factors, not prime factors)
	/// 3. Test against 7 levels of triangular numbers
	/// </summary>
	public class HighlyDivisibleTriangularNumberTest : BaseTest
	{
		private readonly HighlyDivisibleTriangularNumber _sut = new HighlyDivisibleTriangularNumber();

		public HighlyDivisibleTriangularNumberTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(1, 1)]
		[InlineData(2, 3)]
		[InlineData(3, 6)]
		[InlineData(4, 10)]
		[InlineData(5, 15)]
		[InlineData(6, 21)]
		[InlineData(7, 28)]
		public void TestGeneratingTriangularNumbers(int level, int expected)
		{
			int actual = _sut.GetTriangularNumbers(level);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(1, new [] {1})]
		[InlineData(3, new [] {1, 3})]
		[InlineData(6, new [] {1, 2, 3, 6})]
		[InlineData(10, new [] {1, 2, 5, 10})]
		[InlineData(15, new [] {1, 3, 5, 15})]
		[InlineData(21, new [] {1, 3, 7, 21})]
		[InlineData(28, new [] {1, 2, 4, 7, 14, 28})]
		public void TestGeneratingDivisors(int value, IEnumerable<int> expected)
		{
			IEnumerable<int> actual = _sut.GetDivisors(value);

			Assert.True(expected.SequenceEqual(actual));
		}

		/// <summary>
		/// Get the tringular number which matches number of divisors
		/// </summary>
		/// <param name="minimumDivisorCount">Minimum number of divisors to compare</param>
		/// <param name="expected">Minimum tringular number that has at least the miminum divisor count</param>
		[Theory]
		[InlineData(2, 3)]
		[InlineData(4, 6)]
		[InlineData(5, 28)]
		public void TestNumberOfDivisors(int minimumDivisorCount, int expected)
		{
			double actual = _sut.GetTriangularNumberForDivisorCount(minimumDivisorCount);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			const int minimumDivisorCount = 500;
			double result = _sut.GetTriangularNumberForDivisorCount(minimumDivisorCount);

			_output.WriteLine(result.ToString());
		}
	}

	internal class HighlyDivisibleTriangularNumber
	{
		public double GetTriangularNumberForDivisorCount(int minimumDivisorCount)
		{
			int level = 1;
			double triangularNumber = 0;
			int currentDivisorCount = 0;
			do
			{
				triangularNumber = GetTriangularNumbers(level);
				//currentDivisorCount = GetDivisors(triangularNumber).Count();
				currentDivisorCount = GetFactorCount(triangularNumber);

				if (currentDivisorCount >= minimumDivisorCount)
					return triangularNumber;

				level++;
			} while (minimumDivisorCount >= currentDivisorCount);

			return triangularNumber;
		}

		// http://stackoverflow.com/a/4549500/4035
		public int GetFactorCount(double numberToCheck)
		{
			int factorCount = 0;
			int sqrt = (int)Math.Ceiling(Math.Sqrt(numberToCheck));

			// Start from 1 as we want our method to also work when numberToCheck is 0 or 1.
			for (int i = 1; i < sqrt; i++)
			{
				if (numberToCheck % i == 0)
				{
					factorCount += 2; //  We found a pair of factors.
				}
			}

			// Check if our number is an exact square.
			if (sqrt * sqrt == numberToCheck)
			{
				factorCount++;
			}

			return factorCount;
		}

		public IEnumerable<int> GetDivisors(BigInteger value)
		{
			for (int i = 1; i <= value; i++)
			{
				if (value % i == 0)
					yield return i;
			}
		}

		/// <remarks>
		/// Formula on <see cref="https://en.wikipedia.org/wiki/Triangular_number"/>
		/// </remarks>
		public int GetTriangularNumbers(int level)
		{
			return (level * (level + 1)) / 2;
		}
	}
}
