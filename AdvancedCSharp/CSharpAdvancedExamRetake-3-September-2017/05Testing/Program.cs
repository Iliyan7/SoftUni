using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var item = "PerlaAem";
            var size = item.Length;
            Console.WriteLine(item.Substring(size - 3));
        }
    }
}
