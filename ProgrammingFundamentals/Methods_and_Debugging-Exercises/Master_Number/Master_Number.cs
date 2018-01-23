using System;

namespace Master_Number
{
    public class Master_Number
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (IsPalindorme(i) && IsDigitSumDivisibleBy7(i) && ContainsEvenDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static bool IsPalindorme(int n)
        {
            string strN = n.ToString();

            for (int i = 0; i < strN.Length; i++)
            {
                if (strN[i] != strN[strN.Length - 1 - i])
                    return false;
            }

            return true;
        }

        public static bool IsDigitSumDivisibleBy7(int n)
        {
            string strN = n.ToString();
            int sum = 0;

            for (int i = 0; i < strN.Length; i++)
            {
                sum += int.Parse(strN[i].ToString());
            }

            if (sum % 7 == 0)
                return true;

            return false;
        }

        public static bool ContainsEvenDigit(int n)
        {
            string strN = n.ToString();

            for (int i = 0; i < strN.Length; i++)
            {
                if (strN[i] % 2 == 0)
                    return true;
            }

            return false;
        }
    }
}
