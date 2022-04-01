using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapeamentos
{
    public class LeituraMap : IEntityTypeConfiguration<Leitura>
    {
        public void Configure(EntityTypeBuilder<Leitura> tabelaLeitura)
        {
            tabelaLeitura.HasKey(p => p.Id);

            tabelaLeitura.Property(p => p.LeituraAnterior)
                         .IsRequired();

            tabelaLeitura.Property(p => p.LeituraAtual);
             
            tabelaLeitura.Property(p => p.LeituristaId)
                         .IsRequired();

            tabelaLeitura.Property(p => p.ClienteId)
                         .IsRequired();

            tabelaLeitura.Property(p => p.OcorrenciaId)
                         .IsRequired();

            tabelaLeitura.ToTable("Leitura");
        }
    }
}