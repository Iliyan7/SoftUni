using System;

namespace Unicode_Characters
{
    public class Unicode_Characters
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
