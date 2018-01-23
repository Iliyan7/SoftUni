using System;
using System.Linq;

namespace Average_Grades
{
    public class Average_Grades
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Student[] studenInfo = new Student[n];

            for (int i = 0; i < n; i++)
            {
                string[] nameAndGrades = Console.ReadLine().Split(' ');

                studenInfo[i] = new Student(nameAndGrades[0]);
                studenInfo[i].Grades(nameAndGrades.Skip(1).Select(double.Parse).ToArray());
            }

            foreach (Student student in studenInfo
                .Where(x => x.AverageGrade >= 5.0)
                .OrderBy(x => x.GetName)
                .ThenByDescending(x => x.AverageGrade))
            {
                Console.WriteLine("{0} -> {1:F2}", student.GetName, student.AverageGrade);
            }
        }
    }
}
