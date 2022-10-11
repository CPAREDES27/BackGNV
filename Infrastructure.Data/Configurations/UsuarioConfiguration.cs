using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> modelBuilder)
        {
            modelBuilder.ToTable("Usuarios", "DBO");

            modelBuilder.HasKey(e => e.IdUsuario);

            modelBuilder.Property(e => e.UsuarioEmail)
              .IsRequired()
              .HasMaxLength(300)
              .IsUnicode(false);

            modelBuilder.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .IsRequired() 
                .IsUnicode(false);

            modelBuilder.Property(e => e.NomCliente)
              .HasMaxLength(50)
              .IsUnicode(false);

            modelBuilder.Property(e => e.ApeCliente)
                .HasMaxLength(50)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Ruc)
               .HasMaxLength(20)
               .IsUnicode(false);

            modelBuilder.Property(e => e.RazonSocial)
                .HasMaxLength(300)
                .IsUnicode(false);

            modelBuilder.Property(e => e.IdTipoDocumento)
              .HasMaxLength(20)
              .IsUnicode(false);

            modelBuilder.Property(e => e.NumeroDocumento)
              .HasMaxLength(20)
              .IsUnicode(false);

            modelBuilder.Property(e => e.RolId);

            modelBuilder.Property(e => e.FechaNacimiento).HasColumnType("datetime");

            modelBuilder.Property(e => e.EstadoCivil).HasColumnType("int");
 
 

            modelBuilder.Property(e => e.TelefonoFijo)
               .HasMaxLength(20)
               .IsUnicode(false);

            modelBuilder.Property(e => e.TelefonoMovil)
                .HasMaxLength(20)
                .IsUnicode(false);

            modelBuilder.Property(e => e.IdTipoCalle);
             
            modelBuilder.Property(e => e.DireccionResidencia)
                .HasMaxLength(300)
                .IsUnicode(false);

            modelBuilder.Property(e => e.NumeroIntDpto);

            modelBuilder.Property(e => e.ManzanaLote)
            .HasMaxLength(5)
            .IsUnicode(false);

            modelBuilder.Property(e => e.Referencia)
                .HasMaxLength(200)
                .IsUnicode(false);

            modelBuilder.Property(e => e.IdDepartamento)
                .HasMaxLength(2)
                .IsUnicode(false); 
            
            modelBuilder.Property(e => e.IdProvincia)
                .HasMaxLength(4)
                .IsUnicode(false);

            modelBuilder.Property(e => e.IdDistrito)
                .HasMaxLength(6)
                .IsUnicode(false);


            modelBuilder.Property(e => e.Activo);

            modelBuilder.Property(e => e.UsuarioRegistra).HasColumnType("int");

            modelBuilder.Property(e => e.FecRegistro).HasColumnType("datetime");

            

            modelBuilder.Property(e => e.UsuarioModifica).HasColumnType("int"); 
            

            modelBuilder.Property(e => e.FechaModifica).HasColumnType("datetime");
             
            modelBuilder.Property(e => e.TermPoliticasPrivacidad).HasColumnType("bit");
            modelBuilder.Property(e => e.TermFinesComerciales).HasColumnType("bit");

        }
    }
}
