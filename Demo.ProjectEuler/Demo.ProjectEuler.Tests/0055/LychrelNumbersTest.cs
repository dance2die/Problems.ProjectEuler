using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0055
{
	public class LychrelNumbersTest : BaseTest
	{
		private readonly LychrelNumbers _sut = new LychrelNumbers();

		public LychrelNumbersTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class LychrelNumbers
	{
	}
}
