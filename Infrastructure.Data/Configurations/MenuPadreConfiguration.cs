using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class MenuPadreConfiguration : IEntityTypeConfiguration<MenuPadreEntity>
    {
        public void Configure(EntityTypeBuilder<MenuPadreEntity> modelBuilder)
        {
            modelBuilder.ToTable("MenuPadre", "DBO");

            modelBuilder.HasKey(e => e.IdMenuPadre);

            modelBuilder.HasKey(e => e.IdOpcion);

            modelBuilder.Property(e => e.DescMenu)
                .HasMaxLength(200)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Url)
                .HasMaxLength(500)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Orden).HasColumnType("int");

            modelBuilder.Property(e => e.Activo).HasColumnType("bit");

            modelBuilder.Property(e => e.UrlImagen).HasMaxLength(200);
        }
    }
}