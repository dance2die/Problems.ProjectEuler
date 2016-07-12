using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Core;
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
}
