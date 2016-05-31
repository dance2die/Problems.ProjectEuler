using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Demo.ProjectEuler.Tests._0006
{
	public class SumSquareDifference
	{
		public BigInteger GetSquareOfSums(IEnumerable<int> numbers)
		{
			BigInteger result = 0;

			result = (BigInteger) Math.Pow(numbers.Sum(), 2);

			return result;
		}

		public BigInteger GetSumOfSquares(IEnumerable<int> numbers)
		{
			BigInteger result = 0;

			foreach (int number in numbers)
			{
				result += (BigInteger) Math.Pow(number, 2);
			}

			return result;
		}

		public BigInteger GetDifferenceBetweenSqaureOfSumsAndSumOfSquares(IEnumerable<int> numbers)
		{
			var list = numbers.ToList();
			BigInteger sumOfSquares = GetSumOfSquares(list);
			BigInteger squareOfSums = GetSquareOfSums(list);

			return squareOfSums - sumOfSquares;
		}
	}
}