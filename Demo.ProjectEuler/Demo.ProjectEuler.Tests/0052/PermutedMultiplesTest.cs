using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			return -1;
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
