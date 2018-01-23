using System;
using System.Linq;

namespace Compare_Char_Arrays
{
    public class Compare_Char_Arrays
    {
        public static void Main()
        {
            char[] firstCharArr = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] secondCharArr = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

            string[] textArr = new string[] { string.Join("", firstCharArr), string.Join("", secondCharArr) };

            Array.Sort(textArr);

            Console.WriteLine(string.Join("\n", textArr));
        }
    }
}
