using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class MaestroConfiguration : IEntityTypeConfiguration<MaestroEntity>
    {
        public void Configure(EntityTypeBuilder<MaestroEntity> modelBuilder)
        {
            modelBuilder.ToTable("Maestro", "DBO");

            modelBuilder.HasKey(e => e.IdMaestro);

            modelBuilder.Property(e => e.IdMaestro).HasColumnType("int");

            modelBuilder.Property(e => e.Descripcion)
                        .HasMaxLength(200)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.Valor)
                      .HasMaxLength(300)
                      .IsUnicode(false);

            modelBuilder.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Activo)
                .HasColumnType("bit");
        }

    }
}
