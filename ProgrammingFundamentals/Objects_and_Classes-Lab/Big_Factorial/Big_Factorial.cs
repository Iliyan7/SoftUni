using System;
using System.Numerics;

namespace Big_Factorial
{
    public class Big_Factorial
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factorial = GetBigFactorial(n);

            Console.WriteLine(factorial);
        }

        public static BigInteger GetBigFactorial(int n)
        {
            BigInteger result = 1;

            if (n == 1)
            {
                return 1; 
            }

            return n * GetBigFactorial(n-1);
        }
    }
}
