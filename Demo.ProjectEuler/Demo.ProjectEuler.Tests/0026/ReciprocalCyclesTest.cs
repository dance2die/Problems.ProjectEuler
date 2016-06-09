using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0026
{
	public class ReciprocalCyclesTest : BaseTest
	{
		private readonly ReciprocalCycles _sut = new ReciprocalCycles();

		public ReciprocalCyclesTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public class ReciprocalCycles
	{
	}
}
