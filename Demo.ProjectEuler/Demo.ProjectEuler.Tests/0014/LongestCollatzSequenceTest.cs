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

		[Fact]
		public void TestCollatzSequenceCount()
		{
			const int expected = 10;

			const int input = 13;
			int actual = _sut.GetCollatzSequenceCount(input);

			Assert.Equal(expected, actual);
		}


	}

	public class LongestCollatzSequence
	{
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
