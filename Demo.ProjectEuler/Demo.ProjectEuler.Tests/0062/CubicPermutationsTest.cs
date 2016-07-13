using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
		public void TestContainsAllSequence(long number1, long number2, bool expected)
		{
			bool actual = _sut.HasSameNumberSequence(number1, number2);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(345, new[] {41063625L, 56623104L, 66430125L})]
		public void TestSampleData(int number, long[] expected)
		{
			var actual = _sut.GetCubesWithSamePermutations(number).ToList();

			Assert.True(expected.SequenceEqual(actual));
		}
	}

	public class CubicPermutations
	{
		/// <param name="number">Number for which to cubes with same sequences for</param>
		/// <remarks>
		/// To do
		/// 
		/// Get the number sequence
		/// while length of "cubed number" is equal to the given "number",
		///		Increase number by one and get cube.
		///		If sequence is the same as cubed number sequence then yield.
		/// </remarks>
		public IEnumerable<long> GetCubesWithSamePermutations(int cubeRoot)
		{
			const int cubePower = 3;
			var cubed = (long) Math.Pow(cubeRoot, cubePower);

			var numberList1 = GetNumberList(cubed);
			for (long i = cubeRoot;; i++)
			{
				cubed = (long)Math.Pow(i, cubePower);

				if (i == 384 || i == 405)
					Console.WriteLine(i);

				var numberList2 = GetNumberList(cubed);
				if (numberList2.Count > numberList1.Count)
					yield break;

				if (HasSameNumberSequence(numberList1, numberList2))
					yield return ConvertSequenceToLong(numberList2);
			}
		}

		public bool HasSameNumberSequence<T>(IList<T> list1, IList<T> list2)
		{
			var copy1 = list1.ToList();
			var copy2 = list2.ToList();

			copy1.Sort();
			copy2.Sort();

			return copy1.SequenceEqual(copy2);
		}

		public bool HasSameNumberSequence(long number1, long number2)
		{
			var list1 = GetNumberList(number1);
			var list2 = GetNumberList(number2);

			return HasSameNumberSequence(list1, list2);
		}

		private List<int> GetNumberList(long number)
		{
			List<int> list = new List<int>();
			foreach (char c in number.ToString(CultureInfo.InvariantCulture))
			{
				list.Add(Convert.ToInt32(c.ToString()));
			}
			//list.Sort();

			return list;
		}

		private long ConvertSequenceToLong(IEnumerable<int> sequence)
		{
			string valueText = string.Join("", sequence.Select(i => i.ToString()));
			return Convert.ToInt64(valueText);
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


	}
}
