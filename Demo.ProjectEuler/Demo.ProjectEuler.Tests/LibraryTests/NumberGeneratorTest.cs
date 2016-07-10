using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests.LibraryTests
{
	public class NumberGeneratorTest : BaseTest
	{
		private readonly NumberGenerator _sut = new NumberGenerator();

		public NumberGeneratorTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(1, 1)]
		[InlineData(2, 4)]
		[InlineData(3, 9)]
		[InlineData(4, 16)]
		[InlineData(5, 25)]
		public void TestSquareNumber(int input, long expected)
		{
			long actual = _sut.GetSquareNumber(input);

			Assert.Equal(expected, actual);
		}
	}
}
