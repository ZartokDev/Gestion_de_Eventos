using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IEventosNegocio
    {
        List<Eventos> Consultar();
        Eventos Guardar(Eventos entidad);
    }
}