using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests.LibraryTests
{
	public class MathExtTest : BaseTest
	{
		private readonly MathExt _sut = new MathExt();

		public MathExtTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(4, 2, 2)]
		[InlineData(9, 3, 2)]
		[InlineData(41063625, 3, 345)]
		[InlineData(56623104, 3, 384)]
		[InlineData(66430125, 3, 405)]
		[InlineData(16, 4, 2)]
		public void TestNthRoot(int number, int rootPower, double expected)
		{
			double actual = _sut.NthRoot(number, rootPower);

			Assert.True(expected - actual < 0.00001);
		}
	}

	public class MathExt
	{
		public double NthRoot(double number, int rootPower)
		{
			// http://stackoverflow.com/a/18657674/4035
			return Math.Pow(number, 1.0 / rootPower);
		}
	}
}
