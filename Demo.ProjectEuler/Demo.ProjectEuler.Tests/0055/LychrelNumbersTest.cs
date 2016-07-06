using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0055
{
	public class LychrelNumbersTest : BaseTest
	{
		private readonly LychrelNumbers _sut = new LychrelNumbers();

		public LychrelNumbersTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(47, true)]
		[InlineData(349, true)]
		[InlineData(196, false)]
		public void TestLychrelNumber(int number, bool expected)
		{
			bool actual = _sut.IsLychrelNumber(number);

			Assert.Equal(expected, actual);
		}
	}

	public class LychrelNumbers
	{
		public bool IsLychrelNumber(int number)
		{
			return false;
		}
	}
}
