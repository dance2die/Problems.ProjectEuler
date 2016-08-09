using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0099
{
	public class LargestExponentialTest : BaseTest
	{
		private readonly LargestExponential _sut = new LargestExponential();

		public LargestExponentialTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class LargestExponential
	{
	}
}
