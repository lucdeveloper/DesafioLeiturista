using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapeamentos
{
    public class LeituristaMap : IEntityTypeConfiguration<Leiturista>
    {
        public void Configure(EntityTypeBuilder<Leiturista> tabelaLeiturista)
        {
            tabelaLeiturista.HasKey(p => p.Id);

            tabelaLeiturista.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            tabelaLeiturista.Property(p => p.Matricula)
                .IsRequired();
               
            tabelaLeiturista.Property(p => p.Ativo)
                .IsRequired();
          
            tabelaLeiturista.HasMany(p => p.Leituras)
               .WithOne(e => e.Leiturista)
               .HasForeignKey(e => e.LeituristaId);

            tabelaLeiturista.ToTable("Leituristas");
        }
    }
}
