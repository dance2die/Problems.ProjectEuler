using System.Collections.Generic;

namespace Demo.ProjectEuler.Core
{
	public class NumberUtil
	{
		public IEnumerable<int> ToReverseSequence(long number)
		{
			while (number > 0)
			{
				int digit = (int)number % 10;
				yield return digit;

				number /= 10;
			}
		}
	}
}