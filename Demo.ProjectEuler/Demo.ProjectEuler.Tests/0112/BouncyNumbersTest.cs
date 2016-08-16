using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0112
{
	public class BouncyNumbersTest : BaseTest
	{
		private readonly BouncyNumbers _sut = new BouncyNumbers();

		public BouncyNumbersTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(134468, true)]
		[InlineData(12345, true)]
		[InlineData(12345, true)]
		[InlineData(4321, false)]
		[InlineData(88778, false)]
		[InlineData(1, false)]
		[InlineData(45, false)]
		[InlineData(99, false)]
		public void TestIncreasingNumber(int input, bool expected)
		{
			bool actual = _sut.IsIncreasingNumber(input);

			Assert.Equal(expected, actual);
		}
	}

	public class BouncyNumbers
	{
		public bool IsIncreasingNumber(int input)
		{
			return false;
		}



	}
}
