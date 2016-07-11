using System;
using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0061
{
	public class CyclicalFigurateNumbersTest : BaseTest
	{
		private readonly CyclicalFigurateNumbers _sut = new CyclicalFigurateNumbers();

		public CyclicalFigurateNumbersTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestGeneratingFourDigitTriangleNumbers()
		{
			var fourDigitNumber = _sut.GetFourDigitTriangleNumbers().ToList();
			var actual = fourDigitNumber.Count;

			_output.WriteLine("fourDigitNumber.Count: {0}", actual);
			const int expected = 96;	// calculated via trial-error.
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestGeneratingFourDigitSquareNumbers()
		{
			var fourDigitNumber = _sut.GetFourDigitSquareNumbers().ToList();
			var actual = fourDigitNumber.Count;

			_output.WriteLine("fourDigitNumber.Count: {0}", actual);
			const int expected = 68;    // 100-32
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestGeneratingFourDigitPentagonalNumbers()
		{
			var fourDigitNumber = _sut.GetFourDigitPentagonalNumbers().ToList();
			var actual = fourDigitNumber.Count;

			_output.WriteLine("fourDigitNumber.Count: {0}", actual);
			const int expected = 56;    // calculated via trial-error.
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestGeneratingFourDigitHexagonalNumbers()
		{
			var fourDigitNumber = _sut.GetFourDigitHexagonalNumbers().ToList();
			var actual = fourDigitNumber.Count;

			_output.WriteLine("fourDigitNumber.Count: {0}", actual);
			const int expected = 48;    // calculated via trial-error.
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestGeneratingFourDigitHeptagonalNumbers()
		{
			var fourDigitNumber = _sut.GetFourDigitHeptagonalNumbers().ToList();
			var actual = fourDigitNumber.Count;

			_output.WriteLine("fourDigitNumber.Count: {0}", actual);
			const int expected = 43;    // calculated via trial-error.
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestGeneratingFourDigitOctagonalNumbers()
		{
			var fourDigitNumber = _sut.GetFourDigitOctagonalNumbers().ToList();
			var actual = fourDigitNumber.Count;

			_output.WriteLine("fourDigitNumber.Count: {0}", actual);
			const int expected = 40;    // calculated via trial-error.
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			long actual = _sut.GetFourDigitCyclicNumberSum();

			_output.WriteLine(actual.ToString());
		}
	}

	public class CyclicalFigurateNumbers
	{
		private const int LOWER_LIMIT = 999;
		private const int UPPER_LIMIT = 10000;

		private readonly NumberGenerator _numberGenerator = new NumberGenerator();

		public long GetFourDigitCyclicNumberSum()
		{
			var numbers = GetNumbers();
			Permutation permutationManager = new Permutation();
			var permutations = permutationManager.GetPermutations(Enumerable.Range(0, numbers.Count - 1).ToList()).ToList();

			foreach (IEnumerable<int> permutationIndexes in permutations)
			{
				var permutationIndices = permutationIndexes.ToList();
				foreach (int permutationIndex in permutationIndices)
				{
					var cyclicNumbers = new List<long>(numbers.Count);
					for (int i = 0; i < permutationIndices.Count - 1; i++)
					{
						var n1 = numbers[permutationIndex][i];
						cyclicNumbers.Add(n1);

						var cyclicNumber = GetCyclicNumber(n1, numbers[permutationIndex + 1]);
						if (cyclicNumber > 0)
							cyclicNumbers.Add(cyclicNumber);
						else
							break;
					}

					if (cyclicNumbers.Count == numbers.Count)
						return cyclicNumbers.Sum();
				}
			}

			return -1;
		}

		private List<List<long>> GetNumbers()
		{
			var triangleNumbers = GetFourDigitTriangleNumbers();
			var squareNumbers = GetFourDigitSquareNumbers();
			var pentagonalNumbers = GetFourDigitPentagonalNumbers();
			var hexagonalNumbers = GetFourDigitHexagonalNumbers();
			var heptagonalNumbers = GetFourDigitHeptagonalNumbers();
			var octagonalNumbers = GetFourDigitOctagonalNumbers();

			return new List<List<long>>
			{
				triangleNumbers.ToList(),
				squareNumbers.ToList(),
				pentagonalNumbers.ToList(),
				hexagonalNumbers.ToList(),
				heptagonalNumbers.ToList(),
				octagonalNumbers.ToList()
			};
		}

		private long GetCyclicNumber(long number, IEnumerable<long> nextFourDigitNumbers)
		{
			var lastTwoDigitText1 = number.ToString().Substring(2, 2);
			foreach (long nextFourDigitNumber in nextFourDigitNumbers)
			{
				var lastTwoDigitText2 = nextFourDigitNumber.ToString().Substring(0, 2);
				if (lastTwoDigitText1 == lastTwoDigitText2)
					return nextFourDigitNumber;
			}

			return -1;
		}

		public IEnumerable<long> GetFourDigitTriangleNumbers()
		{
			// First 4-digit triangle number starts at 45: 
			// calculated using http://www.mathgoodies.com/calculators/triangular-numbers.html
			const int startIndex = 45;  // from trial and error.
			return GetNumbers(startIndex, _numberGenerator.GetTriangleNumber);
		}

		public IEnumerable<long> GetFourDigitSquareNumbers()
		{
			const int startIndex = 32;  // from trial and error.
			return GetNumbers(startIndex, _numberGenerator.GetSquareNumber);
		}

		public IEnumerable<long> GetFourDigitPentagonalNumbers()
		{
			const int startIndex = 26;  // from trial and error.
			return GetNumbers(startIndex, _numberGenerator.GetPentagonalNumber);
		}

		public IEnumerable<long> GetFourDigitHexagonalNumbers()
		{
			const int startIndex = 23;	// from trial and error.
			return GetNumbers(startIndex, _numberGenerator.GetHexagonalNumber);
		}

		public IEnumerable<long> GetFourDigitHeptagonalNumbers()
		{
			const int startIndex = 21;  // from trial and error.
			return GetNumbers(startIndex, _numberGenerator.GetHeptagonalNumber);
		}

		public IEnumerable<long> GetFourDigitOctagonalNumbers()
		{
			const int startIndex = 19;  // from trial and error.
			return GetNumbers(startIndex, _numberGenerator.GetOctagonalNumber);
		}

		public IEnumerable<long> GetNumbers(int startIndex, Func<long, long> numberGenerator)
		{
			for (int n = startIndex; ; n++)
			{
				var number = numberGenerator(n);
				if (LOWER_LIMIT < number && number < UPPER_LIMIT) 
					yield return number;

				if (number >= UPPER_LIMIT)
					yield break;
			}
		}
	}
}
