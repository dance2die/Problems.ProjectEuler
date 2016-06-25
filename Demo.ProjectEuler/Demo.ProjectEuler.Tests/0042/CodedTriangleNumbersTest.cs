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
	}

	public class CodedTriangleNumbers
	{
		public int GetPosition(char character)
		{
			const int offset = 64;	// 'A' is 65 in ASCII table.
			return character - offset;
		}
	}
}
