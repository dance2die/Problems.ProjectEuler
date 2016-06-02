using System.Collections.Generic;
using System.Numerics;

namespace Demo.ProjectEuler.Tests._0014
{
	public class LongestCollatzSequence
	{
		public int GetLargestCollatzSequenceCount(int maxNumber)
		{
			int maximumSequenceCount = 0;
			int maxInput = 0;

			var lookupDictionary = new Dictionary<BigInteger, int>();
			for (int input = 1; input <= maxNumber; input++)
			{
				var sequenceCount = GetCollatzSequenceCount(input, lookupDictionary);
				if (!lookupDictionary.ContainsKey(sequenceCount))
					lookupDictionary.Add(input, sequenceCount);

				if (sequenceCount > maximumSequenceCount)
				{
					maximumSequenceCount = sequenceCount;
					maxInput = input;
				}
			}

			return maxInput;
		}

		public int GetCollatzSequenceCount(int input, IDictionary<BigInteger, int> lookupDictionary)
		{
			BigInteger sequence = input;
			int count = 1;

			do
			{
				if (lookupDictionary.ContainsKey(sequence))
					return lookupDictionary[sequence] + count;

				if (IsEven(sequence))
					sequence /= 2;
				else
					sequence = 3*sequence + 1;

				count++;
			} while (sequence > 1);

			return count;
		}

		private bool IsEven(BigInteger input)
		{
			return input % 2 == 0;
		}
	}
}