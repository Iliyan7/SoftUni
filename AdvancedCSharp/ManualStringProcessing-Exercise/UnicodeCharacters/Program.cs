using System;

namespace UnicodeCharacters
{
    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            foreach (var c in text)
            {
                Console.Write("\\u{0:x4}", (int)c);
            }

            Console.WriteLine();
        }
    }
}
