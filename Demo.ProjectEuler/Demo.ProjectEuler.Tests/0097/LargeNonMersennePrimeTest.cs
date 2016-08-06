using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0097
{
	public class LargeNonMersennePrimeTest : BaseTest
	{
		private readonly LargeNonMersennePrime _sut = new LargeNonMersennePrime();

		public LargeNonMersennePrimeTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class LargeNonMersennePrime
	{
	}
}
