using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0061
{
	public class CyclicalFigurateNumbersTest : BaseTest
	{
		private readonly CyclicalFigurateNumbers _sut = new CyclicalFigurateNumbers();

		public CyclicalFigurateNumbersTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class CyclicalFigurateNumbers
	{
	}
}
