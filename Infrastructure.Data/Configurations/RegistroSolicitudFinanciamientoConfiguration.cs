using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class RegistroSolicitudFinanciamientoConfiguration : IEntityTypeConfiguration<RegistroSolicitudFinanciamientoEntity>
    {
        public void Configure(EntityTypeBuilder<RegistroSolicitudFinanciamientoEntity> modelBuilder) 
        {
            modelBuilder.ToTable("RegistroSolicitudFinanciamiento", "DBO");

            modelBuilder.HasKey(e => e.IdSfCliente);

            modelBuilder.Property(e => e.IdSfCliente).HasColumnType("int");

            modelBuilder.Property(e => e.IdCliente).HasColumnType("int");

            modelBuilder.Property(e => e.Nombres)
              .HasMaxLength(50)
              .IsUnicode(false);

            modelBuilder.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);

            modelBuilder.Property(e => e.NumeroDocumento)
                .HasMaxLength(22)
                .IsFixedLength(true);
             
            modelBuilder.Property(e => e.FechaNacimiento).HasColumnType("datetime");

            modelBuilder.Property(e => e.EstadoCivil).HasColumnType("int");

            modelBuilder.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Celular)
                .HasMaxLength(18)
                .IsFixedLength(true);

            modelBuilder.Property(e => e.IdNivelEstudios).HasColumnType("int");

            modelBuilder.Property(e => e.Ocupacion)
             .HasMaxLength(50)
             .IsUnicode(false);

            modelBuilder.Property(e => e.TipoContrato)
              .HasMaxLength(50)
              .IsUnicode(false);

            modelBuilder.Property(e => e.TiempoEmpleoCliente)
               .HasMaxLength(10)
               .IsFixedLength(true);


            modelBuilder.Property(e => e.TipoCalle)
                .HasMaxLength(100)
                .IsUnicode(false);

            modelBuilder.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);

            modelBuilder.Property(e => e.NumeroInterior).HasColumnType("int");

            modelBuilder.Property(e => e.MzLt)
              .HasMaxLength(10)
              .IsUnicode(false);
             
            modelBuilder.Property(e => e.Distrito)
                .HasMaxLength(20)
                .IsUnicode(false);

            modelBuilder.Property(e => e.ReferenciaDomicilio)
                .HasMaxLength(100)
                .IsUnicode(false);

            modelBuilder.Property(e => e.TipoVivienda)
               .HasMaxLength(50)
               .IsUnicode(false);

            modelBuilder.Property(e => e.TiempoAnoVivienda).HasColumnType("int");
            modelBuilder.Property(e => e.TiempoMesesVivienda).HasColumnType("int");

            modelBuilder.Property(e => e.IsGasNatural).HasColumnType("bit");

            modelBuilder.Property(e => e.NumeroPlaca)
                .HasMaxLength(8)
                .IsUnicode(false);

            modelBuilder.Property(e => e.MarcaAuto)
               .HasMaxLength(100)
               .IsUnicode(false);

            modelBuilder.Property(e => e.ModeloAuto)
                .HasMaxLength(100)
                .IsUnicode(false);

            modelBuilder.Property(e => e.FechaFabricacion)
                   .HasMaxLength(500)
                .IsUnicode(false);

            modelBuilder.Property(e => e.NumeroTarjetaPropiedad)
                .HasMaxLength(50)
                .IsFixedLength(true);
             

            modelBuilder.Property(e => e.TipoUsoVehicular).HasColumnType("bit"); 

            modelBuilder.Property(e => e.EstadoVehiculo).HasColumnType("int");

            modelBuilder.Property(e => e.IngresoMensual)
                .HasMaxLength(10)
                .IsUnicode(false);

            modelBuilder.Property(e => e.NumeroHijos).HasColumnType("int");

            modelBuilder.Property(e => e.NombreEstablecimiento)
               .HasMaxLength(100)
               .IsUnicode(false);

            modelBuilder.Property(e => e.TipoFinanciamiento).HasColumnType("int");
              

            modelBuilder.Property(e => e.TipoCredito).HasColumnType("int");

            modelBuilder.Property(e => e.PlazoCuotasFinanciamiento)
               .HasMaxLength(10)
               .IsFixedLength(true);

            modelBuilder.Property(e => e.MontoFinanciamiento).HasColumnType("int"); 

            modelBuilder.Property(e => e.Observaciones)
                .HasMaxLength(500)
                .IsUnicode(false);

            modelBuilder.Property(e => e.IdTaller).HasColumnType("int");

            modelBuilder.Property(e => e.IdCargaDocumentos).HasColumnType("int");

            modelBuilder.Property(e => e.ClaseVehiculo)
               .HasMaxLength(100)
               .IsUnicode(false);

            modelBuilder.Property(e => e.NumeroAsientos)
               .HasMaxLength(10)
               .IsUnicode(false);

            modelBuilder.Property(e => e.NumeroMotor)
               .HasMaxLength(10)
               .IsUnicode(false);

            modelBuilder.Property(e => e.NumeroSerie)
               .HasMaxLength(10)
               .IsUnicode(false);
        }
    }
}
