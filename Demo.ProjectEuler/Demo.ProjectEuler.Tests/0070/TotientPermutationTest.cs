using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0070
{
    public class TotientPermutationTest : BaseTest
    {
        private readonly TotientPermutation _sut = new TotientPermutation();

        public TotientPermutationTest(ITestOutputHelper output) : base(output)
        {
        }
    }

    public class TotientPermutation
    {
    }
}
