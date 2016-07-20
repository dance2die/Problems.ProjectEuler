using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0070
{
    public class TotientPermutationTest : BaseTest
    {
        private readonly TotientPermutation _sut = new TotientPermutation();

        public TotientPermutationTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TestGeneratingHugeNumberOfPhiCalculations()
        {
            const int upto = 10000000;

            var totients = _sut.GetPhiUpto(upto).ToList();

            _output.WriteLine(totients.Count.ToString());
        }
    }

    public class TotientPermutation
    {
        private readonly Totient _totient = new Totient();

        public IEnumerable<double> GetPhiUpto(int upto)
        {
            for (int i = 1; i <= upto; i++)
            {
                yield return _totient.GetPhi(i);
            }
        }
    }
}
