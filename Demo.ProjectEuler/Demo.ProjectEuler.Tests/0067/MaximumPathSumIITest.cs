using System.IO;
using System.Numerics;
using Demo.ProjectEuler.Tests.Core;
using Demo.ProjectEuler.Tests._0018;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0067
{
	public class MaximumPathSumIITest : BaseTest
	{
		private readonly MaximumPathSumII _sut = new MaximumPathSumII();

		public MaximumPathSumIITest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void ShowResult()
		{
			string input = File.ReadAllText("./0067/p067_triangle.txt");

			BigInteger actual = _sut.GetMximumPathSum(input);
			_output.WriteLine(actual.ToString());
		}
	}

	public class MaximumPathSumII
	{
		private readonly MaximumPathSum _maximumPathSum = new MaximumPathSum();

		public BigInteger GetMximumPathSum(string input)
		{
			return _maximumPathSum.GetMximumPathSum(input);
		}
	}
}
