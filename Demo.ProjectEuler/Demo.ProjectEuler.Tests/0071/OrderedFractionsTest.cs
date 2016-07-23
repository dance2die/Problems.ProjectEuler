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
			Dictionary<Tuple<int, int>, double> fractionValues = new Dictionary<Tuple<int, int>, double>(upto);

			for (int n = 1; n < upto; n++)
			{
				for (int d = n + 1; d <= upto; d++)
				{
					if (_totient.GreatestCommonDivisor(n, d) == 1)
					{
						double fractionValue = (double)n / d;
						var key = new Tuple<int, int>(n, d);
						fractionValues[key] = fractionValue;
					}
				}
			}

			IOrderedEnumerable<KeyValuePair<Tuple<int, int>, double>> orderedDictionary = fractionValues.OrderBy(pair => pair.Value);

			int index = 0;
			foreach (KeyValuePair<Tuple<int, int>, double> pair in orderedDictionary)
			{
				if (pair.Key.Item1 == 3 && pair.Key.Item2 == 7)
					break;

				index++;
			}

			return orderedDictionary.ToList()[index - 1].Key;
		}
	}
}
