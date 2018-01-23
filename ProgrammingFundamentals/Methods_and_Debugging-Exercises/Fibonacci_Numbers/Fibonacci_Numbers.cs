using System;

namespace Fibonacci_Numbers
{
    public class Fibonacci_Numbers
    {
        public static void Main()
        {
            Console.WriteLine(Fib(int.Parse(Console.ReadLine())));
        }

        public static int Fib(int n)
        {
            int firstTempNum = 0, secondTempNum = 1, currentFibNum = 0;

            for (int i = 0; i < n; i++)
            {
                currentFibNum = firstTempNum + secondTempNum;
                firstTempNum = secondTempNum;
                secondTempNum = currentFibNum;
            }

            return (n == 0) ? 1 : currentFibNum;
        }
    }
}
