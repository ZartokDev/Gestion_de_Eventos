using lib_eventos.entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ITipoEventosNegocioP
    {
        List<TipoEventos> Consultar();
        TipoEventos Guardar(TipoEventos entidad);
        TipoEventos Modificar(TipoEventos entidad);
        TipoEventos Eliminar(TipoEventos entidad);
    }

}