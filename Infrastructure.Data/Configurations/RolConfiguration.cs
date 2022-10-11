using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class RolConfiguration : IEntityTypeConfiguration<RolesEntity>
    {
        public void Configure(EntityTypeBuilder<RolesEntity> typeBuilder)
        {
            typeBuilder.HasKey(e => e.RolId);

            typeBuilder.Property(e => e.DescRol)
                       .IsRequired()
                       .HasMaxLength(200)
                       .IsUnicode(false);
        }
    }
}
