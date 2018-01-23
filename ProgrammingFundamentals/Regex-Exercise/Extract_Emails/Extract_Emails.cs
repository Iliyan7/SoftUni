using System;
using System.Text.RegularExpressions;

namespace Extract_Emails
{
    public class Extract_Emails
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var pattern = @"(?<=\s)[A-Za-z]([A-Za-z]|\.|-|_)+[A-Za-z]@[A-Za-z]([A-Za-z]|-)+[A-Za-z](\.[A-Za-z]?([A-Za-z]|-)+[A-Za-z]){1,}";

            var regex = new Regex(pattern);
            var matches = regex.Matches(text);

            foreach (Match m in matches)
            {
                Console.WriteLine(m);
            }
        }
    }
}
