using System;
using System.Collections.Generic;

namespace Google
{
    public class Program
    {
        public static void Main()
        {
            var peoples = new Dictionary<string, Person>();

            var line = String.Empty;

            while ((line = Console.ReadLine()) != "End")
            {
                var lineTokens = line
                    .Split(' ');

                var personName = lineTokens[0];
                if (!peoples.ContainsKey(personName))
                {
                    peoples.Add(personName, new Person(personName));
                }

                switch (lineTokens[1])
                {
                    case "company":
                        {
                            peoples[personName].Company.Name = lineTokens[2];
                            peoples[personName].Company.Department = lineTokens[3];
                            peoples[personName].Company.Salary = double.Parse(lineTokens[4]);

                            break;
                        }
                    case "pokemon":
                        {
                            var pokemonName = lineTokens[2];
                            var pokemonType = lineTokens[3];

                            peoples[personName].Pokemons.Add(new Pokemon(pokemonName, pokemonType));

                            break;
                        }
                    case "parents":
                        {
                            var parentName = lineTokens[2];
                            var parentBirthday = lineTokens[3];

                            peoples[personName].Parents.Add(new Parent(parentName, parentBirthday));

                            break;
                        }
                    case "children":
                        {
                            var childrenName = lineTokens[2];
                            var childrenBirthday = lineTokens[3];

                            peoples[personName].Childrens.Add(new Children(childrenName, childrenBirthday));

                            break;
                        }
                    case "car":
                        {
                            peoples[personName].Car.Model = lineTokens[2];
                            peoples[personName].Car.Speed = int.Parse(lineTokens[3]);

                            break;
                        }
                }
            }

            Console.WriteLine(peoples[Console.ReadLine()].ToString());
        }
    }
}
