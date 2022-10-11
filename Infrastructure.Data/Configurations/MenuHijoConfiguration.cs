using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class MenuHijoConfiguration : IEntityTypeConfiguration<MenuHijoEntity>
    {
        public void Configure(EntityTypeBuilder<MenuHijoEntity> modelBuilder)
        {
            modelBuilder.ToTable("MenuHijo", "DBO");

            modelBuilder.HasKey(e => e.IdMenuHijo);

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