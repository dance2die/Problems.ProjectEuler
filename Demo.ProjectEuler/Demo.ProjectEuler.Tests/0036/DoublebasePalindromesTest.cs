using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0036
{
	public class DoublebasePalindromesTest : BaseTest
	{
		private readonly DoublebasePalindromes _sut = new DoublebasePalindromes();

		public DoublebasePalindromesTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(585, "1001001001")]
		[InlineData(587, "1001001011")]
		public void TestBinaryString(int value, string expected)
		{
			string actual = _sut.GetBinaryString(value);

			Assert.Equal(expected, actual);
		}
	}

	public class DoublebasePalindromes
	{
		public string GetBinaryString(int value)
		{
			const int radix = 2;
			return Convert.ToString(value, radix);
		}
	}
}
