using System;

namespace Demo.ProjectEuler.Core
{
	public class MathExt
	{
		public double NthRoot(double number, double rootPower)
		{
			// http://stackoverflow.com/a/18657674/4035
			return Math.Pow(number, 1.0 / rootPower);
		}
	}
}