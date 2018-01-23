using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class Program
    {
        public static void Main()
        {
            var personFamiliy = new Family();

            var firstLine = Console.ReadLine();

            var line = String.Empty;
            while ((line = Console.ReadLine()) != "End")
            {
                var lineArgs = line
                    .Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                if (lineArgs.Count() < 2)
                {
                    var l = lineArgs[0]
                        .Split(' ');

                    var personName = l[0] + " " + l[1];
                    var personBirthday = l[2];

                    personFamiliy;

                }
                else
                {

                }
            }
        }
    }
}
