using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0021
{
	public class AmicableNumbersTest : BaseTest
	{
		private readonly AmicableNumbers _sut = new AmicableNumbers();

		public AmicableNumbersTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(220, 284)]
		[InlineData(284, 220)]
		public void TestDivisorNumberCounts(int value, int expected)
		{
			int actual = _sut.GetDivisorSum(value);

			Assert.Equal(expected, actual);
		}

		//[Theory]
		//public void TestBuildingDivisorNumberCountLookup(int value,)
	}

	public class AmicableNumbers
	{
		private readonly Factors _factors = new Factors();

		public int GetDivisorSum(int input)
		{
			return _factors.GetProperDivisors(input).Sum();
		}
	}
}
