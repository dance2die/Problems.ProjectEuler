using System;
using Demo.ProjectEuler.Core;

namespace Demo.ProjectEuler.Tests._0045
{
	public class NextTriangle
	{
		private readonly NumberGenerator _numberGenerator = new NumberGenerator();

		public long GetNextTriangleNumberGreaterThan(long startIndex)
		{
			long triangleIndex = startIndex;
			long triangleNumber = 0;

			while (true)
			{
				triangleNumber = _numberGenerator.GetTriangleNumber(triangleIndex);
				if (IsPentagonal(triangleNumber) && IsHexagonal(triangleNumber))
					break;

				triangleIndex++;
			}

			return triangleNumber;
		}

		// http://www.mathblog.dk/project-euler-44-smallest-pair-pentagonal-numbers/
		private bool IsPentagonal(long number)
		{
			double penTest = (Math.Sqrt(1 + 24 * number) + 1.0) / 6.0;
			return penTest == (long)penTest;
		}

		// https://en.wikipedia.org/wiki/Hexagonal_number
		private bool IsHexagonal(long number)
		{
			double hexTest = (Math.Sqrt(8 * number + 1) + 1) / 4.0;
			return hexTest == (long) hexTest;
		}
	}
}