using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0501
{
	public class EightDivisorsTest : BaseTest
	{
		private readonly EightDivisors _sut = new EightDivisors();

		public EightDivisorsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(24, true)]
		[InlineData(30, true)]
		[InlineData(40, true)]
		[InlineData(42, true)]
		[InlineData(54, true)]
		[InlineData(56, true)]
		[InlineData(66, true)]
		[InlineData(70, true)]
		[InlineData(78, true)]
		[InlineData(88, true)]
		[InlineData(31, false)]
		[InlineData(44, false)]
		[InlineData(55, false)]
		public void TestHasEightDivisors(int value, bool expected)
		{
			bool actual = _sut.HasEdightDivisors(value);

			Assert.Equal(expected, actual);
		}
	}

	public class EightDivisors
	{
		private readonly Factors _factors = new Factors();

		public bool HasEdightDivisors(int value)
		{
			const int factorCount = 8;
			return _factors.GetFactorCount(value) == factorCount;
		}
	}
}
