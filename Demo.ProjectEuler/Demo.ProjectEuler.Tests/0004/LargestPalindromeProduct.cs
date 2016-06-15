using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.ProjectEuler.Tests._0004
{
	public class LargestPalindromeProduct
	{
		public int GetLargestPalindrome(int power)
		{

			int offset = (int) Math.Pow(1, power - 1);
			int limit = (int) Math.Pow(10, power);
			List<int> twoDigitNumbers = Enumerable.Range(offset, limit - offset).Select(x => x++).Reverse().ToList();
			var query = (
				from row in twoDigitNumbers
				from col in twoDigitNumbers
				orderby row descending, col descending 
				select new { row, col });

			int max = 0;
			Palindrome palindrome = new Palindrome();
			foreach (var value in query)
			{
				var product = value.row * value.col;
				if (palindrome.IsPalindrome(product.ToString()) && product > max)
				{
					max = product;
				}
			}

			return max;
		}
	}
}