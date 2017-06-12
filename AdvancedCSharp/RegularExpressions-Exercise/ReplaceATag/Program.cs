using System;
using System.Text.RegularExpressions;

namespace ReplaceATag
{
    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            while (text != "end")
            {
                var result = Regex.Replace(text, "<a", "[URL");
                result = Regex.Replace(result, "\">", "\"]");
                result = Regex.Replace(result, "</a>", "[/URL]");

                Console.WriteLine(result);

                text = Console.ReadLine();
            }
        }
    }
}
