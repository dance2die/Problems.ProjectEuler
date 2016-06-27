namespace Demo.ProjectEuler.Core
{
	public class NumberGenerator
	{
		/// <param name="n">One-based index</param>
		public int GetTriangleNumber(int n)
		{
			return n * (n + 1) / 2;
		}

		/// <param name="n">One-based index</param>
		public int GetPentagonalNumber(int n)
		{
			return n * (3 * n - 1) / 2;
		}
	}
}