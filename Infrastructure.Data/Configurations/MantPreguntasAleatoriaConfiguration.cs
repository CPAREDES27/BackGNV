using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class MantPreguntasAleatoriaConfiguration : IEntityTypeConfiguration<MantPreguntasAleatoriasEntity>
    {
        public void Configure(EntityTypeBuilder<MantPreguntasAleatoriasEntity> modelBuilder)
        {
            modelBuilder.ToTable("Mant_PreguntasAleatorias", "DBO");

            modelBuilder.HasKey(e => e.IdPregunta);
            modelBuilder.Property(e => e.IdPregunta).HasColumnType("int");

            modelBuilder.Property(e => e.Pregunta)
                .HasMaxLength(500)
                .IsUnicode(false);

            modelBuilder.Property(e => e.TextAyuda)
                        .HasMaxLength(500)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.TipoDato)
                        .HasMaxLength(200)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.Activo).HasColumnType("bit");
        }

    }
}
