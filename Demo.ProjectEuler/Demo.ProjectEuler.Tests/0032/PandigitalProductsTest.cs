using System;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0032
{
	public class PandigitalProductsTest : BaseTest
	{
		private readonly PandigitalProducts _sut = new PandigitalProducts();

		public PandigitalProductsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestIsSpecialPandigital()
		{
			var specialPandigitalCandidate = new Tuple<int, int, int>(39, 186, 7254);
			bool isSpecialPandigital = _sut.IsSpecialPandigital(specialPandigitalCandidate);

			Assert.True(isSpecialPandigital);
		}

		[Fact]
		public void TestSlicingIndexes()
		{
			// Number of possible slicing of 9 digit number string
			var expected = new []{
				new Tuple<int, int, int>(1, 1, 7), new Tuple<int, int, int>(1, 2, 6), new Tuple<int, int, int>(1, 3, 5), new Tuple<int, int, int>(1, 4, 4),
				new Tuple<int, int, int>(1, 5, 3), new Tuple<int, int, int>(1, 6, 2), new Tuple<int, int, int>(1, 7, 1),

				new Tuple<int, int, int>(2, 1, 6), new Tuple<int, int, int>(2, 2, 5), new Tuple<int, int, int>(2, 3, 4),
				new Tuple<int, int, int>(2, 4, 3), new Tuple<int, int, int>(2, 5, 2), new Tuple<int, int, int>(2, 6, 1),

				new Tuple<int, int, int>(3, 1, 5), new Tuple<int, int, int>(3, 2, 4), new Tuple<int, int, int>(3, 3, 3),
				new Tuple<int, int, int>(3, 4, 2), new Tuple<int, int, int>(3, 5, 1),

				new Tuple<int, int, int>(4, 1, 4), new Tuple<int, int, int>(4, 2, 3),
				new Tuple<int, int, int>(4, 3, 2), new Tuple<int, int, int>(4, 4, 1),

				new Tuple<int, int, int>(5, 1, 3), new Tuple<int, int, int>(5, 2, 2), new Tuple<int, int, int>(5, 3, 1),

				new Tuple<int, int, int>(6, 1, 2), new Tuple<int, int, int>(6, 2, 1),

				new Tuple<int, int, int>(7, 1, 1),
			};

			const int length = 9;
			var actual = _sut.GetPandigitalSlicingIndexes(length);

			Assert.True(CompareTupleList(expected, actual));
		}

		[Fact]
		public void ShowResult()
		{
			int result = _sut.GetDistinctSumOfSpecialPandigitalNumbers();

			_output.WriteLine(result.ToString());
		}

		private bool CompareTupleList(Tuple<int, int, int>[] expected, Tuple<int, int, int>[] actual)
		{
			for (int i = 0; i < expected.Length; i++)
			{
				if (!expected[i].Equals(actual[i]))
					return false;
			}

			return true;
		}
	}
}
