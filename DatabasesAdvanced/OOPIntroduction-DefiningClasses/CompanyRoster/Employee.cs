using System;

namespace CompanyRoster
{
    public class Employee
    {
        private string name;
        private double salary;
        private string position;
        private string department;
        private string email;
        private int age;

        public Employee(string name, double salary, string position, string department, string email, int age)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;
            this.email = email;
            this.age = age;
        }

        public double Salary => this.salary;

        public string Department => this.department;

        public string GetInfo()
        {
            return $"{this.name} {this.salary:F2} {this.email} {this.age}";
        }
    }
}
