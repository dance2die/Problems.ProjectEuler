using System;
using System.Numerics;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0099
{
	public class LargestExponentialTest : BaseTest
	{
		private readonly LargestExponential _sut = new LargestExponential();

		public LargestExponentialTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestSampleData()
		{
			const long base1 = 632382;
			const int exponent1 = 518061;
			const long base2 = 519432;
			const int exponent2 = 525806;

			Tuple<long, int> leftValue = new Tuple<long, int>(base1, exponent1);
			Tuple<long, int> rightValue = new Tuple<long, int>(base2, exponent2);

			Tuple<long, int> max = _sut.CompareValues(leftValue, rightValue);

			Assert.Equal(leftValue, max);

			//BigInteger value1 = _sut.GetPoweredValue(base1, exponent1);
			//BigInteger value2 = _sut.GetPoweredValue(base2, exponent2);

			//Assert.True(value1 > value2);

		}
	}

	public class LargestExponential
	{
		public Tuple<long, int> CompareValues(Tuple<long, int> leftValue, Tuple<long, int> rightValue)
		{
			double log1 = Math.Log10(leftValue.Item1);
			double log2 = Math.Log10(rightValue.Item1);

			BigInteger poweredValue1 = GetPoweredValue(log1, leftValue.Item2);
			BigInteger poweredValue2 = GetPoweredValue(log2, rightValue.Item2);

			Console.WriteLine(poweredValue1);
			Console.WriteLine(poweredValue2);

			return poweredValue1 > poweredValue2 ? leftValue : rightValue;
		}

		public BigInteger GetPoweredValue(double baseValue, int exponent)
		{
			//return BigInteger.Pow(new BigInteger(baseValue), exponent);
			// http://math.stackexchange.com/questions/8308/working-with-large-exponents
			return new BigInteger(exponent * baseValue);
		}
	}
}
