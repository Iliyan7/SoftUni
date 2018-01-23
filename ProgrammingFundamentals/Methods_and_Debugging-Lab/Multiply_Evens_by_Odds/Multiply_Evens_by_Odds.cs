using System;

namespace Multiply_Evens_by_Odds
{
    public class Multiply_Evens_by_Odds
    {
        public static void Main()
        {
            Console.WriteLine(GetMultipleOfEvensAndOdds(int.Parse(Console.ReadLine())));
        }

        public static int GetMultipleOfEvensAndOdds(int n)
        {
            n = Math.Abs(n);
            return GetSumOfEvenOrOddDigits(n, "even") * GetSumOfEvenOrOddDigits(n, "odd");
        }

        public static int GetSumOfEvenOrOddDigits(int num, string evenOrOdd)
        {
            if (evenOrOdd != "even" && evenOrOdd != "odd")
                return 0;

            int evenSum = 0, oddSum = 0;
            bool isEven = (evenOrOdd == "even") ? true : false;
            string strNum = num.ToString();

            for (int i = 0; i < strNum.Length; i++)
            {
                if ((strNum[i] % 2 == 0) && isEven)
                    evenSum += int.Parse(strNum[i].ToString());

                else if (strNum[i] % 2 != 0 && !isEven)
                    oddSum += int.Parse(strNum[i].ToString());
            }

            return isEven ? evenSum : oddSum;
        }
    }
}
