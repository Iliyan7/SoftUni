using System;
using System.Collections.Generic;
using System.Linq;

namespace Hornet_Comm
{
    public class PrivateMessages
    {
        public string RecipientCode { get; set; }
        public string Message { get; set; }
    }

    public class BroadcastMessages
    {
        public string Freq { get; set; }
        public string Message { get; set; }
    }

    public class Hornet_Comm
    {
        public static void Main()
        {
            var privateMessages = new List<PrivateMessages>();
            var broadcastMessages = new List<BroadcastMessages>();

            while (true)
            {
                var input = Console.ReadLine().Split(new string[] { " <-> " }, StringSplitOptions.None);

                if (input[0] == "Hornet is Green")
                    break;

                if (input.Length < 2)
                    continue;

                var firstQuery = input[0];
                var secondQuery = input[1];

                if (IsPrivateMessage(firstQuery, secondQuery))
                {
                    var recipientCode = string.Join("", firstQuery.Reverse());
                    var message = secondQuery;

                    privateMessages.Add(new PrivateMessages { RecipientCode = recipientCode, Message = message });
                }
                else if (IsBroadcastMessage(firstQuery, secondQuery))
                {
                    var freq = new string(secondQuery.Select(x => char.IsLower(x) ? char.ToUpper(x) : char.ToLower(x)).ToArray());
                    var message = firstQuery;

                    broadcastMessages.Add(new BroadcastMessages { Freq = freq, Message = message });
                }
            }

            var anyMessage = new bool[] { false, false };

            Console.WriteLine("Broadcasts:");
            foreach (var item in broadcastMessages)
            {
                Console.WriteLine("{0} -> {1}", item.Freq, item.Message);
                anyMessage[0] = true;
            }
            if (!anyMessage[0]) Console.WriteLine("None");

            Console.WriteLine("Messages:");
            foreach (var item in privateMessages)
            {
                Console.WriteLine("{0} -> {1}", item.RecipientCode, item.Message);
                anyMessage[1] = true;
            }
            if (!anyMessage[1]) Console.WriteLine("None");
        }

        public static bool IsPrivateMessage(string firstQuery, string secondQuery)
        {
            if (firstQuery.All(c => char.IsDigit(c)) && secondQuery.All(c => char.IsLetterOrDigit(c)))
                return true;

            return false;
        }

        public static bool IsBroadcastMessage(string firstQuery, string secondQuery)
        {
            if (firstQuery.All(c => !char.IsDigit(c)) && secondQuery.All(c => char.IsLetterOrDigit(c)))
                return true;

            return false;
        }
    }
}
