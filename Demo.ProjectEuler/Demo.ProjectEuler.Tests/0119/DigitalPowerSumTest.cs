﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Demo.ProjectEuler.Tests._0042;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0119
{
	public class DigitalPowerSumTest : BaseTest
	{
		private readonly DigitalPowerSum _sut = new DigitalPowerSum();

		public DigitalPowerSumTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(1, false)]
		[InlineData(9, false)]
		[InlineData(512, true)]
		[InlineData(614656, true)]
		public void TestDigitPowerSum(long number, bool expected)
		{
			bool actual = _sut.IsDigitPower(number);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(512, 2)]
		[InlineData(614656, 10)]
		public void TestNthDigitPowerSum(long number, int expected)
		{
			int actual = _sut.GetPowerDigitSumIndex(number);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(2, 512)]
		[InlineData(10, 614656)]
		[InlineData(30, 248155780267521)]
		public void ShowResult(int position, long expected)
		{
			BigInteger actual = _sut.GetNthPowerDigitSum(position);
			_output.WriteLine(actual.ToString());

			Assert.Equal(expected, actual);
		}
	}

	public class DigitalPowerSum
	{
		private readonly NumberUtil _numberUtil = new NumberUtil();

		public BigInteger GetNthPowerDigitSum(int position)
		{
			List<Tuple<int, BigInteger, int>> poweredValues = new List<Tuple<int, BigInteger, int>>();

			// Calculate upto 10th power for numbers
			for (int power = 2; power <= 8; power++)
			{
				// Calculate up to 10000 (random number)
				for (int number = 1; number < 10000; number++)
				{
					if (number % 10 == 0) continue;

					BigInteger powered = power == 1 ? number : BigInteger.Pow(number, power);
					var value = new Tuple<int, BigInteger, int>(number, powered, power);
					poweredValues.Add(value);
				}
			}

			int counter = 0;
			foreach (Tuple<int, BigInteger, int> poweredValue in poweredValues)
			{
				var numberList = _numberUtil.ToReverseSequence(poweredValue.Item2).ToList();
				BigInteger numberSequenceSum = numberList.Aggregate((currentSum, item) => currentSum + item);

				if (numberSequenceSum != 1 && numberSequenceSum == poweredValue.Item1)
					counter++;

				if (counter == position)
					return poweredValue.Item2;
			}

			return counter++;
		}

		public long GetNthPowerDigitSum2(int position)
		{
			int count = 0;
			int i = 1;

			do
			{
				if (IsDigitPower(i))
					count++;

				i++;
			} while (count <= 30);

			return count;
		}

		public int GetPowerDigitSumIndex(long number)
		{
			int count = 0;

			for (int i = 10; i <= number; i++)
			{
				if (IsDigitPower(i))
					count++;
			}

			return count;
		}

		public bool IsDigitPower(long number)
		{
			if (number < 10) return false;  // by definition

			var numberSequenceSum = _numberUtil
				.ToReverseSequence(number)
				.Aggregate((currentSum, item) => currentSum + item);
			int power = 1;

			do
			{
				if (numberSequenceSum == 1) return false;

				BigInteger powered = BigInteger.Pow(numberSequenceSum, power);
				if (powered == number) return true;
				if (powered > number) return false;

				power++;
			} while (true);
		}
	}
}
