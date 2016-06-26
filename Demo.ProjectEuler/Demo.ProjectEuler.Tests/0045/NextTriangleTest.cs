using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0045
{
	public class NextTriangleTest : BaseTest
	{
		private readonly NextTriangle _sut = new NextTriangle();

		public NextTriangleTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class NextTriangle
	{
	}
}
