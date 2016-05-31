using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0008
{
	public class LargestProductInASeriesTest : BaseTest
	{
		private readonly LargestProductInASeries _sut = new LargestProductInASeries();
		private const string INPUT = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";

		public LargestProductInASeriesTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestFourAdjacentDigitsForGreatestProduct()
		{
			const int expected = 5832;

			const int adjacentDigitCount = 4;
			int actual = _sut.GetGreatestProduct(INPUT, adjacentDigitCount);

			Assert.Equal(expected, actual);
		}
	}

	internal class LargestProductInASeries
	{
		public int GetGreatestProduct(string input, int adjacentDigitCount)
		{
			int maxProduct = 0;

			for (int i = 0; i < input.Length - adjacentDigitCount; i++)
			{
				// get a string with length of adjacentDigitCount
				string numberString = input.Substring(i, adjacentDigitCount);

				// Calculate current product.
				int currentProduct = 1;
				foreach (int number in numberString.Select(c => Convert.ToInt32(c.ToString())))
				{
					currentProduct *= number;
				}

				// if current product is greater than the maxProduct, set the maxProduct to the current product.
				if (currentProduct > maxProduct)
					maxProduct = currentProduct;
			}

			return maxProduct;
		}
	}
}
