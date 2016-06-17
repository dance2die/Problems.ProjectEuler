using System.Numerics;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0037
{
	public class TruncatablePrimesTest : BaseTest
	{
		private readonly TruncatablePrimes _sut = new TruncatablePrimes();

		public TruncatablePrimesTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(2, false)]
		[InlineData(3, false)]
		[InlineData(5, false)]
		[InlineData(7, false)]
		[InlineData(3797, true)]
		public void TestTruncablePrime(int prime, bool expected)
		{
			bool actual = _sut.IsTruncablePrime(prime);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			BigInteger result = _sut.GetTruncablePrimes();

			_output.WriteLine(result.ToString());
		}
	}
}
