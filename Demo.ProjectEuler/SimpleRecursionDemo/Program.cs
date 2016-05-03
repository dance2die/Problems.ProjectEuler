using System;

namespace SimpleRecursionDemo
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("In order");
			PrintRecursivelyInOrder(1, 3);
			Console.WriteLine("Reverse");
			PrintRecursivelyReverse(3);
		}

		private static void PrintRecursivelyInOrder(int value, int limit)
		{
			if (value <= limit)
			{
				PrintRecursivelyInOrder(value + 1, limit);
				Console.WriteLine(value);
			}
		}

		private static void PrintRecursivelyReverse(int value)
		{
			if (value >= 1)
			{
				PrintRecursivelyReverse(value - 1);
				Console.WriteLine(value);
			}
		}
	}
}
