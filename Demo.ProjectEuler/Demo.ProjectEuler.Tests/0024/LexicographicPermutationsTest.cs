using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0024
{
	public class LexicographicPermutationsTest : BaseTest
	{
		private readonly LexicographicPermutations _sut = new LexicographicPermutations();

		public LexicographicPermutationsTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class LexicographicPermutations
	{
	}
}
