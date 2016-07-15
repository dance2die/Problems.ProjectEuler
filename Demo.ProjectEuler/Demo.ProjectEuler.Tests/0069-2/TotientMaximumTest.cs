using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0069
{
	public class TotientMaximumTest : BaseTest
	{
		private readonly TotientMaximum _sut = new TotientMaximum();

		public TotientMaximumTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(2, new[] {1})]
		[InlineData(3, new[] {1, 2})]
		[InlineData(4, new[] {1, 3})]
		[InlineData(5, new[] {1, 2, 3, 4})]
		[InlineData(6, new[] {1, 5})]
		[InlineData(7, new[] {1, 2, 3, 4, 5, 6})]
		[InlineData(8, new[] {1, 3, 5, 7})]
		[InlineData(9, new[] {1, 2, 4, 5, 7, 8})]
		[InlineData(10, new[] {1, 3, 7, 9})]
		public void TestRelativePrimeGenerations(int n, int[] expected)
		{
			var actual = _sut.GetRelativePrimes(n).ToList();

			Assert.True(expected.SequenceEqual(actual));
		}
	}

	public class TotientMaximum
	{
		public IEnumerable<int> GetRelativePrimes(int n)
		{
			yield return 1;	// everything is divisible by 1.

			List<int> multiples = new List<int>();
			for (int i = 2; i < n; i++)
			{
				if (n % i > 0)
					yield return i;
				else
				{
					multiples.Add(i);
				}
			}
		}
	}
}
