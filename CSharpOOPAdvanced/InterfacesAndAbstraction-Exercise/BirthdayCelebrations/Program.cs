using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    class Program
    {
        public static void Main()
        {
            var birthdays = new List<IBirthday>();

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                var args = input.
                    Split(' ');

                switch(args[0])
                {
                    case "Citizen": birthdays.Add(new Citizen(args[1], int.Parse(args[2]), args[3], args[4])); break;
                    case "Pet": birthdays.Add(new Pet(args[1], args[2])); break;
                }
            }

            var year = int.Parse(Console.ReadLine());

            foreach (var obj in birthdays)
            {
                var birthday = obj.Birthday;
                var _year = birthday.Substring(birthday.LastIndexOf('/') + 1);

                if (year == int.Parse(_year))
                {
                    Console.WriteLine(obj.Birthday);
                }
            }
        }
    }
}
