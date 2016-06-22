using System.Linq;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0040
{
	public class ChampernownesConstantTest : BaseTest
	{
		private readonly ChampernownesConstant _sut = new ChampernownesConstant();

		public ChampernownesConstantTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(1, "1")]
		[InlineData(2, "12")]
		[InlineData(10, "12345678910")]
		[InlineData(12, "123456789101112")]
		[InlineData(21, "123456789101112131415161718192021")]
		public void TestGeneratingNumberStringUpto(int upto, string expected)
		{
			string actual = _sut.GetNumberStringUpto(upto);

			Assert.Equal(expected, actual);
		}
	}

	public class ChampernownesConstant
	{
		public string GetNumberStringUpto(int upto)
		{
			return string.Join("", Enumerable.Range(1, upto).Select(number => number.ToString()));
		}
	}
}
