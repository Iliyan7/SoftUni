using System;
using System.Text.RegularExpressions;

namespace Replace_a_tag
{
    public class Replace_a_tag
    {
        public static void Main()
        {
            var pattern = @"<a(.*?)>(.*?)<\/a>";
            var replacement = @"[URL$1]$2[/URL]";

            while (true)
            {
                var text = Console.ReadLine();

                if (text == "end") break;

                var regex = new Regex(pattern);
                var result = regex.Replace(text, replacement);

                Console.WriteLine(result);
            }
        }
    }
}
