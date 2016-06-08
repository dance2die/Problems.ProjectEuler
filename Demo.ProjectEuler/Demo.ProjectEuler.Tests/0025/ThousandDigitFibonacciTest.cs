using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0025
{
	public class ThousandDigitFibonacciTest : BaseTest
	{
		private readonly ThousandDigitFibonacci _sut = new ThousandDigitFibonacci();

		public ThousandDigitFibonacciTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class ThousandDigitFibonacci
	{
	}
}
