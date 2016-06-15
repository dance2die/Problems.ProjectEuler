using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0036
{
	public class DoublebasePalindromesTest : BaseTest
	{
		private readonly DoublebasePalindromes _sut = new DoublebasePalindromes();

		public DoublebasePalindromesTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class DoublebasePalindromes
	{
	}
}
