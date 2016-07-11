using System.Diagnostics;
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
		[InlineData(47, false)]
		[InlineData(349, false)]
		[InlineData(196, true)]
		[InlineData(4994, true)]
		[InlineData(10677, true)]
		public void TestLychrelNumber(int number, bool expected)
		{
			bool actual = _sut.IsLychrelNumber(number);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			const int upto = 10000;

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			int actual = _sut.GetLychrelNumberUpto(upto);
			stopwatch.Stop();

			_output.WriteLine("Result: {0}: Ellapsed time: {1}", actual, stopwatch.Elapsed);

			const int expected = 249;
			Assert.Equal(expected, actual);
		}
	}
}
