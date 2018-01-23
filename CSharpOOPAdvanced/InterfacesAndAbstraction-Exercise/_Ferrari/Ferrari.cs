namespace _Ferrari
{
    public class Ferrari : ICar
    {
        private string model;
        private string driverName;

        public Ferrari(string model, string driverName)
        {
            this.Model = model;
            this.DriverName = driverName;
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                this.model = value;
            }
        }

        public string DriverName
        {
            get { return this.driverName; }
            set
            {
                this.driverName = value;
            }
        }

        public string UseBreaks()
        {
            return "Brakes!";
        }

        public string PushTheGas()
        {
            return "Zadu6avam sA!";
        }
    }
}