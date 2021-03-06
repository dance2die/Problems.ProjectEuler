using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Demo.ProjectEuler.Tests._0017
{
	internal class NumberLetterCounts
	{
		private readonly Dictionary<int, string> _numberDictionary= new Dictionary<int, string>
		{
			[1] = "One", [2] = "Two", [3] = "Three", [4] = "Four", [5] = "Five",
			[6] = "Six", [7] = "Seven", [8] = "Eight", [9] = "Nine", [10] = "Ten",
			[11] = "Eleven", [12] = "Twelve", [13] = "Thirteen", [14] = "Fourteen", [15] = "Fifteen",
			[16] = "Sixteen", [17] = "Seventeen", [18] = "Eighteen", [19] = "Nineteen",
			[20] = "Twenty", [30] = "Thirty", [40] = "Forty", [50] = "Fifty", [60] = "Sixty",
			[70] = "Seventy", [80] = "Eighty", [90] = "Ninety", [100] = "Hundred", [1000] = "Thousand",
		};

		public BigInteger GetNumberStringCountUpto(int numberUpto)
		{
			BigInteger result = 0;
			foreach (string numberString in GetNumberStringListUpto(numberUpto))
			{
				result += string.Join("", numberString.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)).Length;
			}

			return result;
		}

		public IEnumerable<string> GetNumberStringListUpto(int numberUpto)
		{
			for (int number = 1; number <= numberUpto; number++)
			{
				string numberString = GetNumberString(number);
				yield return numberString;
			}
		}

		/// <summary>
		/// Converts the number between 1 and 1000 to a pronouncable string.
		/// </summary>
		/// <remarks>
		/// if $t.Item1 (hundredth digit) exists,
		///		Look up [1-9] and Append
		///		Append "Hundred"
		///
		///	if $t.Item2 (tenth digit) == 0
		///		Don't append anything
		///	else if (10 &lt;= $t.Item2 &lt;= 19) then 
		///		Append values between [10-19]
		///	else if (20 &lt;= $t.Item2 &lt;= 99) then
		///		Append t.Item2 + "0"
		///		Append values between [20-90]
		///	
		///	if $t.Item3 == 0
		///		Don't append anything
		///	else
		///		Append values between [1-9]
		/// </remarks>
		public string GetNumberString(int number)
		{
			if (number == 1000)
				return "One Thousand";

			// Parse number into a $t = Tuple<int?, int?, int>
			Tuple<int?, int?, int> numberTuple = ParseNumber(number);
			StringBuilder buffer = new StringBuilder();

			if (numberTuple.Item1.HasValue)
				AppendHundredDigit(buffer, numberTuple);

			if (numberTuple.Item2.HasValue)
				AppendTenthDigitString(numberTuple, buffer);

			if (numberTuple.Item3 != 0)
				AppendZeroDigitString(numberTuple, buffer);

			string result = buffer.ToString().Trim();
			return result;
		}

		private void AppendHundredDigit(StringBuilder buffer, Tuple<int?, int?, int> numberTuple)
		{
			buffer.AppendFormat("{0} {1}", _numberDictionary[numberTuple.Item1.Value], _numberDictionary[100]);
		}

		private void AppendTenthDigitString(Tuple<int?, int?, int> numberTuple, StringBuilder buffer)
		{
			if (numberTuple.Item1.HasValue && numberTuple.Item2 != 0)
				buffer.Append(" And ");

			int tenthDigitValue = Convert.ToInt32(string.Format("{0}{1}",
				numberTuple.Item2.Value, numberTuple.Item3));
			if (10 <= tenthDigitValue && tenthDigitValue <= 19)
			{
				buffer.Append(_numberDictionary[tenthDigitValue]);
			}
			else if (20 <= tenthDigitValue && tenthDigitValue <= 99)
			{
				int flattenedTenthDigitValue = Convert.ToInt32(numberTuple.Item2.Value + "0");
				buffer.Append(_numberDictionary[flattenedTenthDigitValue]);
			}
		}

		private void AppendZeroDigitString(Tuple<int?, int?, int> numberTuple, StringBuilder buffer)
		{
			int tenthDigitValue = Convert.ToInt32(string.Format("{0}{1}",
				numberTuple.Item2 ?? 0, numberTuple.Item3));

			if (numberTuple.Item1.HasValue &&
			    numberTuple.Item3 != 0 &&
			    tenthDigitValue < 10)
				buffer.Append(" And ");
			else
				buffer.Append(" ");

			if (10 > tenthDigitValue || tenthDigitValue > 19)
				buffer.Append(_numberDictionary[numberTuple.Item3]);
		}

		private Tuple<int?, int?, int> ParseNumber(int number)
		{
			var digits = number.ToString().ToCharArray().Select(c => Convert.ToInt32((string) c.ToString())).ToList();
			var length = digits.Count;

			if (length == 3) return new Tuple<int?, int?, int>(digits[0], digits[1], digits[2]);
			if (length == 2) return new Tuple<int?, int?, int>(null, digits[0], digits[1]);
			if (length == 1) return new Tuple<int?, int?, int>(null, null, digits[0]);

			throw new ArgumentException("Number should have up to 3 digits!");
		}
	}
}