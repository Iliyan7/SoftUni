using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ConvertFromBaseNToBase10
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ');

            var baseN = int.Parse(input[0]);
            var baseNNumber = BigInteger.Parse(input[1]);

            Console.WriteLine(ConvertToBase10(baseN, baseNNumber));
        }

        private static BigInteger ConvertToBase10(int baseN, BigInteger baseNNumber)
        {
            var num = baseNNumber.ToString();
            var pow = 0;

            var list = new List<BigInteger>();

            for (int i = num.Length - 1; i >= 0; i--)
            {
                list.Add(int.Parse(num[i].ToString()) * Pow(baseN, pow++));
            }

            return list
                .Aggregate((sum, n) => sum + n);
        }

        private static BigInteger Pow(int num, int power)
        {
            BigInteger result = 1;

            for (int i = 0; i < power; i++)
            {
                result *= num;
            }

            return result;
        }
    }
}
