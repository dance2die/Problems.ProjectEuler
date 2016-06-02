using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0014
{
	public class LongestCollatzSequenceTest : BaseTest
	{
		private readonly LongestCollatzSequence _sut = new LongestCollatzSequence();

		public LongestCollatzSequenceTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(3, 8)]
		[InlineData(4, 3)]
		[InlineData(5, 6)]
		[InlineData(6, 9)]
		[InlineData(7, 17)]
		[InlineData(8, 4)]
		[InlineData(9, 20)]
		[InlineData(13, 10)]
		public void TestCollatzSequenceCount(int input, int expected)
		{
			int actual = _sut.GetCollatzSequenceCount(input, new Dictionary<BigInteger, int>());

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowCollatzSequences()
		{
			const int maxNumber = 1000000;

			int sequences = _sut.GetLargestCollatzSequenceCount(maxNumber);
			_output.WriteLine(sequences.ToString());
		}
	}
}
