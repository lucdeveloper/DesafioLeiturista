using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapeamentos
{
    internal class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> tabelaCliente)
        {
            tabelaCliente.HasKey(p => p.Id);

            tabelaCliente.Property(p => p.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();

            tabelaCliente.Property(p => p.Cpf)
               .HasColumnType("varchar(11)")
               .IsRequired();

            tabelaCliente.HasOne(f => f.Endereco)
               .WithOne(e => e.Cliente);

            tabelaCliente.ToTable("Cliente");
        }
    }
}