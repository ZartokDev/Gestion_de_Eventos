using lib_eventos.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_eventos.interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<TipoTrabajadores>? TipoTrabajadores { get; set; }
        DbSet<Transportes>? Transportes { get; set; }
        DbSet<PersonalApoyos>? PersonalApoyos { get; set; }
        DbSet<TipoPagos>? TipoPagos { get; set; }
        DbSet<Ofertas>? Ofertas { get; set; }
        DbSet<Proveedores>? Proveedores { get; set; }
        DbSet<Horarios>? Horarios { get; set; }
        DbSet<Lugares>? Lugares { get; set; }
        DbSet<TipoPatrocinadores>? TipoPatrocinadores { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<Reservas>? Reservas { get; set; }
        DbSet<TipoEventos>? TipoEventos { get; set; }
        DbSet<Administradores>? Administradores{ get; set; }
        DbSet<Trabajadores>? Trabajadores{ get; set; }
        DbSet<Grupos>? Grupos { get; set; }
        DbSet<Inventarios>? Inventarios { get; set; }
        DbSet<Facturas>? Facturas { get; set; }
        DbSet<Patrocinadores>? Patrocinadores { get; set; }
        DbSet<GruposTrabajadores>? GruposTrabajadores { get; set; }
        DbSet<Eventos>? Eventos { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
