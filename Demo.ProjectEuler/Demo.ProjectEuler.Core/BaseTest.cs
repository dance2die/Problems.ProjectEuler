using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.ProjectEuler.Core
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

	}
}
