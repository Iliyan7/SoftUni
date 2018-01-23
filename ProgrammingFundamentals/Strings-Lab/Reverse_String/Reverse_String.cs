using System;
using System.Text;

namespace Reverse_String
{
    public class Reverse_String
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            Console.WriteLine(ReverseString(text));
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
