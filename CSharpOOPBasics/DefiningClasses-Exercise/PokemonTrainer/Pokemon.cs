namespace PokemonTrainer
{
    public class Pokemon
    {
        private string name;
        private string element;
        private int health;

        public Pokemon(string pokemonName, string pokemonElement, int pokemonHealth)
        {
            this.name = pokemonName;
            this.element = pokemonElement;
            this.health = pokemonHealth;
        }

        public string Element
        {
            get { return this.element; }
        }

        public int Health
        {
            get { return this.health;  }
            set { this.health = value; }
        }
    }
}
