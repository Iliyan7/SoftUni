using System;

namespace DateModifier
{
    public class Program
    {
        public static void Main()
        {
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();

            Console.WriteLine(DateModifier.GetDifference(firstDate, secondDate));
        }
    }
}
