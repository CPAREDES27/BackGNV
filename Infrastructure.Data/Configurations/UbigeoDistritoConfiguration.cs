using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class UbigeoDistritoConfiguration : IEntityTypeConfiguration<UbigeoDistritoEntity>
    {
        public void Configure(EntityTypeBuilder<UbigeoDistritoEntity> modelBuilder)
        { 
            modelBuilder.ToTable("Ubigeo_Distritos", "DBO");

            modelBuilder.HasKey(e => e.IdDistrito);

            modelBuilder.Property(e => e.IdDistrito)
                .HasMaxLength(6)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Distrito)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            modelBuilder.Property(e => e.IdProvinicia)
               .HasMaxLength(4)
               .IsUnicode(false);

            modelBuilder.Property(e => e.IdDepartamento)
                .HasMaxLength(2)
                .IsUnicode(false);
            
        }
    }
}
