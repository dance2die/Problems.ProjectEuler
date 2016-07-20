using System.Collections.Generic;

namespace Demo.ProjectEuler.Core
{
    public class Totient
    {
        public double GetTotientDivision(int n)
        {
            //var relativePrimes = GetRelativePrimes(n).ToList();
            //return (double) n / relativePrimes.Count;

            //return (double) n/GetRelativePrimeCount(n);
            return (double) n/GetPhi(n);
        }

        public int GetRelativePrimeCount(int n)
        {
            int result = 1;

            for (int i = 2; i < n; i++)
            {
                if (GreatestCommonDivisor(n, i) == 1)
                    result++;
            }

            return result;
        }

        public IEnumerable<int> GetRelativePrimes(int n)
        {
            yield return 1;	// everything is divisible by 1.

            for (int i = 2; i < n; i++)
            {
                if (GreatestCommonDivisor(n, i) == 1)
                    yield return i;
            }
        }

        /// <summary>
        /// <see cref="https://en.wikipedia.org/wiki/Euclidean_algorithm"/>
        /// </summary>
        public int GreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                var temp = a;
                a = b;
                b = temp % b;
            }

            return a;
        }

        /// <summary>
        /// <see cref="https://en.wikipedia.org/wiki/Euclidean_algorithm"/>
        /// </summary>
        private int GreatestCommonDivisor2(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }

            return a;
        }

        // http://www.geeksforgeeks.org/eulers-totient-function/
        public double GetPhi(int n)
        {
            double result = n;   // Initialize result as n

            // Consider all prime factors of n and subtract their
            // multiples from result
            for (int p = 2; p * p <= n; ++p)
            {
                // Check if p is a prime factor.
                if (n % p == 0)
                {
                    // If yes, then update n and result 
                    while (n % p == 0)
                        n /= p;
                    result -= result / p;
                }
            }

            // If n has a prime factor greater than sqrt(n)
            // (There can be at-most one such prime factor)
            if (n > 1)
                result -= result / n;
            return result;
        }
    }
}