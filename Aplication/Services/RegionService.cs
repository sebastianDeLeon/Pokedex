using Aplication.Repository;
using Aplication.ViewModel;
using DB;
using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class RegionService

    {
        private readonly RegionRepository _regionService;

        public RegionService(AplicationContext aplicationContext)
        {
            _regionService = new(aplicationContext);
        }

        public async Task Add(SaveRegion region)
        {
            Regiones r = new();
            
            r.id= region.id;
            r.NameRegion= region.NameRegion;
            
            await _regionService.Create(r);
        }

        public async Task Update(SaveRegion region)
        {
            Regiones r = new();
            r.id = region.id;
            r.NameRegion = region.NameRegion;
            

            await _regionService.Update(r);
        }

        public async Task<SaveRegion> GetById(int id)
        {
            var region = await _regionService.ReadById(id);

            SaveRegion r = new();
            r.id = region.id;
            r.NameRegion = region.NameRegion;

            return r;
        }
        public async Task<List<SaveRegion>> GetAllPokemon()
        {
            var regionList = await _regionService.ReadAll();
            return regionList.Select(r => new SaveRegion 
            { 
                id = r.id,
                NameRegion = r.NameRegion
            }).ToList();
            
        }

        public async Task Delete(SaveRegion region)
        {
            Regiones r = new();
            r.id = region.id;
            r.NameRegion = region.NameRegion;


            await _regionService.Delete(r);
        }
    }
}
