using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private List<Tire> tires;

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
        {
            this.model = model;

            this.engine = new Engine(engineSpeed, enginePower);
            this.cargo = new Cargo(cargoWeight, cargoType);

            this.tires = new List<Tire>();
            this.tires.Add(new Tire(tire1Pressure, tire1Age));
            this.tires.Add(new Tire(tire2Pressure, tire2Age));
            this.tires.Add(new Tire(tire3Pressure, tire3Age));
            this.tires.Add(new Tire(tire4Pressure, tire4Age));

        }

        public string Model
        {
            get { return this.model; }
        }

        public int EnginePower
        {
            get { return this.engine.EnginePower; }
        }

        public string CargoType
        {
            get { return this.cargo.CargoType; }
        }

        public bool IsTirePressureUnder1
        {
            get
            {
                if (tires.Any(x => x.TirePressure < 1.0))
                    return true;

                return false;
            }
        }
    }
}
