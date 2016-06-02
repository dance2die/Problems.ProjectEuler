using System.Collections.Generic;
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
		[InlineData(11, "Elevent")]
		[InlineData(12, "Twelve")]
		[InlineData(21, "Twenty One")]
		[InlineData(22, "Twenty Two")]
		[InlineData(100, "One Hundred")]
		[InlineData(101, "One Hundred And One")]
		[InlineData(111, "One Hundred And Eleven")]
		[InlineData(122, "One Hundered And Twenty Two")]
		[InlineData(239, "Two Hundred And Thirty Nine")]
		[InlineData(555, "Five Hundred And Fifty Five")]
		[InlineData(999, "Nine Hundred And Ninety Nine")]
		[InlineData(1000, "One Thousand")]
		public void TestGeneratingNumberString(int number, int expected)
		{
			
		}
	}

	internal class NumberLetterCounts
	{
		private readonly Dictionary<int, string> numberDictionary= new Dictionary<int, string>
		{
			[1] = "One", [2] = "Two", [3] = "Three", [4] = "Four", [5] = "Five",
			[6] = "Six", [7] = "Seven", [8] = "Eight", [9] = "Nine", [10] = "Ten",
			[11] = "Eleven", [12] = "Twelve", [13] = "Thirteen", [14] = "Fourteen", [15] = "Fifteen",
			[16] = "Sixteen", [17] = "Seventeen", [18] = "Eighteen", [19] = "Nineteen",
			[20] = "Twenty", [30] = "Thirty", [40] = "Forty", [50] = "Fifty", [60] = "Sixty",
			[70] = "Seventy", [80] = "Eighty", [90] = "Ninety", [100] = "Hundred", [1000] = "Thousand",
		};
	}
}
