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
		private const int UPTO = 10000000;

		private readonly TotientPermutation _sut = new TotientPermutation();

        public TotientPermutationTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TestGeneratingHugeNumberOfPhiCalculations()
        {
            var phis = _sut.GetPhiUpto(UPTO).ToList();

            _output.WriteLine(phis.Count.ToString());
        }

	    [Fact]
	    public void TestHugeTotientDivisions()
	    {
		    var totients = _sut.GetTotientUpto(UPTO).ToList();

			_output.WriteLine(totients.Count.ToString());
		}

	    [Fact]
	    public void ShowResult()
	    {
			Totient totientManager = new Totient();
			Permutation permutationManager = new Permutation();

			double minimum = double.MaxValue;
		    int minimumIndex = 2;
			for (int n = minimumIndex; n <= UPTO; n++)
			{
				var phi = totientManager.GetPhi(n);
				if (permutationManager.IsPermutation(n, phi))
				{
					double totient = n / phi;
					if (totient < minimum)
					{
						minimum = totient;
						minimumIndex = n;
					}
				}
			}

			_output.WriteLine(minimumIndex.ToString());

		    const int expected = 8319823;
		    int actual = minimumIndex;
			Assert.Equal(expected, actual);
	    }
    }

    public class TotientPermutation
    {
        private readonly Totient _totient = new Totient();

	    public IEnumerable<double> GetTotientUpto(int upto)
	    {
			for (int i = 1; i <= upto; i++)
			{
				yield return _totient.GetTotientDivision(i);
			}
		}

	    public IEnumerable<double> GetPhiUpto(int upto)
        {
            for (int i = 1; i <= upto; i++)
            {
                yield return _totient.GetPhi(i);
            }
        }
    }
}
