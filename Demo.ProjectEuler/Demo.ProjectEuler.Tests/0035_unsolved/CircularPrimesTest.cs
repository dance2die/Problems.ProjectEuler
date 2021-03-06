﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0035
{
	public class CircularPrimesTest : BaseTest
	{
		private readonly CircularPrimes _sut = new CircularPrimes();

		public CircularPrimesTest(ITestOutputHelper output) : base(output)
		{
		}

		/// <remarks>
		/// Runs in 2 seconds
		/// </remarks>
		[Fact]
		public void TestGettingPrimesUnderOneMillion()
		{
			Prime prime = new Prime();
			List<int> primes = new List<int>();

			for (int i = 1; i <= 999999; i++)
			{
				if (prime.IsPrimeNumber(i))
					primes.Add(i);
			}

			_output.WriteLine(primes.Count.ToString());
		}

		[Theory]
		[InlineData(2, 2, true)]
		[InlineData(3, 3, true)]
		[InlineData(5, 5, true)]
		[InlineData(7, 7, true)]
		[InlineData(11, 11, true)]
		[InlineData(11, 13, false)]
		[InlineData(13, 11, false)]
		[InlineData(13, 31, true)]
		[InlineData(17, 71, true)]
		[InlineData(37, 73, true)]
		[InlineData(79, 97, true)]
		[InlineData(311, 113, true)]
		[InlineData(243, 342, true)]
		[InlineData(2, 12, false)]
		[InlineData(24, 48, false)]
		[InlineData(1234, 1253, false)]
		public void TestIsCircularPrime(int prime, int circularPrimeCandidate, bool expected)
		{
			var actual = _sut.IsCircularPrime(prime, circularPrimeCandidate);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(2, new[] {2}, 10)]
		[InlineData(11, new[] {11, 11}, 20)]
		[InlineData(13, new[] {13, 31}, 33)]
		[InlineData(17, new[] {17, 71}, 77)]
		[InlineData(79, new[] {79, 97}, 100)]
		[InlineData(197, new[] {197 , 971, 719}, 1000)]
		public void TestCircularPrimes(int prime, int[] expected, int primeCount)
		{
			var primes = _sut.GetPrimesUnder(primeCount);
			var actual = _sut.GetCircularPrimes(prime, 
				primes.Where(p => p.ToString().Length == prime.ToString().Length).ToList());

			Assert.True(expected.SequenceEqual(actual));
		}

		[Theory]
		[InlineData(2, 1, 10)]
		[InlineData(11, 1, 20)]
		[InlineData(13, 2, 33)]
		[InlineData(17, 2, 77)]
		[InlineData(79, 2, 100)]
		[InlineData(197, 3, 1000)]
		public void TestCircularPrimeCount(int prime, int expected, int primeCount)
		{
			var primes = _sut.GetPrimesUnder(primeCount);
			int actual = _sut.GetCircularPrimeCount(prime, 
				primes.Where(p => p.ToString().Length == prime.ToString().Length).ToList());

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestPrimesUnder100()
		{
			const int limit = 100;
			var actual = _sut.GetCircularPrimeCountUnder(limit);

			const int expected = 13;
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestPrimesUnder1000000()
		{
			const int limit = 1000000;
			var result = _sut.GetCircularPrimeCountUnder(limit);

			_output.WriteLine(result.ToString());
		}
	}

	public class CircularPrimes
	{
		private readonly Prime _prime = new Prime();

		public int GetCircularPrimeCountUnder(int limit)
		{
			var primes = GetPrimesUnder(limit).ToList();
			var oneDigitPrimes = primes.Where(p => p < 10).ToList();
			//var allCircularPrimes = new List<int>(oneDigitPrimes);

			var result = oneDigitPrimes.Count;

			for (int i = oneDigitPrimes.Count; i < primes.Count; i++)
			{
				var prime = primes[i];
				var circularPrimeCount = GetCircularPrimeCount(prime,
					primes.Where(p => p.ToString().Length == prime.ToString().Length).ToList());

				//if (circularPrimeCount > 1)
				//{
				//	result += circularPrimeCount;
				//}
				result += circularPrimeCount;
			}

			return result;
		}

		public int GetCircularPrimeCount(int prime, List<int> primes)
		{
			var primeText = prime.ToString();
			List<int> circularNunmbers = GetCircularNumbers(primeText).Distinct().ToList();

			int count = 0;
			for (int i = 0; i < primes.Count; i++)
			{
				foreach (int circularNunmber in circularNunmbers)
				{
					if (_prime.IsPrimeNumber(circularNunmber) && circularNunmber == primes[i])
					{
						count++;
						primes.Remove(circularNunmber);
					}
				}
			}

			return count;
		}

		private IEnumerable<int> GetCircularNumbers(string primeText)
		{
			Queue<char> digitQueue = GetDigitQueue(primeText);
			for (int i = 0; i < primeText.Length; i++)
			{
				int candidatePrime = Convert.ToInt32(new string(digitQueue.ToArray()));
				yield return candidatePrime;

				// Rotate the digit
				char firstDigit = digitQueue.Dequeue();
				digitQueue.Enqueue(firstDigit);
			}
		}

		public IEnumerable<int> GetCircularPrimes(int prime, List<int> primes)
		{
			var primeText = prime.ToString();
			Queue<char> digitQueue = GetDigitQueue(primeText);

			List<int> circularPrimes = new List<int>();
			for (int i = 0; i < primeText.Length; i++)
			{
				int candidatePrime = Convert.ToInt32(new string(digitQueue.ToArray()));
				circularPrimes.AddRange(primes.Where(p => p == candidatePrime));

				// Rotate the digit
				char firstDigit = digitQueue.Dequeue();
				digitQueue.Enqueue(firstDigit);
			}

			return circularPrimes;
		}

		public bool IsCircularPrime(int prime, int circularPrimeCandidate)
		{
			var circularPrimeCandidateText = circularPrimeCandidate.ToString();
			var primeText = prime.ToString();

			if (circularPrimeCandidateText.Length != primeText.Length)
				return false;

			bool any = circularPrimeCandidateText.All(c => primeText.Contains(c))
				&& primeText.All(c => circularPrimeCandidateText.Contains(c));
			return any;
		}

		public IEnumerable<int> GetPrimesUnder(int limit)
		{
			for (int primeCandidate = 1; primeCandidate <= limit; primeCandidate++)
			{
				if (_prime.IsPrimeNumber(primeCandidate))
					yield return primeCandidate;
			}
		}

		private Queue<char> GetDigitQueue(string primeText)
		{
			Queue<char> digitQueue = new Queue<char>(primeText.Length);
			foreach (char c in primeText)
			{
				digitQueue.Enqueue(c);
			}

			return digitQueue;
		}
	}
}
