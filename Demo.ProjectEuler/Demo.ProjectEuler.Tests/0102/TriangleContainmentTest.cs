using System.IO;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0102
{
	public class TriangleContainmentTest : BaseTest
	{
		private readonly TriangleContainment _sut = new TriangleContainment();

		public TriangleContainmentTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(new[] { -340, 495, -153, -910, 835, -947 }, true)]
		[InlineData(new[] { -175, 41, -421, -714, 574, -645 }, false)]
		public void TestSampleData(int[] points, bool expected)
		{
			bool actual = _sut.ContainsOrigin(points);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			string input = File.ReadAllText("./0102/p102_triangles.txt");

			int actual = _sut.GetNumberOfTrianglesContainingOrigin(input);
			_output.WriteLine(actual.ToString());

			const int expected = 228;
			Assert.Equal(expected, actual);
		}
	}
}
