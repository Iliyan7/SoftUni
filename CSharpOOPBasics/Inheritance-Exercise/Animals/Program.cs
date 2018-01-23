using System;

namespace Animals
{
    class Program
    {
        public static void Main()
        {
            var animalType = String.Empty;

            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                var args = Console.ReadLine()
                    .Split(' ');

                try
                {
                    switch (animalType)
                    {
                        case "Dog":
                            {
                                Animal animal = new Dog(args[0], int.Parse(args[1]), args[2]);
                                Console.WriteLine(animalType);
                                Console.WriteLine(animal);
                                break;
                            }
                        case "Frog":
                            {
                                Animal animal = new Frog(args[0], int.Parse(args[1]), args[2]);
                                Console.WriteLine(animalType);
                                Console.WriteLine(animal);
                                break;
                            }
                        case "Cat":
                            {
                                Animal animal = new Cat(args[0], int.Parse(args[1]), args[2]);
                                Console.WriteLine(animalType);
                                Console.WriteLine(animal);
                                break;
                            }
                        case "Kitten":
                            {
                                Animal animal = new Kitten(args[0], int.Parse(args[1]), args[2]);
                                Console.WriteLine(animalType);
                                Console.WriteLine(animal);
                                break;
                            }
                        case "Tomcat":
                            {
                                Animal animal = new Tomcat(args[0], int.Parse(args[1]), args[2]);
                                Console.WriteLine(animalType);
                                Console.WriteLine(animal);
                                break;
                            }
                        default: throw new ArgumentException("Invalid input!");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
