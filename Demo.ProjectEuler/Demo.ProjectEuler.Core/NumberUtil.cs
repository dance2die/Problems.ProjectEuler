using System.Collections.Generic;
using System.Numerics;

namespace Demo.ProjectEuler.Core
{
	public class NumberUtil
	{
		public IEnumerable<long> ToReverseSequence(BigInteger number)
		{
			while (number > 0)
			{
				long digit = (long) number % 10;
				yield return digit;

				number /= 10;
			}
		}
	}
}