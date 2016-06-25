using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0042
{
	/// <summary>
	/// Test Scenarios
	/// 
	/// Get Position of a character in English.
	/// 
	/// Calculate a triangle number for a given number
	/// </summary>
	public class CodedTriangleNumbersTest : BaseTest
	{
		private readonly CodedTriangleNumbers _sut = new CodedTriangleNumbers();

		public CodedTriangleNumbersTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData('A', 1)]
		[InlineData('B', 2)]
		[InlineData('C', 3)]
		[InlineData('D', 4)]
		[InlineData('E', 5)]
		[InlineData('N', 14)]
		[InlineData('X', 24)]
		[InlineData('Y', 25)]
		[InlineData('Z', 26)]
		public void TestGettingCharacterPosition(char character, int expected)
		{
			int actual = _sut.GetPosition(character);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(1, 1)]
		[InlineData(2, 3)]
		[InlineData(3, 6)]
		[InlineData(4, 10)]
		[InlineData(5, 15)]
		[InlineData(6, 21)]
		[InlineData(7, 28)]
		[InlineData(8, 36)]
		[InlineData(9, 45)]
		[InlineData(10, 55)]
		public void TestTriangleNumberGeneration(int n, int expected)
		{
			int actual = _sut.GetTriangleNumber(n);

			Assert.Equal(expected, actual);
		}
	}

	public class CodedTriangleNumbers
	{
		public int GetTriangleNumber(int n)
		{
			return n * (n + 1) / 2;
		}

		public int GetPosition(char character)
		{
			const int offset = 64;	// 'A' is 65 in ASCII table.
			return character - offset;
		}
	}
}
