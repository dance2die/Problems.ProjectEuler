using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests.LibraryTests
{
	public class ESieveTest : BaseTest
	{
		private readonly ESieve _sut = new ESieve();

		public ESieveTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class ESieve
	{
	}
}
