using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class UbigeoDepartamentoConfiguration : IEntityTypeConfiguration<UbigeoDepartamentoEntity>
    {
        public void Configure(EntityTypeBuilder<UbigeoDepartamentoEntity> modelBuilder)
        {
           
            modelBuilder.ToTable("Ubigeo_Departamentos", "DBO");

            modelBuilder.HasKey(e => e.IdDepartamento);

            modelBuilder.Property(e => e.IdDepartamento)
                .HasMaxLength(2)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Departamento)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Flag).HasColumnType("bit");
        }
    }
}
