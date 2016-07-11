using System.Linq;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0061
{
	public class CyclicalFigurateNumbersTest : BaseTest
	{
		private readonly CyclicalFigurateNumbers _sut = new CyclicalFigurateNumbers();

		public CyclicalFigurateNumbersTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestGeneratingFourDigitTriangleNumbers()
		{
			var fourDigitNumber = _sut.GetFourDigitTriangleNumbers().ToList();
			var actual = fourDigitNumber.Count;

			_output.WriteLine("fourDigitNumber.Count: {0}", actual);
			const int expected = 96;	// calculated via trial-error.
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestGeneratingFourDigitSquareNumbers()
		{
			var fourDigitNumber = _sut.GetFourDigitSquareNumbers().ToList();
			var actual = fourDigitNumber.Count;

			_output.WriteLine("fourDigitNumber.Count: {0}", actual);
			const int expected = 68;    // 100-32
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestGeneratingFourDigitPentagonalNumbers()
		{
			var fourDigitNumber = _sut.GetFourDigitPentagonalNumbers().ToList();
			var actual = fourDigitNumber.Count;

			_output.WriteLine("fourDigitNumber.Count: {0}", actual);
			const int expected = 56;    // calculated via trial-error.
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestGeneratingFourDigitHexagonalNumbers()
		{
			var fourDigitNumber = _sut.GetFourDigitHexagonalNumbers().ToList();
			var actual = fourDigitNumber.Count;

			_output.WriteLine("fourDigitNumber.Count: {0}", actual);
			const int expected = 48;    // calculated via trial-error.
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestGeneratingFourDigitHeptagonalNumbers()
		{
			var fourDigitNumber = _sut.GetFourDigitHeptagonalNumbers().ToList();
			var actual = fourDigitNumber.Count;

			_output.WriteLine("fourDigitNumber.Count: {0}", actual);
			const int expected = 43;    // calculated via trial-error.
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestGeneratingFourDigitOctagonalNumbers()
		{
			var fourDigitNumber = _sut.GetFourDigitOctagonalNumbers().ToList();
			var actual = fourDigitNumber.Count;

			_output.WriteLine("fourDigitNumber.Count: {0}", actual);
			const int expected = 40;    // calculated via trial-error.
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			long actual = _sut.GetFourDigitCyclicNumberSum();
			_output.WriteLine(actual.ToString());

			const int expected = 28684;
			Assert.Equal(expected, actual);
		}
	}
}
