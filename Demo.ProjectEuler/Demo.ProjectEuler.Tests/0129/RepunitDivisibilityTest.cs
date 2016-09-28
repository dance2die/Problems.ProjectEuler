using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0129
{
	public class RepunitDivisibilityTest : BaseTest
	{
		private readonly RepunitDivisibility _sut = new RepunitDivisibility();

		public RepunitDivisibilityTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class RepunitDivisibility
	{
	}
}
