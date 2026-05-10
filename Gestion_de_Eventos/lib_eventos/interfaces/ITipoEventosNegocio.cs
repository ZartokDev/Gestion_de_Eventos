using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface ITipoEventosNegocio
    {
        List<TipoEventos> Consultar();
        TipoEventos Guardar(TipoEventos entidad);
    }
}