using System;
using System.Text;

namespace ConcatenateStrings
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var text = new StringBuilder(n * 5);

            for (int i = 0; i < n; i++)
            {
                text.AppendFormat("{0} ", Console.ReadLine());
            }

            Console.WriteLine(text.ToString().TrimEnd());
        }
    }
}
