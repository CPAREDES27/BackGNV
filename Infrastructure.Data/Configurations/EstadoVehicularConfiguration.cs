using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class EstadoVehicularConfiguration : IEntityTypeConfiguration<EstadoVehicularEntity>
    {
        public void Configure(EntityTypeBuilder<EstadoVehicularEntity> modelBuilder)
        {
            modelBuilder.ToTable("EstadoVehicular", "DBO");

            modelBuilder.HasKey(e => e.Id);

            modelBuilder.Property(e => e.Id).HasColumnType("int");

            modelBuilder.Property(e => e.Estado)
                .HasMaxLength(100)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Flag).HasColumnType("bit");
        }
    }
}
