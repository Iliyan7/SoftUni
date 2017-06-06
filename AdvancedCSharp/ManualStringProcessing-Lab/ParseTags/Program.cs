using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTags
{
    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var openTag = "<upcase>";
            var closeTag = "</upcase>";

            var openTagIndex = 0;
            while ((openTagIndex = text.IndexOf(openTag)) != -1)
            {
                var closeTagIndex = text.IndexOf(closeTag);

                if (closeTagIndex == -1)
                    break;

                var toBeReplaced = text
                    .Substring(openTagIndex, closeTagIndex - openTagIndex + closeTag.Length);

                var toUpper = toBeReplaced
                    .Replace(openTag, String.Empty)
                    .Replace(closeTag, String.Empty)
                    .ToUpper();

                text = text
                    .Replace(toBeReplaced, toUpper);
            }

            Console.WriteLine(text);
        }
    }
}
