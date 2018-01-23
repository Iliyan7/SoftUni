using System;

namespace English_Name_of_Last_Digit
{
    public class English_Name_of_Last_Digit
    {
        public static void Main()
        {
            long n = long.Parse(Console.ReadLine());

            Console.WriteLine(GetNameOfLastDigit(n));
        }

        public static string GetNameOfLastDigit(long n)
        {
            string[] digitNames = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            return digitNames[Math.Abs(n) % 10];
        }
    }
}
