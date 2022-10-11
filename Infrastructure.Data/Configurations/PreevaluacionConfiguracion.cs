using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class PreevaluacionConfiguracion : IEntityTypeConfiguration<PreEvaluationEntity>
    {
        public void Configure(EntityTypeBuilder<PreEvaluationEntity> modelBuilder)
        {
            modelBuilder.ToTable("Preevaluaciones");

            modelBuilder.HasKey(e => e.IdPreevaluacion);

            modelBuilder.Property(e => e.IdPreevaluacion)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            modelBuilder.Property(e => e.Apellido)
                .HasMaxLength(80)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Nombre)
                .HasMaxLength(80)
                .IsUnicode(false);

            modelBuilder.Property(e => e.IdTipoDocumento).HasColumnType("int");

            modelBuilder.Property(e => e.NumDocumento)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            modelBuilder.Property(e => e.NumPlaca) 
                .HasMaxLength(15)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Celular)
                .HasMaxLength(20)
                .IsUnicode(false);

            modelBuilder.Property(e => e.NombreAsesorReferido)
               .HasMaxLength(100)
               .IsUnicode(false);

            modelBuilder.Property(e => e.TermCondiciones).HasColumnType("bit");

            modelBuilder.Property(e => e.FinComerciales).HasColumnType("bit");

            modelBuilder.Property(e => e.IdEstado).HasColumnType("int");

            modelBuilder.Property(e => e.FechaRegistro).HasColumnType("datetime");

            modelBuilder.Property(e => e.UsuarioModifica).HasColumnType("int");

            modelBuilder.Property(e => e.FechaModifica).HasColumnType("datetime");

            modelBuilder.Property(e => e.IdProducto).HasColumnType("int");

            modelBuilder.Property(e => e.FlagUser).HasColumnType("bit");

            modelBuilder.Property(e => e.IdAsesor).HasColumnType("int");

        }
    }
}
