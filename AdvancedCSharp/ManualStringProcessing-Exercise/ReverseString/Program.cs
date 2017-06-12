using System;
using System.Text;

namespace ReverseString
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var reversed = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                reversed.Append(input[input.Length - i - 1]);
            }

            Console.WriteLine(reversed);
        }
    }
}
