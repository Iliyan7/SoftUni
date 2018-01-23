using System.Text;

namespace CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine, int weight, string color)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.color = color;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.model}:");
            sb.AppendLine($"  {this.engine.Model}:");
            sb.AppendLine($"    Power: {this.engine.Power}");
            if (this.engine.Displacement < 0)
            {
                sb.AppendLine($"    Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"    Displacement: {this.engine.Displacement}");
            }
            sb.AppendLine($"    Efficiency: {this.engine.Efficiency}");
            if(this.weight < 0)
            {
                sb.AppendLine($"  Weight: n/a");
            }
            else
            {
                sb.AppendLine($"  Weight: {this.weight}");
            }
            sb.Append($"  Color: {this.color}");

            return sb.ToString();
        }
    }
}
