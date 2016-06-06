﻿using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0021
{
	public class AmicableNumbersTest : BaseTest
	{
		private readonly AmicableNumbers _sut = new AmicableNumbers();

		public static IEnumerable<object[]> DivisorNumberSumLookupData => new[]
		{
			new object[] {220, new KeyValuePair<int, int>(220, 284)},
			new object[] {284, new KeyValuePair<int, int>(284, 220)}
		};

		public static IEnumerable<object[]> DictionaryData => new[]
		{
			new object[] {220, 284, new Dictionary<int, int> { [220] = 284, [284] = 220 } }
		};

		public AmicableNumbersTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(220, 284)]
		[InlineData(284, 220)]
		public void TestDivisorNumberCounts(int value, int expected)
		{
			int actual = _sut.GetDivisorSum(value);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[MemberData("DivisorNumberSumLookupData")]
		public void TestBuildingDivisorNumberCountLookup(int value, KeyValuePair<int, int> expected)
		{
			KeyValuePair<int, int> actual = _sut.GetPairOfNumberSum(value);

			Assert.True(expected.Key == actual.Key && expected.Value == actual.Value);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[MemberData("DictionaryData")]
		public void TestBuildingDictionary(int value1, int value2, IDictionary<int, int> expected)
		{
			Dictionary<int, int> actual = _sut.GetDivisorSumDictionary(new[] {value1, value2});

			Assert.Equal(expected, actual);
		}
	}

	public class AmicableNumbers
	{
		private readonly Factors _factors = new Factors();

		public Dictionary<int, int> GetDivisorSumDictionary(IEnumerable<int> values)
		{
			Dictionary<int, int> result = new Dictionary<int, int>();
			foreach (int value in values)
			{
				KeyValuePair<int, int> pairOfNumberSum = GetPairOfNumberSum(value);
				result.Add(pairOfNumberSum.Key, pairOfNumberSum.Value);
			}

			return result;
		}

		public int GetDivisorSum(int value)
		{
			return _factors.GetProperDivisors(value).Sum();
		}

		public KeyValuePair<int, int> GetPairOfNumberSum(int value)
		{
			var divisorSum = GetDivisorSum(value);
			return new KeyValuePair<int, int>(value, divisorSum);
		}
	}
}
