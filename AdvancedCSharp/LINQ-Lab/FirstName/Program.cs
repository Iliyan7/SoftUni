using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstName
{
    public class Program
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(' ');

            var letters = Console.ReadLine()
                .Split(' ')
                .OrderBy(w => w);

            foreach (var letter in letters)
            {
                var result = names
                    .Where(x => x.ToLower()[0].ToString() == letter.ToLower())
                    .FirstOrDefault();

                if(result != null)
                {
                    Console.WriteLine(result);
                    return;
                }
            }

            Console.WriteLine("No match");
        }
    }
}
