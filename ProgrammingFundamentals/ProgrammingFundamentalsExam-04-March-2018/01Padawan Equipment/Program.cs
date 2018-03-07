using System;

namespace _01Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            var money = double.Parse(Console.ReadLine());
            var studentsCount = int.Parse(Console.ReadLine());
            var sabresPrice = double.Parse(Console.ReadLine());
            var robesPrice = double.Parse(Console.ReadLine());
            var beltsPrice = double.Parse(Console.ReadLine());

            var costOfEquipment = sabresPrice * Math.Ceiling(studentsCount * 1.1) + robesPrice * studentsCount + beltsPrice * (studentsCount - (studentsCount / 6));

            if(costOfEquipment <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {costOfEquipment:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(costOfEquipment - money):F2}lv more.");
            }
        }
    }
}
