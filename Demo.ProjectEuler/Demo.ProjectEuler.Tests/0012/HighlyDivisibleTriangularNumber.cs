using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Demo.ProjectEuler.Core;

namespace Demo.ProjectEuler.Tests._0012
{
	internal class HighlyDivisibleTriangularNumber
	{
		private readonly Factors _factors = new Factors();

		public double GetTriangularNumberForDivisorCount(int minimumDivisorCount)
		{
			int level = 1;
			double triangularNumber = 0;
			int currentDivisorCount = 0;
			do
			{
				triangularNumber = GetTriangularNumbers(level);
				//currentDivisorCount = GetDivisors(triangularNumber).Count();
				currentDivisorCount = GetFactorCount(triangularNumber);

				if (currentDivisorCount >= minimumDivisorCount)
					return triangularNumber;

				level++;
			} while (minimumDivisorCount >= currentDivisorCount);

			return triangularNumber;
		}

		// http://stackoverflow.com/a/4549500/4035
		public int GetFactorCount(double numberToCheck)
		{
			return _factors.GetFactorCount(numberToCheck);
		}

		public IEnumerable<int> GetDivisors(int value)
		{
			return _factors.GetDivisors(value).ToList();
		}

		/// <remarks>
		/// Formula on <see cref="https://en.wikipedia.org/wiki/Triangular_number"/>
		/// </remarks>
		public int GetTriangularNumbers(int level)
		{
			return (level * (level + 1)) / 2;
		}
	}
}