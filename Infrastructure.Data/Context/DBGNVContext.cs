using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data.Context
{
    public partial class DBGNVContext : DbContext
    {
        public DBGNVContext()
        {
        }

        public DBGNVContext(DbContextOptions<DBGNVContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<RolesEntity> Roles { get; set; }
        public virtual DbSet<RolesMenuEntity> RolesMenus { get; set; }
        public virtual DbSet<UsuarioEntity> Usuarios { get; set; } 
        public virtual DbSet<MenuPadreEntity> MenuPadre { get; set; }
        public virtual DbSet<MenuHijoEntity> MenuHijo { get; set; } 
        public virtual DbSet<PreEvaluationEntity> Preevaluaciones { get; set; }
        public virtual DbSet<RegistroReglasKnockoutEntity> ReglaKnockout { get; set; } 
        public virtual DbSet<EstadoCivilClienteEntity> EstadoCivilCliente { get; set; }
        public virtual DbSet<EstadoNivelEstudiosClienteEntity> EstadoNivelEstudiosCliente { get; set; }
        public virtual DbSet<EstadoVehicularEntity> EstadoVehicular { get; set; }
        public virtual DbSet<TipoCreditoFinanciamientoEntity> TipoCreditoFinanciamiento { get; set; } 
        public virtual DbSet<RegistroSolicitudFinanciamientoEntity> RegistroSolicitudFinanciamiento { get; set; }
        public virtual DbSet<SfCargaDocumentoEntity> SfCargaDocumento { get; set; }
        public virtual DbSet<TallerEntity> Taller { get; set; } 
        public virtual DbSet<TipoDocumentoEntity> TipoDocumento { get; set; }
        public virtual DbSet<TipoEstadoEntity> TipoEstado { get; set; }
        public virtual DbSet<UbigeoDepartamentoEntity> Ubigeo_Departamentos { get; set; }
        public virtual DbSet<UbigeoDistritoEntity> Ubigeo_Distritos { get; set; }
        public virtual DbSet<UbigeoProvinciaEntity> Ubigeo_Provincias { get; set; }
        public virtual DbSet<MaestroEntity> Maestro { get; set; }
        public virtual DbSet<MantPreguntasAletoriaEntity> Mant_PreguntasAletorias { get; set; }
        public virtual DbSet<RkCargaDocumentoEntity> Rk_CargaDocumentos { get; set; }
        public virtual DbSet<EstadoTipoFinanciamientoEntity> EstadoTipoFinanciamiento { get; set; }
        public virtual DbSet<MantPreguntasAleatoriasEntity> MantPreguntasAleatorias { get; set; }
        public virtual DbSet<MantPreguntasAleatoriasDetalleEntity> MantPreguntasAleatoriasDetalles { get; set; }
        public virtual DbSet<MantAnswerEntity> MantAnswer { get; set; }
        public virtual DbSet<ProductEntity> Productos { get; set; }
        public virtual DbSet<TipoProductoEntity> TipoProducto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
        }
    }
}
