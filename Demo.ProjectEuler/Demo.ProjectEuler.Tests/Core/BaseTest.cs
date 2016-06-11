using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests.Core
{
	public class BaseTest
	{
		protected readonly ITestOutputHelper _output;

		public BaseTest(ITestOutputHelper output)
		{
			_output = output;
		}

		// http://stackoverflow.com/a/17545215/4035
		protected bool EqualsExcludingWhitespace(string expected, string actual)
		{
			return expected.Where(c => !char.IsWhiteSpace(c))
			   .SequenceEqual(actual.Where(c => !char.IsWhiteSpace(c)));
		}

		/// <summary>
		/// Compare two list of list sequences.
		/// </summary>
		protected bool IsMultidimensionalArrayEqual<T>(
			T[,] array1, T[,] array2)
		{
			if (array1.Length != array2.Length)
				return false;

			for (int i = 0; i < array1.Length; i++)
			{
				for (int j = 0; j < array1.Length; j++)
				{
					if (!array1[i, j].Equals(array2[i, j]))
						return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Compare two list of list sequences.
		/// </summary>
		protected bool IsMultidimensionalArraySequenceEqual<T>(
			IEnumerable<IEnumerable<int>> enumerable1, IEnumerable<IEnumerable<int>> enumerable2)
		{
			var list1 = enumerable1.ToList();
			var list2 = enumerable2.ToList();

			for (int i = 0; i < list1.Count; i++)
			{
				if (!list1[i].SequenceEqual(list2[i]))
					return false;
			}

			return true;
		}
	}
}
