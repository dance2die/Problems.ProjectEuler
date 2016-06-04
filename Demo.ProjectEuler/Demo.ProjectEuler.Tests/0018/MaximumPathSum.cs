using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.ProjectEuler.Tests._0018
{
	public class MaximumPathSum
	{
		public int GetMximumPathSum(string input)
		{
			List<IEnumerable<int>> matrix = ParseInput(input).ToList();

			var currentLastRow = new List<int>();
			for (int i = matrix.Count - 1; i >= 1; i--)
			{
				var currentLastRowCopy = currentLastRow.ToList();
				var lastRow = currentLastRow.Count > 0 ? currentLastRowCopy : matrix[i].ToList();
				var prevRow = matrix[i - 1].ToList();
				currentLastRow.Clear();

				for (int j = 0; j < prevRow.Count; j++)
				{
					var leftValue = lastRow[j] + prevRow[j];
					var rightValue = lastRow[j + 1] + prevRow[j];

					currentLastRow.Add(Math.Max(leftValue, rightValue));
				}
			}

			return currentLastRow.Sum();
		}

		public IEnumerable<IEnumerable<int>> ParseInput(string input)
		{
			var lines = input.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
			foreach (string line in lines)
			{
				yield return line.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(s => Convert.ToInt32(s));
			}
		}
	}
}