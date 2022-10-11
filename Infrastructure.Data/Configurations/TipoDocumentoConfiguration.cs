using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumentoEntity>
    {
        public void Configure(EntityTypeBuilder<TipoDocumentoEntity> modelBuilder)
        {
            modelBuilder.ToTable("TipoDocumento", "DBO");

            modelBuilder.HasKey(e => e.IdTipoDocumento);

            modelBuilder.Property(e => e.IdTipoDocumento).HasColumnType("int");

            modelBuilder.Property(e => e.TipoDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TipoDocumento");

            modelBuilder.Property(e => e.Activo).HasColumnType("bit");
        }
    }
}
