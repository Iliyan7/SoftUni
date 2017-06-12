using System;
using System.Numerics;
using System.Text;

namespace ConvertFromBase10ToBaseN
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ');

            var baseN = int.Parse(input[0]);
            var base10 = BigInteger.Parse(input[1]);
            
            Console.WriteLine(ConvertToBaseN(base10, baseN));
        }

        private static string ConvertToBaseN(BigInteger base10, int baseN)
        {
            var sb = new StringBuilder();

            var num = base10;
            var remainder = 0;

            while (num > 0)
            {
                remainder = (int)(num % baseN);
                num = num / baseN;

                sb.Append(remainder.ToString());
            }

            return ReverseString(sb.ToString());
        }

        private static string ReverseString(string str)
        {
            var sb = new StringBuilder(str.Length);

            for (int i = str.Length - 1; i >= 0; i--)
            {
                sb.Append(str[i]);
            }

            return sb.ToString();
        }
    }
}
