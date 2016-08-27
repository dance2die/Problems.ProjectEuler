using System;
using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0124
{
	public class OrderedRadicalsTest : BaseTest
	{
		private readonly OrderedRadicals _sut = new OrderedRadicals();

		public OrderedRadicalsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(504, 42)]
		[InlineData(1, 1)]
		[InlineData(2, 2)]
		[InlineData(4, 2)]
		[InlineData(8, 2)]
		[InlineData(3, 3)]
		[InlineData(9, 3)]
		[InlineData(5, 5)]
		[InlineData(6, 6)]
		[InlineData(7, 7)]
		[InlineData(10, 10)]
		public void TestGettingRadValue(int n, int expected)
		{
			long actual = _sut.GetRadValue(n);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			const int upto = 100000;
			const int resultPosition = 10000;
			long actual = _sut.GetOrderedRadValue(upto, resultPosition);
			_output.WriteLine(actual.ToString());

			const int expected = 21417;
			Assert.Equal(expected, actual);
		}
	}

	public class OrderedRadicals
	{
		private readonly Prime _primeManager = new Prime();

		public long GetOrderedRadValue(int upto, int resultPosition)
		{
			List<Tuple<int, long>> radValues = new List<Tuple<int, long>>(upto);
			for (int n = 1; n <= upto; n++)
			{
				Tuple<int, long> radValue = Tuple.Create(n, GetRadValue(n));
				radValues.Add(radValue);
			}

			IComparer<Tuple<int, long>> radTupleComparer = new RadTupleComparer();
			radValues.Sort(radTupleComparer);

			return radValues[resultPosition - 1].Item1;
		}

		public long GetRadValue(int n)
		{
			if (n == 1) return 1;

			var result = _primeManager
				.GetPrimeFactors(n)
				.Distinct()
				// Cast double list to integer list because "GetPrimeFactors" return a list of doubles
				.Select(value => (int)value)
				.Aggregate(1, (x, y) => x * y);
			return result;
		}
	}

	public class RadTupleComparer : IComparer<Tuple<int, long>>
	{
		public int Compare(Tuple<int, long> x, Tuple<int, long> y)
		{
			var result = x.Item2.CompareTo(y.Item2);
			return result == 0 ? x.Item1.CompareTo(y.Item1) : result;
		}
	}
}
