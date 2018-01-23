using System;

namespace Price_Change_Alert
{
    public class Price_Change_Alert
    {
        public static void Main()
        {
            int numOfPrices = int.Parse(Console.ReadLine());
            double significanceThreshold = double.Parse(Console.ReadLine());
            double lastPrice = double.Parse(Console.ReadLine());

            for (int i = 0; i < numOfPrices - 1; i++)
            {
                double currentPrice = double.Parse(Console.ReadLine());

                double limitAlert = GetLimit(lastPrice, currentPrice);
                bool isSignificantDifference = checkForSignificantDifference(limitAlert, significanceThreshold);

                Console.WriteLine(GetMessage(currentPrice, lastPrice, limitAlert, isSignificantDifference));

                lastPrice = currentPrice;
            }
        }

        public static double GetLimit(double lastPrice, double currentPrice)
        {
            return (currentPrice - lastPrice) / lastPrice;
        }

        public static bool checkForSignificantDifference(double limitAlert, double significanceThreshold)
        {
            if (Math.Abs(limitAlert) >= significanceThreshold)
            {
                return true;
            }

            return false;
        }

        public static string GetMessage(double currentPrice, double lastPrice, double limitAlert, bool isSignificantDifference)
        {
            string message = null;

            limitAlert *= 100.0;

            if (limitAlert == 0)
            {
                message = string.Format("NO CHANGE: {0}", currentPrice);
            }
            else if (!isSignificantDifference)
            {
                message = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, limitAlert);
            }
            else if (isSignificantDifference && (limitAlert > 0))
            {
                message = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, limitAlert);
            }
            else if (isSignificantDifference && (limitAlert < 0))
            {
                message = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, limitAlert);
            }

            return message;
        }
    }
}
