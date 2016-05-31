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
			BigInteger actual = _sut.GetDifferenceBetweenSqaureOfSumsAndSumOfSquares(_testInput);

			const int expected = 2640;
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			var input = Enumerable.Range(1, 100);
			BigInteger result = _sut.GetDifferenceBetweenSqaureOfSumsAndSumOfSquares(input);

			_output.WriteLine(result.ToString());
		}
	}
}
