using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Person
    {
        private string name;
        private Company company;
        private List<Pokemon> pokemons;
        private List<Parent> parents;
        private List<Children> childrens;
        private Car car;

        public Person(string personName)
        {
            this.name = personName;

            this.company = new Company();
            this.pokemons = new List<Pokemon>();
            this.parents = new List<Parent>();
            this.childrens = new List<Children>();
            this.car = new Car();
        }

        public Company Company
        {
            get { return this.company; }
        }

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
        }

        public List<Parent> Parents
        {
            get { return this.parents; }
        }

        public List<Children> Childrens
        {
            get { return this.childrens; }
        }

        public Car Car
        {
            get { return this.car; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.name}");
            sb.AppendLine("Company:");
            if (!string.IsNullOrEmpty(this.Company.Name))
            {
                sb.AppendLine($"{this.Company.Name} {this.Company.Department} {this.Company.Salary:F2}");
            }
            sb.AppendLine("Car:");
            if (!string.IsNullOrEmpty(this.Car.Model))
            {
                sb.AppendLine($"{this.Car.Model} {this.Car.Speed}");
            }
            sb.AppendLine("Pokemon:");
            foreach (var pokemon in this.Pokemons)
            {
                sb.AppendLine($"{pokemon.Name} {pokemon.Type}");
            }
            sb.AppendLine("Parents:");
            foreach (var parent in this.Parents)
            {
                sb.AppendLine($"{parent.Name} {parent.Birthday}");
            }
            sb.AppendLine("Children:");
            foreach (var children in this.Childrens)
            {
                sb.AppendLine($"{children.Name} {children.Birthday}");
            }

            return sb.ToString();
        }
    }
}
