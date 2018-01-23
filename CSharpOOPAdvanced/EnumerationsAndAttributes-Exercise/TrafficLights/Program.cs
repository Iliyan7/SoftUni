using System;
using System.Collections.Generic;
using System.Linq;

namespace TrafficLights
{
    class Program
    {
        public static void Main()
        {
            var inputSignals = Console.ReadLine()
                .Split(' ')
                .Select(s => (Signal)Enum.Parse(typeof(Signal), s));

            var trafficLights = new List<TrafficLight>();

            foreach (var signal in inputSignals)
            {
                trafficLights.Add(new TrafficLight(signal));
            }
            
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                foreach (var trafficLight in trafficLights)
                {
                    trafficLight.Update();
                }

                Console.WriteLine(string.Join(" ", trafficLights));
            }
        }
    }
}
