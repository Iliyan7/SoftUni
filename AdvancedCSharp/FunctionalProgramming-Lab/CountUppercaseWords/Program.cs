using System;
using System.Linq;

namespace CountUppercaseWords
{
    public class Program
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => char.IsUpper(w[0]))
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
