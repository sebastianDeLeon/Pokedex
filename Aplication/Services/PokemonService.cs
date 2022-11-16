using Aplication.Repositor;
using DB;
using Aplication.ViewModel;
using DB.Models;

namespace Aplication.Services
{
    public class PokemonService
    {
        private readonly PokemonRepository _repository;

        public PokemonService(AplicationContext aplicationContext)
        {
            _repository = new(aplicationContext);
        }
        public async Task Add(SavePokemonView pokemon)
        {
            Pokemones p = new();
            p.id = pokemon.id;
            p.name = pokemon.name;
            p.RegionPokemon = pokemon.RegionPokemon;
            p.Type1 = pokemon.Type1;
            p.Type2 = pokemon.Type2;
            p.ImagenUrl = pokemon.ImagenUrl;

            await _repository.Create(p);
        }
        public async Task Update(SavePokemonView pokemon)
        {
            Pokemones p = new();
            p.id = pokemon.id;
            p.name = pokemon.name;
            p.RegionPokemon = pokemon.RegionPokemon;
            p.Type1 = pokemon.Type1;
            p.Type2 = pokemon.Type2;
            p.ImagenUrl = pokemon.ImagenUrl;

            await _repository.Update(p);
        }
        public async Task<SavePokemonView> GetById(int id)
        {
            var pokemon = await _repository.ReadById(id);

            SavePokemonView p = new SavePokemonView();
            p.id = pokemon.id;
            p.name = pokemon.name;
            p.RegionPokemon = pokemon.RegionPokemon;
            p.Type1 = pokemon.Type1;
            p.Type2 = pokemon.Type2;
            p.ImagenUrl = pokemon.ImagenUrl;

            return p;
        }
        public async Task<List<SavePokemonView>> GetAllPokemon()
        {
            var pokemonList = await _repository.ReadAll();
            
            return pokemonList.Select(p => new SavePokemonView
            {
                id = p.id,
                name = p.name,
                RegionPokemon = p.RegionPokemon,
                Type1 = p.Type1,
                Type2 = p.Type2,
                ImagenUrl = p.ImagenUrl,
                Type1N = p.Tipos.NameTipos,
                Type2N = p.Tipos2.NameTipos,
                NombreRegion = p.Regiones.NameRegion

            }).ToList();
        }
        public async Task<List<SavePokemonView>> GetAllPokemonRegion(int? filter)
        {
            var pokemonList = await _repository.ReadAll();


            var lista = pokemonList.Select(p => new SavePokemonView
            {
                id = p.id,
                name = p.name,
                RegionPokemon = p.RegionPokemon,
                Type1 = p.Type1,
                Type2 = p.Type2,
                ImagenUrl = p.ImagenUrl,
                Type1N = p.Tipos.NameTipos,
                Type2N = p.Tipos2.NameTipos,
                NombreRegion = p.Regiones.NameRegion

            }).ToList();

            if(filter != null)
            {
                lista = lista.Where(p => p.RegionPokemon == filter).ToList();
            }

            return lista;
        }
        public async Task<List<SavePokemonView>> GetAllPokemonNombre(string? filter)
        {
            var pokemonList = await _repository.ReadAll();


            var lista = pokemonList.Select(p => new SavePokemonView
            {
                id = p.id,
                name = p.name,
                RegionPokemon = p.RegionPokemon,
                Type1 = p.Type1,
                Type2 = p.Type2,
                ImagenUrl = p.ImagenUrl,
                Type1N = p.Tipos.NameTipos,
                Type2N = p.Tipos2.NameTipos,
                NombreRegion = p.Regiones.NameRegion

            }).ToList();

            if (filter != null)
            {
                lista = lista.Where(p => p.name == filter).ToList();
            }

            return lista;
        }
        public async Task<List<SavePokemonView>> GetAllPokemonTipo(int id)
        {
            var pokemonList = await _repository.ReadAll();

            return pokemonList.Select(p => new SavePokemonView
            {
                id = p.id,
                name = p.name,
                RegionPokemon = p.RegionPokemon,
                Type1 = p.Type1,
                Type2 = p.Type2,
                ImagenUrl = p.ImagenUrl,
                Type1N = p.Tipos.NameTipos,
                Type2N = p.Tipos2.NameTipos,
                NombreRegion = p.Regiones.NameRegion

            }).ToList();
        }
        public async Task Delete(SavePokemonView pokemon)
        {
            Pokemones p = new();
            p.id = pokemon.id;
            p.name = pokemon.name;
            p.RegionPokemon = pokemon.RegionPokemon;
            p.Type1 = pokemon.Type1;
            p.Type2 = pokemon.Type2;
            p.ImagenUrl = pokemon.ImagenUrl;

            await _repository.Delete(p);
        }

    }
}
