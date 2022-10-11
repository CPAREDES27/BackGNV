using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class MantPreguntasAleatoriaDetalleConfiguration : IEntityTypeConfiguration<MantPreguntasAleatoriasDetalleEntity>
    {
        public void Configure(EntityTypeBuilder<MantPreguntasAleatoriasDetalleEntity> modelBuilder)
        {
            modelBuilder.ToTable("Mant_PreguntasAleatoriasDetalle", "DBO");

            modelBuilder.HasKey(e => e.IdDetalle);
            modelBuilder.Property(e => e.IdDetalle).HasColumnType("int");
            modelBuilder.Property(e => e.IdPregunta).HasColumnType("int");
            
            modelBuilder.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            modelBuilder.Property(e => e.Activo).HasColumnType("bit");
        }
    }
}
