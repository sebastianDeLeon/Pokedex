using Aplication.Services;
using Aplication.ViewModel;
using DB;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex_CRUD.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonService _pokemon;
        private readonly RegionService _region;
        private readonly TipoService _tipo;

        public PokemonController(AplicationContext aplicationContext)
        {
            _pokemon = new(aplicationContext);
            _region = new(aplicationContext);
            _tipo = new(aplicationContext);
        }

        public async Task<IActionResult> PokemonesLista()
        {
            ViewBag.regiones = await _region.GetAllPokemon();
            ViewBag.tipos = await _tipo.GetAllPokemon();
            return View(await _pokemon.GetAllPokemon());
        }
        public async Task<IActionResult> Crear()
        {
            SavePokemonView ps = new SavePokemonView();
            ps.regions = await _region.GetAllPokemon();
            ps.tipos = await _tipo.GetAllPokemon();
            return View("SavePokemon", ps);
        }
        [HttpPost]
        public async Task<IActionResult> Crear(SavePokemonView pokemon)
        {
            //pokemon.regions = await _region.GetAllPokemon();
            //pokemon.tipos = await _tipo.GetAllPokemon();
            await _pokemon.Add(pokemon);
            return RedirectToRoute(new { controller = "Pokemon", action = "PokemonesLista" });
        }
        public async Task<IActionResult> Actualizar(int id)
        {
            SavePokemonView ps = await _pokemon.GetById(id);
            ps.regions = await _region.GetAllPokemon();
            ps.tipos = await _tipo.GetAllPokemon();
            return View("SavePokemon", ps);
        }
        [HttpPost]
        public async Task<IActionResult> Actualizar(SavePokemonView pokemonView)
        {
            await _pokemon.Update(pokemonView);
            return RedirectToRoute(new { controller = "Pokemon", action = "PokemonesLista" });
        }

        public async Task<IActionResult> DeletePokemon(int id)
        {
            return View("DeletePokemon", await _pokemon.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePokemon(SavePokemonView pokemonView)
        {
            await _pokemon.Delete(pokemonView);
            return RedirectToRoute(new { controller = "Pokemon", action = "PokemonesLista" });
        }
    }
}
