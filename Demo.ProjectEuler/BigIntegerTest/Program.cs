using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BigIntegerTest
{
	public class Program
	{
		public static void Main(string[] args)
		{
			BigInteger two = 2 * BigInteger.Pow(10, 200);
			BigInteger squareRoot = GetBigIntegerSquareRoot(two);
			Console.WriteLine(squareRoot);

			var sum = squareRoot.ToString().ToCharArray().Select(c => Convert.ToInt32(c.ToString())).Take(100).Sum();
			Console.WriteLine(sum);
		}

		private static BigInteger GetBigIntegerSquareRoot(BigInteger value)
		{
			return new BigInteger(Math.Exp(BigInteger.Log(value) / 2));
		}
	}
}
