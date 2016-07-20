using System;
using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0069
{
	public class TotientMaximumTest : BaseTest
	{
		private readonly TotientMaximum _sut = new TotientMaximum();

		public TotientMaximumTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(2, new[] {1})]
		[InlineData(3, new[] {1, 2})]
		[InlineData(4, new[] {1, 3})]
		[InlineData(5, new[] {1, 2, 3, 4})]
		[InlineData(6, new[] {1, 5})]
		[InlineData(7, new[] {1, 2, 3, 4, 5, 6})]
		[InlineData(8, new[] {1, 3, 5, 7})]
		[InlineData(9, new[] {1, 2, 4, 5, 7, 8})]
		[InlineData(10, new[] {1, 3, 7, 9})]
		public void TestRelativePrimeGenerations(int n, int[] expected)
		{
			var actual = _sut.GetRelativePrimes(n).ToList();

			Assert.True(expected.SequenceEqual(actual));
		}

		[Theory]
		[InlineData(2, 1)]
		[InlineData(3, 1.5)]
		[InlineData(4, 2)]
		[InlineData(5, 1.25)]
		[InlineData(6, 3)]
		[InlineData(7, 1.16666)]
		[InlineData(8, 2)]
		[InlineData(9, 1.5)]
		[InlineData(10, 2.5)]
		public void TestGeneratingTotientDivision(int n, double expected)
		{
			double actual = _sut.GetTotientDivision(n);

			const double precision = 0.00001;
			Assert.True(expected - actual < precision);
		}

		[Theory]
		[InlineData(2, 1)]
		[InlineData(3, 2)]
		[InlineData(4, 2)]
		[InlineData(5, 4)]
		[InlineData(6, 2)]
		[InlineData(7, 6)]
		[InlineData(8, 4)]
		[InlineData(9, 6)]
		[InlineData(10, 4)]
		public void TestRelativePrimeCount(int n, int expected)
		{
			int actual = _sut.GetRelativePrimeCount(n);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestGeneratingTotientDivisionsForSampleData()
		{
			//const int upto = 10;
			const int upto = 10000;
			const int expected = 6;

			double actual = 0;
			Prime primeManager = new Prime();
			// Remove "n^n" from calculation
			// remove 2, 2^2, 2^3,...
			var primes = Enumerable.Range(1, upto).Where(number => primeManager.IsPrimeNumber(number)).ToList();

			List<int> primeMultiples = new List<int>();
			foreach (int prime in primes)
			{
				primeMultiples.Add(prime);

				double currentNumber = 0;
				int counter = 2;
				while (currentNumber <= upto)
				{
					currentNumber = Math.Pow(prime, counter);
					if (currentNumber <= upto)
						primeMultiples.Add((int)currentNumber);

					counter++;
				}
			}


			var numbers = Enumerable.Range(1, upto).Where(number => !primeMultiples.Contains(number));


			foreach (int number in numbers)
			{
				double value = _sut.GetTotientDivision(number);
				if (value > actual)
					actual = number;
			}

			_output.WriteLine("Result: {0}", actual);
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestGreatestCommonDivisorCollectionCreation()
		{
			const int upto = 100;
			Dictionary<Tuple<int, int>, int> lookup = new Dictionary<Tuple<int, int>, int>();
			for (int i = 1; i <= upto; i++)
			{
				for (int j = 2; j <= upto; j++)
				{
					Tuple<int, int> key = new Tuple<int, int>(j, i);
					//if (!lookup.ContainsKey(key))
						lookup[key] = _sut.GreatestCommonDivisor(j, i);
				}
			}

			_output.WriteLine(lookup.Keys.Count.ToString());
		}
	}

	public class TotientMaximum
	{
		public double GetTotientDivision(int n)
		{
			//var relativePrimes = GetRelativePrimes(n).ToList();
			//return (double) n / relativePrimes.Count;

			return (double) n/GetRelativePrimeCount(n);
		}

		public int GetRelativePrimeCount(int n)
		{
			int result = 1;

			for (int i = 2; i < n; i++)
			{
				if (GreatestCommonDivisor(n, i) == 1)
					result++;
			}

			return result;
		}

		public IEnumerable<int> GetRelativePrimes(int n)
		{
			yield return 1;	// everything is divisible by 1.

			for (int i = 2; i < n; i++)
			{
				if (GreatestCommonDivisor(n, i) == 1)
					yield return i;
			}
		}

		/// <summary>
		/// <see cref="https://en.wikipedia.org/wiki/Euclidean_algorithm"/>
		/// </summary>
		public int GreatestCommonDivisor(int a, int b)
		{
			while (b != 0)
			{
				var temp = a;
				a = b;
				b = temp % b;
			}

			return a;
		}

		/// <summary>
		/// <see cref="https://en.wikipedia.org/wiki/Euclidean_algorithm"/>
		/// </summary>
		private int GreatestCommonDivisor2(int a, int b)
		{
			while (a != b)
			{
				if (a > b)
					a -= b;
				else
					b -= a;
			}

			return a;
		}
	}
}
