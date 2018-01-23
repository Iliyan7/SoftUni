using System;

namespace Blank_Receipt
{
    public class Blank_Receipt
    {
        public static void Main()
        {
            PrintReceipt();
        }

        public static void PrintReceipt()
        {
            PrintReceiptHeader();
            PrintReceiptBody();
            PrintReceiptFooter();
        }

        public static void PrintReceiptHeader()
        {
            Console.WriteLine("CASH RECEIPT\n------------------------------");
        }

        public static void PrintReceiptBody()
        {
            Console.WriteLine("Charged to____________________\nReceived by___________________");
        }

        public static void PrintReceiptFooter()
        {
            Console.WriteLine("------------------------------\n\u00A9 SoftUni");
        }
    }
}
