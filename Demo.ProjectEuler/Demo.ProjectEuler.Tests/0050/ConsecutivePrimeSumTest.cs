using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0050
{
	public class ConsecutivePrimeSumTest : BaseTest
	{
		private readonly ConsecutivePrimeSum _sut = new ConsecutivePrimeSum();

		public ConsecutivePrimeSumTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class ConsecutivePrimeSum
	{
	}
}
