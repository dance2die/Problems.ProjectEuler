using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0017
{
	public class NumberLetterCountsTest : BaseTest
	{
		private readonly NumberLetterCounts _sut = new NumberLetterCounts();

		public NumberLetterCountsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(1, "One")]
		[InlineData(7, "Seven")]
		[InlineData(10, "Ten")]
		[InlineData(11, "Eleven")]
		[InlineData(12, "Twelve")]
		[InlineData(21, "Twenty One")]
		[InlineData(22, "Twenty Two")]
		[InlineData(100, "One Hundred")]
		[InlineData(101, "One Hundred And One")]
		[InlineData(111, "One Hundred And Eleven")]
		[InlineData(122, "One Hundred And Twenty Two")]
		[InlineData(239, "Two Hundred And Thirty Nine")]
		[InlineData(555, "Five Hundred And Fifty Five")]
		[InlineData(999, "Nine Hundred And Ninety Nine")]
		[InlineData(1000, "One Thousand")]
		public void TestGeneratingNumberString(int number, string expected)
		{
			string actual = _sut.GetNumberString(number);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(1, new[] { "One" })]
		[InlineData(2, new[] { "One", "Two" })]
		[InlineData(3, new[] { "One", "Two", "Three" })]
		[InlineData(4, new[] { "One", "Two", "Three", "Four" })]
		[InlineData(5, new[] { "One", "Two", "Three", "Four", "Five" })]
		[InlineData(10,new[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" })]
		[InlineData(11,new[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven" })]
		[InlineData(21, new[] {"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen", "Twenty", "Twenty One" })]
		public void TestNumberStringList(int numberUpto, IEnumerable<string> expected)
		{
			var actual = _sut.GetNumberStringListUpto(numberUpto);

			Assert.True(expected.SequenceEqual(actual));
		}

		[Theory]
		[InlineData(5, 19)]
		public void TestNumberStringCount(int numberUpto, int expected)
		{
			BigInteger actual = _sut.GetNumberStringCountUpto(numberUpto);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(342, 23)]
		[InlineData(115, 20)]
		public void TestStringCountForOneNumber(int number, int expected)
		{
			string numberString = _sut.GetNumberString(number);
			_output.WriteLine("numberString:'{0}'", numberString);
			int actual = string.Join("", numberString.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)).Length;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			const int numberUpto = 1000;
			BigInteger result = _sut.GetNumberStringCountUpto(numberUpto);

			_output.WriteLine(result.ToString());
		}
	}
}
