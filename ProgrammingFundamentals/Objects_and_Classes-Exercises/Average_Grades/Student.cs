using System.Linq;

namespace Average_Grades
{
    public class Student
    {
        private string name;
        private double[] grades;

        public Student(string val)
        {
            name = val;
        }

        public void Grades(double[] val)
        {
            grades = val;
        }

        public string GetName
        {
            get
            {
                return name;
            }
        }

        public double AverageGrade
        {
            get
            {
                return grades.Average();
            }
        }
    }
}
