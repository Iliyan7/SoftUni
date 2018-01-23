using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    public class Program
    {
        public static void Main()
        {
            var employees = new List<Employee>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine()
                    .Split();

                var name = args[0];
                var salary = double.Parse(args[1]);
                var pos = args[2];
                var department = args[3];
                var email = "n/a";
                var age = -1;

                if (args.Length > 4)
                {
                    try
                    {
                        age = int.Parse(args[4]);
                    }
                    catch (Exception)
                    {
                        email = args[4];
                    }
                }

                if(args.Length > 5)
                {
                    age = int.Parse(args[5]);
                }

                employees.Add(new Employee(name, salary, pos, department, email, age));
            }

            var highestPayingDepartment = employees
                .GroupBy(e => e.Department)
                .Select(g => new
                {
                    Name = g.Key,
                    AverageSalary = g.Average(x => x.Salary),
                    Employees = g
                })
                .OrderByDescending(g => g.AverageSalary)
                .First();

            Console.WriteLine("Highest Average Salary: {0}", highestPayingDepartment.Name);

            foreach (var departmentEmployees in highestPayingDepartment.Employees.OrderByDescending(x => x.Salary))
            {
                Console.WriteLine(departmentEmployees.GetInfo());
            }
        }
    }
}
