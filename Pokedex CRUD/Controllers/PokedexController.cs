using Aplication.Services;
using Aplication.ViewModel;
using DB;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex_CRUD.Controllers
{
    public class PokedexController : Controller
    {
        public readonly PokemonService _v;
        private readonly RegionService _region;
        private readonly TipoService _tipo;
        public PokedexController(AplicationContext app)
        {
            _v = new(app);
            _region = new RegionService(app);
            _tipo = new TipoService(app);
        }
        public async Task<IActionResult> Pokedex(int? regionId)
        {
            ViewBag.regiones = await _region.GetAllPokemon();
            ViewBag.tipos = await _tipo.GetAllPokemon();
            return View(await _v.GetAllPokemonRegion(regionId));
        }
        public async Task<IActionResult> PokedexNombre(string? nombre)
        {
            ViewBag.regiones = await _region.GetAllPokemon();
            ViewBag.tipos = await _tipo.GetAllPokemon();
            return View("Pokedex",await _v.GetAllPokemonNombre(nombre));
        }

    }
}
