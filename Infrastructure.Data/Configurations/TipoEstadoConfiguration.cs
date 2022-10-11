using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class TipoEstadoConfiguration : IEntityTypeConfiguration<TipoEstadoEntity>
    {
        public void Configure(EntityTypeBuilder<TipoEstadoEntity> modelBuilder)
        {
            modelBuilder.ToTable("TipoEstado", "DBO");

            modelBuilder.HasKey(e => e.IdEstado);

            modelBuilder.Property(e => e.IdEstado).HasColumnType("int");

            modelBuilder.Property(e => e.Estado)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            modelBuilder.Property(e => e.FechaRegistro).HasColumnType("datetime");

            modelBuilder.Property(e => e.Activo).HasColumnType("bit");
        }
    }
}
