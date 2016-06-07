using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0022
{
	public class NamesScoresTest : BaseTest
	{
		private readonly NamesScores _sut = new NamesScores();
		private const string INPUT_FILE = @".\0022\p022_names.txt";

		public NamesScoresTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData('A', 1)][InlineData('B', 2)][InlineData('C', 3)][InlineData('D', 4)][InlineData('E', 5)]
		[InlineData('F', 6)][InlineData('G', 7)][InlineData('H', 8)][InlineData('I', 9)][InlineData('J', 10)]
		[InlineData('K', 11)][InlineData('L', 12)][InlineData('M', 13)][InlineData('N', 14)][InlineData('O', 15)]
		[InlineData('P', 16)][InlineData('Q', 17)][InlineData('R', 18)][InlineData('S', 19)][InlineData('T', 20)]
		[InlineData('U', 21)][InlineData('V', 22)][InlineData('W', 23)][InlineData('X', 24)][InlineData('Y', 25)]
		[InlineData('Z', 26)]
		public void TestAlphabetNumberAssignment(char letter, int expected)
		{
			int actual = _sut.GetLetterNumber(letter);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestNameWorth()
		{
			const int expected = 53;    // COLIN 3 + 15 + 12 + 9 + 14 = 53

			int actual = _sut.GetNameWorth("COLIN");

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			var fileContent = File.ReadAllText(INPUT_FILE);
			var names = fileContent
				.Split(new[] { ",", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
				// remove double quotes around nammes.
				.Select(name => name.Trim('"'))
				.OrderBy(name => name)
				.ToList();

			BigInteger actual = _sut.GetTotalNameScore(names);

			_output.WriteLine(actual.ToString());
		}
	}

	public class NamesScores
	{
		private const int OFFSET = 64;  // "A" is 65.

		public BigInteger GetTotalNameScore(List<string> names)
		{
			BigInteger result = 0;
			for (int i = 0; i < names.Count; i++)
			{
				int position = i + 1;	// position is 1-based;
				string name = names[i];

				result += position * GetNameWorth(name);
			}

			return result;
		}

		public int GetNameWorth(string name)
		{
			return name.Sum(GetLetterNumber);
		}

		public int GetLetterNumber(char letter)
		{
			int asciiValue = letter;
			return asciiValue - OFFSET;
		}
	}
}
