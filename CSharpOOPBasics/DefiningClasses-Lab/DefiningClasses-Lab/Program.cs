using System;
using System.Collections.Generic;

namespace DefiningClasses_Lab
{
    class Program
    {
        public static void Main()
        {
            var command = String.Empty;

            var accounts = new Dictionary<int, BankAccount>();

            while ((command = Console.ReadLine()) != "End")
            {
                var cmdArgs = command
                    .Split(' ');

                switch (cmdArgs[0])
                {
                    case "Create": execCreate(int.Parse(cmdArgs[1]), accounts); break;
                    case "Deposit": execDeposit(int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2]), accounts); break;
                    case "Withdraw": execWithdraw(int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2]), accounts); break;
                    case "Print": execPrint(int.Parse(cmdArgs[1]), accounts); break;
                }
            }
        }

        private static void execPrint(int id, Dictionary<int, BankAccount> accounts)
        {
            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
                return;
            }

            Console.WriteLine(accounts[id].ToString());
        }

        private static void execWithdraw(int id, int amount, Dictionary<int, BankAccount> accounts)
        {
            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
                return;
            }

            if (accounts[id].Balance < amount)
            {
                Console.WriteLine("Insufficient balance");
                return;
            }

            accounts[id].Withdraw(amount);
        }

        private static void execDeposit(int id, int amount, Dictionary<int, BankAccount> accounts)
        {
            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
                return;
            }

            accounts[id].Deposit(amount);

        }

        private static void execCreate(int id, Dictionary<int, BankAccount> accounts)
        {
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
                return;
            }

            if(id < 0)
            try
            {
                var account = new BankAccount();
                account.ID = id;
                accounts.Add(id, account);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
