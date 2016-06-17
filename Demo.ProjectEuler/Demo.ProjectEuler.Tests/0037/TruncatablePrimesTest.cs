using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0037
{
	public class TruncatablePrimesTest : BaseTest
	{
		private readonly TruncatablePrimes _sut = new TruncatablePrimes();

		public TruncatablePrimesTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class TruncatablePrimes
	{
	}
}
