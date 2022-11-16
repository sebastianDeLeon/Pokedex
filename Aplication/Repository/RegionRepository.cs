using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Repository
{
    public class RegionRepository
    {
        public readonly AplicationContext DB_context;

        public RegionRepository(AplicationContext aplicationContext) { DB_context = aplicationContext; }
        #region CRUD
        public async Task Create(Regiones regiones)
        {
            await DB_context.AddAsync(regiones);
            await DB_context.SaveChangesAsync();
        }

        public async Task<List<Regiones>> ReadAll()
        {
            return await DB_context.Set<Regiones>().ToListAsync();
        }

        public async Task<Regiones> ReadById(int id)
        {
            return await DB_context.Set<Regiones>().FindAsync(id);
        }

        public async Task Update(Regiones regiones)
        {
            DB_context.Entry(regiones).State = EntityState.Modified;
            await DB_context.SaveChangesAsync();
        }

        public async Task Delete(Regiones regiones)
        {
            DB_context.Set<Regiones>().Remove(regiones);
            await DB_context.SaveChangesAsync();
        }
        #endregion
    }
}
