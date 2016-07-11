using System;

namespace Demo.ProjectEuler.Core
{
	public class NumberGenerator
	{
		/// <param name="n">One-based index</param>
		public long GetTriangleNumber(long n)
		{
			return n * (n + 1) / 2;
		}

		/// <param name="n">One-based index</param>
		public long GetSquareNumber(long n)
		{
			return (long) Math.Pow(n, 2);
		}

		/// <param name="n">One-based index</param>
		public long GetPentagonalNumber(long n)
		{
			return n * (3 * n - 1) / 2;
		}

		/// <param name="n">One-based index</param>
		public long GetHexagonalNumber(long n)
		{
			return n * (2 * n - 1);
		}

		/// <summary>
		/// Formula: n(5n−3)/2
		/// </summary>
		/// <param name="n">One-based index</param>
		public long GetHeptagonalNumber(long n)
		{
			return n * (5 * n - 3) / 2;
		}

		/// <summary>
		/// Formula: n(3n−2)
		/// </summary>
		/// <param name="n">One-based index</param>
		public long GetOctagonalNumber(long n)
		{
			return n * (3 * n - 2);
		}
	}
}