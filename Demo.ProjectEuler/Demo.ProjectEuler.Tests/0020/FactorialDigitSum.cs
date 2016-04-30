using System;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace Demo.ProjectEuler.Tests._0020
{
	public class FactorialDigitSum
	{
		public int SumFactorialDigits(int input)
		{
			char[] digitCharacters = GetFactorialCharArray(input);
			int[] digits = digitCharacters.Select(c => Convert.ToInt32((string) c.ToString())).ToArray();
			return digits.Sum();
		}

		public char[] GetFactorialCharArray(int input)
		{
			var factorialText = GetFactorial(input).ToString(CultureInfo.InvariantCulture);
			return factorialText.ToCharArray(0, factorialText.Length);
		}

		public BigInteger GetFactorial(int input)
		{
			BigInteger result = 1;
			if (input <= 1)
				return 1;

			for (int i = input; i > 0; i--)
			{
				result *= i;
			}

			return result;
		}
	}
}