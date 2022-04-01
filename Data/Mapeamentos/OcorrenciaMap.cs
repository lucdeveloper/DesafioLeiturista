using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapeamentos
{
    public class OcorrenciaMap : IEntityTypeConfiguration<Ocorrencia>
    {
        public void Configure(EntityTypeBuilder<Ocorrencia> tabelaOcorrencia)
        {
            tabelaOcorrencia.HasKey(p => p.Id);

            tabelaOcorrencia.Property(p => p.Descricao)
                .HasColumnType("varchar(200)")
                .IsRequired();

            tabelaOcorrencia.Property(p => p.PermiteLeitura)
               .IsRequired();

            tabelaOcorrencia.Property(p => p.Valor)
               .IsRequired();
   
            tabelaOcorrencia.ToTable("Ocorrencia");
        }
    }
}