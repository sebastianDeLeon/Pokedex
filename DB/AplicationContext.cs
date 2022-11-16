using Microsoft.EntityFrameworkCore;
using DB.Models;

namespace DB
{
    public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions<AplicationContext> db) : base(db) { }

        public DbSet<Pokemones> Pokemones { get; set; }
        public DbSet<Regiones> Regiones { get; set; }
        public DbSet<Tipos> Tipos { get; set; }
        public DbSet<Tipo2> Tipo2 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region tablas
            modelBuilder.Entity<Pokemones>().ToTable("Pokemones");
            modelBuilder.Entity<Regiones>().ToTable("Regiones");
            modelBuilder.Entity<Tipos>().ToTable("Tipos");
            #endregion

            #region Primary Key
            modelBuilder.Entity<Pokemones>().HasKey(p => p.id);
            modelBuilder.Entity<Regiones>().HasKey(r => r.id);
            modelBuilder.Entity<Tipos>().HasKey(t => t.id);
            #endregion

            #region relaciones
            modelBuilder.Entity<Regiones>()
                .HasMany<Pokemones>(r => r.Pokemones)
                .WithOne(p => p.Regiones)
                .HasForeignKey(p => p.RegionPokemon)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tipos>()
                .HasMany<Pokemones>(t => t.Pokemones)
                .WithOne(p => p.Tipos)
                .HasForeignKey(p => p.Type1)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Tipo2>()
                .HasMany<Pokemones>(t => t.Pokemones2)
                .WithOne(p => p.Tipos2)
                .HasForeignKey(p => p.Type2)
                .OnDelete(DeleteBehavior.Cascade);


            #endregion
            modelBuilder.Entity<Tipos>()
                .HasIndex(p => p.NameTipos).IsUnique();
            modelBuilder.Entity<Tipo2>()
                .HasIndex(p => p.NameTipos).IsUnique();
            modelBuilder.Entity<Regiones>()
                .HasIndex(p => p.NameRegion).IsUnique();
            modelBuilder.Entity<Pokemones>()
                .HasIndex(p => p.name).IsUnique();
            #region Configuracion de propiedades
            //modelBuilder.Entity<Pokemones>().Ignore(p => p.Tipos);
            //base.OnModelCreating(modelBuilder);
            #endregion
        }
    }
}