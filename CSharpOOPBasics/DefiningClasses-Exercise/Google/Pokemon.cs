namespace Google
{
    public class Pokemon
    {
        private string name;
        private string type;

        public Pokemon(string pokemonName, string pokemonType)
        {
            this.name = pokemonName;
            this.type = pokemonType;
        }

        public string Name
        {
            get { return this.name; }
        }

        public string Type
        {
            get { return this.type; }
        }
    }
}