using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests._0003;
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
		public void TestGetAllPrimesUnder(int value, IEnumerable<double> expectedResult)
		{
			List<double> actualResult = _sut.GetPrimeNumbersUnder(value);

			Assert.True(actualResult.SequenceEqual(expectedResult));
		}
	}

	public class SummationOfPrimes : Prime
	{
		public List<double> GetPrimeNumbersUnder(double value)
		{
			var result = new List<double>();

			for (double i = 2; i <= value; i++)
			{
				//foreach (double primeNumber in result)
				//{
				//	if (i % primeNumber == 0)
				//	{
				//		break;
				//	}
				//}

				if (IsPrimeNumber(i))
					result.Add(i);
			}

			return result;
		}
	}
}
