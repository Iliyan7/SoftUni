using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    public class Program
    {
        public static void Main()
        {
            var invitedRegularGuests = new SortedSet<string>();
            var invitedVIPGuests = new SortedSet<string>();

            FillInvitationLists(invitedRegularGuests, invitedVIPGuests);
            ClearArrivedGuests(invitedRegularGuests, invitedVIPGuests);

            var vipCount = invitedVIPGuests.Count;
            var regularCount = +invitedRegularGuests.Count;

            Console.WriteLine(vipCount + regularCount);

            if(vipCount > 0)
                Console.WriteLine(string.Join(Environment.NewLine, invitedVIPGuests));

            if(regularCount > 0)
                Console.WriteLine(string.Join(Environment.NewLine, invitedRegularGuests));
        }

        private static void FillInvitationLists(SortedSet<string> invitedRegularGuests, SortedSet<string> invitedVIPGuests)
        {
            var guest = Console.ReadLine();
            while (guest != "PARTY")
            {
                if (char.IsDigit(guest[0]))
                  invitedVIPGuests.Add(guest);
                else
                    invitedRegularGuests.Add(guest);

                guest = Console.ReadLine();
            }
        }

        private static void ClearArrivedGuests(SortedSet<string> invitedRegularGuests, SortedSet<string> invitedVIPGuests)
        {
            var guest = Console.ReadLine();
            while (guest != "END")
            {
                if (char.IsDigit(guest[0]))
                    invitedVIPGuests.Remove(guest);
                else
                    invitedRegularGuests.Remove(guest);

                guest = Console.ReadLine();
            }
        }
    }
}
