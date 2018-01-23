using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Convert_from_base_N_to_base_10
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();

            Console.WriteLine(ConvertToBaseTen(numbers[1], (int)numbers[0]));
        }

        public static BigInteger ConvertToBaseTen(BigInteger baseN, int notation)
        {
            var num = baseN.ToString();
            var pow = 0;

            var list = new List<BigInteger>();

            for (int i = num.Length - 1; i >= 0; i--)
            {
                var result = Convert.ToInt32(num[i].ToString()) * Pow(notation, pow++);

                list.Add(result);
            }

            return list.Aggregate((sum, n) => sum + n);
        }

        public static BigInteger Pow(int N, int power)
        {
            BigInteger result = 1;

            for (int i = 0; i < power; i++)
            {
                result *= N;
            }

            return result;
        }
    }
}
