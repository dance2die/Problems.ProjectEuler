using System;
using System.Collections.Generic;
using System.Linq;
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
			int actual = _sut.GetCollatzSequenceCount(input);

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

	public class LongestCollatzSequence
	{
		public int GetLargestCollatzSequenceCount(int maxNumber)
		{
			int maximumSequenceCount = 0;
			int maxInput = 0;

			for (int input = 1; input <= maxNumber; input++)
			{
				var sequenceCount = GetCollatzSequenceCount(input);
				if (sequenceCount > maximumSequenceCount)
				{
					maximumSequenceCount = sequenceCount;
					maxInput = input;
				}
			}

			return maxInput;
		}

		public int GetCollatzSequenceCount(int input)
		{
			int sequence = input;
			int count = 1;

			do
			{
				if (IsEven(sequence))
					sequence /= 2;
				else
					sequence = 3*sequence + 1;

				count++;
			} while (sequence > 1);

			return count;
		}

		private bool IsEven(int input)
		{
			return input % 2 == 0;
		}
	}
}
