using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Repositor
{
    public class PokemonRepository
    {
        public readonly AplicationContext DB_context;

        public PokemonRepository(AplicationContext aplicationContext) { DB_context = aplicationContext; }
        #region CRUD
        public async Task Create(Pokemones pokemon) 
        { 
            await DB_context.AddAsync(pokemon);
            await DB_context.SaveChangesAsync(); 
        }

        public async Task<List<Pokemones>> ReadAll()
        {
            return await DB_context.Set<Pokemones>()
                .Include(p => p.Regiones)
                .Include(p => p.Tipos)
                .Include(p => p.Tipos2)
                .ToListAsync();
        }

        public async Task<Pokemones> ReadById(int id)
        {
            return await DB_context.Set<Pokemones>().FindAsync(id);
        }

        public async Task Update(Pokemones pokemon)
        {
            DB_context.Entry(pokemon).State = EntityState.Modified;
            await DB_context.SaveChangesAsync();
        }

        public async Task Delete(Pokemones pokemon)
        {
            DB_context.Set<Pokemones>().Remove(pokemon);
            await DB_context.SaveChangesAsync();
        }
        #endregion
    }
}
