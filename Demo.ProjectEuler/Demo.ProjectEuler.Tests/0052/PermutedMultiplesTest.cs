using System.Linq;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0052
{
	public class PermutedMultiplesTest : BaseTest
	{
		private readonly PermutedMultiple _sut = new PermutedMultiple();

		public PermutedMultiplesTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestDoublingNumberHasSameNumbersWithSampleData()
		{
			const long input = 125874;
			const bool expected = true;

			const int multiplyBy = 2;
			bool actual = _sut.CheckPermutedMultiples(input, multiplyBy);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestMultipleMultiplicationsWithSameDigits()
		{
			long actual = _sut.GetMultipleCheckPermutedMultiples();

			_output.WriteLine(actual.ToString());
		}
	}

	public class PermutedMultiple
	{
		public long GetMultipleCheckPermutedMultiples()
		{
			long counter = 1;

			do
			{
				bool isPermutedMutiple = true;
				for (int multiplyBy = 1; multiplyBy <= 6; multiplyBy++)
				{
					if (!isPermutedMutiple) break;

					isPermutedMutiple = CheckPermutedMultiples(counter, multiplyBy);
				}

				if (isPermutedMutiple) return counter;

				counter++;
			} while (true);
		}

		public bool CheckPermutedMultiples(long input, int multiplyBy)
		{
			long multiplied = input * multiplyBy;
			var multipliedSequence = multiplied.ToString().ToList();
			multipliedSequence.Sort();

			var inputSequence = input.ToString().ToList();
			inputSequence.Sort();

			return inputSequence.SequenceEqual(multipliedSequence);
		}
	}
}
