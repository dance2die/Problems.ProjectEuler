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
		[InlineData(13195, new[] { 5, 7, 13, 29})]
		public void TestGetPrimeFactors(int input, IEnumerable<int> expectedResult)
		{
			foreach (var item in expectedResult)
			{
				_output.WriteLine("Item: {0}", item);
			}
		}
	}
}
