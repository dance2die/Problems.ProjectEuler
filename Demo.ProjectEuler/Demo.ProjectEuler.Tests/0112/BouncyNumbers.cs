using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;

namespace Demo.ProjectEuler.Tests._0112
{
	public class BouncyNumbers
	{
		private readonly NumberUtil _numberUtil = new NumberUtil();

		public int GetBouncyNumberPercentageUpto(int uptoPercentage)
		{
			int bouncyNumberCountTotal = 0;
			int from = 1;

			do
			{
				int bouncyNumberCount = GetBouncyNumberCountBetween(from, 1);
				bouncyNumberCountTotal += bouncyNumberCount;
				if (bouncyNumberCountTotal*100/from == 99)
					return from;

				from++;
			} while (true);
		}

		public int GetBouncyNumberPercentage(int upto)
		{
			return GetBouncyNumberCount(upto) * 100 / upto;
		}

		public int GetBouncyNumberCountBetween(int from, int count)
		{
			int bouncyNumberCount = 0;
			var numbers = Enumerable.Range(from, count);
			foreach (var number in numbers)
			{
				if (IsBouncyNumber(number))
					bouncyNumberCount++;
			}

			return bouncyNumberCount;
		}

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
			IEnumerable<int> numbers = _numberUtil.ToReverseSequence(input);
			return IsNotBouncyNumber(input, numbers);
		}

		public bool IsIncreasingNumber(int input)
		{
			IEnumerable<int> numbers = _numberUtil.ToReverseSequence(input).Reverse();
			return IsNotBouncyNumber(input, numbers);
		}

		private bool IsNotBouncyNumber(int input, IEnumerable<int> numberSequence)
		{
			int previousNumber = 0;

			foreach (int number in numberSequence)
			{
				if (previousNumber > number)
					return false;

				previousNumber = number;
			}

			return true;
		}
	}
}