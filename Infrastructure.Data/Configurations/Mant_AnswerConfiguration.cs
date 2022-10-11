using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class Mant_AnswerConfiguration : IEntityTypeConfiguration<MantAnswerEntity>
    {
        public void Configure(EntityTypeBuilder<MantAnswerEntity> modelBuilder)
        {
            modelBuilder.ToTable("Mant_Answer", "DBO");

            modelBuilder.HasKey(e => e.IdAnswer);

            modelBuilder.Property(e => e.IdAnswer).HasColumnType("int");

            modelBuilder.Property(e => e.IdQuestion).HasColumnType("int");

            modelBuilder.Property(e => e.IdFinancing).HasColumnType("int");

            modelBuilder.Property(e => e.Answer) 
                        .IsUnicode(false);
             
        }

    }
}
