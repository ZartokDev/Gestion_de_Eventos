using lib_eventos.entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IEventosNegocioP
    {
        List<Eventos> Consultar();
        Eventos Guardar(Eventos entidad);
    }
}
