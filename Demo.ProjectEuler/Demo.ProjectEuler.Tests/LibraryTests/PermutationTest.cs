using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests.LibraryTests
{
    public class PermutationTest : BaseTest
    {
        private readonly Permutation _sut = new Permutation();

        public PermutationTest(ITestOutputHelper output) : base(output)
        {
        }
    }
}
