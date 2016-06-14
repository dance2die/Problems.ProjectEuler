using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
	}

	public class CircularPrimes
	{
	}
}
