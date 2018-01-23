using System;

namespace _Ferrari
{
    class Program
    {
        public static void Main()
        {
            var driverName = Console.ReadLine();
            ICar ferrari = new Ferrari("488-Spider", driverName);

            Console.WriteLine("{0}/{1}/{2}/{3}", ferrari.Model, ferrari.UseBreaks(), ferrari.PushTheGas(), ferrari.DriverName);

            string ferrariName = typeof(Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }
        }
    }
}
