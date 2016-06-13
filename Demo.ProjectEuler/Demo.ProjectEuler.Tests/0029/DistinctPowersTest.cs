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
		public void TestSampleDataSequence()
		{
			BigInteger[] expected = {4, 8, 9, 16, 25, 27, 32, 64, 81, 125, 243, 256, 625, 1024, 3125};

			const int from = 2;
			const int to = 5;
			var actual = _sut.GetDistinctPowers(from, to);

			Assert.True(expected.SequenceEqual(actual));
		}

		[Fact]
		public void TestSampleDataSequenceCount()
		{
			const int expected = 15;

			const int from = 2;
			const int to = 5;
			var actual = _sut.GetDistinctPowers(from, to).Count;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResultUsingBruteForceMethod()
		{
			const int from = 2;
			const int to = 100;
			var result = _sut.GetDistinctPowers(from, to).Count;

			_output.WriteLine(result.ToString());
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
