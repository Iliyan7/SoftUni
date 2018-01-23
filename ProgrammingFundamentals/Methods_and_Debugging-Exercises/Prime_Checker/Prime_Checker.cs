using System;

namespace Prime_Checker
{
    public class Prime_Checker
    {
        public static void Main()
        {
            Console.WriteLine(isPrime(long.Parse(Console.ReadLine())));
        }

        public static bool isPrime(long number)
        {
            if (number < 2)
                return false;

            for (long i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}
