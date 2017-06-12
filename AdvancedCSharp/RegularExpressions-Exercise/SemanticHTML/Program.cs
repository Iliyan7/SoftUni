using System;
using System.Text.RegularExpressions;

namespace SemanticHTML
{
    public class Program
    {
        public static void Main()
        {
            var input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var isMatchOpenTag = Regex.Match(input, "\\s*<div.+((?>id|class)\\s*=\\s*\"(.+?)\").+");
                var isMatchCloseTag = Regex.Match(input, @"\s*<\/div>(\s+<!--\s*(.+?)\s*-->)");

                var output = input;

                if (isMatchOpenTag.Success)
                {
                    output = Regex.Replace(isMatchOpenTag.Value, "div", isMatchOpenTag.Groups[2].Value);
                    output = Regex.Replace(output, isMatchOpenTag.Groups[1].Value, String.Empty);
                    output = Regex.Replace(output, @"\s{2,}", " ");

                    output = output
                        .Remove(output.Length - 1)
                        .TrimEnd(' ');

                    output += ">";
                }
                else if(isMatchCloseTag.Success)
                {
                    output = Regex.Replace(isMatchCloseTag.Value, "div", isMatchCloseTag.Groups[2].Value);
                    output = Regex.Replace(output, isMatchCloseTag.Groups[1].Value, String.Empty);
                }

                Console.WriteLine(output);
            }
        }
    }
}
