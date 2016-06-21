using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Demo.ProjectEuler.Core;

namespace EightDivisorsDemo
{
	class Program
	{
		private static readonly EightDivisors _sut = new EightDivisors();

		static void Main(string[] args)
		{
			Stopwatch watch = new Stopwatch();
			watch.Start();
			int actual = _sut.GetEightDivisorFactorsUpto(1000000);
			watch.Stop();

			//const int expected = 224427;
			//System.Diagnostics.Debug.Assert(expected == actual);
			Console.WriteLine("Actual: {0}; Time: {1}", actual, watch.Elapsed);
		}
	}

	public class EightDivisors
	{
		private const int FACTOR_COUNT = 8;

		private readonly Factors _factors = new Factors();

		public int GetEightDivisorFactorsUpto(int upto)
		{
			int result = 0;
			List<int> numbers = Enumerable.Range(1, upto).ToList();
			List<int> eightDivisors = new List<int>();

			for (int i = 0; i < numbers.Count; i++)
			{
				var number = numbers[i];
				int divisorCount = _factors.GetFactorCount(number);

				//if (eightDivisors.Any(n => number % n == 0)) continue;

				if (divisorCount == FACTOR_COUNT)
				{
					result++;
					eightDivisors.Add(number);
					//numbers.RemoveAll(n => n % number == 0 && n > number);
				}
			}

			return result;
		}

		public bool HasEdightDivisors(int value)
		{
			return _factors.GetFactorCount(value) == FACTOR_COUNT;
		}
	}

}
