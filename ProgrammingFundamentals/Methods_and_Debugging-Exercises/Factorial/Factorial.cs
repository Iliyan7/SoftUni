using System;
using System.Numerics;

namespace Factorial
{
    public class Factorial
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFactorial(n));
        }

        public static BigInteger GetFactorial(int n)
        {
            BigInteger factorial = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
