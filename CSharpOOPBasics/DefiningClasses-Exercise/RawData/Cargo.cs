namespace RawData
{
    internal class Cargo
    {
        private int cargoWeight;
        private string cargoType;

        public Cargo(int cargoWeight, string cargoType)
        {
            this.cargoWeight = cargoWeight;
            this.cargoType = cargoType;
        }

        public string CargoType
        {
            get { return this.cargoType; }
        }
    }
}