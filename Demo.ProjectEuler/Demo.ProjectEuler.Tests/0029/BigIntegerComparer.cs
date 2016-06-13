using System.Collections.Generic;
using System.Numerics;

namespace Demo.ProjectEuler.Tests._0029
{
	public class BigIntegerComparer : IEqualityComparer<BigInteger>
	{
		public bool Equals(BigInteger x, BigInteger y)
		{
			return x.Equals(y);
		}

		public int GetHashCode(BigInteger obj)
		{
			return obj.GetHashCode();
		}
	}
}