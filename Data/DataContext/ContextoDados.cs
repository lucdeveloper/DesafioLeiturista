using Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Data.DataContext
{
    public class ContextoDados : DbContext
    {
        public ContextoDados() { }

        public ContextoDados(DbContextOptions<ContextoDados> options) : base(options) { }

        public  DbSet<Leiturista> Leituristas { get; set; }
        public  DbSet<Leitura> Leitura { get; set; }
        public  DbSet<Cliente> Cliente { get; set; }
        public  DbSet<Usuario> Usuario { get; set; }
        public DbSet<Ocorrencia> Ocorrencia { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Endereco> Cargo { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextoDados).Assembly);
        }
    }
}