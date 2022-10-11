using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class TallerConfiguration : IEntityTypeConfiguration<TallerEntity>
    {
        public void Configure(EntityTypeBuilder<TallerEntity> modelBuilder)
        {
            modelBuilder.ToTable("Taller");

            modelBuilder.HasKey(e => e.IdTaller);

            modelBuilder.Property(e => e.IdTaller)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            modelBuilder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Activo).HasColumnType("bit");
        }
    }
}
