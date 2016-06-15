using System.Linq;

namespace Demo.ProjectEuler.Tests._0004
{
	public class Palindrome
	{
		public bool IsPalindrome(string inputText)
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