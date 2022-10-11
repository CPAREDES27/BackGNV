using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class EstadoCivilClienteConfiguration : IEntityTypeConfiguration<EstadoCivilClienteEntity>
    {
        public void Configure(EntityTypeBuilder<EstadoCivilClienteEntity> modelBuilder)
        {
            modelBuilder.ToTable("EstadoCivilCliente", "DBO");

            modelBuilder.HasKey(e => e.Id);
           
            modelBuilder.Property(e => e.Id).HasColumnType("int");
            
            modelBuilder.Property(e => e.Estado)
                    .HasMaxLength(15)
                    .IsUnicode(false);

            modelBuilder.Property(e => e.Flag).HasColumnType("bit"); 
        }
    }
}
