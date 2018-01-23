using System;

namespace Primes_in_Given_Range
{
    public class Primes_in_Given_Range
    {
        public static void Main()
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());

            string primeNums = null;

            for (int i = startNum; i <= endNum; i++)
            {
                if (isPrime(i))
                    primeNums += string.Format("{0}, ", i);
            }

            char[] charToTrims = new char[] { ',', ' ' };
            Console.WriteLine("{0}", primeNums.TrimEnd(charToTrims));
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
