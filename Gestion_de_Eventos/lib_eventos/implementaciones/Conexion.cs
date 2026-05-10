using lib_eventos.entidades;
using lib_eventos.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_eventos.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        }

        public DbSet<TipoTrabajadores>? TipoTrabajadores { get; set; }
        public DbSet<Transportes>? Transportes { get; set; }
        public DbSet<PersonalApoyos>? PersonalApoyos { get; set; }
        public DbSet<TipoPagos>? TipoPagos { get; set; }
        public DbSet<Ofertas>? Ofertas { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<Horarios>? Horarios { get; set; }
        public DbSet<Lugares>? Lugares { get; set; }
        public DbSet<TipoPatrocinadores>? TipoPatrocinadores { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Reservas>? Reservas { get; set; }
        public DbSet<TipoEventos>? TipoEventos { get; set; }
        public DbSet<Administradores>? Administradores { get; set; }
        public DbSet<Trabajadores>? Trabajadores { get; set; }
        public DbSet<Grupos>? Grupos { get; set; }
        public DbSet<Inventarios>? Inventarios { get; set; }
        public DbSet<Facturas>? Facturas { get; set; }
        public DbSet<Patrocinadores>? Patrocinadores { get; set; }
        public DbSet<GruposTrabajadores>? GruposTrabajadores { get; set; }
        public DbSet<Eventos>? Eventos { get; set; }
    }
}
