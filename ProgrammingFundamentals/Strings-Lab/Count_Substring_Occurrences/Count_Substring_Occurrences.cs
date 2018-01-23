using System;

namespace Count_Substring_Occurrences
{
    public class Count_Substring_Occurrences
    {
        public static void Main()
        {
            var text = Console.ReadLine().ToLower();
            var word = Console.ReadLine().ToLower();

            var index = text.IndexOf(word);
            var count = 0;

            while (index != -1)
            {
                count++;
                index = text.IndexOf(word, index + 1);
            }

            Console.WriteLine(count);
        }
    }
}
