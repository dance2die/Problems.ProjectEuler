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
		public long GetPentagonalNumber(long n)
		{
			return n * (3 * n - 1) / 2;
		}

		/// <param name="n">One-based index</param>
		public long GetHexagonalNumber(long n)
		{
			return n * (2 * n - 1);
		}
	}
}