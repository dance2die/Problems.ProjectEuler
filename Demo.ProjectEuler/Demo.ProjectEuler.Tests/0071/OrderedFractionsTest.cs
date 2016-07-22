using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0071
{
	public class OrderedFractionsTest : BaseTest
	{
		private readonly OrderedFractions _sut = new OrderedFractions();

		public OrderedFractionsTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class OrderedFractions
	{
	}
}
