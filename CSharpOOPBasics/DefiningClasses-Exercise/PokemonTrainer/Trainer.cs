using System.Collections.Generic;

namespace PokemonTrainer
{
    public class Trainer
    {
        private int badges;
        private List<Pokemon> pokemons;

        public Trainer(string pokemonName, string pokemonElement, int pokemonHealth)
        {
            this.badges = 0;
            this.pokemons = new List<Pokemon>();
            this.AddPokemon(pokemonName, pokemonElement, pokemonHealth);
        }

        public int Badges
        {
            get { return this.badges; }
        }

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
        }

        public void AddBadge()
        {
            this.badges += 1;
        }

        public void AddPokemon(string pokemonName, string pokemonElement, int pokemonHealth)
        {
            this.pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
        }

        public void ReducePokemonHealth(int health)
        {
            foreach (var pokemon in this.pokemons)
            {
                var reducedHealth = pokemon.Health - health;

                if (reducedHealth > 0)
                {
                    pokemon.Health = reducedHealth;
                }
            }

            this.pokemons
                .RemoveAll(x => x.Health - health < 1);
        }
    }
}
