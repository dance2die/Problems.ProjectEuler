using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.ProjectEuler.Tests._0004
{
	public class LargestPalindromeProduct
	{
		public int GetLargestPalindrome(int power)
		{
			int limit = (int) Math.Pow(10, power);
			List<int> twoDigitNumbers = Enumerable.Range(0, limit).Select(x => x++).Reverse().ToList();
			var query = (
				from row in twoDigitNumbers
				from col in twoDigitNumbers
				orderby row descending, col descending 
				select new { row, col });

			int max = 0;
			foreach (var value in query)
			{
				var product = value.row * value.col;
				if (IsPalindrome(product) && product > max)
				{
					max = product;
				}
			}

			return max;
		}

	
		public bool IsPalindrome(int input)
		{
			if (input.ToString().Length == 1) return true;

			string inputText = input.ToString();
			int midIndex = inputText.Length / 2;
			int leftEndIndex = midIndex;
			int rightStartIndex = midIndex;

			if (inputText.Length > 2 && inputText.Length % 2 == 1)
			{
				rightStartIndex++;
			}

			string leftText = inputText.Substring(0, leftEndIndex);
			string rightText = new string(inputText.Substring(rightStartIndex).ToCharArray().Reverse().ToArray());

			return leftText == rightText;
		}
	}
}