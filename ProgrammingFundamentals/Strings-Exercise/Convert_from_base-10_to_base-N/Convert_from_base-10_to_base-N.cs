using System;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Convert_from_base_10_to_base_N
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();

            Console.WriteLine(ConvertToBaseN(numbers[1], (int)numbers[0]));
        }

        public static BigInteger ConvertToBaseN(BigInteger baseTen, int divisor)
        {
            var sb = new StringBuilder();

            var rest = 0;
            var num = baseTen;
            
            while (num > 0)
            {
                rest = (int)(num % divisor);
                num = num / divisor;

                sb.Append(rest.ToString());
            }

            return BigInteger.Parse(ReverseString(sb.ToString()));
        }

        public static string ReverseString(string str)
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
