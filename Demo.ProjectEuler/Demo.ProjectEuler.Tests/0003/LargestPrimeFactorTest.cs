using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0003
{
	public class LargestPrimeFactorTest
	{
		private readonly ITestOutputHelper _output;

		public LargestPrimeFactorTest(ITestOutputHelper output)
		{
			_output = output;
		}

		[Theory]
		[InlineData(-1000, false)]
		[InlineData(-1, false)]
		[InlineData(0, false)]
		[InlineData(1, false)]
		[InlineData(2, true)]
		[InlineData(3, true)]
		[InlineData(4, false)]
		[InlineData(5, true)]
		[InlineData(6, false)]
		[InlineData(7, true)]
		[InlineData(8, false)]
		[InlineData(17, true)]
		[InlineData(100, false)]
		public void TestIsPrimeNumber(int value, bool expectedResult)
		{
			var sut = new LargestPrimeFactor();

			bool actualResult = sut.IsPrimeNumber(value);

			Assert.Equal(expectedResult, actualResult);
		}

		[Theory]
		[InlineData(0, new double[] {})]
		[InlineData(1, new double[] {})]
		[InlineData(2, new double[] {2})]
		[InlineData(3, new double[] {2, 3})]
		[InlineData(4, new double[] {2, 3})]
		[InlineData(5, new double[] {2, 3, 5})]
		[InlineData(6, new double[] {2, 3, 5})]
		[InlineData(7, new double[] {2, 3, 5, 7})]
		[InlineData(8, new double[] {2, 3, 5, 7})]
		[InlineData(9, new double[] {2, 3, 5, 7})]
		[InlineData(10, new double[] {2, 3, 5, 7})]
		[InlineData(11, new double[] {2, 3, 5, 7, 11})]
		[InlineData(13, new double[] {2, 3, 5, 7, 11, 13})]
		[InlineData(17, new double[] {2, 3, 5, 7, 11, 13, 17})]
		public void TestUniquePrimeNumbers(int value, IEnumerable<double> expectedResult)
		{
			var sut = new LargestPrimeFactor();

			List<double> actualResult = sut.GetPrimeNumbersUnder(value);

			Assert.True(actualResult.SequenceEqual(expectedResult));
		}

		[Theory]
		[InlineData(2, new double [] {2})]
		[InlineData(3, new double[] {3})]
		[InlineData(4, new double[] {2, 2})]
		[InlineData(5, new double[] {5})]
		[InlineData(6, new double[] {2, 3})]
		[InlineData(7, new double[] {7})]
		[InlineData(8, new double[] {2, 2, 2})]
		[InlineData(9, new double[] {3, 3})]
		[InlineData(10, new double[] {2, 5})]
		[InlineData(15, new double[] { 3, 5 })]
		[InlineData(31, new double[] { 31 })]
		[InlineData(13195, new double[] { 5, 7, 13, 29 })]
		public void TestGetPrimeFactors(double value, IEnumerable<double> expectedResult)
		{
			var sut = new LargestPrimeFactor();

			List<double> actualResult = sut.GetPrimeFactors(value);

			Assert.True(actualResult.SequenceEqual(expectedResult));
		}

		//[Fact]
		//public void ShowResult()
		//{
		//	var sut = new LargestPrimeFactor();

		//	const double testValue = 600851475143;
		//	List<double> actualResult = sut.GetPrimeFactors(testValue);

		//	_output.WriteLine("LargestPrimeFactor for {0}: {1}", testValue, actualResult);
		//}
	}
}
