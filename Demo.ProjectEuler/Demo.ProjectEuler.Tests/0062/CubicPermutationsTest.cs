using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0062
{
	public class CubicPermutationsTest : BaseTest
	{
		private readonly CubicPermutations _sut = new CubicPermutations();

		public CubicPermutationsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(345, new [] { 345, 384, 405 })]
		public void TestSampleDataPermutations(int number, int[] expected)
		{
			var actual = _sut.GetCubePermutations(number).Distinct().ToList();
			actual.Sort();

			Assert.True(expected.SequenceEqual(actual));
		}
	}

	public class CubicPermutations
	{
		private readonly Permutation _permutation = new Permutation();
		private readonly MathExt _math = new MathExt();

		public IEnumerable<int> GetCubePermutations(int number)
		{
			const double power = 3;	// cube
			const double precision = 0.000001;

			double cubed = Math.Pow(number, power);

			var cubeSequence = cubed
				.ToString(CultureInfo.InvariantCulture)
				.ToCharArray()
				.Select(c => Convert.ToInt32(c.ToString()))
				.ToList();
			var permutations = _permutation.GetPermutations(cubeSequence);

			int index = 0;
			foreach (IEnumerable<int> sequence in permutations.Distinct())
			{
				double doubleValue = ConvertSequenceToDouble(sequence);
				double rooted = _math.NthRoot(doubleValue, power);
				double decimalValue = rooted - Math.Truncate(rooted);
				double difference = 1 - decimalValue;

				if (difference < precision)
				{
					Console.WriteLine("index: {0}", index);
					yield return (int) Math.Round(rooted, 0);
				}

				index++;
			}
		}

		private double ConvertSequenceToDouble(IEnumerable<int> sequence)
		{
			string valueText = sequence.Aggregate("", (current, value) => current + value.ToString());
			return Convert.ToDouble(valueText);
		}
	}
}
