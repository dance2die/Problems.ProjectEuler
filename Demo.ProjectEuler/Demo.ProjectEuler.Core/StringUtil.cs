using System.Globalization;

namespace Demo.ProjectEuler.Core
{
	public class StringUtil
	{
		public char[] GetFactorialCharArray(int input)
		{
			var inputText = input.ToString(CultureInfo.InvariantCulture);
			return inputText.ToCharArray(0, inputText.Length);
		}

	}
}
