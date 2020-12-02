using Backend_Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Context
{
    public class AplicacaoDbContext : DbContext
    {
        public AplicacaoDbContext(DbContextOptions<AplicacaoDbContext> options): base(options) 
        {

        }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Diretor> Diretores { get; set; }
        public DbSet<Locadora> Locadoras { get; set; }
        public DbSet<FilmeLocadora> FilmeLocadoras { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<FilmeLocadora>(entity =>
            {
                entity.HasKey(e => new { e.LocadoraId, e.FilmeId });
            });            
        }
    }
}
