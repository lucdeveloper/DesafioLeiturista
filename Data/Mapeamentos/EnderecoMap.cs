using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapeamentos
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> tabelaEndereco)
        {
            tabelaEndereco.HasKey(p => p.Id);

            tabelaEndereco.Property(p => p.Logradouro)
                          .HasColumnType("varchar(200)")
                          .IsRequired();

            tabelaEndereco.Property(p => p.Numero)
                          .HasColumnType("varchar(100)")
                          .IsRequired();

            tabelaEndereco.Property(p => p.Cep)
                          .HasColumnType("varchar(8)")
                          .IsRequired();

            tabelaEndereco.Property(p => p.Latitude)
                          .IsRequired();

            tabelaEndereco.Property(p => p.Longitude)
                          .IsRequired();

            tabelaEndereco.ToTable("Endereco");
        }
    }
}