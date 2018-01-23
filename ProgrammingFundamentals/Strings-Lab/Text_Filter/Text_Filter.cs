using System;
using System.Linq;

namespace Text_Filter
{
    public class Text_Filter
    {
        public static void Main()
        {
            var bannedWords = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var text = Console.ReadLine();

            for (int i = 0; i < bannedWords.Length; i++)
            {
                text = text.Replace(bannedWords[i], new string('*', bannedWords[i].Length));
            }

            Console.WriteLine(text);
        }
    }
}
