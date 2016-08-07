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
			const long expected = 8739992577;

			long actual = _sut.GetLast10Digits();

			Assert.Equal(expected, actual);
		}
	}

	public class LargeNonMersennePrime
	{
		public long GetLast10Digits()
		{
			return -1;
		}
	}
}
