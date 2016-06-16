using System.Diagnostics;
using System.Numerics;
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

		[Fact]
		public void ShowResult()
		{
			Stopwatch watch = new Stopwatch();
			watch.Start();
			BigInteger result = _sut.GetPalindromeNumberSumUnderOneMillion();
			watch.Stop();

			_output.WriteLine("Result: {0}; Time: {1}", result, watch.Elapsed);
		}
	}
}
