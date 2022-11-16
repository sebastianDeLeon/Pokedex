using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;
namespace Aplication.Repository
{
    public class TipoRepository
    {
        public readonly AplicationContext DB_context;

        public TipoRepository(AplicationContext aplicationContext) { DB_context = aplicationContext; }

        Tipo2 tipo2 = new Tipo2();
        #region CRUD
        public async Task Create(Tipos tipos)
        {
            tipo2.id = tipos.id;
            tipo2.NameTipos = tipos.NameTipos;
            
            await DB_context.AddAsync(tipo2);
            await DB_context.AddAsync(tipos);
            await DB_context.SaveChangesAsync();
        }

        public async Task<List<Tipos>> ReadAll()
        {
            return await DB_context.Set<Tipos>().ToListAsync();
        }

        public async Task<Tipos> ReadById(int id)
        {
            return await DB_context.Set<Tipos>().FindAsync(id);
        }

        public async Task Update(Tipos tipos)
        {
            tipo2.id = tipos.id;
            tipo2.NameTipos = tipos.NameTipos;

            DB_context.Entry(tipo2).State = EntityState.Modified;
            DB_context.Entry(tipos).State = EntityState.Modified;
            await DB_context.SaveChangesAsync();
        }

        public async Task Delete(Tipos tipos)
        {
            tipo2.id = tipos.id;
            tipo2.NameTipos = tipos.NameTipos;

            DB_context.Set<Tipo2>().Remove(tipo2);
            DB_context.Set<Tipos>().Remove(tipos);
            await DB_context.SaveChangesAsync();
        }
        #endregion
    }
}
