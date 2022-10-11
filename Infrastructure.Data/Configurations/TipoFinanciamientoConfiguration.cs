using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class TipoFinanciamientoConfiguration : IEntityTypeConfiguration<EstadoTipoFinanciamientoEntity>
    {
        public void Configure(EntityTypeBuilder<EstadoTipoFinanciamientoEntity> modelBuilder)
        {
            modelBuilder.ToTable("EstadoTipoFinanciamiento", "DBO");

            modelBuilder.HasKey(e => e.Id);

            modelBuilder.Property(e => e.Id).HasColumnType("int");

            modelBuilder.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Descripcion");

            modelBuilder.Property(e => e.Activo).HasColumnType("bit");
        }
    }
}
