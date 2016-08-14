using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.ProjectEuler.Tests._0102
{
	public class TriangleContainment
	{
		public int GetNumberOfTrianglesContainingOrigin(string input)
		{
			List<int[]> parsed = ParseInput(input).ToList();
			int result = 0;

			foreach (int[] points in parsed)
			{
				if (ContainsOrigin(points))
					result++;
			}

			return result;
		}

		private IEnumerable<int[]> ParseInput(string input)
		{
			var lines = input.Split(new[] { Environment.NewLine, "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string line in lines)
			{
				string[] splitted = line.Split(',');

				Func<string, int> valueOf = Convert.ToInt32;
				yield return new[]
				{
					valueOf(splitted[0]), valueOf(splitted[1]), valueOf(splitted[2]),
					valueOf(splitted[3]), valueOf(splitted[4]), valueOf(splitted[5])
				};
			}
		}

		/// <summary>
		/// Find if the triangle specified by the given points contains origin or not
		/// using algorithm found here. <see cref="http://stackoverflow.com/a/2049593/4035"/>
		/// </summary>
		/// <remarks>
		/// <see cref="http://stackoverflow.com/questions/2049582/how-to-determine-if-a-point-is-in-a-2d-triangle"/>
		/// </remarks>
		public bool ContainsOrigin(int[] points)
		{
			if (points.Length != 6)
				throw new ArgumentException("There should be 6 numbers!", nameof(points));

			const int originX = 0;
			const int originY = 0;

			var b1 = sign(originX, originY, points[0], points[1], points[2], points[3]) < 0.0f;
			var b2 = sign(originX, originY, points[2], points[3], points[4], points[5]) < 0.0f;
			var b3 = sign(originX, originY, points[4], points[5], points[0], points[1]) < 0.0f;

			return ((b1 == b2) && (b2 == b3));
		}

		private float sign(int x1, int y1, int x2, int y2, int x3, int y3)
		{
			return (x1 - x3) * (y2 - y3) - (x2 - x3) * (y1 - y3);
		}
	}
}