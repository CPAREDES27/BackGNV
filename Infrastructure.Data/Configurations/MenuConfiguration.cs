using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<MenuEntity>
    {
        public void Configure(EntityTypeBuilder<MenuEntity> modelBuilder)
        {
            modelBuilder.HasKey(e => e.IdMenu);

            modelBuilder.ToTable("Menu");

            modelBuilder.Property(e => e.DescMenu)
                .HasMaxLength(200)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Url)
                .HasMaxLength(500)
                .IsUnicode(false);

            modelBuilder.Property(e => e.UrlImagen).HasMaxLength(200);
        }
    }
}
 