using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface ITipoEventosNegocio
    {
        List<TipoEventos> Consultar();
        TipoEventos Guardar(TipoEventos entidad);
        TipoEventos Modificar(TipoEventos entidad);
        TipoEventos Eliminar(TipoEventos entidad);
    }
}