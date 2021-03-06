﻿using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0010
{
	public class SummationOfPrimesTest
	{
		private readonly ITestOutputHelper _output;
		private SummationOfPrimes _sut;

		public SummationOfPrimesTest(ITestOutputHelper output)
		{
			_output = output;
			_sut = new SummationOfPrimes();
		}

		[Theory]
		[InlineData(2, new double[] { 2 })]
		[InlineData(3, new double[] { 2, 3 })]
		[InlineData(4, new double[] { 2, 3 })]
		[InlineData(5, new double[] { 2, 3, 5 })]
		[InlineData(6, new double[] { 2, 3, 5})]
		[InlineData(7, new double[] { 2, 3, 5, 7 })]
		[InlineData(8, new double[] { 2, 3, 5, 7 })]
		[InlineData(9, new double[] { 2, 3, 5, 7 })]
		[InlineData(10, new double[] { 2, 3, 5, 7 })]
		[InlineData(15, new double[] { 2, 3, 5, 7, 11, 13 })]
		public void TestGetAllPrimesUnder(double value, IEnumerable<double> expectedResult)
		{
			List<double> actualResult = _sut.GetPrimeNumbersUnder(value);

			Assert.True(actualResult.SequenceEqual(expectedResult));
		}

		[Theory]
		[InlineData(-1, 0)]
		[InlineData(0, 0)]
		[InlineData(1, 0)]
		[InlineData(10, 17)]
		public void TestSumPrimesUnder(double value, double expectedResult)
		{
			double actualResult = _sut.GetPrimeSumFor(value);

			Assert.Equal(expectedResult, actualResult);
		}

		[Fact]
		public void ShowResult()
		{
			double result = _sut.GetPrimeSumFor(2000000);

			_output.WriteLine("Prime Number Sum below 2 million: {0}", result);
		}
	}
}
