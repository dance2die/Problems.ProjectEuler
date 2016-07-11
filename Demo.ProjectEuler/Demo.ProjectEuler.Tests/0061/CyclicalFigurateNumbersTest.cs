using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0061
{
	public class CyclicalFigurateNumbersTest : BaseTest
	{
		private readonly CyclicalFigurateNumbers _sut = new CyclicalFigurateNumbers();

		public CyclicalFigurateNumbersTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestGeneratingFourDigitTriangleNumbers()
		{
			var fourDigitTriangleNumbers = _sut.GetFourDigitTriangleNumbers().ToList();
			var actual = fourDigitTriangleNumbers.Count;

			_output.WriteLine("fourDigitTriangleNumbers.Count: {0}", actual);
			const int expected = 96;	// calculated via trial-error.
			Assert.Equal(expected, actual);
		}
	}

	public class CyclicalFigurateNumbers
	{
		private readonly NumberGenerator _numberGenerator = new NumberGenerator();

		public IEnumerable<long> GetFourDigitTriangleNumbers()
		{
			// First 4-digit triangle number starts at 45: 
			// calculated using http://www.mathgoodies.com/calculators/triangular-numbers.html
			const int limit = 10000;
			for (int i = 45;; i++)
			{
				var triangleNumber = _numberGenerator.GetTriangleNumber(i);
				if (triangleNumber < limit)
					yield return triangleNumber;
				else
					yield break;
			}
		}
	}
}
