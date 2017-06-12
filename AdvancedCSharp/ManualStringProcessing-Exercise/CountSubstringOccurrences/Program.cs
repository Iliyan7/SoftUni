using System;

namespace CountSubstringOccurrences
{
    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine()
                .ToLower();

            var subString = Console.ReadLine()
                .ToLower();

            var count = 0;

            while (true)
            {
                if (!text.Contains(subString))
                    break;

                text = text.Remove(text.IndexOf(subString), 1);
                count++;
            }

            Console.WriteLine(count);
        }
    }
}
