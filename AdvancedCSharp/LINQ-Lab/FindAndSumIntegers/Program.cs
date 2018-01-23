using System;
using System.Linq;

namespace FindAndSumIntegers
{
    public class Program
    {
        public static void Main()
        {
            var elements = Console.ReadLine()
                .Split(' ')
                // -- SoftUni Solution --
                //.Select(n =>
                //{
                //    long value;
                //    bool success = long.TryParse(n, out value);
                //    return new { value, success };
                //})
                //    .Where(b => b.success)
                //    .Select(x => x.value);

                // -- My Solution --
                // Filter strings by checking if it contains '-' or any digit
                // NOTE: Isn't best way to check if string is number (exception may occur)
                .Where(x => x.Any(d => d == '-' || char.IsDigit(d))); 

            if (elements.Count() == 0)
            {
                Console.WriteLine("No match");
                return;
            }

            Console.WriteLine(elements
                .Select(long.Parse) // Remove this line if you want to use SoftUni Solution
                .Sum());
        }
    }
}
