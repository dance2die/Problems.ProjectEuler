using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
	}

	public class TriangleContainment
	{
		/// <summary>
		/// Find if the triangle specified by the given points contains origin or not
		/// using algorithm found here. <see cref="http://stackoverflow.com/a/2049593/4035"/>
		/// </summary>
		public bool ContainsOrigin(int[] points)
		{
			if (points.Length != 6)
				throw new ArgumentException("There should be 6 numbers!", nameof(points));

			return false;
		}
	}
}
