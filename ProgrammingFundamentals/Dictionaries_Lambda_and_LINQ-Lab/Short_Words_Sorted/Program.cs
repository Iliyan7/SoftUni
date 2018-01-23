using System;
using System.Linq;

namespace Short_Words_Sorted
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = new char[] { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' };
            string[] words = Console.ReadLine().ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(string.Join(", ", words.Distinct().Where(x => x.Length < 5).OrderBy(x => x)));
        }
    }
}
