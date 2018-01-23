using System;
using System.Globalization;

namespace Day_of_Week
{
    public class Day_of_Week
    {
        public static void Main()
        {
            DateTime date = DateTime.ParseExact(Console.ReadLine(),
                "d-M-yyyy",
                CultureInfo.InvariantCulture);

            Console.WriteLine(date.DayOfWeek);
        }
    }
}
