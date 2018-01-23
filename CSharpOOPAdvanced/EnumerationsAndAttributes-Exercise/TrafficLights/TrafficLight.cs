using System;

namespace TrafficLights
{
    public class TrafficLight
    {
        private Signal signalState;

        public TrafficLight(Signal signal)
        {
            this.signalState = signal;
        }

        public void Update()
        {
            this.signalState = (Signal)(((int)this.signalState + 1)
                % Enum.GetNames(typeof(Signal)).Length);
        }

        public override string ToString()
        {
            return this.signalState.ToString();
        }
    }
}
