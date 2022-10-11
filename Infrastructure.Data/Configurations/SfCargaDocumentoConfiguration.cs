using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class SfCargaDocumentoConfiguration : IEntityTypeConfiguration<SfCargaDocumentoEntity>
    {
        public void Configure(EntityTypeBuilder<SfCargaDocumentoEntity> modelBuilder)
        { 
            modelBuilder.ToTable("Sf_CargaDocumentos", "DBO");

            modelBuilder.HasKey(e => e.IdCargaDocumentos);

            modelBuilder.Property(e => e.IdCargaDocumentos).HasColumnType("int");

            modelBuilder.Property(e => e.IdSfCliente).HasColumnType("int");

            modelBuilder.Property(e => e.RootArchivo)
               .HasMaxLength(200)
               .IsUnicode(false)
               .HasColumnName("RootArchivo");

            modelBuilder.Property(e => e.TipoFlujoDocumento)
                   .HasMaxLength(200)
                   .IsUnicode(false)
                   .HasColumnName("TipoFlujoDocumento");

        }
    }
}
