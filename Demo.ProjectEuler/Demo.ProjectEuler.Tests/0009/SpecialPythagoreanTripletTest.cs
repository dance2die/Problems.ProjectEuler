using System;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0009
{
	public class SpecialPythagoreanTripletTest
	{
		private readonly ITestOutputHelper _output;

		public SpecialPythagoreanTripletTest(ITestOutputHelper output)
		{
			_output = output;
		}

		[Fact]
		public void FindTriplets()
		{
			const int limit = 997;
			const int power = 2;

			//int maxProduct = 0;
			for (int a = 3; a <= limit; a++)
			{
				for (int b = 3; b <= limit; b++)
				{
					int value = (int)(Math.Pow(a, power) + Math.Pow(b, power));
					int c = (int)Math.Sqrt(value);

					if ((a < b && b < c) 
						&& IsPythagoreanTriplet(a, b, c) 
						&& (a + b + c == 1000))
					{
						_output.WriteLine("A:{0}, B:{1}, C:{2}", a, b, c);
						_output.WriteLine("Product: {0}", a * b * c);
						Assert.True(true);
						return;
					}
				}
			}
			Assert.False(true);
		}

		public bool IsPythagoreanTriplet(int a, int b, int c)
		{
			const int power = 2;
			return Math.Abs(Math.Pow(a, power) + Math.Pow(b, power) - Math.Pow(c, power)) < 0.0001;
		}
		
}