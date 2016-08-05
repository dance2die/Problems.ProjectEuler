using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0089
{
	public class RomanNumeralsTest : BaseTest
	{
		private readonly RomanNumerals _sut = new RomanNumerals();

		public RomanNumeralsTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class RomanNumerals
	{
	}
}
