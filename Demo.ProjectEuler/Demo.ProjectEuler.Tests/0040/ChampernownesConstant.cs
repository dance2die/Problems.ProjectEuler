using System;
using System.Linq;

namespace Demo.ProjectEuler.Tests._0040
{
	public class ChampernownesConstant
	{
		public int GetDigitValueAt(string stringNumber, int oneBasedIndex)
		{
			return Convert.ToInt32(stringNumber[oneBasedIndex - 1].ToString());
		}

		public string GetNumberStringUpto(int upto)
		{
			return string.Join("", Enumerable.Range(1, upto).Select(number => number.ToString()));
		}
	}
}