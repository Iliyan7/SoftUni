using System;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        private double salary;
        private double workingHours;

        public Worker(string firstName, string lastName, double salary, double workingHours) 
            : base(firstName, lastName)
        {
            this.Salary = salary;
            this.WorkingHours = workingHours;
        }

        public double Salary
        {
            get { return this.salary; }
            set
            {
                if(value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.salary = value;
            }
        }

        public double WorkingHours
        {
            get { return this.workingHours; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workingHours = value;
            }
        }

        private double CalculateSalaryPerHour()
        {
            return this.Salary / (this.WorkingHours * 5);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"First Name: {this.FirstName}");
            sb.AppendLine($"Last Name: {this.LastName}");
            sb.AppendLine($"Week Salary: {this.Salary:F2}");
            sb.AppendLine($"Hours per day: {this.WorkingHours:F2}");
            sb.AppendLine($"Salary per hour: {this.CalculateSalaryPerHour():F2}");

            return sb.ToString();
        }
    }
}
