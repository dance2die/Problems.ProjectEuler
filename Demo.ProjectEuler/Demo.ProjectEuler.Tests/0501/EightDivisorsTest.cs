using System;
using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0501
{
	public class EightDivisorsTest : BaseTest
	{
		private readonly EightDivisors _sut = new EightDivisors();

		public EightDivisorsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(24, true)]
		[InlineData(30, true)]
		[InlineData(40, true)]
		[InlineData(42, true)]
		[InlineData(54, true)]
		[InlineData(56, true)]
		[InlineData(66, true)]
		[InlineData(70, true)]
		[InlineData(78, true)]
		[InlineData(88, true)]
		[InlineData(31, false)]
		[InlineData(44, false)]
		[InlineData(55, false)]
		public void TestHasEightDivisors(int value, bool expected)
		{
			bool actual = _sut.HasEdightDivisors(value);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(100, 10)]
		[InlineData(1000, 180)]
		[InlineData(1000000, 224427)]
		public void TestNumberOfFactorsUpto(long upto, long expected)
		{
			long actual = _sut.GetEightDivisorFactorsUpto(upto);

			Assert.Equal(expected, actual);
		}
	}

	public class EightDivisors
	{
		private const int FACTOR_COUNT = 8;

		private readonly Factors _factors = new Factors();

		public long GetEightDivisorFactorsUpto(long upto)
		{
			long result = 0;
			List<long> eightDivisors = new List<long>();

			for (int i = 1; i < upto; i++)
			{
				var number = i;
				int divisorCount = _factors.GetFactorCount(number);

				//if (eightDivisors.Any(n => number % n == 0)) continue;

				if (divisorCount == FACTOR_COUNT)
				{
					result++;
					eightDivisors.Add(number);
					//numbers.RemoveAll(n => n % number == 0 && n > number);
				}
			}

			return result;
		}

		public bool HasEdightDivisors(int value)
		{
			return _factors.GetFactorCount(value) == FACTOR_COUNT;
		}
	}
}
