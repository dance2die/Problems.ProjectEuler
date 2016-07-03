using System.Linq;

namespace Demo.ProjectEuler.Tests._0052
{
	public class PermutedMultiple
	{
		public long GetMultipleCheckPermutedMultiples()
		{
			long counter = 1;

			do
			{
				bool isPermutedMutiple = true;
				for (int multiplyBy = 1; multiplyBy <= 6; multiplyBy++)
				{
					if (!isPermutedMutiple) break;

					isPermutedMutiple = CheckPermutedMultiples(counter, multiplyBy);
				}

				if (isPermutedMutiple) return counter;

				counter++;
			} while (true);
		}

		public bool CheckPermutedMultiples(long input, int multiplyBy)
		{
			long multiplied = input * multiplyBy;
			var multipliedSequence = multiplied.ToString().ToList();
			multipliedSequence.Sort();

			var inputSequence = input.ToString().ToList();
			inputSequence.Sort();

			return inputSequence.SequenceEqual(multipliedSequence);
		}
	}
}