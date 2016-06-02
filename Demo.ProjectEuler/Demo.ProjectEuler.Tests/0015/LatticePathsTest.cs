using System.Numerics;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0015
{
	public class LatticePathsTest : BaseTest
	{
		private readonly LatticePaths _sut = new LatticePaths();

		public LatticePathsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(2, 6)]
		[InlineData(3, 20)]
		public void TestCombinations(int size, ulong expected)
		{
			BigInteger actual = _sut.GetLatticePaths(size);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			const int input = 20;
			BigInteger result = _sut.GetLatticePaths(input);

			_output.WriteLine(result.ToString());
		}
	}
}
