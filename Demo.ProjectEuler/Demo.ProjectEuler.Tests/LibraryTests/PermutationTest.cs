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

        [Theory]
        [InlineData(1, 1, true)]
        [InlineData(12, 21, true)]
        [InlineData(12, 213, false)]
        [InlineData(1234, 2341, true)]
        [InlineData(1234, 2345, false)]
        [InlineData(10, 1, false)]
        public void TestIsPermutation(int value1, int value2, bool expected)
        {
            bool actual = _sut.IsPermutation(value1, value2);

            Assert.Equal(expected, actual);
        }
    }
}
