using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0001
{
	public class MultiplesOf3And5Test
	{
		private readonly ITestOutputHelper _output;

		public MultiplesOf3And5Test(ITestOutputHelper output)
		{
			_output = output;
		}

		[Theory]
		[InlineData(9, 23)]
		public void TestSumUpTo(int upTo, int expectedResult)
		{
			var sut = new MultiplesOf3And5();
			var actualResult = sut.CalculateUpTo(9);

			Assert.Equal(expectedResult, actualResult);
		}
	}
}
