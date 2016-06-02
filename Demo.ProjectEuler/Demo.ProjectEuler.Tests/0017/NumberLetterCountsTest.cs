using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0017
{
	public class NumberLetterCountsTest : BaseTest
	{
		private readonly NumberLetterCounts _sut = new NumberLetterCounts();
		private readonly Dictionary<int, string> numberDictionary= new Dictionary<int, string>
		{
			[1] = "One", [2] = "Two", [3] = "Three", [4] = "Four", [5] = "Five",
			[6] = "Six", [7] = "Seven", [8] = "Eight", [9] = "Nine", [10] = "Ten",
			[11] = "Eleven", [12] = "Twelve", [13] = "Thirteen", [14] = "Fourteen", [15] = "Fifteen",
			[16] = "Sixteen", [17] = "Seventeen", [18] = "Eighteen", [19] = "Nineteen",
			[20] = "Twenty", [30] = "Thirty", [40] = "Forty", [50] = "Fifty", [60] = "Sixty",
			[70] = "Seventy", [80] = "Eighty", [90] = "Ninety", [100] = "Hundred", [1000] = "Thousand",
		};

		public NumberLetterCountsTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	internal class NumberLetterCounts
	{
	}
}
