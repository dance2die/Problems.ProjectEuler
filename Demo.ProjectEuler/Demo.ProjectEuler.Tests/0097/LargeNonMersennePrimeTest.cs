using System;
using System.Numerics;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0097
{
	public class LargeNonMersennePrimeTest : BaseTest
	{
		private readonly LargeNonMersennePrime _sut = new LargeNonMersennePrime();

		public LargeNonMersennePrimeTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void ShowResult()
		{
			const int power = 7830457;

			int left = 28433;
			BigInteger right = BigInteger.Pow(2, power);

			BigInteger result = left * right + 1;

			string resultString = result.ToString();
			_output.WriteLine(resultString.Substring(resultString.Length - 10));

			// output 8739992577
		}

		[Fact]
		public void ShowResultOptimized()
		{
			const string expected = "8739992577";

			string actual = _sut.GetLast10Digits();

			Assert.Equal(expected, actual);
		}
	}

	public class LargeNonMersennePrime
	{
		public string GetLast10Digits()
		{
			const long power = 7830456;	// one less because we are starting with 2.
			const long multiplier = 28433;

			long last10Digits = 2;
			for (int i = 1; i <= power; i++)
			{
				long powered = last10Digits * 2;
				string poweredString = powered.ToString();
				last10Digits = poweredString.Length > 10 
					? Convert.ToInt64(poweredString.Substring(poweredString.Length - 10))
					: powered;
			}

			long output = last10Digits * multiplier + 1;
			string outputString = output.ToString();

			return outputString.Substring(outputString.Length - 10);
		}
	}
}
