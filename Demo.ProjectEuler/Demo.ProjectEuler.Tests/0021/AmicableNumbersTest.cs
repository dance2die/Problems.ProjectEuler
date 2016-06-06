using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0021
{
	public class AmicableNumbersTest : BaseTest
	{
		private readonly AmicableNumbers _sut = new AmicableNumbers();

		public AmicableNumbersTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class AmicableNumbers
	{
	}
}
