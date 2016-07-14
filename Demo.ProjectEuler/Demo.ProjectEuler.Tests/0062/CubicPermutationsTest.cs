using System.Linq;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0062
{
	public class CubicPermutationsTest : BaseTest
	{
		private readonly CubicPermutations _sut = new CubicPermutations();

		public CubicPermutationsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(41063625, 56623104, true)]
		[InlineData(41063625, 66430125, true)]
		[InlineData(12345678, 87654321, true)]
		[InlineData(12345678, 87654312, true)]
		[InlineData(12345678, 87654321, true)]
		[InlineData(12345678, 87654312, true)]
		[InlineData(12345678, 12345670, false)]
		[InlineData(12345678, 12345679, false)]
		[InlineData(12345678, 43214321, false)]
		[InlineData(12345678, 87658765, false)]
		[InlineData(123, 1234, false)]
		[InlineData(123, 12345, false)]
		public void TestContainsAllSequence(long number1, long number2, bool expected)
		{
			bool actual = _sut.HasSameNumberSequence(number1, number2);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(345, new[] { "41063625", "56623104", "66430125" })]
		public void TestSampleData(int number, string[] expected)
		{
			var actual = _sut.GetCubesWithSamePermutations(number).ToList();

			Assert.True(expected.SequenceEqual(actual));
		}

		[Fact]
		public void TestGettingSmallestCubeWithThreePermutations()
		{
			const int permutationCount = 3;

			long actual = _sut.GetSmallestCubeWithin(permutationCount);

			const long expected = 41063625L;
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			const int permutationCount = 5;

			long actual = _sut.GetSmallestCubeWithin(permutationCount);
			_output.WriteLine(actual.ToString());

			const long expected = 127035954683L;
			Assert.Equal(expected, actual);
		}
	}
}
