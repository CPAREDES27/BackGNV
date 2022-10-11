using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class RkCargaDocumentoConfiguration : IEntityTypeConfiguration<RkCargaDocumentoEntity>
    {
        public void Configure(EntityTypeBuilder<RkCargaDocumentoEntity> modelBuilder)
        {
            modelBuilder.ToTable("Rk_CargaDocumentos");

            modelBuilder.HasKey(e => e.IdCargaDocumentos);

            modelBuilder.Property(e => e.IdCargaDocumentos).HasColumnType("int");

            modelBuilder.Property(e => e.IdReglanockout).HasColumnType("int");

            modelBuilder.Property(e => e.RootArchivo)
                .HasMaxLength(200)
                .IsUnicode(false);

            modelBuilder.Property(e => e.TipoProcesoDocumento)
                .HasMaxLength(200)
                .IsUnicode(false);
        }
    }
}
