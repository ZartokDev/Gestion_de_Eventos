using lib_eventos.entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IAuditoriasNegocioP
    {
        List<Auditorias> Consultar();
        Auditorias Guardar(Auditorias entidad);
        Auditorias Modificar(Auditorias entidad);
        Auditorias Eliminar(Auditorias entidad);
    }
}
