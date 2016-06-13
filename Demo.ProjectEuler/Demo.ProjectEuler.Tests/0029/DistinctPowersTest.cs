using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0029
{
	public class DistinctPowersTest : BaseTest
	{
		private readonly DistinctPowers _sut = new DistinctPowers();

		public DistinctPowersTest(ITestOutputHelper output) : base(output)
		{
		}

		/// <summary>
		/// Test using brute force method.
		/// </summary>
		[Fact]
		public void TestSampleData()
		{
			BigInteger[] expected = {4, 8, 9, 16, 25, 27, 32, 64, 81, 125, 243, 256, 625, 1024, 3125};

			var actual = _sut.GetDistinctPowers(2, 5);

			Assert.True(expected.SequenceEqual(actual));
		}
	}

	public class DistinctPowers
	{
		public List<BigInteger> GetDistinctPowers(int from, int to)
		{
			List<BigInteger> list = new List<BigInteger>();
			for (int i = from; i <= to; i++)
			{
				for (int j = from; j <= to; j++)
				{
					list.Add((BigInteger) Math.Pow(i, j));
				}
			}

			var result = list.Distinct(new BigIntegerComparer()).ToList();
			result.Sort();

			return result;
		}


	}

	public class BigIntegerComparer : IEqualityComparer<BigInteger>
	{
		public bool Equals(BigInteger x, BigInteger y)
		{
			return x.Equals(y);
		}

		public int GetHashCode(BigInteger obj)
		{
			return obj.GetHashCode();
		}
	}
}
