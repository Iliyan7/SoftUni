using System;
using System.Globalization;
using System.Linq;

namespace Count_Work_Days
{
    public class Count_Work_Days
    {
        public static void Main()
        {
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            DateTime[] holidays = new DateTime[]
            {
                DateTime.ParseExact("01-01", "dd-MM", CultureInfo.InvariantCulture),
                DateTime.ParseExact("03-03", "dd-MM", CultureInfo.InvariantCulture),
                DateTime.ParseExact("01-05", "dd-MM", CultureInfo.InvariantCulture),
                DateTime.ParseExact("06-05", "dd-MM", CultureInfo.InvariantCulture),
                DateTime.ParseExact("24-05", "dd-MM", CultureInfo.InvariantCulture),
                DateTime.ParseExact("06-09", "dd-MM", CultureInfo.InvariantCulture),
                DateTime.ParseExact("22-09", "dd-MM", CultureInfo.InvariantCulture),
                DateTime.ParseExact("01-11", "dd-MM", CultureInfo.InvariantCulture),
                DateTime.ParseExact("24-12", "dd-MM", CultureInfo.InvariantCulture),
                DateTime.ParseExact("25-12", "dd-MM", CultureInfo.InvariantCulture),
                DateTime.ParseExact("26-12", "dd-MM", CultureInfo.InvariantCulture),
            };

            int workingDaysCounter = 0;

            for (DateTime i = startDate; i <= endDate; i = i.AddDays(1))
            {

                if (!(i.DayOfWeek == DayOfWeek.Saturday || i.DayOfWeek == DayOfWeek.Sunday) && !IsHolidayDay(i, holidays))
                    workingDaysCounter++;
            }

            Console.WriteLine(workingDaysCounter);
        }

        public static bool IsHolidayDay(DateTime currentDay, DateTime[] holidays)
        {
            for (int i = 0; i < holidays.Length; i++)
            {
                if (currentDay.Day == holidays[i].Day && currentDay.Month == holidays[i].Month)
                    return true;
            }

            return false;
        }
    }
}
