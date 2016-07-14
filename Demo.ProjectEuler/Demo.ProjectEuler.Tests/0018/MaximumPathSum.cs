using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Demo.ProjectEuler.Tests._0018
{
	/// <summary>
	/// Get the maximum sum from a triangular tree
	/// </summary>
	/// <remarks>
	/// Pseudo code
	/// 
	/// nlr (new last row) = List
	/// for i = rows length = 1 to >= 1 i--
	///		lr (last row) = if nlr length > 0 then nlr else rows[i]
	///		pr (previous row) = row[i - 1]
	///		Clear nlr
	/// 
	///		for j = 0; j = pr length; j++
	///			nlr[j] = Max( (lr[j] + pr[j], (lr[j+1] + pr[j]) )
	/// 
	/// return nlr.sum() // even though there is only one number
	/// </remarks>
	public class MaximumPathSum
	{
		/// <summary>
		/// Work from bottom up instead of top to bottom.
		/// </summary>
		public BigInteger GetMximumPathSum(string input)
		{
			var triangle = ParseInput(input).ToList();

			var currentLastRow = new List<BigInteger>();
			for (int i = triangle.Count - 1; i >= 1; i--)
			{
				var currentLastRowCopy = currentLastRow.ToList();
				var lastRow = currentLastRow.Count > 0 ? currentLastRowCopy : triangle[i].ToList();
				var prevRow = triangle[i - 1].ToList();
				currentLastRow.Clear();

				for (int j = 0; j < prevRow.Count; j++)
				{
					var leftValue = lastRow[j] + prevRow[j];
					var rightValue = lastRow[j + 1] + prevRow[j];

					currentLastRow.Add(BigInteger.Max(leftValue, rightValue));
				}
			}

			return currentLastRow.Aggregate(BigInteger.Zero, (current, value) => current + value);
		}

		public IEnumerable<IEnumerable<BigInteger>> ParseInput(string input)
		{
			var lines = input.Split(new[] {Environment.NewLine, "\n"}, StringSplitOptions.RemoveEmptyEntries);
			foreach (string line in lines)
			{
				yield return line.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse);
			}
		}
	}
}