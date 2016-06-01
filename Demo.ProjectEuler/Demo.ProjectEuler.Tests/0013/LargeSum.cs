using System;
using System.Linq;
using System.Numerics;

namespace Demo.ProjectEuler.Tests._0013
{
	public class LargeSum
	{
		public BigInteger SumNumbers(string input)
		{
			var lines = input.Split(new[] {" ", Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);

			BigInteger result = 0;
			foreach (BigInteger number in lines.Select(BigInteger.Parse))
			{
				result += number;
			}

			return result;
		}
	}
}