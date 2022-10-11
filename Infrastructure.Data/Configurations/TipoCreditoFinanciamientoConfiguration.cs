using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class TipoCreditoFinanciamientoConfiguration : IEntityTypeConfiguration<TipoCreditoFinanciamientoEntity>
    {
        public void Configure(EntityTypeBuilder<TipoCreditoFinanciamientoEntity> modelBuilder)
        {
            modelBuilder.ToTable("TipoCreditoFinanciamiento", "DBO");

            modelBuilder.HasKey(e => e.Id);

            modelBuilder.Property(e => e.Id).HasColumnType("int");

            modelBuilder.Property(e => e.TipoCredito)
                .HasMaxLength(100)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Flag).HasColumnType("bit");
        }
    }
}
