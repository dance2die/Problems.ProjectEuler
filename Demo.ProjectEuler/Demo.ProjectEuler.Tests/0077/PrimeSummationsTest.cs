using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0077
{
	public class PrimeSummationsTest : BaseTest
	{
		private readonly PrimeSummations _sut = new PrimeSummations();

		public PrimeSummationsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(10, 5)]
		public void TestSampleData(int n, int expected)
		{
			int actual = _sut.GetPrimeSummations(n);

			Assert.Equal(expected, actual);
		}
	}

	public class PrimeSummations
	{
		public int GetPrimeSummations(int n)
		{
			return -1;
		}
	}
}
