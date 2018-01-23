using System;
using System.Numerics;

namespace Factorial_Trailing_Zeroes
{
    public class Factorial_Trailing_Zeroes
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factorial = GetFactorial(n);

            Console.WriteLine(GetTrailingZero(factorial));
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

        public static int GetTrailingZero(BigInteger factorial)
        {
            string strNum = factorial.ToString();

            int count = 0;

            for (int i = strNum.Length - 1; i >= 0; i--)
            {
                if (strNum[i] == '0')
                    count++;
                else
                    break;
            }

            return count;
        }
    }
}
