using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IAuditoriasNegocio
    {
        List<Auditorias> Consultar();
        Auditorias Guardar(Auditorias entidad);
        Auditorias Modificar(Auditorias entidad);
        Auditorias Eliminar(Auditorias entidad);
    }
}