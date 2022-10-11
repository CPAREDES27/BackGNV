using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class Mant_PreguntasAletoriasConfiguration : IEntityTypeConfiguration<MantPreguntasAletoriaEntity>
    {
        public void Configure(EntityTypeBuilder<MantPreguntasAletoriaEntity> modelBuilder)
        {
            modelBuilder.ToTable("Mant_PreguntasAletorias" , "DBO");

            modelBuilder.HasKey(e => e.Id);

            modelBuilder.Property(e => e.Id).HasColumnType("int");

            modelBuilder.Property(e => e.Pregunta)
                .HasMaxLength(500)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Respuesta)
                .HasMaxLength(500)
                .IsUnicode(false);

            modelBuilder.Property(e => e.TipoDato)
                .HasMaxLength(200)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Activo).HasColumnType("bit");
        }
    }
}
