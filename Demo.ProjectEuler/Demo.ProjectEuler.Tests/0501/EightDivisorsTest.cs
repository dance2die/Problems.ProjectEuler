using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0501
{
	public class EightDivisorsTest : BaseTest
	{
		private readonly EightDivisors _sut = new EightDivisors();

		public EightDivisorsTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class EightDivisors
	{
	}
}
