using System.Linq;
using Demo.ProjectEuler.Core;

namespace Demo.ProjectEuler.Tests._0042
{
	public class CodedTriangleNumbers
	{
		private readonly NumberGenerator _triangle = new NumberGenerator();

		public bool IsTriangleWord(string word)
		{
			int wordPositionSum = word.Sum(GetPosition);
			int triangleNumber = 0;

			// Optimization: Lowest number can be 1 for "A"
			int n = word.Length;

			// Get triangle numbers until wordPositionSum is reached.
			do
			{
				triangleNumber = _triangle.GetTriangleNumber(n);

				if (triangleNumber == wordPositionSum)
					return true;

				n++;
			} while (triangleNumber <= wordPositionSum);

			return false;
		}

		public int GetPosition(char character)
		{
			const int offset = 64;	// 'A' is 65 in ASCII table.
			return character - offset;
		}

		public int GetTriangleNumber(int n)
		{
			return _triangle.GetTriangleNumber(n);
		}
	}
}