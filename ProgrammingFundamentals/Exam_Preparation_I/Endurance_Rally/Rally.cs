using System;

namespace Endurance_Rally
{
    public class Rally
    {
        private string driverName;
        private double fuelLeft;
        private int reachedZone;

        public Rally(string name, double fuel, int zone)
        {
            driverName = name;
            fuelLeft = fuel;
            reachedZone = zone;
        }

        public string DriverName { get { return driverName; } }

        public double FuelLeft { get { return fuelLeft; } }

        public int ReachedZone { get { return reachedZone; } }
    }
}
