using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class EstadoNivelEstudiosClienteConfiguration : IEntityTypeConfiguration<EstadoNivelEstudiosClienteEntity>
    {
        public void Configure(EntityTypeBuilder<EstadoNivelEstudiosClienteEntity> modelBuilder) 
        {
            modelBuilder.ToTable("EstadoNivelEstudiosCliente", "DBO");

            modelBuilder.HasKey(e => e.Id);

            modelBuilder.Property(e => e.Id).HasColumnType("int");

            modelBuilder.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Flag).HasColumnType("bit");
        }
    }
}
