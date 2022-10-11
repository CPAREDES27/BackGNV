using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class UbigeoProvinciaConfiguration : IEntityTypeConfiguration<UbigeoProvinciaEntity>
    {
        public void Configure(EntityTypeBuilder<UbigeoProvinciaEntity> modelBuilder)
        { 
            modelBuilder.ToTable("Ubigeo_Provincias", "DBO");

            modelBuilder.HasKey(e => e.IdProvinicia);

            modelBuilder.Property(e => e.IdProvinicia)
                .HasMaxLength(4)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Provincia)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false);

            modelBuilder.Property(e => e.IdDepartamento)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false);
       
        }
    }
}
