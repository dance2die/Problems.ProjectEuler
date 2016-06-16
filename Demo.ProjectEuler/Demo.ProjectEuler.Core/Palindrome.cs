using System;
using System.Linq;

namespace Demo.ProjectEuler.Core
{
	public class Palindrome
	{
		/// <summary>
		/// Check if Palindrome
		/// </summary>
		/// <remarks>
		/// From "anotherwealth"'s solution on ProjectEuler.
		/// Runs a bit faster than IsPalindrome2
		/// </remarks>
		public bool IsPalindrome(string inputText)
		{
			var charArray = inputText.ToCharArray();
			Array.Reverse(charArray);
			return inputText.Equals(new string(charArray));
		}

		public bool IsPalindrome2(string inputText)
		{
			if (inputText.Length == 1) return true;

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