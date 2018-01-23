using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Different_Integers_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNum = Console.ReadLine();

            long num;
            bool result = long.TryParse(inputNum, out num);

            if (result)
                Console.WriteLine("{0} can fit in:", num);
            else
            {
                Console.WriteLine("{0} can't fit in any type", inputNum);
                return;
            }

            string[] dataType = new string[7];

            if (-128 <= num && num <= 127)
                dataType[0] = "sbyte";

            if (0 <= num && num <= 255)
                dataType[1] = "byte";

            if (-32768 <= num && num <= 32767)
                dataType[2] = "short";

            if (0 <= num && num <= 65535)
                dataType[3] = "ushort";

            if (-2147483648 <= num && num <= 2147483647)
                dataType[4] = "int";

            if (0 <= num && num <= 4294967295)
                dataType[5] = "uint";

            if (-9223372036854775808 <= num && num <= 9223372036854775807)
                dataType[6] = "long";

            for (int i = 0; i < dataType.Length; i++)
            {
                if (dataType[i] != null)
                    Console.WriteLine("* {0}", dataType[i]);
            }
        }
    }
}
