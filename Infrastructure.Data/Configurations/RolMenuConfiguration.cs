using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class RolMenuConfiguration : IEntityTypeConfiguration<RolesMenuEntity>
    {
        public void Configure(EntityTypeBuilder<RolesMenuEntity> modelBuilder)
        {
            modelBuilder.HasNoKey();

            modelBuilder.ToTable("RolesMenu");
             
        }
    }
}
