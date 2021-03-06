using System;
using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;

namespace Demo.ProjectEuler.Tests._0061
{
	public class CyclicalFigurateNumbers
	{
		private const int LOWER_LIMIT = 999;
		private const int UPPER_LIMIT = 10000;

		private readonly NumberGenerator _numberGenerator = new NumberGenerator();

		public long GetFourDigitCyclicNumberSum()
		{
			var numbers = GetNumbers();
			Permutation permutationManager = new Permutation();
			var permutations = permutationManager.GetPermutations(Enumerable.Range(0, numbers.Count).ToList()).ToList();

			foreach (IEnumerable<int> permutationIndexes in permutations)
			{
				var permutationIndices = permutationIndexes.ToList();
				var newNumbers = new List<List<long>>(permutationIndices.Count);
				foreach (int permutationIndex in permutationIndices)
				{
					newNumbers.Add(numbers[permutationIndex]);
				}

				var cyclicNumbers = CalculateCyclicNumbers(newNumbers).ToList();
				if (cyclicNumbers.Count == numbers.Count)
					return cyclicNumbers.Sum();
			}

			return -1;
		}

		private IEnumerable<long> CalculateCyclicNumbers(List<List<long>> matrix)
		{
			var result = new List<long>();

			foreach (List<long> row in matrix)
			{
				foreach (long number in row)
				{
					var tempNumber = number;
					result.Add(tempNumber);

					for (int i = 0; i < matrix.Count - 1; i++)
					{
						long cyclicNumber = GetCyclicNumber(tempNumber, matrix[i + 1]);
						if (cyclicNumber > 0 && !result.Contains(cyclicNumber))
						{
							result.Add(cyclicNumber);
							tempNumber = cyclicNumber;
						}
						else
						{
							result.Clear();
							break;
						}
					}

					if (result.Count == matrix.Count)
					{
						long lastCyclic = GetCyclicNumber(result.Last(), new List<long> {result.First()});
						if (lastCyclic < 0)
							result.Clear();
						else
							return result;
					}
				}
			}

			return result;
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