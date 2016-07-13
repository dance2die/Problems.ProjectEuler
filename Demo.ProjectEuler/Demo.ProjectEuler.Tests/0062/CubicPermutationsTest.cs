﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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

		//[Theory]
		//[InlineData(345, new [] { 345, 384, 405 })]
		//public void TestSampleDataPermutations(int number, int[] expected)
		//{
		//	var actual = _sut.GetCubePermutations(number);
		//	actual.Sort();

		//	Assert.True(expected.SequenceEqual(actual));
		//}

		//[Fact]
		//public void ShowResult()
		//{
		//	int actual = _sut.GetFiveCubePermutations();
		//	_output.WriteLine(actual.ToString());
		//}

		[Theory]
		[InlineData(41063625, 56623104, true)]
		[InlineData(41063625, 66430125, true)]
		[InlineData(12345678, 87654321, true)]
		[InlineData(12345678, 87654312, true)]
		[InlineData(12345678, 87654321, true)]
		[InlineData(12345678, 87654312, true)]
		[InlineData(12345678, 12345670, false)]
		[InlineData(12345678, 12345679, false)]
		[InlineData(12345678, 43214321, false)]
		[InlineData(12345678, 87658765, false)]
		[InlineData(123, 1234, false)]
		[InlineData(123, 12345, false)]
		public void TestContainsAllSequence(int number1, int number2, bool expected)
		{
			bool actual = _sut.HasSameNumberSequence(number1, number2);

			Assert.Equal(expected, actual);
		}
	}

	public class CubicPermutations
	{
		public bool HasSameNumberSequence(int number1, int number2)
		{
			var list1 = GetSortedNumberList(number1);
			var list2 = GetSortedNumberList(number2);

			return list1.SequenceEqual(list2);
		}

		private List<int> GetSortedNumberList(int number)
		{
			var list = number
				.ToString(CultureInfo.InvariantCulture)
				.ToCharArray()
				.Select(c => Convert.ToInt32(c.ToString())).ToList();
			list.Sort();

			return list;
		}

		//private readonly Permutation _permutation = new Permutation();
		//private readonly MathExt _math = new MathExt();

		//public int GetFiveCubePermutations()
		//{
		//	List<int> permutations = new List<int>();

		//	int number = 345;
		//	do
		//	{
		//		permutations = GetCubePermutations(number);
		//		if (number % 10 == 0)
		//			Console.WriteLine(number);

		//		if (permutations.Count == 5)
		//			return permutations.Min();

		//		number++;
		//	} while (true);
		//}

		//public List<int> GetCubePermutations(int number)
		//{
		//	const double power = 3;	// cube
		//	const double precision = 0.000001;

		//	double cubed = Math.Pow(number, power);

		//	var cubeSequence = cubed
		//		.ToString(CultureInfo.InvariantCulture)
		//		.ToCharArray()
		//		.Select(c => Convert.ToInt32(c.ToString()))
		//		.ToList();
		//	var permutations = _permutation.GetPermutations(cubeSequence);

		//	int index = 0;
		//	List<int> result = new List<int>();

		//	foreach (IEnumerable<int> sequence in permutations.Distinct())
		//	{
		//		double doubleValue = ConvertSequenceToDouble(sequence);
		//		double rooted = _math.NthRoot(doubleValue, power);
		//		double decimalValue = rooted - Math.Truncate(rooted);
		//		double difference = 1 - decimalValue;

		//		if (difference < precision)
		//		{
		//			//Console.WriteLine("index: {0}", index);
		//			int resultValue = (int) Math.Round(rooted, 0);
		//			//yield return resultValue;
		//			if (!result.Contains(resultValue))
		//				result.Add(resultValue);
		//		}

		//		index++;
		//	}

		//	return result;
		//}

		//private double ConvertSequenceToDouble(IEnumerable<int> sequence)
		//{
		//	string valueText = string.Join("", sequence.Select(i => i.ToString()));
		//	return Convert.ToDouble(valueText);
		//}
	}
}
