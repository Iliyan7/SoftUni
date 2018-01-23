namespace CarSalesman
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.model = model;
            this.power = power;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        public string Model
        {
            get { return this.model; }
        }

        public int Power
        {
            get { return this.power; }
        }

        public int Displacement
        {
            get { return this.displacement; }
        }

        public string Efficiency
        {
            get { return this.efficiency; }
        }
    }
}
