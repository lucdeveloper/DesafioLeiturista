using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapeamentos
{
    public class CargoMap : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> tabelaCargo)
        {
            tabelaCargo.HasKey(p => p.Id);

            tabelaCargo.Property(p => p.Descricao)
                .HasColumnType("varchar(200)")
                .IsRequired();

            tabelaCargo.ToTable("Cargo");
        }
    }
}