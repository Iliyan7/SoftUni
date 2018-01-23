using System;
using System.Linq;

namespace Sieve_of_Eratosthenes
{
    public class Sieve_of_Eratosthenes
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            bool[] primes = new bool[n + 1];

            MakeAllToTrue(primes, primes.Length);
            MakeOnlyPrimesToTrue(primes, primes.Length);

            int[] primesArr = GetPrimes(primes, primes.Length);
            Console.WriteLine(string.Join(" ", primesArr.Where(x => x != 0).ToArray()));
        }

        public static void MakeAllToTrue(bool[] primes, int n)
        {
            for (int i = 2; i < n; i++)
            {
                primes[i] = true;
            }
        }

        public static void MakeOnlyPrimesToTrue(bool[] primes, int n)
        {
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (primes[i])
                {
                    for (int j = i * i, m = 0; j < n; j = (i * i + m * i), m++)
                    {
                        primes[j] = false;
                    }
                }
            }
        }

        public static int[] GetPrimes(bool[] primes, int n)
        {
            int[] tempArr = new int[n - 1];

            for (int i = 2; i < n; i++)
            {
                if (primes[i])
                    tempArr[i - 1] = i;
            }

            return tempArr;
        }
    }
}
