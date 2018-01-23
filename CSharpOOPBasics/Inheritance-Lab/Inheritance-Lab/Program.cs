using System;

namespace Inheritance_Lab
{
    class Program
    {
        public static void Main()
        {
            /* 
            var randomList = new RandomList();

            randomList.Add(1);
            randomList.Add(2L);
            randomList.Add(3.0);
            randomList.Add(true);
            randomList.Add("5");

            Console.WriteLine(randomList.RandomString());
            */

            var stackOfStrings = new StackOfStrings();

            stackOfStrings.Push("1");
            stackOfStrings.Push("2");
            stackOfStrings.Push("3");

            Console.WriteLine(stackOfStrings.Peek());
            Console.WriteLine(stackOfStrings.Pop());
            Console.WriteLine(stackOfStrings.Peek());
            Console.WriteLine(stackOfStrings.IsEmpty());
        }
    }
}
