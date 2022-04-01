using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapeamentos
{ 
   public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> tabelaUsuario)
        {
            tabelaUsuario.HasKey(p => p.Id);

            tabelaUsuario.Property(p => p.Nome)                
                         .HasColumnType("varchar(200)")
                         .IsRequired();

            tabelaUsuario.Property(p => p.Email)
                         .HasColumnType("varchar(200)")
                         .IsRequired();

            tabelaUsuario.Property(p => p.Senha)
                         .HasColumnType("varchar(150)")
                         .IsRequired();

            tabelaUsuario.Property(p => p.Cargo)
                         .HasColumnType("varchar(50)")
                         .IsRequired();
                
            tabelaUsuario.ToTable("Usuario");
        }
    }
}
