using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0069
{
	public class TotientMaximumTest : BaseTest
	{
		private readonly TotientMaximum _sut = new TotientMaximum();

		public TotientMaximumTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class TotientMaximum
	{
	}
}
