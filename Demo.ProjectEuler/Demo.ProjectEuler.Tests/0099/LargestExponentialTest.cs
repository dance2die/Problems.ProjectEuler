using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

			Tuple<long, int> max = _sut.GetMax(leftValue, rightValue);

			Assert.Equal(leftValue, max);
		}

		[Fact]
		public void ShowResult()
		{
			string input = File.ReadAllText("./0099/p099_base_exp.txt");

			int actual = _sut.GetMaxLine(input);
			_output.WriteLine(actual.ToString());

			const int expected = 709;
			Assert.Equal(expected, actual);
		}
	}

	public class LargestExponential
	{
		public int GetMaxLine(string input)
		{
			List<Tuple<long, int>> values = ParseInput(input).ToList();

			Tuple<long, int> maxValue = values.First();
			int currLineNumber = 1;
			int maxLineNumber = 1;
			foreach (Tuple<long, int> value in values)
			{
				Tuple<long, int> tempMax = GetMax(maxValue, value);
				if (!tempMax.Equals(maxValue))
				{
					maxValue = tempMax;
					maxLineNumber = currLineNumber;
				}

				currLineNumber++;
			}

			return maxLineNumber;
		}

		private IEnumerable<Tuple<long, int>> ParseInput(string input)
		{
			var lines = input.Split(new[] {Environment.NewLine, "\n", "\r"}, StringSplitOptions.RemoveEmptyEntries);
			foreach (string line in lines)
			{
				string[] splitted = line.Split(',');
				yield return new Tuple<long, int>(Convert.ToInt64(splitted[0]), Convert.ToInt32(splitted[1]));
			}
		}

		public Tuple<long, int> GetMax(Tuple<long, int> leftValue, Tuple<long, int> rightValue)
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
