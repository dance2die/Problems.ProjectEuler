using System;
using System.IO;
using System.Linq;
using System.Reflection;
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

		[Theory]
		[InlineData("SKY", true)]
		[InlineData("ABC", true)]
		[InlineData("DEF", true)]
		[InlineData("XXX", false)]
		[InlineData("XYZ", false)]
		public void TestTriangleWord(string word, bool expected)
		{
			bool actual = _sut.IsTriangleWord(word);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			var wordText = File.ReadAllText("./0042/words.txt");
			var words = wordText.Split(new []{"\"", ","}, StringSplitOptions.RemoveEmptyEntries);
			int triangleWordCount = words.Count(word => _sut.IsTriangleWord(word));

			_output.WriteLine(triangleWordCount.ToString());
		}
	}

	public class CodedTriangleNumbers
	{
		public bool IsTriangleWord(string word)
		{
			int wordPositionSum = word.Sum(GetPosition);
			int triangleNumber = 0;

			// Optimization: Lowest number can be 1 for "A"
			int n = word.Length;

			// Get triangle numbers until wordPositionSum is reached.
			do
			{
				triangleNumber = GetTriangleNumber(n);

				if (triangleNumber == wordPositionSum)
					return true;

				n++;
			} while (triangleNumber <= wordPositionSum);

			return false;
		}

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
