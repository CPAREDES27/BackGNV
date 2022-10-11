using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ReglaKnockoutConfiguration : IEntityTypeConfiguration<RegistroReglasKnockoutEntity>
    {
        public void Configure(EntityTypeBuilder<RegistroReglasKnockoutEntity> modelBuilder)
        {
            modelBuilder.ToTable("RegistroReglasKnockout", "DBO");

            modelBuilder.HasKey(e => e.IdReglanockout);

            modelBuilder.Property(e => e.IdReglanockout).HasColumnType("int");

            modelBuilder.Property(e => e.IdPreevaluacion).HasColumnType("int");

            modelBuilder.Property(e => e.FechaVencimientoRevisioAnual).HasColumnType("datetime");

            modelBuilder.Property(e => e.FechaVencimientoCilindro).HasColumnType("datetime");
             
            modelBuilder.Property(e => e.IndicadorCreditoActivo).HasColumnType("bit").HasDefaultValue(null);

            modelBuilder.Property(e => e.IndicadorParaConsumir).HasColumnType("bit").HasDefaultValue(null);

            modelBuilder.Property(e => e.IndicadorAntiguedadMenos10Anios).HasColumnType("bit").HasDefaultValue(null);

            modelBuilder.Property(e => e.IndicadorTitular20A65Anios).HasColumnType("bit").HasDefaultValue(null);

            modelBuilder.Property(e => e.IndicadorDniRegistradoEnReniec).HasColumnType("bit").HasDefaultValue(null);

            modelBuilder.Property(e => e.IndicadorDniTitularContrato).HasColumnType("bit").HasDefaultValue(null);

            modelBuilder.Property(e => e.IndicadorLicenciaConducirVigente).HasColumnType("bit").HasDefaultValue(null);

            modelBuilder.Property(e => e.IndicadorTitularPropietarioVehiculo).HasColumnType("bit").HasDefaultValue(null);

            modelBuilder.Property(e => e.IndicadorSoatVigente).HasColumnType("bit").HasDefaultValue(null);

            modelBuilder.Property(e => e.IndicadorVehiculoNoMultasPendientePago).HasColumnType("bit").HasDefaultValue(null);

            modelBuilder.Property(e => e.IndicadorTitularNoMultasPendientePago).HasColumnType("bit").HasDefaultValue(null);

            modelBuilder.Property(e => e.IndicadorVehiculoNoOrdenCaptura).HasColumnType("bit").HasDefaultValue(null);

            modelBuilder.Property(e => e.IndicadorEstadoPreevaluacion).HasColumnType("bit").HasDefaultValue(null);

            modelBuilder.Property(e => e.FechaRegistro).HasColumnType("datetime").HasDefaultValue(null);

            modelBuilder.Property(e => e.IdEstadoPrevaluacion).HasColumnType("int").HasDefaultValue(null);
        }
    }
}
