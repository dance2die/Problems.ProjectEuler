using System.Numerics;

namespace Demo.ProjectEuler.Tests._0025
{
	public class ThousandDigitFibonacci
	{
		public int GetFirstIndexOfFibonacciDigit2(int targetDigitLength)
		{
			if (targetDigitLength == 1)
				return 1;

			int currentDigitLength = 0;
			int index = 2;
			BigInteger[] previousNumbers = { 1, 1 };
			while (currentDigitLength < targetDigitLength)
			{
				var fibonacciNumber = previousNumbers[0] + previousNumbers[1];
				previousNumbers[0] = previousNumbers[1];
				previousNumbers[1] = fibonacciNumber;

				currentDigitLength = fibonacciNumber.ToString().Length;
				index++;
			}

			return index;
		}

		public int GetFirstIndexOfFibonacciDigit(int targetDigitLength)
		{
			if (targetDigitLength == 1)
				return 1;

			int currentDigitLength = 0;
			int index = 0;
			while (currentDigitLength < targetDigitLength)
			{
				//var fibonacciNumber = Fibonacci(index);
				var fibonacciNumber = GetFibonacciNumberAt(index);

				currentDigitLength = fibonacciNumber.ToString().Length;
				index++;
			}

			return index;
		}

		// Fast doubling algorithm
		// https://www.nayuki.io/page/fast-fibonacci-algorithms
		// https://www.nayuki.io/res/fast-fibonacci-algorithms/fastfibonacci.cs
		private static BigInteger Fibonacci(int n)
		{
			BigInteger a = BigInteger.Zero;
			BigInteger b = BigInteger.One;
			for (int i = 31; i >= 0; i--)
			{
				BigInteger d = a * (b * 2 - a);
				BigInteger e = a * a + b * b;
				a = d;
				b = e;
				if ((((uint)n >> i) & 1) != 0)
				{
					BigInteger c = a + b;
					a = b;
					b = c;
				}
			}
			return a;
		}

		public BigInteger GetFibonacciNumberAt(int term)
		{
			if (term == 1 || term == 2)
				return 1;

			BigInteger result = 0;
			BigInteger[] previousNumbers = {1, 1};
			for (int i = 2; i < term; i++)
			{
				result = previousNumbers[0] + previousNumbers[1];
				previousNumbers[0] = previousNumbers[1];
				previousNumbers[1] = result;
			}

			return result;
		}
	}
}