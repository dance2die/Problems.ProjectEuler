using System.Linq;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0029
{
	public class DistinctPowersTest : BaseTest
	{
		private readonly DistinctPowers _sut = new DistinctPowers();

		public DistinctPowersTest(ITestOutputHelper output) : base(output)
		{
		}

		/// <summary>
		/// Test using brute force method.
		/// </summary>
		[Fact]
		public void TestSampleDataSequence()
		{
			double[] expected = {4, 8, 9, 16, 25, 27, 32, 64, 81, 125, 243, 256, 625, 1024, 3125};

			const int from = 2;
			const int to = 5;
			var actual = _sut.GetDistinctPowers(from, to);

			Assert.True(expected.SequenceEqual(actual));
		}

		[Fact]
		public void TestSampleDataSequenceCount()
		{
			const int expected = 15;

			const int from = 2;
			const int to = 5;
			var actual = _sut.GetDistinctPowers(from, to).Count;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResultUsingBruteForceMethod()
		{
			const int from = 2;
			const int to = 100;
			var result = _sut.GetDistinctPowers(from, to).Count;

			_output.WriteLine(result.ToString());
		}

		[Fact]
		public void ShowResultUsingBruteForceMethodUpto1000()
		{
			const int from = 2;
			const int to = 1000;
			var result = _sut.GetDistinctPowers(from, to).Count;

			_output.WriteLine(result.ToString());
		}
	}
}
