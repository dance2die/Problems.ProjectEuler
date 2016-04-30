using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0020
{
	public class FactorialDigitSumTest
	{
		private readonly ITestOutputHelper _output;
		private readonly FactorialDigitSum _sut;

		public FactorialDigitSumTest(ITestOutputHelper output)
		{
			_output = output;
			_sut = new FactorialDigitSum();
		}

		[Theory]
		[InlineData(-100, 1)]
		[InlineData(0, 1)]
		[InlineData(1, 1)]
		[InlineData(2, 2)]
		[InlineData(3, 6)]
		[InlineData(4, 24)]
		[InlineData(5, 120)]
		[InlineData(6, 720)]
		[InlineData(10, 3628800)]
		public void TestFactorials(int input, float expectedResult)
		{
			float actualResult = _sut.GetFactorial(input);

			Assert.Equal(expectedResult, actualResult);
		}
	}

	public class FactorialDigitSum
	{
		public float GetFactorial(int input)
		{
			float result = 1;
			if (input <= 1)
				return 1;

			for (int i = input; i > 0; i--)
			{
				result *= i;
			}

			return result;
		}
	}
}
