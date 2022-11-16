using Aplication.Services;
using Aplication.ViewModel;
using DB;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex_CRUD.Controllers
{
    public class TipoController : Controller
    {
        private readonly TipoService _tipo;

        public TipoController(AplicationContext aplicationContext)
        {
            _tipo = new(aplicationContext);
        }
        public async Task<IActionResult> Tipo()
        {
            return View(await _tipo.GetAllPokemon());
        }

        public IActionResult CreateTipo()
        {
            return View("SaveTipo", new SaveTipo());
        }
        [HttpPost]
        public async Task<IActionResult> CreateTipo(SaveTipo tipo)
        {
            await _tipo.Add(tipo);
            return RedirectToRoute(new { controller = "Tipo", action = "Tipo" });
        }
        public async Task<IActionResult> Actualizar(int id)
        {
            return View("SaveTipo",await _tipo.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Actualizar(SaveTipo tipo)
        {
            await _tipo.Update(tipo);
            return RedirectToRoute(new { controller = "Tipo", action = "Tipo" });
        }
        public async Task<IActionResult> DeleteTipo(int id)
        {
            return View("DeleteTipo", await _tipo.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteTipo(SaveTipo tipo)
        {
            await _tipo.Delete(tipo);
            return RedirectToRoute(new { controller = "Tipo", action = "Tipo" });
        }
    }
}
