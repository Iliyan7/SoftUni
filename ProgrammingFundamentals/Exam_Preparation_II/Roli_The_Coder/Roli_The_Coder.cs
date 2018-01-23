using System;
using System.Collections.Generic;
using System.Linq;

namespace Roli_The_Coder
{
    public class Roli_The_Coder
    {
        public static void Main()
        {
            var events = new List<Roli>();

            while(true)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (input[0] == "Time" && input[1] == "for" && input[2] == "Code")
                    break;

                var eventID = int.Parse(input[0]);
                var eventName = input[1];

                if (eventName[0] != '#')
                    continue;

                var participantList = new List<string>();
                AddParticipantToList(input, participantList);

                if (!events.Any(x => x.EventID == eventID))
                {
                    var roliEvent = new Roli()
                    {
                        EventID = eventID,
                        EventName = eventName,
                        EventParticipants = participantList
                    };

                    events.Add(roliEvent);
                }
                else
                {
                    var index = events.FindIndex(x => x.EventID == eventID);

                    if (events[index].EventName == eventName)
                    {
                        events[index].EventParticipants.AddRange(participantList);
                    }
                }
            }

            DistinctClassList(events);

            foreach (var roliEvent in events.OrderByDescending(x => x.EventParticipants.Count).ThenBy(x => x.EventName))
            {
                Console.WriteLine("{0} - {1}", roliEvent.EventName.Substring(1), roliEvent.EventParticipants.Count);

                foreach (var name in roliEvent.EventParticipants.OrderBy(x => x))
                {
                    Console.WriteLine(name);
                }
            }
        }

        public static void AddParticipantToList(string[] input, List<string> participantList)
        {
            for (int i = 2; i < input.Length; i++)
            {
                participantList.Add(input[i]);
            }
        }

        public static void DistinctClassList(List<Roli> events)
        {
            for (int i = 0; i < events.Count; i++)
            {
                events[i].EventParticipants = events[i].EventParticipants.Distinct().ToList();
            }
        }
    }
}
