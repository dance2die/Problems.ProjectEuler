using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0127
{
	public class AbcHitsTest : BaseTest
	{
		private readonly AbcHits _sut = new AbcHits();

		public AbcHitsTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class AbcHits
	{
	}
}
