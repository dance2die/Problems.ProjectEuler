using System;
using System.Linq;
using System.Numerics;

namespace Demo.ProjectEuler.Tests._0008
{
	internal class LargestProductInASeries
	{
		public BigInteger GetGreatestProduct(string input, int adjacentDigitCount)
		{
			BigInteger maxProduct = 0;

			for (int i = 0; i <= input.Length - adjacentDigitCount; i++)
			{
				// get a string with length of adjacentDigitCount
				string numberString = input.Substring(i, adjacentDigitCount);

				// Calculate current product.
				BigInteger currentProduct = 1;
				foreach (int number in numberString.Select(c => Convert.ToInt32((string) c.ToString())))
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