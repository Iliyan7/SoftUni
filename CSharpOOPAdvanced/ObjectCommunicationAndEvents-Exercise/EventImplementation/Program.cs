using System;

namespace EventImplementation
{
    class Program
    {
        public static void Main()
        {
            var dispacher = new Dispatcher();
            var handler = new Handler();

            dispacher.NameChange += handler.OnDispatcherNameChange;

            string name = Console.ReadLine();

            while (name != "End")
            {
                dispacher.Name = name;
                name = Console.ReadLine();
            }
        }
    }
}
