using Aplication.Repository;
using Aplication.ViewModel;
using DB;
using DB.Models;

namespace Aplication.Services
{
    public class TipoService
    {
        private readonly TipoRepository _tipoService;

        public TipoService(AplicationContext aplicationContext)
        {
            _tipoService = new(aplicationContext);
        }

        public async Task Add(SaveTipo tipo)
        {
            Tipos t = new();

            t.id = tipo.id;
            t.NameTipos = tipo.NameTipos;

            await _tipoService.Create(t);
        }

        public async Task Update(SaveTipo tipo)
        {
            Tipos t = new();
            t.id = tipo.id;
            t.NameTipos = tipo.NameTipos;


            await _tipoService.Update(t);
        }

        public async Task<SaveTipo> GetById(int id)
        {
            var tipo = await _tipoService.ReadById(id);

            SaveTipo t = new();
            t.id = tipo.id;
            t.NameTipos = tipo.NameTipos;

            return t;
        }
        public async Task<List<SaveTipo>> GetAllPokemon()
        {
            var tipoList = await _tipoService.ReadAll();
            return tipoList.Select(t => new SaveTipo
            {
                id = t.id,
                NameTipos = t.NameTipos
            }).ToList();

        }

        public async Task Delete(SaveTipo tipo)
        {
            Tipos t = new();
            t.id = tipo.id;
            t.NameTipos = tipo.NameTipos;

            await _tipoService.Delete(t);
        }
    }
}
