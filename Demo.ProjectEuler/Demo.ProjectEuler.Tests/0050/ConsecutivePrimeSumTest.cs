using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0050
{
	/// <summary>
	/// Test Scenarios.
	/// </summary>
	public class ConsecutivePrimeSumTest : BaseTest
	{
		private readonly ConsecutivePrimeSum _sut = new ConsecutivePrimeSum();

		public ConsecutivePrimeSumTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(50, 41)]
		[InlineData(1000, 953)]
		public void TestSampleData(int upto, int expected)
		{
			int actual = _sut.GetConsecutivePrimeSum(upto);

			Assert.Equal(expected, actual);
		}
	}

	public class ConsecutivePrimeSum
	{

		public int GetConsecutivePrimeSum(int upto)
		{
			return -1;
		}
	}
}
