using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests.LibraryTests
{
	public class ESieveTest : BaseTest
	{
		private readonly ESieve _sut = new ESieve();

		public ESieveTest(ITestOutputHelper output) : base(output)
		{
		}

		/// <remarks>
		/// Generated expected primes using 
		/// http://www.free-online-calculator-use.com/prime-number-generator.html
		/// </remarks>
		[Theory]
		[InlineData(2, new [] { 2 })]
		[InlineData(10, new [] { 2, 3, 5, 7 })]
		[InlineData(50, new [] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47 })]
		[InlineData(100, new [] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 })]
		[InlineData(200, new [] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199 })]
		public void TestGeneratingPrimes(int upto, int[] expected)
		{
			int[] actual = _sut.GetPrimes(upto).ToArray();

			Assert.True(expected.SequenceEqual(actual));
		}
	}
}
