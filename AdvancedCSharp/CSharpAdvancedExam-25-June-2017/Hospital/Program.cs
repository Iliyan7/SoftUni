using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    public class Program
    {
        public static void Main()
        {
            var input = String.Empty;

            var departments = new Dictionary<string, List<string>>();
            var doctors = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "Output")
            {
                var patientInformation = input
                    .Split(' ');

                var department = patientInformation[0];
                var doctorName = patientInformation[1] + " " + patientInformation[2];
                var patientName = patientInformation[3];

                if (!departments.ContainsKey(department))
                {
                    departments.Add(department, new List<string>());
                }

                if (departments[department].Count < 60)
                {
                    departments[department].Add(patientName);
                }

                if (!doctors.ContainsKey(doctorName))
                {
                    doctors.Add(doctorName, new List<string>());
                }

                doctors[doctorName].Add(patientName);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                var commands = input
                    .Split(' ');

                if (commands.Length == 1)
                {
                    PrintPatientsByDepartments(departments[commands[0]]);
                }
                else
                {
                    var room = 0;
                    var parsed = int.TryParse(commands[1], out room);

                    if (parsed)
                    {
                        PrintPatientsByDepartments(departments[commands[0]], room);
                    }
                    else
                    {
                        var doctor = commands[0] + " " + commands[1];

                        PrintPatientsByDoctors(doctors[doctor]);
                    }
                }
            }
        }

        private static void PrintPatientsByDepartments(List<string> list)
        {
            foreach (var patient in list)
            {
                Console.WriteLine(patient);
            }
        }

        private static void PrintPatientsByDepartments(List<string> list, int room)
        {
            foreach (var patient in list
                .Skip(room * 3 - 3)
                .Take(3)
                .OrderBy(x => x))
            {
                Console.WriteLine(patient);
            }
        }

        private static void PrintPatientsByDoctors(List<string> list)
        {
            foreach (var patient in list.OrderBy(x => x))
            {
                Console.WriteLine(patient);
            }
        }
    }
}
