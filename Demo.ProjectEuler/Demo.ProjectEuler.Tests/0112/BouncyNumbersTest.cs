﻿using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0112
{
	public class BouncyNumbersTest : BaseTest
	{
		private readonly BouncyNumbers _sut = new BouncyNumbers();

		public BouncyNumbersTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(134468, true)]
		[InlineData(12345, true)]
		[InlineData(1, true)]
		[InlineData(45, true)]
		[InlineData(99, true)]
		[InlineData(123450, false)]
		[InlineData(828, false)]
		[InlineData(121, false)]
		[InlineData(4321, false)]
		[InlineData(88778, false)]
		[InlineData(32, false)]
		[InlineData(101, false)]
		[InlineData(102, false)]
		[InlineData(323, false)]
		public void TestIncreasingNumber(int input, bool expected)
		{
			bool actual = _sut.IsIncreasingNumber(input);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(98765, true)]
		[InlineData(8531, true)]
		[InlineData(4321, true)]
		[InlineData(43210, true)]
		[InlineData(1, true)]
		[InlineData(21, true)]
		[InlineData(321, true)]
		[InlineData(99, true)]
		[InlineData(88778, false)]
		[InlineData(134468, false)]
		[InlineData(12345, false)]
		[InlineData(12345, false)]
		[InlineData(45, false)]
		[InlineData(101, false)]
		[InlineData(102, false)]
		[InlineData(323, false)]
		public void TestDecreasingNumber(int input, bool expected)
		{
			bool actual = _sut.IsDecreasingNumber(input);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(155349, true)]
		[InlineData(88778, true)]
		[InlineData(12321, true)]
		[InlineData(21780, true)]
		[InlineData(12345, false)]
		[InlineData(5311, false)]
		public void TestBouncyNumber(int input, bool expected)
		{
			bool actual = _sut.IsBouncyNumber(input);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestBouncyNumberCountUpto1000()
		{
			const int upto = 1000;
			int actual = _sut.GetBouncyNumberCount(upto);

			const int expected = 525;    // percentage
			Assert.Equal(expected, actual);
		}
	}

	public class BouncyNumbers
	{
		private readonly NumberUtil _numberUtil = new NumberUtil();

		public int GetBouncyNumberCount(int upto)
		{
			int bouncyNumberCount = 0;
			var numbers = Enumerable.Range(1, upto).ToList();
			foreach (var number in numbers)
			{
				if (IsBouncyNumber(number))
					bouncyNumberCount++;
			}

			return bouncyNumberCount;
		}

		public bool IsBouncyNumber(int input)
		{
			if (input < 100) return false;	// by definition

			return !IsIncreasingNumber(input) && !IsDecreasingNumber(input);
		}

		public bool IsDecreasingNumber(int input)
		{
			IEnumerable<int> numbers = _numberUtil.ToReverseSequence(input).Reverse();
			int previousNumber = 9;

			foreach (int number in numbers)
			{
				if (previousNumber < number)
					return false;

				previousNumber = number;
			}

			return true;
		}

		public bool IsIncreasingNumber(int input)
		{
			IEnumerable<int> numbers = _numberUtil.ToReverseSequence(input).Reverse();
			int previousNumber = 0;

			foreach (int number in numbers)
			{
				if (previousNumber > number)
					return false;

				previousNumber = number;
			}

			return true;
		}
	}
}
