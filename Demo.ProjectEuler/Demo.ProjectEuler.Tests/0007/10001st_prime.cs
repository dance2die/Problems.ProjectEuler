using Demo.ProjectEuler.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0007
{
	public class _10001st_prime
	{
		private readonly ITestOutputHelper _output;

		public _10001st_prime(ITestOutputHelper output)
		{
			_output = output;
		}

		[Fact]
		public void Get10001stPrime()
		{
			Prime prime = new Prime();
			int counter = 0;
			int number = 2;
			do
			{
				if (prime.IsPrimeNumber(number))
				{
					counter++;
					if (counter % 2000 == 0 || counter == 10001)
						_output.WriteLine("Prime ({0}): {1}", counter, number);
				}
				number++;
			} while (counter <= 10001);
		}
	}
}
