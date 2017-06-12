using System;

namespace FormattingNumbers
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            var a = int.Parse(numbers[0]);
            var b = double.Parse(numbers[1]);
            var c = double.Parse(numbers[2]);

            Console.WriteLine("|{0,-10:X}|{1}|{2,10:F2}|{3,-10:F3}|", a, ConvertToBinary(a), b, c);
        }

        private static string ConvertToBinary(int num)
        {
            var binary = Convert.ToString(num, 2);

            if(binary.Length > 10)
            {
                binary = binary.Substring(0, 10);
            }
            else if(binary.Length < 10)
            {
                binary = binary.PadLeft(10, '0');
            }

            return binary;
        }
    }
}
