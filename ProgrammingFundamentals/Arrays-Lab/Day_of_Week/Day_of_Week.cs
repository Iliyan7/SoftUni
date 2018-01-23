using System;

namespace Day_of_Week
{
    public class Day_of_Week
    {
        public static void Main()
        {
            string[] weekDays = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            int dayIndex = int.Parse(Console.ReadLine());

            if (1 <= dayIndex && dayIndex <= 7)
            {
                Console.WriteLine(weekDays[dayIndex-1]);
            }
            else
            {
                Console.WriteLine("Invalid Day!");
            }
        }
    }
}
