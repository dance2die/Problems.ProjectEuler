using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0006
{
	public class SumSquareDifferenceTest : BaseTest
	{
		private readonly SumSquareDifference _sut = new SumSquareDifference();
		private readonly IEnumerable<int> _testInput = Enumerable.Range(1, 10);

		public SumSquareDifferenceTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestSampleInputForSumOfSquares()
		{
			BigInteger actual = _sut.GetSumOfSquares(_testInput);

			const int expected = 385;
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestSampleInputForSquareOfSums()
		{
			BigInteger actual = _sut.GetSquareOfSums(_testInput);

			const int expected = 3025;
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestDifferenceBetweenSumOfSquaresAndSquareOfSums()
		{
			BigInteger sumOfSquares = _sut.GetSumOfSquares(_testInput);
			BigInteger squareOfSums = _sut.GetSquareOfSums(_testInput);
			BigInteger actual = squareOfSums - sumOfSquares;

			const int expected = 2640;
			Assert.Equal(expected, actual);
		}
	}

	public class SumSquareDifference
	{
		public BigInteger GetSquareOfSums(IEnumerable<int> numbers)
		{
			BigInteger result = 0;

			result = (BigInteger) Math.Pow(numbers.Sum(), 2);

			return result;
		}

		public BigInteger GetSumOfSquares(IEnumerable<int> numbers)
		{
			BigInteger result = 0;

			foreach (int number in numbers)
			{
				result += (BigInteger) Math.Pow(number, 2);
			}

			return result;
		}
	}
}
