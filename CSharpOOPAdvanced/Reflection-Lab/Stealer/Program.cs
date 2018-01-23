using System;

namespace Stealer
{
    class Program
    {
        public static void Main()
        {
            Spy spy = new Spy();
            string result = spy.CollectGettersAndSetters("Hacker");
            Console.WriteLine(result);
        }
    }
}
