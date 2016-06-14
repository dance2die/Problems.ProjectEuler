using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0035
{
	public class CircularPrimesTest : BaseTest
	{
		private readonly CircularPrimes _sut = new CircularPrimes();

		public CircularPrimesTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class CircularPrimes
	{
	}
}
