using System;
using System.Reflection;

namespace OldestFamilyMember
{
    public class Program
    {
        public static void Main()
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            var n = int.Parse(Console.ReadLine());

            var family = new Family();

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine()
                    .Split(' ');

                var person = new Person(args[0], int.Parse(args[1]));

                family.AddMember(person);
            }

            var oldestPerson = family
                .GetOldestMember();

            Console.WriteLine("{0} {1}", oldestPerson.Name, oldestPerson.Age);
        }
    }
}
