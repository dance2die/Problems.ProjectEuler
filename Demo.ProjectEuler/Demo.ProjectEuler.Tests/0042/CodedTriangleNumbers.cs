using System.Linq;

namespace Demo.ProjectEuler.Tests._0042
{
	public class CodedTriangleNumbers
	{
		public bool IsTriangleWord(string word)
		{
			int wordPositionSum = word.Sum(GetPosition);
			int triangleNumber = 0;

			// Optimization: Lowest number can be 1 for "A"
			int n = word.Length;

			// Get triangle numbers until wordPositionSum is reached.
			do
			{
				triangleNumber = GetTriangleNumber(n);

				if (triangleNumber == wordPositionSum)
					return true;

				n++;
			} while (triangleNumber <= wordPositionSum);

			return false;
		}

		public int GetTriangleNumber(int n)
		{
			return n * (n + 1) / 2;
		}

		public int GetPosition(char character)
		{
			const int offset = 64;	// 'A' is 65 in ASCII table.
			return character - offset;
		}
	}
}