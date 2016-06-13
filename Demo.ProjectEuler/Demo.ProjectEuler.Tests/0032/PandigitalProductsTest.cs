using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0032
{
	public class PandigitalProductsTest : BaseTest
	{
		private readonly PandigitalProducts _sut = new PandigitalProducts();

		public PandigitalProductsTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class PandigitalProducts
	{
	}
}
