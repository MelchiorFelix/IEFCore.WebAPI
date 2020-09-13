using IEFCore.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEFCore.WebAPI.Data
{
    public class HeroiContext : DbContext
    {
        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<IdentidadeSecreta> IdentidadesSecretas { get; set; }
        public DbSet<HeroiBatalha> HeroisBatalhas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=DockerSQL2019;Persist Security Info=True;User ID=SA;Initial Catalog=HeroApp;Data Source=localhost,1433");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroiBatalha>(entity => 
            {
                entity.HasKey(e => new {e.BatalhaId, e.HeroiId });
            });
        }
    }
}
