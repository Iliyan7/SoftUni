using System;

namespace RecursiveFibonacci
{
    public class Program
    {
        private static long[] fibonacciNumbers;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            fibonacciNumbers = new long[n];
            Console.WriteLine(GetFibonacci(n));
        }

        private static long GetFibonacci(int n)
        {
            if (n == 1 || n == 2)
                return 1;
            else if (fibonacciNumbers[n - 1] > 0)
                return fibonacciNumbers[n - 1];

            return fibonacciNumbers[n - 1] = GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}