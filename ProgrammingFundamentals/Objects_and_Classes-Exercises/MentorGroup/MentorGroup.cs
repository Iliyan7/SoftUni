using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MentorGroup
{
    public class MentorGroup
    {
        public static void Main()
        {
            var students = new SortedDictionary<string, Student>();

            while (true)
            {
                string[] userAndDates = Console.ReadLine().Split(' ', ',');

                string user = userAndDates[0];

                if (user == "end")
                    break;

                DateTime[] dates = userAndDates
                    .Skip(1)
                    .Select(x => DateTime.ParseExact(x, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                    .ToArray();

                if (!students.ContainsKey(user))
                {
                    students.Add(user,
                        new Student()
                        {
                            DatesAttended = dates
                        });
                }
                else
                {
                    if (students[user].DatesAttended.Length == 0)
                        students[user].DatesAttended = dates;
                    else
                        students[user].DatesAttended = students[user].DatesAttended.Concat(dates).ToArray();
                }
            }

            while (true)
            {
                string[] userAndComments = Console.ReadLine().Split('-');

                string user = userAndComments[0];

                if (user == "end of comments")
                    break;

                if (!students.ContainsKey(user))
                    continue;

                string comment = userAndComments[1];

                if (students[user].Comments == null)
                {
                    students[user].Comments = new List<string>();
                }

                students[user].Comments.Add(comment);
            }

            foreach (var pair in students)
            {
                Console.WriteLine("{0}", pair.Key);
                Console.WriteLine("Comments:");

                if (pair.Value.Comments != null)
                {
                    foreach (string comment in pair.Value.Comments)
                    {
                        Console.WriteLine("- {0}", comment);
                    }
                }

                Console.WriteLine("Dates attended:");

                if (pair.Value.DatesAttended != null)
                {
                    foreach (DateTime date in pair.Value.DatesAttended.OrderBy(x => x))
                    {
                        Console.WriteLine("-- {0:dd/MM/yyyy}", date);

                    }
                }
            }
        }
    }
}
