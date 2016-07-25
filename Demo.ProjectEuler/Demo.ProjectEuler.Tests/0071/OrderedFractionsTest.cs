using System;
using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0071
{
	public class OrderedFractionsTest : BaseTest
	{
		private readonly OrderedFractions _sut = new OrderedFractions();

		public OrderedFractionsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestSampleData()
		{
			const int upto = 8;
			Tuple<int, int> actual = _sut.GetPreviousNumberBefore3Over7(upto);

			Tuple<int, int> expected = new Tuple<int, int>(2, 5);
			Assert.True(expected.Equals(actual));
		}

		[Fact]
		public void ShowResult()
		{
			const int upto = 1000000;
			Tuple<int, int> actual = _sut.GetPreviousNumberBefore3Over7(upto);
			_output.WriteLine(actual.ToString());
		}
	}

	public class OrderedFractions
	{
		private readonly Totient _totient = new Totient();

		public Tuple<int, int> GetPreviousNumberBefore3Over7(int upto)
		{
			double comparisonValue = (double) 3 / 7;
			double previousValue = 0;
			Tuple<int, int> previousTuple = new Tuple<int, int>(0, 0);

			for (int n = 1; n < upto; n++)
			{
				for (int d = n + 1; d <= upto; d += 2)
				{
					double fractionValue = (double)n / d;
					if (fractionValue > comparisonValue) continue;
					if (previousValue > fractionValue) continue;
					if (n % d == 0 || d % n == 0) continue;

					if ((n != 3 && d != 7) && _totient.GreatestCommonDivisor(n, d) == 1)
					{
						previousValue = fractionValue;
						previousTuple = new Tuple<int, int>(n, d);
					}
				}
			}

			return previousTuple;
		}
	}
}
