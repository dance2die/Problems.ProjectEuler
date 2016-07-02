using System;
using System.Diagnostics;

namespace ConsecutivePrimeSum
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			Demo.ProjectEuler.Tests._0050.ConsecutivePrimeSum sut = new Demo.ProjectEuler.Tests._0050.ConsecutivePrimeSum();
			sut.GetLongestConsecutivePrimeSum(1000000);

			stopwatch.Stop();
			Console.WriteLine("Ellapsed Time: {0}", stopwatch.Elapsed);
		}
	}
}
