using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0005
{
	public class SmallestMultipleTest
	{
		private readonly ITestOutputHelper _output;
		private readonly SmallestMultiple _sut;

		public SmallestMultipleTest(ITestOutputHelper output)
		{
			_output = output;
			_sut = new SmallestMultiple();
		}

		[Fact]
		public void FindSmallestMultipleBetween1And10()
		{
			const int expected = 2520;	// value found in question #3
			const int uppperBound = 10;	// count up to 10;

			var actual = _sut.GetSmallestMultiple(uppperBound);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void FindSmallestMultipleBetween1And20()
		{
			const int uppperBound = 20; // count up to 10;

			var actual = _sut.GetSmallestMultiple(uppperBound);
			_output.WriteLine("Smallest Multiple between 1 and 20: {0}", actual);
		}
	}
}
