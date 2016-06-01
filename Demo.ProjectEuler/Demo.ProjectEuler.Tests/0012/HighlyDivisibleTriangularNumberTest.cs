using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0012
{
	/// <summary>
	/// 1. Generate Triangular Numbers
	/// 2. Find divisors for a number (regular factors, not prime factors)
	/// 3. Test against 7 levels of triangular numbers
	/// </summary>
	public class HighlyDivisibleTriangularNumberTest : BaseTest
	{
		private readonly HighlyDivisibleTriangularNumber _sut = new HighlyDivisibleTriangularNumber();

		public HighlyDivisibleTriangularNumberTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(1, 1)]
		[InlineData(2, 3)]
		[InlineData(3, 6)]
		[InlineData(4, 10)]
		[InlineData(5, 15)]
		[InlineData(6, 21)]
		[InlineData(7, 28)]
		public void TestGeneratingTriangularNumbers(int level, int expected)
		{
			int actual = _sut.GetTriangularNumbers(level);

			Assert.Equal(expected, actual);
		}
	}

	internal class HighlyDivisibleTriangularNumber
	{
		/// <remarks>
		/// Formula on <see cref="https://en.wikipedia.org/wiki/Triangular_number"/>
		/// </remarks>
		public int GetTriangularNumbers(int level)
		{
			return (level * (level + 1)) / 2;
		}
	}
}
