using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0102
{
	public class TriangleContainmentTest : BaseTest
	{
		private readonly TriangleContainment _sut = new TriangleContainment();

		public TriangleContainmentTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class TriangleContainment
	{
	}
}
