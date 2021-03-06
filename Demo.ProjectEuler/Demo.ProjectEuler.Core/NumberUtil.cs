﻿using System.Collections.Generic;
using System.Numerics;

namespace Demo.ProjectEuler.Core
{
	public class NumberUtil
	{
		public IEnumerable<int> ToReverseSequence(BigInteger number)
		{
			while (number > 0)
			{
				int digit = (int) (number % 10);
				yield return digit;

				number /= 10;
			}
		}
	}
}