using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Winning_Ticket
{
    public class Winning_Ticket
    {
        public static void Main()
        {
            var tickets = Console.ReadLine()
                .Split(',')
                .Select(x => x.Trim())
                .ToArray();

            foreach(var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                var leftHalf = ticket.Substring(0, 10);
                var rightHalf = ticket.Substring(10);

                var winningChars = new string[] { "@", "#", "\\$", "\\^" };

                var isNoMatch = false;

                foreach (var c in winningChars)
                {
                    var regex = new Regex($"{c}{{6,10}}");
                    var leftMatch = regex.Match(leftHalf);
                    var rightMatch = regex.Match(rightHalf);

                    if (leftMatch.Success && rightMatch.Success
                        && leftMatch.Value.Contains(rightMatch.Value[0]))
                    {
                        var minLen = leftMatch.Length <= rightMatch.Length ? leftMatch.Length : rightMatch.Length;

                        if (minLen < 10)
                            Console.WriteLine("ticket \"{0}\" - {1}{2}", ticket, minLen, leftMatch.Value[0]);
                        else
                            Console.WriteLine("ticket \"{0}\" - {1}{2} Jackpot!", ticket, minLen, leftMatch.Value[0]);

                        isNoMatch = true;
                        break;
                    }
                    
                }

                if(!isNoMatch)
                    Console.WriteLine("ticket \"{0}\" - no match", ticket);
            }
        }
    }
}
