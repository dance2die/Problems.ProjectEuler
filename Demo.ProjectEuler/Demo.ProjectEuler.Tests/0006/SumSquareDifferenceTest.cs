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

		public SumSquareDifferenceTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestSampleInputForSumOfSquares()
		{
			var numbers = Enumerable.Range(1, 10);

			BigInteger actual = _sut.GetSumOfSquares(numbers);

			const int expected = 385;
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestSampleInputForSquareOfSums()
		{
			var numbers = Enumerable.Range(1, 10);

			BigInteger actual = _sut.GetSquareOfSums(numbers);

			const int expected = 3025;
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
