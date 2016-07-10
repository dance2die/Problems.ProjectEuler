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
		public void TestSquareNumber(int n, long expected)
		{
			long actual = _sut.GetSquareNumber(n);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(1, 1)]
		[InlineData(2, 7)]
		[InlineData(3, 18)]
		[InlineData(4, 34)]
		[InlineData(5, 55)]
		public void TestHeptagonalNumber(int n, long expected)
		{
			long actual = _sut.GetHeptagonalNumber(n);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(1, 1)]
		[InlineData(2, 8)]
		[InlineData(3, 21)]
		[InlineData(4, 40)]
		[InlineData(5, 65)]
		public void TestOctagonalNumber(int n, long expected)
		{
			long actual = _sut.GetOctagonalNumber(n);

			Assert.Equal(expected, actual);
		}
	}
}
