using System;

namespace Polymorphism_Lab
{
    class Program
    {
        public static void Main()
        {
            /*var mo = new MathOperations();
            Console.WriteLine(mo.Add(2, 3));
            Console.WriteLine(mo.Add(2.2, 3.3, 5.5));
            Console.WriteLine(mo.Add(2.2m, 3.3m, 4.4m));*/

            /*Animal cat = new Cat("Pesho", "Whiskas");
            Animal dog = new Dog("Gosho", "Meat");

            Console.WriteLine(cat.ExplainMyself());
            Console.WriteLine(dog.ExplainMyself());*/

            Shape circle = new Circle(5.0);
            Console.WriteLine(circle.Draw());
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());

            Shape rectangle = new Rectangle(2.7, 10.5);
            Console.WriteLine(rectangle.Draw());
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
        }
    }
}
