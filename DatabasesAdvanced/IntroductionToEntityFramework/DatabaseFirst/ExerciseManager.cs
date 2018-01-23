using DatabaseFirst.Data;
using DatabaseFirst.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;

namespace DatabaseFirst
{
    public class ExerciseManager
    {
        private SoftUniContext db;

        public ExerciseManager(SoftUniContext db)
        {
            this.db = db;
        }

        public void Run()
        {
            this.Exercise10();
        }

        private void Exercise5()
        {
            var employees = db.Employees
                    .Where(e => e.Department.Name == "Research and Development")
                    .OrderBy(e => e.Salary)
                    .ThenByDescending(e => e.FirstName)
                    .Select(e => new
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        DepartmentName = e.Department.Name,
                        Salary = e.Salary
                    })
                    .ToList();

            foreach (var e in employees)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
            }
        }

        private void Exercise6()
        {
            var address = new Address();
            address.AddressText = "Vitoshka 15";
            address.TownId = 4;

            db.Addresses.Add(address);

            var nakov = db.Employees
                .Where(e => e.LastName.Equals("Nakov"))
                .FirstOrDefault();

            nakov.Address = address;

            db.SaveChanges();

            var employees = db.Employees
               .OrderByDescending(e => e.AddressId)
               .Take(10)
               .Include(e => e.Address);

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Address.AddressText);
            }
        }

        private void Exercise7()
        {
            var employees = db.Employees
                .Where(e => e.EmployeeProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Take(30)
                .Select(e => new
                {
                    Name = $"{e.FirstName} {e.LastName}",
                    ManagerName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                    Projects = e.EmployeeProjects.Select(ep => new
                    {
                        ep.Project.Name,
                        StartDate = ep.Project.StartDate,
                        EndDate = ep.Project.EndDate
                    })
                })
                .ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Name} - Manager: {employee.ManagerName}");

                foreach (var project in employee.Projects)
                {
                    Console.Write($"--{project.Name} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - ");

                    if (project.EndDate == null)
                    {
                        Console.WriteLine("not finished");
                    }
                    else
                    {
                        Console.WriteLine(project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
                    }
                }
            }
        }

        private void Exercise8()
        {
            var addresses = db.Addresses
                .Select(a => new
                {
                    a.AddressText,
                    Town = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                })
                .OrderByDescending(e => e.EmployeeCount)
                .ThenBy(a => a.Town)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            foreach (var a in addresses)
            {
                Console.WriteLine($"{a.AddressText}, {a.Town} - {a.EmployeeCount} employees");
            }
        }

        private void Exercise9()
        {
            var employee147 = db.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    Name = $"{e.FirstName} {e.LastName}",
                    JobTitle = e.JobTitle,
                    Projects = e.EmployeeProjects.Select(ep => new
                    {
                        ep.Project.Name
                    })
                    .OrderBy(p => p.Name)
                    .ToList()
                })
                .FirstOrDefault();

            Console.WriteLine($"{employee147.Name} - {employee147.JobTitle}");

            foreach (var project in employee147.Projects)
            {
                Console.WriteLine(project.Name);
            }
        }

        private void Exercise10()
        {
            var departments = db.Departments
                .Where(d => d.Employees.Count() > 5)
                .Select(d => new
                {
                    d.Name,
                    ManagerName = $"{d.Manager.FirstName} {d.Manager.LastName}",
                    ManagerJobTitle = d.Manager.JobTitle,
                    Employees = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                    //.OrderBy(e => e.FirstName)
                    //.ThenBy(e => e.LastName)
                })
                .OrderBy(d => d.Employees.Count())
                .ToList();

            foreach (var d in departments)
            {
                Console.WriteLine($"{d.Name} - {d.ManagerName}");
                //Console.WriteLine($"{d.ManagerName} - {d.ManagerJobTitle}");

                foreach (var e in d.Employees.OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName))
                {
                    Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }

                Console.WriteLine(new String('-', 10));
            }
        }

        private void Exercise11()
        {

        }

        private void Exercise14()
        {
        }

        private void Exercise15()
        {
        }

        private void Exercise16()
        {
        }
    }
}
