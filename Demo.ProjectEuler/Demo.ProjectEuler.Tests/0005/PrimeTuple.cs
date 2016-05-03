namespace Demo.ProjectEuler.Tests._0005
{
	/// <summary>
	/// Writable Integer tuple
	/// </summary>
	public class PrimeTuple
	{
		public int PrimeNumber { get; set; }
		public int Power { get; set; }

		public PrimeTuple(int primeNumber, int power)
		{
			PrimeNumber = primeNumber;
			Power = power;
		}
	}
}