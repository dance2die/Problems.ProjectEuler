using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0056
{
	public class PowerfulDigitSumTest : BaseTest
	{
		private readonly PowerfulDigitSum _sut = new PowerfulDigitSum();

		public PowerfulDigitSumTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class PowerfulDigitSum
	{
	}
}
