using Aplication.Services;
using DB;
using Aplication.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex_CRUD.Controllers
{
    public class RegionController : Controller
    {
        private readonly RegionService _region;

        public RegionController(AplicationContext aplicationContext)
        {
            _region = new(aplicationContext);
        }
        public async Task<IActionResult> Regiones()
        {
            return View(await _region.GetAllPokemon());
        }
        public IActionResult CreateRegion()
        {
            return View("SaveRegion", new SaveRegion());
        }
        [HttpPost]
        public async Task<IActionResult> CreateRegion(SaveRegion region)
        {
            await _region.Add(region);
            return RedirectToRoute(new { controller = "Region", action = "Regiones" });
        }

        public async Task<IActionResult> Actualizar(int id)
        {
            return View("SaveRegion",await _region.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Actualizar(SaveRegion region)
        {
            await _region.Update(region);
            return RedirectToRoute(new { controller = "Region", action = "Regiones" });
        }

        public async Task<IActionResult> DeleteRegion(int id)
        {
            return View("DeleteRegion", await _region.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRegion(SaveRegion region)
        {
            await _region.Delete(region);
            return RedirectToRoute(new { controller = "Region", action = "Regiones" });
        }
    }
}
