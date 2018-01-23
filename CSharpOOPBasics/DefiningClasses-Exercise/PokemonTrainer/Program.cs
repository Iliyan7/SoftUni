using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Program
    {
        public static void Main()
        {
            var trainers = new Dictionary<string, Trainer>();

            var line = String.Empty;

            while ((line = Console.ReadLine()) != "Tournament")
            {
                var info = line
                    .Split(' ');

                var trainerName = info[0];
                var pokemonName = info[1];
                var pokemonElement = info[2];
                var pokemonHealth = int.Parse(info[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(pokemonName, pokemonElement, pokemonHealth));
                }
                else
                {
                    trainers[trainerName].AddPokemon(pokemonName, pokemonElement, pokemonHealth);
                }
            }

            while ((line = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if(trainer.Value.Pokemons.Any(x => x.Element.Equals(line)))
                    {
                        trainer.Value.AddBadge();
                    }
                    else
                    {
                        trainer.Value.ReducePokemonHealth(10);
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.Value.Badges))
            {
                Console.WriteLine("{0} {1} {2}", trainer.Key, trainer.Value.Badges, trainer.Value.Pokemons.Count);
            }
        }
    }
}
