using System.Collections.Generic;
using System.Linq;
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

		[Theory]
		[InlineData(1, new [] {1})]
		[InlineData(3, new [] {1, 3})]
		[InlineData(6, new [] {1, 2, 3, 6})]
		[InlineData(10, new [] {1, 2, 5, 10})]
		[InlineData(15, new [] {1, 3, 5, 15})]
		[InlineData(21, new [] {1, 3, 7, 21})]
		[InlineData(28, new [] {1, 2, 4, 7, 14, 28})]
		public void TestGeneratingDivisors(int value, IEnumerable<int> expected)
		{
			IEnumerable<int> actual = _sut.GetDivisors(value);

			Assert.True(expected.SequenceEqual(actual));
		}
	}

	internal class HighlyDivisibleTriangularNumber
	{
		public IEnumerable<int> GetDivisors(int value)
		{
			for (int i = 1; i <= value; i++)
			{
				if (value % i == 0)
					yield return i;
			}
		}

		/// <remarks>
		/// Formula on <see cref="https://en.wikipedia.org/wiki/Triangular_number"/>
		/// </remarks>
		public int GetTriangularNumbers(int level)
		{
			return (level * (level + 1)) / 2;
		}
	}
}
